using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient.Properties.Self
{
    /// <summary>
    /// A collection of properties for getting information about a player's mana.
    /// </summary>
    public class SelfMana
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's mana data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public SelfMana(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the current mana of the player.
        /// </summary>
        public uint Current => _classMemory.Read<uint>(TkAddresses.Self.Mana.Current);

        /// <summary>
        /// Gets the difference between the maximum mana and current mana of the player.
        /// </summary>
        public uint Deficit => Max - Current;

        /// <summary>
        /// Gets the maximum mana of the player.
        /// </summary>
        public uint Max => _classMemory.Read<uint>(TkAddresses.Self.Mana.Max);

        /// <summary>
        /// Gets the percentage of current mana to max mana of the player.
        /// </summary>
        public double Percent => (float)Current / Max;

        #endregion Properties
    }
}
