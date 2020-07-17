namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A spell known to the player.
    /// </summary>
    public class Spell
    {
        #region Constructors

        /// <summary>
        /// Initializes a spell with its key properties.
        /// </summary>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        /// <param name="alignedName">The name of the spell.</param>
        public Spell(int index, string alignedName)
        {
            Letter = Infrastructure.Letter.Parse(index);
            AlignedName = alignedName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The alphabetic character that corresponds to the position of the spell within a player's spell inventory.
        /// </summary>
        public string Letter { get; }

        /// <summary>
        /// The name of the spell.
        /// </summary>
        public string AlignedName { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// </summary>
        /// <returns>A string representation of all key properties of the spell.</returns>
        public override string ToString()
        {
            return $"{Letter}: {AlignedName}";
        }

        #endregion Public Methods
    }
}
