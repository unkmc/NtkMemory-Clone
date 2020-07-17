using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Activity;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a debuff key spell used to determine when it is actively affecting
    /// the player.
    /// </summary>
    public class DebuffStatus : KeySpellStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of the debuff.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        /// <param name="aliases">A list of all unaligned and aligned names of the debuff.</param>
        public DebuffStatus(TkActivity activity, IEnumerable<KeySpell> aliases) : base(activity, aliases) { }

        #endregion Constructors

        #region Protected Methods

        /// <summary>
        /// This is way of dealing with lag. A status effect can remain active for a brief
        /// period after the status box shows it as having expired. This method forces a
        /// status to show as inactive three times in a row to be considered truly inactive.
        /// Essentially, this enforces an artificial delay of three command cycles in between
        /// detecting an inactive status effect and recasting that status effect to avoid
        /// redundant casting.
        /// </summary>
        protected override bool CheckIfActive()
        {
            var isActive = !IsCoolingDown() && IsListedInActiveEffects();
            return isActive;
        }

        #endregion Protected Methods
    }
}
