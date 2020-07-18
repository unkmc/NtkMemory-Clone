using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Application.Common;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Rogue
{
    internal class RogueTrainer
    {
        #region Fields

        private readonly RogueClient _rogue;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyBool _shouldUpdateNpcs;
        private readonly AutoHotkeyToggle _isRunning;
        private readonly AutoHotkeyToggle _isPaused;
        private readonly AutoHotkeyToggle _shouldAmbushOnMelee;
        private readonly AutoHotkeyToggle _shouldTaunt;
        private readonly AutoHotkeyToggle _shouldLethalStrikeOnAethers;
        private readonly AutoHotkeyToggle _shouldDesperateAttackOnAethers;
        private readonly AutoHotkeyToggle _shouldAutoMelee;

        #endregion Fields

        #region Constructors

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public RogueTrainer(RogueConfiguration config)
        {
            TkTrainerFactory.Initialize(TkClient.BasePath.Rogue.ToString());

            _clients = new ActiveClients(config.Process);

            _rogue = string.IsNullOrWhiteSpace(config.Name)
                ? _clients.GetRogue()
                : _clients.GetRogue(config.Name);

            _rogue.Activity.DefaultCommandCooldown = config.CommandDelay;

            Log.Debug($"Key item assignments:\n{_rogue.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_rogue.Spells.KeySpells}\n");

            _shouldUpdateNpcs = new AutoHotkeyBool("shouldUpdateNpcs", false);
            _isRunning = new AutoHotkeyToggle("^F3", "isRunning", true);
            _isPaused = new AutoHotkeySuspendToggle("F3", "isPaused", false);
            _shouldTaunt = new AutoHotkeyToggleWithPrerequisite("7", "shouldTaunt", false, _shouldUpdateNpcs);
            _shouldLethalStrikeOnAethers = new AutoHotkeyToggle("8", "shouldLethalStrikeOnAethers", config.LethalStrike.Value);
            _shouldDesperateAttackOnAethers = new AutoHotkeyToggle("9", "shouldDesperateAttackOnAethers", config.DesperateAttack.Value);
            _shouldAutoMelee = new AutoHotkeyToggle("0", "shouldAutoMelee", config.Attack.Value);
            _shouldAmbushOnMelee = new AutoHotkeyToggle("-", "shouldAmbushOnMelee", config.Ambush.Value);

            var toggles = new[]
            {
                _isRunning,
                _isPaused,
                _shouldTaunt,
                _shouldLethalStrikeOnAethers,
                _shouldDesperateAttackOnAethers,
                _shouldAutoMelee,
                _shouldAmbushOnMelee
            };

            _ahk = AutoHotkeyEngine.Instance;
            _ahk.LoadToggles(toggles);
        }

        #endregion Constructors

        #region Public Methods

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
                TkTrainerFactory.Terminate(ex);
            }

            while (_isRunning.Value)
            {
                try
                {
                    if (_isPaused.Value) continue;
                    _rogue.UpdateGroup(_clients);
                    if (await _rogue.Commands.Buffs.Rage()) continue;
                    if (await _rogue.Commands.Buffs.Fury()) continue;
                    if (await _rogue.Commands.Buffs.ShadowFigure()) continue;
                    if (await _rogue.Commands.Buffs.Might()) continue;
                    if (await LethalStrike(85)) continue;
                    if (await DesperateAttack(85)) continue;
                    if (await TauntNpcs()) continue;
                    if (await Invisible()) continue;
                    await Melee();
                }
                catch (Exception ex)
                {
                    TkTrainerFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down trainer for {_rogue.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkTrainerFactory.Terminate(_rogue);
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

        private async Task<bool> Invisible()
        {
            if (_shouldAutoMelee.Value)
            {
                return await _rogue.Commands.Buffs.Invisible(_shouldAmbushOnMelee.Value);
            }

            return false;
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
