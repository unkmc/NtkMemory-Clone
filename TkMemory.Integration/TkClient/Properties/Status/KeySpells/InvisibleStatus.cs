using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Activity;

namespace TkMemory.Integration.TkClient.Properties.Status.KeySpells
{
    /// <summary>
    /// Tracks the properties of a Rogue's Invisible key spell used to determine when it is active.
    /// </summary>
    public class InvisibleStatus : KeySpellStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes the key spell properties used to track the status of the buff.
        /// </summary>
        /// <param name="activity">The activity data of the player.</param>
        /// <param name="aliases">A list of all unaligned and aligned names of the buff.</param>
        public InvisibleStatus(TkActivity activity, IEnumerable<KeySpell> aliases) : base(activity, aliases) { }

        #endregion Constructors

        #region Properties

        public int Cooldown { get; set; }

        #endregion Properties

        #region Protected Methods

        /// <summary>
        /// Invisible needs to be cast so often that it does not work very well to try to
        /// detect it in the status effects window to decide when to cast it or not. Casting
        /// at set intervals is more efficient.
        /// </summary>
        protected override bool CheckIfActive()
        {
            return IsCoolingDown(Cooldown);
        }

        #endregion Protected Methods
    }
}
