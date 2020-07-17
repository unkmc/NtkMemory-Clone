using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Fighter
{
    /// <summary>
    /// Commands common to both Rogues and Warriors.
    /// </summary>
    public class FighterCommands : PeasantCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public FighterCommands(RogueClient self) : base(self) { }

        /// <summary>
        /// Assigns spells from the Warrior's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Warrior.</param>
        public FighterCommands(WarriorClient self) : base(self) { }

        #endregion Constructors
    }
}
