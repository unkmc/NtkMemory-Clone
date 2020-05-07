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

using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient.Properties
{
    /// <summary>
    /// A collection of properties to describe and/or set the entities currently being targeted by the player.
    /// </summary>
    public class TkTargeting
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's targeting data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkTargeting(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The current auto-target target ("Tab" targeting by default).
        /// </summary>
        public uint AutoTarget
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.AutoTarget);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.AutoTarget);
        }

        /// <summary>
        /// The current target of the player for casting any targetable spell.
        /// </summary>
        public uint Spell
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.Spell);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.Spell);
        }

        /// <summary>
        /// The current target lock target ("V" targeting by default).
        /// </summary>
        public uint TargetLock
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.TargetLock);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.TargetLock);
        }

        #endregion Properties
    }
}
