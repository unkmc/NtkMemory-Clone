using AutoHotkey.Interop;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TkMemory.Application.Common;
using TkMemory.Integration.AutoHotkey;
using TkMemory.Integration.TkClient;

namespace TkMemory.AutoFollow
{
    internal class AutoFollowTrainer
    {
        #region Fields

        private readonly AutoFollowConfiguration _config;
        private readonly AutoHotkeyToggle _isRunning;
        private readonly AutoHotkeyToggle _isPaused;

        #endregion Fields

        #region Constructors

        public AutoFollowTrainer(AutoFollowConfiguration config)
        {
            _config = config;

            TkTrainerFactory.Initialize("AutoFollow");

            _isRunning = new AutoHotkeyToggle("ScrollLock", "isRunning", true);
            _isPaused = new AutoHotkeyToggle("Pause", "isPaused", false);

            var toggles = new[]
            {
                _isRunning,
                _isPaused
            };

            AutoHotkeyEngine.Instance.LoadToggles(toggles);
        }

        #endregion Constructors

        #region Public Methods

        [SuppressMessage("ReSharper", "EnforceIfStatementBraces")]
        [SuppressMessage("ReSharper", "SwitchStatementHandlesSomeKnownEnumValuesWithDefault")]
        public async Task AutoFollow()
        {
            var activeClients = new ActiveClients(Path.GetFileNameWithoutExtension(_config.Process));
            var leader = activeClients.GetClient(_config.Leader);
            var distance = _config.Distance;
            var followers = activeClients.Clients.Where(client =>
                !string.Equals(leader.Self.Name, client.Self.Name, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            Log.Information($"Following {leader.Self.Name} at a distance of no more than {distance} space(s).");

            while (_isRunning.Value)
            {
                try
                {
                    if (_isPaused.Value) continue;

                    foreach (var follower in followers)
                    {
                        switch (follower.Self.BasePath)
                        {
                            case TkClient.BasePath.Mage:
                                await ((MageClient)follower).Commands.Movement.Follow(leader, distance);
                                break;

                            case TkClient.BasePath.Poet:
                                await ((PoetClient)follower).Commands.Movement.Follow(leader, distance);
                                break;

                            case TkClient.BasePath.Rogue:
                                await ((RogueClient)follower).Commands.Movement.Follow(leader, distance);
                                break;

                            case TkClient.BasePath.Warrior:
                                await ((WarriorClient)follower).Commands.Movement.Follow(leader, distance);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TkTrainerFactory.Terminate(ex);
                }
            }
        }

        #endregion Public Methods
    }
}
