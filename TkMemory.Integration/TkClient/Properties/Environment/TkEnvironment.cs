using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient.Properties.Environment
{
    /// <summary>
    /// A collection of properties to describe the current environment and the player's current position within it.
    /// </summary>
    public class TkEnvironment
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's environmental data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkEnvironment(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Map = new Map(_classMemory);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Data about the current map and the player's current position on it.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// The current in-game time.
        /// </summary>
        public ushort Time => _classMemory.Read<ushort>(TkAddresses.Environment.Time);

        #endregion Properties
    }
}
