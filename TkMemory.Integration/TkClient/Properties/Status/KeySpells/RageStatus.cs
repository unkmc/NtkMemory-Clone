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

using Serilog;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using TkMemory.Domain.Spells;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a Rage/Cunning key spell used to determine when it is actively affecting
    /// the player and when it can be recast.
    /// </summary>
    public class RageStatus : BuffStatus
    {
        #region Fields

        private const int RequiredDurationInactiveCount = RequiredInactiveCount * 3; // It is 2 to 2.5 minutes without rage if you pull the trigger too soon on this one, so wait longer to make sure it counts.
        private const string DottedLine = "------------------------";

        private static readonly Regex NumbersRegex = new Regex(@"([0-9]+)", RegexOptions.None);

        private readonly int _maxRageLevel;
        private readonly BuffKeySpell[] _rageLevels;
        private readonly TkClient _self;

        private int _currentRageLevel;
        private bool _recastPending;
        private DateTime _latestDurationInactivity;
        private int _durationInactiveCount;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of Rage/Cunning.
        /// </summary>
        /// <param name="self">All game client data for the Rogue or Warrior.</param>
        /// <param name="rageLevels">A list of each key spell for each level of Rage/Cunning.</param>
        public RageStatus(TkClient self, BuffKeySpell[] rageLevels) : base(self.Activity, rageLevels)
        {
            _self = self;
            _rageLevels = rageLevels;
            _maxRageLevel = GetMaxRageLevel();
            _currentRageLevel = GetCurrentRageLevel();

            Log.Debug($"Starting rage level is {_currentRageLevel}.");

            _latestDurationInactivity = DateTime.Now.AddMilliseconds(-self.Activity.DefaultCommandCooldown);
            _durationInactiveCount = RequiredDurationInactiveCount;
        }

        #endregion Constructors

        #region Protected Methods

        /// <summary>
        /// Rages sure are complex. Each rage creates two entries in the status box with
        /// identical descriptions. We have to analyze both to figure out if the spell
        /// can be recast to increase its level, and we also have to keep track of which
        /// rage level we are on since there is currently no way to reliably pull that
        /// from the application's memory. And on top of all of that, we have to take the
        /// same InactiveCount precautions for lag that we do with any other BuffStatus.
        /// </summary>
        protected override bool CheckIfActive()
        {
            if (IsCoolingDown())
            {
                return true;
            }

            if (HasAethersRemaining())
            {
                if (_recastPending)
                {
                    _recastPending = false;
                    _currentRageLevel = GetCurrentRageLevel();

                    Log.Debug($"Current rage level is now {_currentRageLevel}.");
                }

                InactiveCount = 0;
                return true;
            }

            if ((DateTime.Now - LatestInactivity).TotalMilliseconds < Activity.DefaultCommandCooldown)
            {
                return true;
            }

            InactiveCount++;
            LatestInactivity = DateTime.Now;

            Log.Verbose($"{Aliases[0]} inactivity counter is at {InactiveCount}.");

            if (InactiveCount < RequiredInactiveCount)
            {
                return true;
            }

            if (GetRemainingDuration() == 0)
            {
                if ((DateTime.Now - _latestDurationInactivity).TotalMilliseconds < Activity.DefaultCommandCooldown)
                {
                    return true;
                }

                _durationInactiveCount++;
                _latestDurationInactivity = DateTime.Now;

                Log.Verbose($"{Aliases[0]} inactivity counter is at {_durationInactiveCount}.");

                if (_durationInactiveCount < RequiredDurationInactiveCount)
                {
                    return true;
                }

                _currentRageLevel = 0;
                _recastPending = true;

                Log.Information($"Current rage level is now {_currentRageLevel}.");

                return false;
            }

            _durationInactiveCount = 0;

            if (_currentRageLevel == _maxRageLevel)
            {
                return true;
            }

            _recastPending = true;
            return false;
        }

        #endregion Protected Methods

        #region Private Methods

        private int GetCurrentRageLevel()
        {
            var remainingDuration = GetRemainingDuration();

            if (remainingDuration == 0)
            {
                return 0;
            }

            var currentRage = _rageLevels
                .Where(spell => spell.Duration > remainingDuration)
                .OrderBy(spell => spell.Duration)
                .First();

            var currentRageLevel = Convert.ToInt32(NumbersRegex.Match(currentRage.DisplayName).Groups[1].Value);

            return currentRageLevel > _maxRageLevel
                ? _maxRageLevel
                : currentRageLevel;
        }

        private int GetMaxRageLevel()
        {
            var maxRage = _rageLevels
                .Where(spell => spell.Cost <= _self.Self.Mana.Max)
                .OrderByDescending(spell => spell.Cost)
                .FirstOrDefault();

            if (maxRage == null)
            {
                return 0;
            }

            var maxRageLevel = Convert.ToInt32(NumbersRegex.Match(maxRage.DisplayName).Groups[1].Value);
            Log.Debug($"Maximum rage possible with current max mana of {_self.Self.Mana.Max:N0} is level {maxRageLevel} at a cost of {maxRage.Cost:N0} mana.");

            return maxRageLevel;
        }

        /// <summary>
        /// Rage/Cunning is unique in that it appears in the status box twice. Above the dotted line is the remaining duration
        /// of the spell. Below the dotted line is the remaining aethers. This checks to see is there is a Rage/Cunning entry
        /// specifically below the dotted line.
        /// </summary>
        private bool HasAethersRemaining()
        {
            var spellName = Aliases[0];
            var statusBoxText = Activity.ActiveStatusEffects;

            if (string.IsNullOrWhiteSpace(statusBoxText) || !statusBoxText.Contains(DottedLine))
            {
                return false;
            }

            var textBelowDottedLine = statusBoxText
                .Split(new[] { DottedLine }, StringSplitOptions.RemoveEmptyEntries)[1];

            var aetherStatuses = textBelowDottedLine
                .Split(new[] { System.Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            return aetherStatuses.Any(aetherStatus =>
                CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                    aetherStatus.Replace("'", string.Empty),
                    spellName.Replace("'", string.Empty),
                    CompareOptions.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// Rage/Cunning is unique in that it appears in the status box twice. Above the dotted line is the remaining duration
        /// of the spell. Below the dotted line is the remaining aethers. This checks to see is there is a Rage/Cunning entry
        /// specifically above the dotted line and returns the number of seconds in that entry.
        /// </summary>
        private int GetRemainingDuration()
        {
            var spellName = Aliases[0];
            var statusBoxText = Activity.ActiveStatusEffects;

            if (string.IsNullOrWhiteSpace(statusBoxText))
            {
                return 0;
            }

            var textAboveDottedLine = statusBoxText
                .Split(new[] { DottedLine }, StringSplitOptions.RemoveEmptyEntries)[0];

            var durationStatuses = textAboveDottedLine
                .Split(new[] { System.Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var rageDuration = durationStatuses.FirstOrDefault(durationStatus =>
                CultureInfo.InvariantCulture.CompareInfo.IndexOf(
                    durationStatus.Replace("'", string.Empty),
                    spellName.Replace("'", string.Empty),
                    CompareOptions.OrdinalIgnoreCase) >= 0);

            return rageDuration == null
                ? 0
                : Convert.ToInt32(NumbersRegex.Match(rageDuration).Groups[1].Value);
        }

        #endregion Private Methods
    }
}
