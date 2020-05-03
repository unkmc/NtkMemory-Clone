// This file is part of TkMemory.

// TkMemory is free software. You can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License or (at your
// option) any later version.

// TkMemory is distributed in the hope that it will be useful but WITHOUT
// ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory. If not, please refer to:
// https://www.gnu.org/licenses/gpl-3.0.en.html

using Serilog;
using System;
using System.Threading.Tasks;
using TkMemory.Domain.Items;
using TkMemory.Domain.Spells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands
{
    internal static class ItemCommands
    {
        #region Fields

        private const int MaxNumberOfItemUsages = 6;
        private static bool _hasWarnedOfExcessiveUsage;
        private static bool _hasWarnedOfDepletedItems;

        #endregion Fields

        #region Public Methods

        public static async Task<bool> RestoreMajorManaForSpell(TkClient itemUser, KeySpell spell)
        {
            return await RestoreManaForSpell(itemUser, spell, itemUser.Inventory.KeyItems.MajorManaRestoration);
        }

        public static async Task<bool> RestoreMinorManaForSpell(TkClient itemUser, KeySpell spell)
        {
            return await RestoreManaForSpell(itemUser, spell, itemUser.Inventory.KeyItems.MinorManaRestoration);
        }

        public static async Task<bool> UseMajorManaRestorationItem(TkClient itemUser, int minimumRestoration = 1)
        {
            var majorManaRestorationItem = itemUser.Inventory.KeyItems.MajorManaRestoration;
            return await UseManaRestorationItem(itemUser, majorManaRestorationItem, minimumRestoration);
        }

        public static async Task<bool> UseMinorManaRestorationItem(TkClient itemUser, int minimumRestoration = 1)
        {
            var minorManaRestorationItem = itemUser.Inventory.KeyItems.MinorManaRestoration;
            return await UseManaRestorationItem(itemUser, minorManaRestorationItem, minimumRestoration);
        }

        #endregion Public Methods

        #region Private Methods

        private static async Task<bool> RestoreManaForSpell(TkClient itemUser, KeySpell spell, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentMana = (int)itemUser.Self.Mana.Current;

            if (currentMana < spell.Cost)
            {
                return await UseManaRestorationItem(itemUser, manaRestorationItem, spell.Cost - currentMana);
            }

            return true;
        }

        // ReSharper disable once UnusedMember.Local
        private static async Task<bool> RestoreManaIfBelowPercent(TkClient itemUser, double minimumManaPercent, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentManaPercent = itemUser.Self.Mana.Percent;

            if (currentManaPercent < minimumManaPercent)
            {
                return await UseManaRestorationItem(itemUser, manaRestorationItem);
            }

            return false;
        }

        // ReSharper disable once UnusedMember.Local
        private static async Task<bool> RestoreManaIfEligible(TkClient itemUser, Restoration manaRestorationItem)
        {
            await itemUser.Activity.WaitForCommandCooldown();
            var currentManaDeficit = itemUser.Self.Mana.Deficit;

            if (currentManaDeficit > manaRestorationItem.RestoreAmount)
            {
                return await UseManaRestorationItem(itemUser, manaRestorationItem);
            }

            return false;
        }

        public static async Task<bool> UseItem(TkClient itemUser, Item item, int usages = 1)
        {
            if (item == null)
            {
                return false;
            }

            itemUser.Inventory.Update();
            await itemUser.Activity.WaitForCommandCooldown();

            if (usages > item.Quantity)
            {
                usages = item.Quantity;
            }

            for (var i = 0; i < usages; i++)
            {
                itemUser.Send($"{Keys.Esc}u{item.Letter}");
                await Task.Delay(20);

                Log.Information($"{itemUser.Self.Name} used {item.Name}.");
            }

            // ReSharper disable once InvertIf
            if (usages == item.Quantity)
            {
                // Updates the item inventory again if the current item was completely used up.
                // This creates an extra delay of one command cycle, but it usually (barring
                // significant lag) prevents an attempt to use the item once after it is gone.
                itemUser.Activity.ResetCommandCooldown();
                await itemUser.Activity.WaitForCommandCooldown();
                itemUser.Inventory.Update();
            }

            return true;
        }

        private static async Task<bool> UseManaRestorationItem(TkClient itemUser, Restoration manaRestorationItem, int minimumRestoration = 1)
        {
            var requiredUsages = (int)Math.Ceiling((float)minimumRestoration / manaRestorationItem.RestoreAmount);

            if (requiredUsages > MaxNumberOfItemUsages)
            {
                if (!_hasWarnedOfExcessiveUsage)
                {
                    Log.Warning($"{itemUser.Self.Name} is about to try to cast a spell with insufficient mana. Normally, I would rapidly use as much {manaRestorationItem.Name} as needed to provide enough mana, but in this case, that would require {requiredUsages} uses, and I have to draw the line somewhere. Automated mana restoration will not be attempted for spells that would require more than {MaxNumberOfItemUsages} uses.");
                }

                _hasWarnedOfExcessiveUsage = true;
                return false;
            }

            itemUser.IncrementManaRestorationItemUsageCount(requiredUsages);

            if (await UseItem(itemUser, manaRestorationItem, requiredUsages))
            {
                return true;
            }

            if (!_hasWarnedOfDepletedItems)
            {
                Log.Error($"{itemUser.Self.Name} does not have any mana restoration items left.");
            }

            _hasWarnedOfDepletedItems = true;
            return false;
        }

        #endregion Private Methods
    }
}
