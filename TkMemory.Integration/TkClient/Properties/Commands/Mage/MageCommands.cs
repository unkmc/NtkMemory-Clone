using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Commands.Peasant;

namespace TkMemory.Integration.TkClient.Properties.Commands.Mage
{
    /// <summary>
    /// Commands specific to Mages.
    /// </summary>
    public class MageCommands : CasterCommands
    {
        #region Constructors

        /// <summary>
        /// Assigns spells from the Mage's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Mage.</param>
        public MageCommands(MageClient self) : base(self)
        {
            Attacks = new MageAttackCommands(self);
            Debuffs = new MageDebuffCommands(self);
            Heal = new PeasantHealCommands(self);
            Mana = new MageManaCommands(self);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commands for physical attacks and casting attack spells.
        /// </summary>
        public MageAttackCommands Attacks { get; }

        /// <summary>
        /// Commands for casting debuffs and debuff cures.
        /// </summary>
        public MageDebuffCommands Debuffs { get; }

        /// <summary>
        /// Commands for casting vita restoration spells.
        /// </summary>
        public PeasantHealCommands Heal { get; }

        /// <summary>
        /// Commands for casting mana restoration spells.
        /// </summary>
        public MageManaCommands Mana { get; }

        #endregion Properties
    }
}
