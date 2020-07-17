using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Activity;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Mage or Poet
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Invoke, etc.).
    /// </summary>
    public abstract class CasterStatus : TkStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Mage's or Poet's status data.
        /// </summary>
        /// <param name="activity">The activity data of the Mage or Poet.</param>
        protected CasterStatus(TkActivity activity) : base(activity)
        {
            Invoke = new BuffStatus(Activity, Caster.Invoke);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Invoke key spell.
        /// </summary>
        public BuffStatus Invoke { get; }

        #endregion Properties
    }
}
