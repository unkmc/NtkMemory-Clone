using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Application.Common;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Mage
{
    internal class MageTrainer
    {
        #region Fields

        private readonly MageClient _mage;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyToggle _isRunning;
        private readonly AutoHotkeyToggle _isPaused;
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

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public MageTrainer(MageConfiguration config)
        {
            TkTrainerFactory.Initialize(TkClient.BasePath.Mage.ToString());

            _clients = new ActiveClients(config.Process);

            _mage = string.IsNullOrWhiteSpace(config.Name)
                ? _clients.GetMage()
                : _clients.GetMage(config.Name);

            _mage.Activity.DefaultCommandCooldown = config.CommandDelay;

            Log.Debug($"Key item assignments:\n{_mage.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_mage.Spells.KeySpells}\n");

            _isRunning = new AutoHotkeyToggle("^F1", "isRunning", true);
            _isPaused = new AutoHotkeySuspendToggle("F1", "isPaused", false);
            _shouldEsunaExternalGroupMembers = new AutoHotkeyToggle("F11", "shouldEsunaExternalGroupMembers", false);
            _shouldHeal = new AutoHotkeyToggle("`", "shouldHeal", config.Heal.Value);
            _shouldBlind = new AutoHotkeyToggle("1", "shouldBlind", config.Blind.Value);
            _shouldParalyze = new AutoHotkeyToggle("2", "shouldParalyze", config.Paralyze.Value);
            _shouldVenom = new AutoHotkeyToggle("3", "shouldVenom", config.Venom.Value);
            _shouldVex = new AutoHotkeyToggle("4", "shouldVex", config.Vex.Value);
            _shouldZap = new AutoHotkeyToggle("5", "shouldZap", config.Zap.Value);
            _shouldUpdateNpcs = new AutoHotkeyToggle("6", "shouldUpdateNpcs", false);

            var toggles = new[]
            {
                _isRunning,
                _isPaused,
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

        [SuppressMessage("ReSharper", "CyclomaticComplexity")]
        [SuppressMessage("ReSharper", "EnforceIfStatementBraces")]
        public async Task AutoHunt()
        {
            Log.Information($"Starting AutoHunt for {_mage.Self.Name}...");

            while (_isRunning.Value)
            {
                try
                {
                    if (_isPaused.Value) continue;
                    _mage.UpdateGroup(_clients);
                    MarkExternalGroupMembersForEsuna();
                    if (await _mage.Commands.Mana.Invoke()) continue;
                    if (await HealGroupIfBelowVitaPercent(20)) continue;
                    if (await _mage.Commands.Asv.SanctuaryGroup()) continue;
                    if (await _mage.Commands.Debuffs.RemoveCurseGroup()) continue;
                    if (await _mage.Commands.Debuffs.CureParalysisGroup()) continue;
                    if (await _mage.Commands.Debuffs.PurgeGroup()) continue;
                    if (await _mage.Commands.Asv.HardenArmorGroup()) continue;
                    if (await HealGroupIfEligible()) continue; // Most mana-efficient healing
                    if (await BlindNpcs()) continue;
                    if (await VexNpcs()) continue;
                    if (await ParalyzeNpcs()) continue;
                    if (await UpdateNpcs()) continue;
                    if (await VenomNpcs()) continue;
                    if (await _mage.Commands.Asv.ValorGroup()) continue;
                    if (await _mage.Commands.Heal.HealGroupIfBelowVitaPercent(50)) continue; // For when the heal amount is relatively large compared to target's max vita
                    await ZapNpcs();
                }
                catch (Exception ex)
                {
                    TkTrainerFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down Mage trainer for {_mage.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkTrainerFactory.Terminate(_mage);
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
