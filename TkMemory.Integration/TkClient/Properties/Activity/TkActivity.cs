using AutoHotkey.Interop.ClassMemory;
using Serilog;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Activity {
    /// <summary>
    /// Contains information about activity (actions, status effects, commands, etc.) that are at least potentially
    /// beyond the full control of the player (e.g. status effects like Sanctuary that can be cast on the player
    /// without the player's consent). Status-related properties are cross-listed with TkStatus properties, but this
    /// class cannot access fully player-controlled status effects (e.g. fury, rage, cunning, invoke, etc.). Command-
    /// related properties and methods are cross-listed in PeasantCommands for convenience since that is an intuitive
    /// place to find them, but they really belong here as they are all related to the command cool down enforced by
    /// the server which is beyond the control of the player.
    /// </summary>
    public class TkActivity {
        #region Fields

        private const int MaximumSpellCooldownInMilliseconds = 1000;
        private const int MinimumSpellCooldownInMilliseconds = 333;
        private const int MeleeCommandCooldownInMilliseconds = 250;
        private const int MovementCommandCooldownInMilliseconds = 167;

        private readonly ClassMemory _classMemory;

        private int _defaultCommandCooldown;
        private Address _activeStatusEffectsAddress;
        private DateTime _timeOfPreviousCommand;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's activity data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkActivity(ClassMemory classMemory) {
            _classMemory = classMemory;
            _defaultCommandCooldown = MinimumSpellCooldownInMilliseconds;
            _timeOfPreviousCommand = DateTime.Now.AddMilliseconds(-MaximumSpellCooldownInMilliseconds);

            Asv = new AsvActivity(this);
            Debuffs = new DebuffActivity(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets a list of status effects currently affecting the player. The information included in the returned string could
        /// include buff durations, debuff durations, or aethers.
        /// </summary>
        public string ActiveStatusEffects => GetActiveStatusEffects();

        /// <summary>
        /// Gets the latest activity documented in the box on the right side of the screen that shows things like experience gained
        /// and items picked up or dropped. However, certain types of entries in that box are not eligible to be returned by this.
        /// Items picked up or dropped is one such example. If that was your latest activity, this would return the activity before
        /// that one (assuming it is eligible). The eligibility criteria are unknown. Due to that inconsistency and the fact that
        /// many entries are identical with no good way to distinguish between no new entry and a new but identical entry, this
        /// property is quite unreliable and is not used in any significant way.
        /// </summary>
        [Obsolete]
        public string LatestActivity => _classMemory.ReadString(TkAddresses.Self.Status.LatestActivity);

        /// <summary>
        /// Gets the name of the status effect that was most recently activated or deactivated. For example, if Sanctuary is cast
        /// on you, this will return "Sanctuary" until another status effect is activated or deactivated. And when the Sanctuary
        /// effect wears off, this will again return "Sanctuary" until another status effect is activated or deactivated. There is
        /// no known difference that indicates activation vs. deactivation. Some other types of data can appear here as well. The
        /// only known example is that it always gets information about the player's profile picture when the game first loads. Due
        /// to the data inconsistency and inability to distinguish between a status effect being toggled on or off, this property
        /// is quite unreliable and is not used in any significant way.
        /// </summary>
        [Obsolete]
        public string LatestStatusEffectChanged => _classMemory.ReadString(TkAddresses.Self.Status.LatestChange);

        /// <summary>
        /// The default number of milliseconds to wait in between commands.
        /// </summary>
        public int DefaultCommandCooldown {
            get => _defaultCommandCooldown;
            set {
                if (value < MinimumSpellCooldownInMilliseconds) {
                    value = MinimumSpellCooldownInMilliseconds;
                    Log.Warning($"Spell cool down adjusted to the minimum allowable value of {value} milliseconds.");
                }

                if (value > MaximumSpellCooldownInMilliseconds) {
                    value = MaximumSpellCooldownInMilliseconds;
                    Log.Warning($"Spell cool down adjusted to the maximum allowable value of {value} milliseconds.");
                }

                _defaultCommandCooldown = value;
            }
        }

        /// <summary>
        /// The current status of a player in regard to the Harden Armor, Sanctuary,
        /// and Valor buffs.
        /// </summary>
        public AsvActivity Asv { get; }

        /// <summary>
        /// The current status of a player in regard to various debuffs.
        /// </summary>
        public DebuffActivity Debuffs { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Resets that timestamp of the most recently performed command to be the current time.
        /// This method should usually be called any time a command is performed, although there
        /// are some exceptions when no cooldown is required between commands (e.g. using a mana
        /// restoration before casting a spell).
        /// </summary>
        public void ResetCommandCooldown() {
            _timeOfPreviousCommand = DateTime.Now;
        }

        /// <summary>
        /// Delays any further action until the number of milliseconds since the previous command
        /// is greater than the number of milliseconds currently assigned to the DefaultCommandCooldown
        /// property.
        /// </summary>
        public async Task WaitForCommandCooldown() {
            await WaitForCommandCooldown(DefaultCommandCooldown);
        }

        /// <summary>
        /// Delays any further melee commands until the number of milliseconds since the previous command
        /// is greater than of the number of milliseconds set for the cooldown on melee commands.
        /// </summary>
        public async Task WaitForMeleeCooldown() {
            await WaitForCommandCooldown(MeleeCommandCooldownInMilliseconds);
        }

        /// <summary>
        /// Delays any further movement commands until the number of milliseconds since the previous command
        /// is greater than of the number of milliseconds set for the cooldown on movement commands.
        /// </summary>
        public async Task WaitForMovementCooldown() {
            await WaitForCommandCooldown(MovementCommandCooldownInMilliseconds);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Testing has revealed that different instances of the TK client can store the status effects string at different
        /// addresses in memory. The cause of this is not known. This method attempts to determine the correct address to
        /// use for reading the status effects from a particular instance of the TK client.
        /// </summary>
        [SuppressMessage("ReSharper", "InvertIf")]
        private string GetActiveStatusEffects() {
            if (_activeStatusEffectsAddress != null) {
                var probableActiveEffects = _classMemory.ReadString(_activeStatusEffectsAddress, Constants.DefaultEncoding);
                if (!string.IsNullOrWhiteSpace(probableActiveEffects)) {
                    return probableActiveEffects;
                }
            }

            var activeEffects = _classMemory.ReadString(TkAddresses.Self.Status.ActiveEffects, Constants.DefaultEncoding);
            Log.Debug("activeEffects: " + activeEffects);
            if (!string.IsNullOrWhiteSpace(activeEffects)) {
                _activeStatusEffectsAddress = TkAddresses.Self.Status.ActiveEffects;
                Log.Debug("The primary memory address will be used for reading active status effects.");
                return activeEffects;
            }

            for (int i = 0; i < TkAddresses.Self.Status.PossibleActiveEffects.Length; i++) {
                Log.Debug("The primary active status effects memory address did not yeild any active statuses, will try alternates...");
                var possibleActiveEffects = _classMemory.ReadString(TkAddresses.Self.Status.PossibleActiveEffects[i], Constants.DefaultEncoding);
                if (!string.IsNullOrWhiteSpace(possibleActiveEffects)) {
                    _activeStatusEffectsAddress = TkAddresses.Self.Status.PossibleActiveEffects[i];
                    Log.Debug("An alternate memory address will be used for reading active status effects.");
                    return activeEffects;
                }
            }

            return string.Empty;
        }

        private async Task WaitForCommandCooldown(int cooldown) {
            var remainingCooldown = (int)Math.Ceiling(cooldown - (DateTime.Now - _timeOfPreviousCommand).TotalMilliseconds);

            if (remainingCooldown > 0) {
                await Task.Delay(remainingCooldown);
            }
        }

        #endregion Private Methods
    }
}
