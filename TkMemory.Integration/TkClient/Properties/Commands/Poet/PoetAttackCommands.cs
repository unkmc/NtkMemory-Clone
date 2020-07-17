using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands for physical attacks and casting attack spells specific to Poets.
    /// </summary>
    public class PoetAttackCommands : PeasantAttackCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns attack spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetAttackCommands(PoetClient self) : base(self) { }

        #endregion Constructors
    }
}
