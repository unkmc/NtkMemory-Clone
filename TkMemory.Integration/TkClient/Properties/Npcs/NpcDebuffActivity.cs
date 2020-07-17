using System;
using TkMemory.Domain.Spells;

namespace TkMemory.Integration.TkClient.Properties.Npcs
{
    /// <summary>
    /// Provides information about the current effect of a detrimental status effect upon an NPC.
    /// </summary>
    public class NpcDebuffActivity
    {
        #region Fields

        private readonly int _duration;
        private DateTime _timeLastCast;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a timer to track the status effect.
        /// </summary>
        /// <param name="buffKeySpell">The spell that causes the status effect.</param>
        public NpcDebuffActivity(BuffKeySpell buffKeySpell)
        {
            if (buffKeySpell == null)
            {
                _duration = int.MaxValue;
                _timeLastCast = DateTime.MaxValue;
                return;
            }

            _duration = buffKeySpell.Duration + 1;
            OverrideTimer();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets whether or not the status effect is currently affecting the NPC.
        /// </summary>
        public bool IsActive => (DateTime.Now - _timeLastCast).TotalSeconds < _duration;

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Alters the timer used track when the debuff was most recently cast on the NPC
        /// such that the trainer will recast on the NPC at the next opportunity.
        /// </summary>
        public void OverrideTimer()
        {
            _timeLastCast = DateTime.Now.AddSeconds(-_duration);
        }

        /// <summary>
        /// Resets the timer used track when the debuff was most recently cast on the NPC.
        /// </summary>
        public void ResetTimer()
        {
            _timeLastCast = DateTime.Now;
        }

        #endregion Public Methods
    }
}
