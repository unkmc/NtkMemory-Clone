using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Activity;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Poet
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Invoke, etc.).
    /// </summary>
    public class PoetStatus : CasterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Poet's status data.
        /// </summary>
        /// <param name="activity">The activity data of the Poet.</param>
        public PoetStatus(TkActivity activity) : base(activity)
        {
            HardenBody = new BuffStatus(Activity, Poet.HardenBody);
            Restore = new BuffStatus(Activity, Poet.Restore);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Harden Body buff.
        /// </summary>
        public BuffStatus HardenBody { get; }

        /// <summary>
        /// Gets the status of the Restore key spell.
        /// </summary>
        public BuffStatus Restore { get; }

        #endregion Properties
    }
}
