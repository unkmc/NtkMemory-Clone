using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Caster;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

// ReSharper disable UnusedMember.Global

namespace TkMemory.Integration.TkClient.Properties.Commands.Poet
{
    /// <summary>
    /// Commands specific to Poets.
    /// </summary>
    public class PoetCommands : CasterCommands
    {
        #region Fields

        private readonly KeySpell _hardenBodySpell;
        private readonly BuffStatus _hardenBodyStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns spells from the Poet's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Poet.</param>
        public PoetCommands(PoetClient self) : base(self)
        {
            _hardenBodySpell = self.Spells.KeySpells.HardenBody;
            _hardenBodyStatus = self.Status.HardenBody;

            Attacks = new PoetAttackCommands(self);
            Debuffs = new PoetDebuffCommands(self);
            Heal = new PoetHealCommands(self);
            Mana = new PoetManaCommands(self);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Commands for physical attacks and casting attack spells.
        /// </summary>
        public PoetAttackCommands Attacks { get; }

        /// <summary>
        /// Commands for casting debuffs and debuff cures.
        /// </summary>
        public PoetDebuffCommands Debuffs { get; }

        /// <summary>
        /// Commands for casting vita restoration spells.
        /// </summary>
        public PoetHealCommands Heal { get; }

        /// <summary>
        /// Commands for casting mana restoration spells.
        /// </summary>
        public PoetManaCommands Mana { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Casts the Harden Body buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> HardenBody()
        {
            return await SpellCommands.CastAetheredSpell(Self, _hardenBodySpell, _hardenBodyStatus);
        }

        #endregion Public Methods
    }
}
