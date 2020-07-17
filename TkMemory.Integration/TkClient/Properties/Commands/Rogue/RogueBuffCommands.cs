using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Fighter;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Commands.Rogue
{
    /// <summary>
    /// Commands specific to Rogues that are used to cast buffs.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class RogueBuffCommands : FighterBuffCommands
    {
        #region Fields

        private const int AmbushCooldown = 500;
        private const int MeleeCooldown = 750;

        private readonly RogueClient _self;
        private readonly KeySpell _invisibleSpell;
        private readonly InvisibleStatus _invisibleStatus;
        private readonly KeySpell _mightSpell;
        private readonly BuffStatus _mightStatus;
        private readonly KeySpell _shadowFigureSpell;
        private readonly BuffStatus _shadowFigureStatus;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Assigns buff spells from the Rogue's spell inventory.
        /// </summary>
        /// <param name="self">The game client data for the Rogue.</param>
        public RogueBuffCommands(RogueClient self) : base(self)
        {
            _self = self;
            _invisibleSpell = self.Spells.KeySpells.Invisible;
            _invisibleStatus = self.Status.Invisible;
            _mightSpell = self.Spells.KeySpells.Might;
            _mightStatus = self.Activity.Asv.Valor;
            _shadowFigureSpell = self.Spells.KeySpells.ShadowFigure;
            _shadowFigureStatus = self.Status.ShadowFigure;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Makes the caster invisible to multiply physical attack damage.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Invisible(bool ambush)
        {
            _invisibleStatus.Cooldown = ambush && _self.Spells.KeySpells.Ambush != null
                ? AmbushCooldown
                : MeleeCooldown;

            return await SpellCommands.CastInvisibleSpell(Self, _invisibleSpell, _invisibleStatus);
        }

        /// <summary>
        /// Casts the Might buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> Might()
        {
            return await SpellCommands.CastAetheredSpell(Self, _mightSpell, _mightStatus);
        }

        /// <summary>
        /// Casts the Shadow Figure buff on the caster.
        /// </summary>
        /// <returns>True if the spell was cast; false otherwise.</returns>
        public async Task<bool> ShadowFigure()
        {
            return await SpellCommands.CastAetheredSpell(Self, _shadowFigureSpell, _shadowFigureStatus);
        }

        #endregion Public Methods
    }
}
