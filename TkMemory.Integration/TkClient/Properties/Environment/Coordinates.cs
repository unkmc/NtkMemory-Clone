using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient.Properties.Environment
{
    /// <summary>
    /// A collection of properties to describe the player's current position on the current map.
    /// </summary>
    public class Coordinates
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's position data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public Coordinates(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The X-coordinate of the player's current position on the current map.
        /// </summary>
        public uint X => _classMemory.Read<uint>(TkAddresses.Environment.Map.Coordinates.X);

        /// <summary>
        /// The Y-coordinate of the player's current position on the current map.
        /// </summary>
        public uint Y => _classMemory.Read<uint>(TkAddresses.Environment.Map.Coordinates.Y);

        #endregion Properties
    }
}
