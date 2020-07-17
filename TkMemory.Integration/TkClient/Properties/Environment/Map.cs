using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Environment
{
    /// <summary>
    /// A collection of properties to describe the current map and the player's current position on it.
    /// </summary>
    public class Map
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's map data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public Map(ClassMemory classMemory)
        {
            _classMemory = classMemory;
            Coordinates = new Coordinates(_classMemory);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The coordinates of the player's current position on the current map.
        /// </summary>
        public Coordinates Coordinates { get; }

        /// <summary>
        /// The name of the current map.
        /// </summary>
        public string Name => _classMemory.ReadString(TkAddresses.Environment.Map.Name, Constants.DefaultEncoding);

        #endregion Properties
    }
}
