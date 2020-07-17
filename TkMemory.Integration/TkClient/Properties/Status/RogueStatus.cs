using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Rogue
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Cunning, etc.).
    /// </summary>
    public class RogueStatus : FighterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Rogue's status data.
        /// </summary>
        /// <param name="self">All game client data for the Rogue.</param>
        public RogueStatus(TkClient self) : base(self.Activity)
        {
            DesperateAttack = new BuffStatus(Activity, Rogue.DesperateAttack);
            Invisible = new InvisibleStatus(Activity, Rogue.Invisible);
            LethalStrike = new BuffStatus(Activity, Rogue.LethalStrike);
            Fury = new BuffStatus(Activity, Rogue.Fury);
            Rage = new RageStatus(self, Rogue.Cunning);
            ShadowFigure = new BuffStatus(Activity, Rogue.ShadowFigure);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Desperate Attack key spell.
        /// </summary>
        public BuffStatus DesperateAttack { get; }

        /// <summary>
        /// Gets the status of the Invisible buff.
        /// </summary>
        public InvisibleStatus Invisible { get; }

        /// <summary>
        /// Gets the status of the Lethal Strike key spell.
        /// </summary>
        public BuffStatus LethalStrike { get; }

        /// <summary>
        /// Gets the status of the Shadow Figure buff.
        /// </summary>
        public BuffStatus ShadowFigure { get; }

        #endregion Properties
    }
}
