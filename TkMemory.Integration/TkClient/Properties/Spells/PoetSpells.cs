using AutoHotkey.Interop.ClassMemory;
using System.Text;
using TkMemory.Domain.Spells.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Spells
{
    /// <summary>
    /// Provides information about the spells currently known by a Poet.
    /// </summary>
    public class PoetSpells : TkSpells
    {
        #region Constructors

        /// <summary>
        /// Initializes a Poet's spell data.
        /// </summary>
        /// <param name="classMemory">The application memory for the Poet's game client.</param>
        public PoetSpells(ClassMemory classMemory) : base(classMemory)
        {
            KeySpells = new PoetKeySpells(Spells);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the key spells known to the Poet.
        /// </summary>

        public PoetKeySpells KeySpells { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Outputs all spells known to the Poet using the format used in-game for the a player's spell inventory.
        /// Also lists all key spells known to the Poet.
        /// </summary>
        /// <returns>A string representation of all spells and key spells known to the Poet.</returns>

        public override string ToString()
        {
            if (Spells == null || Spells.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(KeySpells.ToString());

            return sb.ToString();
        }

        #endregion Public Methods
    }
}
