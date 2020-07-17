using AutoHotkey.Interop.ClassMemory;
using System;
using TkMemory.Integration.TkClient.Infrastructure;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Entity
{
    /// <summary>
    /// A collection of methods for determining the pixel position of an NPC or player on the screen.
    /// </summary>
    [Obsolete]
    public class Pixels
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes retrieval of position data from the application memory of the game.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public Pixels(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets the X-coordinate of the NPC's or player's pixel position on the screen.
        /// </summary>
        /// <param name="entityIndex">The index of the NPC or player within the list of entities in the application's memory.</param>
        /// <returns>The X-coordinate of the NPC's or player's pixel position on the screen.</returns>
        public int GetX(int entityIndex)
        {
            var address = TkAddresses.Entity.Pixels.X;
            var offsets = address.Offsets.AddPositionOffset(entityIndex, TkAddresses.Entity.PositionOffset);
            return _classMemory.Read<int>(address.BaseAddress, offsets);
        }

        /// <summary>
        /// Gets the Y-coordinate of the NPC's or player's pixel position on the screen.
        /// </summary>
        /// <param name="entityIndex">The index of the NPC or player within the list of entities in the application's memory.</param>
        /// <returns>The Y-coordinate of the NPC's or player's pixel position on the screen.</returns>
        public int GetY(int entityIndex)
        {
            var address = TkAddresses.Entity.Pixels.Y;
            var offsets = address.Offsets.AddPositionOffset(entityIndex, TkAddresses.Entity.PositionOffset);
            return _classMemory.Read<int>(address.BaseAddress, offsets);
        }

        #endregion Public Methods
    }
}
