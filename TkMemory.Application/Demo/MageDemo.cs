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
    internal class MageDemo
    {
        #region Fields

        private readonly MageClient _mage;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyToggle _isBotRunning;
        private readonly AutoHotkeyToggle _isBotPaused;
        private readonly AutoHotkeyToggle _shouldEsunaExternalGroupMembers;
        private readonly AutoHotkeyToggle _shouldHeal;
        private readonly AutoHotkeyToggle _shouldVex;
        private readonly AutoHotkeyToggle _shouldBlind;
        private readonly AutoHotkeyToggle _shouldParalyze;
        private readonly AutoHotkeyToggle _shouldVenom;
        private readonly AutoHotkeyToggle _shouldZap;
        private readonly AutoHotkeyToggle _shouldUpdateNpcs;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes settings and defines hotkeys.
        /// </summary>
        public MageDemo()
        {
            TkBotFactory.Initialize();

            _clients = new ActiveClients(TkBotFactory.ProcessName);
            _mage = _clients.GetMage();
            _mage.Activity.DefaultCommandCooldown = TkBotFactory.CommandCooldown;

            Log.Debug($"Key item assignments:\n{_mage.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_mage.Spells.KeySpells}\n");

            _isBotRunning = new AutoHotkeyToggle("^F1", "isBotRunning", true);
            _isBotPaused = new AutoHotkeySuspendToggle("F1", "isBotPaused", false);
            _shouldEsunaExternalGroupMembers = new AutoHotkeyToggle("PrintScreen", "shouldEsunaExternalGroupMembers", false);
            _shouldHeal = new AutoHotkeyToggle("`", "shouldHeal", true);
            _shouldBlind = new AutoHotkeyToggle("1", "shouldBlind", false);
            _shouldParalyze = new AutoHotkeyToggle("2", "shouldParalyze", false);
            _shouldVenom = new AutoHotkeyToggle("3", "shouldVenom", false);
            _shouldVex = new AutoHotkeyToggle("4", "shouldVex", true);
            _shouldZap = new AutoHotkeyToggle("5", "shouldZap", false);
            _shouldUpdateNpcs = new AutoHotkeyToggle("6", "shouldUpdateNpcs", false);

            var toggles = new[]
            {
                _isBotRunning,
                _isBotPaused,
                _shouldEsunaExternalGroupMembers,
                _shouldHeal,
                _shouldBlind,
                _shouldParalyze,
                _shouldVenom,
                _shouldVex,
                _shouldZap,
                _shouldUpdateNpcs
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
            Log.Information($"Starting AutoHunt for {_mage.Self.Name}...");

            while (_isBotRunning.Value)
            {
                try
                {
                    if (_isBotPaused.Value) continue;
                    _mage.UpdateGroup(_clients);
                    MarkExternalGroupMembersForEsuna();
                    if (await _mage.Commands.Mana.Invoke(20)) continue;
                    if (await HealGroupIfBelowVitaPercent(20)) continue;
                    if (await _mage.Commands.Asv.SanctuaryGroup()) continue;
                    if (await HealGroupIfBelowVitaPercent(30)) continue;
                    if (await _mage.Commands.Debuffs.RemoveCurseGroup()) continue;
                    if (await _mage.Commands.Debuffs.CureParalysisGroup()) continue;
                    if (await _mage.Commands.Debuffs.PurgeGroup()) continue;
                    if (await _mage.Commands.Asv.HardenArmorGroup()) continue;
                    if (await HealGroupIfEligible()) continue;
                    if (await UpdateNpcs()) continue;
                    if (await BlindNpcs()) continue;
                    if (await VexNpcs()) continue;
                    if (await ParalyzeNpcs()) continue;
                    if (await VenomNpcs()) continue;
                    if (await _mage.Commands.Asv.ValorGroup()) continue;
                    await ZapNpcs();
                }
                catch (Exception ex)
                {
                    TkBotFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down Mage bot for {_mage.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkBotFactory.Terminate(_mage);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> BlindNpcs()
        {
            if (!_shouldBlind.Value)
            {
                return false;
            }

            return await _mage.Commands.Debuffs.BlindNpcs();
        }

        private async Task<bool> HealGroupIfBelowVitaPercent(int minimumVitaPercent)
        {
            if (!_shouldHeal.Value)
            {
                return false;
            }

            return await _mage.Commands.Heal.HealGroupIfBelowVitaPercent(minimumVitaPercent);
        }

        private async Task<bool> HealGroupIfEligible()
        {
            if (!_shouldHeal.Value)
            {
                return false;
            }

            return await _mage.Commands.Heal.HealGroupIfEligible();
        }

        private void MarkExternalGroupMembersForEsuna()
        {
            if (!_shouldEsunaExternalGroupMembers.Value)
            {
                return;
            }

            _shouldEsunaExternalGroupMembers.Value = false;
            _mage.MarkExternalGroupMembersForEsuna();
        }

        private async Task<bool> ParalyzeNpcs()
        {
            if (!_shouldParalyze.Value)
            {
                return false;
            }

            return await _mage.Commands.Debuffs.ParalyzeNpcs();
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private async Task<bool> UpdateNpcs()
        {
            if (_shouldUpdateNpcs.Value)
            {
                _shouldUpdateNpcs.Value = false;
                return await _mage.UpdateNpcs(_mage.Spells.KeySpells.Zap, true);
            }

            return await _mage.UpdateNpcs(_mage.Spells.KeySpells.Zap);
        }

        private async Task<bool> VenomNpcs()
        {
            if (!_shouldVenom.Value)
            {
                return false;
            }

            return await _mage.Commands.Debuffs.VenomNpcs();
        }

        private async Task<bool> VexNpcs()
        {
            if (!_shouldVex.Value)
            {
                return false;
            }

            return await _mage.Commands.Debuffs.CurseNpcs();
        }

        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private async Task<bool> ZapNpcs()
        {
            if (!_shouldZap.Value)
            {
                return false;
            }

            return await _mage.Commands.Attacks.ZapNpcs();
        }

        #endregion Private Methods
    }
}
