// This file is part of TkMemory.Application.

// TkMemory.Application is free software. You can redistribute it and/or
// modify it under the terms of the GNU General Public License as published
// by the Free Software Foundation, either version 3 of the License or (at
// your option) any later version.

// TkMemory.Application is distributed in the hope that it will be useful
// but WITHOUT ANY WARRANTY, without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
// more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory.Application. If not, please refer to:
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
    internal class RogueDemo
    {
        #region Fields

        private readonly RogueClient _rogue;
        private readonly ActiveClients _clients;

        private readonly AutoHotkeyBool _shouldUpdateNpcs;
        private readonly AutoHotkeyToggle _isBotRunning;
        private readonly AutoHotkeyToggle _isBotPaused;
        private readonly AutoHotkeyToggle _shouldAmbushOnMelee;
        private readonly AutoHotkeyToggle _shouldTaunt;
        private readonly AutoHotkeyToggle _shouldLethalStrikeOnAethers;
        private readonly AutoHotkeyToggle _shouldDesperateAttackOnAethers;
        private readonly AutoHotkeyToggle _shouldAutoMelee;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes settings and defines hotkeys.
        /// </summary>
        public RogueDemo()
        {
            TkBotFactory.Initialize();

            _clients = new ActiveClients(TkBotFactory.ProcessName);
            _rogue = _clients.GetRogue();
            _rogue.Activity.DefaultCommandCooldown = TkBotFactory.CommandCooldown;

            Log.Debug($"Key item assignments:\n{_rogue.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_rogue.Spells.KeySpells}\n");

            _shouldUpdateNpcs = new AutoHotkeyBool("shouldUpdateNpcs", false);
            _isBotRunning = new AutoHotkeyToggle("^F3", "isBotRunning", true);
            _isBotPaused = new AutoHotkeyToggle("F3", "isBotPaused", false);
            _shouldTaunt = new AutoHotkeyToggleWithPrerequisite("7", "shouldTaunt", false, _shouldUpdateNpcs);
            _shouldLethalStrikeOnAethers = new AutoHotkeyToggle("8", "shouldLethalStrikeOnAethers", false);
            _shouldDesperateAttackOnAethers = new AutoHotkeyToggle("9", "shouldDesperateAttackOnAethers", false);
            _shouldAutoMelee = new AutoHotkeyToggle("0", "shouldAutoMelee", false);
            _shouldAmbushOnMelee = new AutoHotkeyToggle("-", "shouldAmbushOnMelee", false);

            var toggles = new[]
            {
                _isBotRunning,
                _isBotPaused,
                _shouldTaunt,
                _shouldLethalStrikeOnAethers,
                _shouldDesperateAttackOnAethers,
                _shouldAutoMelee,
                _shouldAmbushOnMelee
            };

            AutoHotkeyEngine.Instance.LoadToggles(toggles);
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
            Log.Information($"Starting AutoHunt for {_rogue.Self.Name}...");

            try
            {
                await _rogue.Commands.Buffs.Enchant();
            }
            catch (Exception ex)
            {
                TkBotFactory.LogException(ex);
            }

            while (_isBotRunning.Value)
            {
                try
                {
                    if (_isBotPaused.Value) continue;
                    _rogue.UpdateGroup(_clients);
                    if (await _rogue.Commands.Buffs.Rage()) continue;
                    if (await _rogue.Commands.Buffs.Fury()) continue;
                    if (await _rogue.Commands.Buffs.ShadowFigure()) continue;
                    if (await _rogue.Commands.Buffs.Might()) continue;
                    if (await LethalStrike(85)) continue;
                    if (await DesperateAttack(85)) continue;
                    if (await TauntNpcs()) continue;
                    await Melee();
                }
                catch (Exception ex)
                {
                    TkBotFactory.LogException(ex);
                }
            }

            Log.Information($"Shutting down  bot for {_rogue.Self.Name}...");
            TkBotFactory.Terminate(_rogue);
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<bool> DesperateAttack(double minimumVitaPercent = 80)
        {
            if (!_shouldAutoMelee.Value || !_shouldDesperateAttackOnAethers.Value)
            {
                return false;
            }

            return await _rogue.Commands.Attacks.DesperateAttack(minimumVitaPercent);
        }

        private async Task<bool> LethalStrike(double minimumVitaPercent = 80)
        {
            if (!_shouldAutoMelee.Value || !_shouldLethalStrikeOnAethers.Value)
            {
                return false;
            }

            return await _rogue.Commands.Attacks.LethalStrike(minimumVitaPercent);
        }

        private async Task Melee()
        {
            if (_shouldAutoMelee.Value)
            {
                await _rogue.Commands.Attacks.Melee(_shouldAmbushOnMelee.Value);
            }
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
                await _rogue.UpdateNpcs(_rogue.Spells.KeySpells.Zap, true);
            }

            if (await _rogue.Commands.Attacks.TauntNpcs())
            {
                return true;
            }

            _shouldTaunt.Value = false;
            return false;
        }

        #endregion Private Methods
    }
}
