using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Application.Common;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.Poet
{
    internal class PoetTrainer
    {
        #region Fields

        private readonly PoetClient _poet;
        private readonly ActiveClients _clients;
        private readonly AutoHotkeyEngine _ahk;

        private readonly AutoHotkeyToggle _isRunning;
        private readonly AutoHotkeyToggle _isPaused;
        private readonly AutoHotkeyToggle _shouldHardenBody;
        private readonly AutoHotkeyToggle _resetCurses;
        private readonly AutoHotkeyToggle _shouldEsunaExternalGroupMembers;

        #endregion Fields

        #region Constructors

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public PoetTrainer(PoetConfiguration config)
        {
            TkTrainerFactory.Initialize(TkClient.BasePath.Poet.ToString());

            _clients = new ActiveClients(config.Process);
            _poet = _clients.GetPoet();
            _poet.Activity.DefaultCommandCooldown = config.CommandDelay;

            Log.Debug($"Key item assignments:\n{_poet.Inventory.KeyItems}\n");
            Log.Debug($"Key spell assignments:\n{_poet.Spells.KeySpells}\n");

            _isRunning = new AutoHotkeyToggle("^F2", "isRunning", true);
            _isPaused = new AutoHotkeySuspendToggle("F2", "isPaused", false);
            _shouldHardenBody = new AutoHotkeyToggle("F5", "shouldHardenBody", config.HardenBody.Value);
            _resetCurses = new AutoHotkeyToggle("F12", "resetCurses", false);
            _shouldEsunaExternalGroupMembers = new AutoHotkeyToggle("^F12", "shouldEsunaExternalGroupMembers", false);

            var toggles = new[]
            {
                _isRunning,
                _isPaused,
                _shouldHardenBody,
                _resetCurses,
                _shouldEsunaExternalGroupMembers
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
            Log.Information($"Starting AutoHunt for {_poet.Self.Name}...");

            while (_isRunning.Value)
            {
                try
                {
                    if (_isPaused.Value) continue;
                    _poet.UpdateGroup(_clients);
                    ResetCurses();
                    MarkExternalGroupMembersForEsuna();
                    if (await _poet.Commands.Mana.Invoke()) continue;
                    if (await _poet.Commands.Heal.RestoreGroupIfEligible()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(20)) continue;
                    if (await _poet.Commands.Asv.SanctuaryGroup()) continue;
                    if (await _poet.Commands.Debuffs.AtoneGroup()) continue;
                    if (await _poet.Commands.Debuffs.RemoveCurseGroup()) continue;
                    if (await _poet.Commands.Debuffs.CureParalysisGroup()) continue;
                    if (await _poet.Commands.Debuffs.PurgeGroup()) continue;
                    if (await _poet.Commands.Asv.HardenArmorGroup()) continue;
                    if (await _poet.Commands.Debuffs.RemoveVeilGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfEligible()) continue; // Most mana-efficient healing
                    if (await _poet.Commands.Debuffs.CurseNpcs()) continue;
                    if (await _poet.UpdateNpcs(_poet.Spells.KeySpells.Heal)) continue;
                    if (await _poet.Commands.Mana.InspireGroup()) continue;
                    if (await HardenBody()) continue;
                    if (await _poet.Commands.Asv.ValorGroup()) continue;
                    if (await _poet.Commands.Heal.HealGroupIfBelowVitaPercent(50)) continue; // For when the heal amount is relatively large compared to target's max vita
                    await _poet.Commands.Debuffs.DisheartenNpcs();
                }
                catch (Exception ex)
                {
                    TkTrainerFactory.Terminate(ex);
                }
            }

            Log.Information($"Shutting down Poet trainer for {_poet.Self.Name}...");
            _ahk.ExecRaw("Suspend");
            TkTrainerFactory.Terminate(_poet);
        }

        #endregion Public Methods

        #region Private Methods

        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private async Task<bool> HardenBody()
        {
            if (!_shouldHardenBody.Value)
            {
                return false;
            }

            return await _poet.Commands.HardenBody();
        }

        private void MarkExternalGroupMembersForEsuna()
        {
            if (!_shouldEsunaExternalGroupMembers.Value)
            {
                return;
            }

            _shouldEsunaExternalGroupMembers.Value = false;
            _poet.MarkExternalGroupMembersForEsuna();
        }

        private void ResetCurses()
        {
            if (!_resetCurses.Value)
            {
                return;
            }

            _resetCurses.Value = false;

            foreach (var npc in _poet.Npcs)
            {
                npc.Activity.Curse.OverrideTimer();
            }
        }

        #endregion Private Methods
    }
}
