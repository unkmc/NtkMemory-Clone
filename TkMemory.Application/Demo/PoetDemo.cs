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

using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Application.Demo
{
    /// <summary>
    /// A sample bot to demonstrate and test the mechanics of using the TkMemory library.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal class PoetDemo
    {
        #region Fields

        private readonly PoetClient _poet;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyToggle _isBotRunning;
        private readonly AutoHotkeyToggle _isBotPaused;
        private readonly AutoHotkeyToggle _shouldHardenBody;
        private readonly AutoHotkeyToggle _shouldEsunaExternalGroupMembers;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes settings and defines hotkeys.
        /// </summary>
        public PoetDemo()
        {
            TkBotFactory.Initialize();

            _clients = new ActiveClients(TkBotFactory.ProcessName);
            _poet = _clients.GetPoet();
            _poet.Activity.DefaultCommandCooldown = TkBotFactory.CommandCooldown;

            Log.Debug($"Key item assignments:\n{_poet.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_poet.Spells.KeySpells}\n");

            _isBotRunning = new AutoHotkeyToggle("^F2", "isRunning", true);
            _isBotPaused = new AutoHotkeySuspendToggle("F2", "isPaused", false);
            _shouldHardenBody = new AutoHotkeyToggle("F5", "shouldHardenBody", true);
            _shouldEsunaExternalGroupMembers = new AutoHotkeyToggle("F12", "shouldEsunaExternalGroupMembers", false);

            var toggles = new[]
            {
                _isBotRunning,
                _isBotPaused,
                _shouldHardenBody,
                _shouldEsunaExternalGroupMembers
            };

            _ahk = AutoHotkeyEngine.Instance;
            _ahk.LoadToggles(toggles);
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Defines and executes the logic of the bot. Lines in the try statement can be
        /// rearranged to tweak the logic, or commands can be added/removed for significantly
        /// different bot behavior.
        /// </summary>
        [SuppressMessage("ReSharper", "CyclomaticComplexity")]
        [SuppressMessage("ReSharper", "EnforceIfStatementBraces")]
        public async Task AutoHunt()
        {
            Log.Information($"Starting Poet bot for {_poet.Self.Name}...");

            while (_isBotRunning.Value)
            {
                try
                {
                    if (_isBotPaused.Value) continue;
                    _poet.UpdateGroup(_clients);
                    MarkExternalGroupMembersForEsuna();
                    if (await _poet.Commands.Mana.Invoke(20)) continue;
                    if (await _poet.Commands.Heal.RestoreGroupIfEligible()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(20)) continue;
                    if (await _poet.Commands.Asv.SanctuaryGroup()) continue;
                    if (await _poet.Commands.Debuffs.AtoneGroup()) continue;
                    if (await _poet.Commands.Debuffs.RemoveCurseGroup()) continue;
                    if (await _poet.Commands.Debuffs.CureParalysisGroup()) continue;
                    if (await _poet.Commands.Debuffs.PurgeGroup()) continue;
                    if (await _poet.Commands.Asv.HardenArmorGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(50)) continue;
                    if (await _poet.Commands.Debuffs.CurseNpcs()) continue;
                    if (await _poet.UpdateNpcs(_poet.Spells.KeySpells.Heal)) continue;
                    if (await _poet.Commands.Debuffs.RemoveVeilGroup()) continue;
                    if (await _poet.Commands.Mana.InspireGroup()) continue;
                    if (await HardenBody()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfEligible()) continue;
                    if (await _poet.Commands.Asv.ValorGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(85)) continue;
                    await _poet.Commands.Debuffs.DisheartenNpcs();
                }
                catch (Exception ex)
                {
                    TkBotFactory.LogException(ex);
                }
            }

            Log.Information($"Shutting down Poet bot for {_poet.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkBotFactory.Terminate(_poet);
        }

        #endregion Public Methods

        #region Private Methods

        private void MarkExternalGroupMembersForEsuna()
        {
            if (!_shouldEsunaExternalGroupMembers.Value)
            {
                return;
            }

            _shouldEsunaExternalGroupMembers.Value = false;
            _poet.MarkExternalGroupMembersForEsuna();
        }

        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private async Task<bool> HardenBody()
        {
            if (!_shouldHardenBody.Value)
            {
                return false;
            }

            return await _poet.Commands.HardenBody();
        }

        #endregion Private Methods
    }
}
