using System;
using TkMemory.Domain.Items;

namespace TkMemory.Domain.Spells
{
    /// <summary>
    /// A spell known to the player that is likely to be of relevance to a bot.
    /// </summary>
    public class KeySpell : Spell
    {
        #region Constructors

        /// <summary>
        /// Initialize a key spell with its key properties.
        /// </summary>
        /// <param name="unalignedName">The original name of the spell when no alignment has been chosen.</param>
        /// <param name="alignedName">The name of the spell.</param>
        /// <param name="cost">The amount of mana required to cast the spell once.</param>
        /// <param name="index">The numeric index of the position of the item within a player's spell inventory.</param>
        public KeySpell(string unalignedName, string alignedName, int cost, int index = 0) : base(index, alignedName)
        {
            UnalignedName = unalignedName;
            Cost = cost;
            IsOrbSpell = false;
        }

        /// <summary>
        /// Initialize a key spell that is cast by using an orb item.
        /// </summary>
        /// <param name="orb">The orb item used to cast the spell.</param>
        public KeySpell(Item orb) : base(Infrastructure.Index.Parse(orb.Letter, 'A'), orb.Name)
        {
            UnalignedName = orb.Name;
            Cost = 0;
            IsOrbSpell = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The amount of mana required to cast the spell once.
        /// </summary>
        public int Cost { get; }

        /// <summary>
        /// Gets the unaligned name of the spell with its aligned name following in parentheses.
        /// </summary>
        public string DisplayName => GetDisplayName();

        /// <summary>
        /// The original name of the spell when no alignment has been chosen.
        /// </summary>
        public string UnalignedName { get; }

        /// <summary>
        /// True if the spell is cast by using an orb item; false if it is a traditional spell.
        /// </summary>
        public bool IsOrbSpell { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spell properties using the format used in-game for a player's spell inventory.
        /// Also outputs the cost of the spell.
        /// </summary>
        /// <returns>A string representation of all key properties of the key spell.</returns>
        public override string ToString()
        {
            return $"{base.ToString()} (Cost: {Cost:N0})";
        }

        #endregion Public Methods

        #region Private Methods

        private string GetDisplayName()
        {
            var alignedName = AlignedName
                .Replace("Dispell", "Dispel")
                .Replace("Baekho's Cunning", string.Empty)
                .Replace("Chung Ryong's Rage", string.Empty)
                .Replace("Call of the Wild (", string.Empty)
                .Replace(")", string.Empty);

            if (string.IsNullOrWhiteSpace(alignedName) ||
                string.Equals(UnalignedName, alignedName, StringComparison.OrdinalIgnoreCase))
            {
                return UnalignedName;
            }

            return $"{UnalignedName} ({alignedName})";
        }

        #endregion Private Methods
    }
}
