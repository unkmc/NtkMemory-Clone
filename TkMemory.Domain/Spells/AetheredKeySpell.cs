namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A spell known to the player that has aethers and is likely to be of relevance to a bot.
    /// </summary>
    public class AetheredKeySpell : KeySpell
    {
        #region Constructors

        /// <summary>
        /// Initialize a key spell with aethers with its key properties.
        /// </summary>
        /// <param name="unalignedName">The name of the spell before choosing an alignment.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="aethers">The number of seconds after casting before the spell can be cast again.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public AetheredKeySpell(string unalignedName, string alignedName, int cost, int aethers, int index = 0) : base(unalignedName, alignedName, cost, index)
        {
            Aethers = aethers;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The number of seconds after casting before the spell can be cast again.
        /// </summary>
        public int Aethers { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell and its aethers.
        /// </summary>
        /// <returns>A string representation of all key properties of the aethered spell.</returns>
        public override string ToString()
        {
            return Aethers > 0
                ? base.ToString().Replace(")", $", Aethers: {Aethers:N0})")
                : base.ToString();
        }

        #endregion Public Methods
    }
}
