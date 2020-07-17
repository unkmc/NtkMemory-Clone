using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Application.Common;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Warrior
{
    internal class WarriorTrainer
    {
        #region Fields

        private readonly WarriorClient _warrior;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyBool _shouldUpdateNpcs;
        private readonly AutoHotkeyToggle _isRunning;
        private readonly AutoHotkeyToggle _isPaused;
        private readonly AutoHotkeyToggle _shouldSpotTrapsOnAethers;
        private readonly AutoHotkeyToggle _shouldTaunt;
        private readonly AutoHotkeyToggle _shouldWhirlwindOnAethers;
        private readonly AutoHotkeyToggle _shouldBerserkOnAethers;
        private readonly AutoHotkeyToggle _shouldAutoMelee;

        #endregion Fields

        #region Constructors

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public WarriorTrainer(WarriorConfiguration config)
        {
            TkTrainerFactory.Initialize(TkClient.BasePath.Warrior.ToString());

            _clients = new ActiveClients(config.Process);
            _warrior = _clients.GetWarrior();
            _warrior.Activity.DefaultCommandCooldown = config.CommandDelay;

            Log.Debug($"Key item assignments:\n{_warrior.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_warrior.Spells.KeySpells}\n");

            _shouldUpdateNpcs = new AutoHotkeyBool("shouldUpdateNpcs", false);
            _isRunning = new AutoHotkeyToggle("^F4", "isRunning", true);
            _isPaused = new AutoHotkeySuspendToggle("F4", "isPaused", false);
            _shouldSpotTrapsOnAethers = new AutoHotkeyToggle("F6", "shouldSpotTrapsOnAethers", false);
            _shouldTaunt = new AutoHotkeyToggleWithPrerequisite("F7", "shouldTaunt", false, _shouldUpdateNpcs);
            _shouldWhirlwindOnAethers = new AutoHotkeyToggle("F8", "shouldWhirlwindOnAethers", config.Whirlwind.Value);
            _shouldBerserkOnAethers = new AutoHotkeyToggle("F9", "shouldBerserkOnAethers", config.Berserk.Value);
            _shouldAutoMelee = new AutoHotkeyToggle("F10", "shouldAutoMelee", config.Attack.Value);

            var toggles = new[]
            {
                _isRunning,
                _isPaused,
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
                TkTrainerFactory.Terminate(ex);
            }

            while (_isRunning.Value)
            {
                try
                {
                    if (_isPaused.Value) continue;
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
                    TkTrainerFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down Warrior trainer for {_warrior.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkTrainerFactory.Terminate(_warrior);
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
