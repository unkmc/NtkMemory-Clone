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
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Infrastructure;
using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Commands.Mage
{
    /// <summary>
    /// Commands for spells specific to Mages that are used restore the mana.
    /// </summary>
    public class MageManaCommands : CasterManaCommands
    {
        #region Fields

        private readonly KeySpell _mageInvokeOrb;
        private readonly BuffStatus _mageInvokeStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns mana restoration spells from a Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public MageManaCommands(MageClient self) : base(self)
        {
            if (Self.Inventory.KeyItems.InvokeOrb != null)
            {
                _mageInvokeOrb = new KeySpell(Self.Inventory.KeyItems.InvokeOrb);
                _mageInvokeStatus = self.Status.MageInvoke;
            }

            if (InvokeSpell == null && _mageInvokeOrb == null)
            {
                Log.Warning($"{self.Self.Name} does not have an Invoke spell. Mana restoration item consumption will be very high.");
            }
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Uses the mage invoke orb to restore mana at the cost of vita but only if current
        /// mana is less than the specified threshold. Set threshold to 100 to always Invoke
        /// as soon as possible.
        /// </summary>
        /// <param name="manaPercentFloor">The mana percent threshold below which the spell
        /// is eligible to be cast.</param>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        [SuppressMessage("ReSharper", "InvertIf")]
        public override async Task<bool> Invoke(double manaPercentFloor = 10)
        {
            if (Self.Self.Mana.Percent > manaPercentFloor.EvaluateAsPercentage())
            {
                return false;
            }

            var didMageInvoke = false;

            if (_mageInvokeOrb != null)
            {
                didMageInvoke = await SpellCommands.CastAetheredSpell(Self, _mageInvokeOrb, _mageInvokeStatus);
            }

            if (didMageInvoke)
            {
                InvokeStatus.ResetStatusCooldown();
                return true;
            }

            var didInvoke = await SpellCommands.CastAetheredSpell(Self, InvokeSpell, InvokeStatus, true);

            if (didInvoke)
            {
                _mageInvokeStatus?.ResetStatusCooldown();
            }

            return didInvoke;
        }

        #endregion Public Methods
    }
}
