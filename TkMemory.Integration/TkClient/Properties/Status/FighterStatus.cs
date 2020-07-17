using TkMemory.Integration.TkClient.Properties.Activity;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Rogue or Warrior.
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Rage, Cunning, etc.).
    /// </summary>
    public class FighterStatus : TkStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Rogue's or Warrior's status data.
        /// </summary>
        /// <param name="activity">The activity data of the Rogue or Warrior.</param>
        public FighterStatus(TkActivity activity) : base(activity) { }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Fury buff.
        /// </summary>
        public BuffStatus Fury { get; protected set; }

        /// <summary>
        /// Gets the status of the Rage buff.
        /// </summary>
        public RageStatus Rage { get; protected set; }

        #endregion Properties
    }
}
