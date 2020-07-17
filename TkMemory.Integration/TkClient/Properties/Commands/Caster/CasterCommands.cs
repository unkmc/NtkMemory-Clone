using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Caster
{
    /// <summary>
    /// Commands common to both Mages and Poets.
    /// </summary>
    public class CasterCommands : PeasantCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public CasterCommands(MageClient self) : base(self)
        {
            Asv = new CasterAsvCommands(self);
        }

        /// <summary>
        /// Assigns spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public CasterCommands(PoetClient self) : base(self)
        {
            Asv = new CasterAsvCommands(self);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commands for casting the Harden Armor, Sanctuary, and Valor buffs.
        /// </summary>
        public CasterAsvCommands Asv { get; }

        #endregion Properties
    }
}
