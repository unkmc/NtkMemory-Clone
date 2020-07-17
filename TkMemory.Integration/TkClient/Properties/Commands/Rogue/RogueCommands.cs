using TkMemory.Integration.TkClient.Properties.Commands.Fighter;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Rogue
{
    /// <summary>
    /// Commands specific to Rogues.
    /// </summary>
    public class RogueCommands : FighterCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public RogueCommands(RogueClient self) : base(self)
        {
            Attacks = new RogueAttackCommands(self);
            Buffs = new RogueBuffCommands(self);
            Heal = new PeasantHealCommands(self);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commands for physical attacks and casting attack spells.
        /// </summary>
        public RogueAttackCommands Attacks { get; }

        /// <summary>
        /// Commands for casting buff spells.
        /// </summary>
        public RogueBuffCommands Buffs { get; }

        /// <summary>
        /// Commands for casting vita restoration spells.
        /// </summary>
        public PeasantHealCommands Heal { get; }

        #endregion Properties
    }
}
