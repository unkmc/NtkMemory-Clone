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
    internal class WarriorDemo
    {
        #region Fields

        private readonly WarriorClient _warrior;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyBool _shouldUpdateNpcs;
        private readonly AutoHotkeyToggle _isBotRunning;
        private readonly AutoHotkeyToggle _isBotPaused;
        private readonly AutoHotkeyToggle _shouldSpotTrapsOnAethers;
        private readonly AutoHotkeyToggle _shouldTaunt;
        private readonly AutoHotkeyToggle _shouldWhirlwindOnAethers;
        private readonly AutoHotkeyToggle _shouldBerserkOnAethers;
        private readonly AutoHotkeyToggle _shouldAutoMelee;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes settings and defines hotkeys.
        /// </summary>
        public WarriorDemo()
        {
            TkBotFactory.Initialize();

            _clients = new ActiveClients(TkBotFactory.ProcessName);
            _warrior = _clients.GetWarrior();
            _warrior.Activity.DefaultCommandCooldown = TkBotFactory.CommandCooldown;

            Log.Debug($"Key item assignments:\n{_warrior.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_warrior.Spells.KeySpells}\n");

            _shouldUpdateNpcs = new AutoHotkeyBool("shouldUpdateNpcs", false);
            _isBotRunning = new AutoHotkeyToggle("^F4", "isBotRunning", true);
            _isBotPaused = new AutoHotkeySuspendToggle("F4", "isBotPaused", false);
            _shouldSpotTrapsOnAethers = new AutoHotkeyToggle("F6", "shouldSpotTrapsOnAethers", false);
            _shouldTaunt = new AutoHotkeyToggleWithPrerequisite("F7", "shouldTaunt", false, _shouldUpdateNpcs);
            _shouldWhirlwindOnAethers = new AutoHotkeyToggle("F8", "shouldWhirlwindOnAethers", false);
            _shouldBerserkOnAethers = new AutoHotkeyToggle("F9", "shouldBerserkOnAethers", false);
            _shouldAutoMelee = new AutoHotkeyToggle("F10", "shouldAutoMelee", true);

            var toggles = new[]
            {
                _isBotRunning,
                _isBotPaused,
                _shouldTaunt,
                _shouldWhirlwindOnAethers,
                _shouldBerserkOnAethers,
                _shouldAutoMelee,
                _shouldSpotTrapsOnAethers
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
        [SuppressMessage("ReSharper", "EnforceIfStatementBraces")]
        public async Task AutoHunt()
        {
            Log.Information($"Starting AutoHunt for {_warrior.Self.Name}...");

            try
            {
                await _warrior.Commands.Buffs.Enchant();
            }
            catch (Exception ex)
            {
                TkBotFactory.Terminate(ex);
            }

            while (_isBotRunning.Value)
            {
                try
                {
                    if (_isBotPaused.Value) continue;
                    _warrior.UpdateGroup(_clients);
                    if (await _warrior.Commands.Buffs.Rage()) continue;
                    if (await _warrior.Commands.Buffs.Fury()) continue;
                    if (await _warrior.Commands.Buffs.Backstab()) continue;
                    if (await _warrior.Commands.Buffs.Flank()) continue;
                    if (await _warrior.Commands.Buffs.Potence()) continue;
                    if (await _warrior.Commands.Buffs.Blessing()) continue;
                    if (await Whirlwind(85)) continue;
                    if (await Berserk(85)) continue;
                    if (await TauntNpcs()) continue;
                    if (await SpotTraps()) continue;
                    await Melee();
                }
                catch (Exception ex)
                {
                    TkBotFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down Warrior bot for {_warrior.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkBotFactory.Terminate(_warrior);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> Berserk(double minimumVitaPercent = 80)
        {
            if (!_shouldAutoMelee.Value || !_shouldBerserkOnAethers.Value)
            {
                return false;
            }

            return await _warrior.Commands.Attacks.Berserk(minimumVitaPercent);
        }

        private async Task Melee()
        {
            if (_shouldAutoMelee.Value)
            {
                await _warrior.Commands.Attacks.Melee();
            }
        }

        private async Task<bool> SpotTraps()
        {
            if (!_shouldSpotTrapsOnAethers.Value)
            {
                return false;
            }

            return await _warrior.Commands.SpotTraps();
        }

        private async Task<bool> TauntNpcs()
        {
            if (!_shouldTaunt.Value)
            {
                return false;
            }

            if (_shouldUpdateNpcs.Value)
            {
                _shouldUpdateNpcs.Value = false;
                await _warrior.UpdateNpcs(_warrior.Spells.KeySpells.Zap, true);
            }

            if (await _warrior.Commands.Attacks.TauntNpcs())
            {
                return true;
            }

            _shouldTaunt.Value = false;
            return false;
        }

        private async Task<bool> Whirlwind(double minimumVitaPercent = 80)
        {
            if (!_shouldAutoMelee.Value || !_shouldWhirlwindOnAethers.Value)
            {
                return false;
            }

            return await _warrior.Commands.Attacks.Whirlwind(minimumVitaPercent);
        }

        #endregion Private Methods
    }
}
