namespace TkMemory.Integration.TkClient.Properties.Npcs
{
    /// <summary>
    /// Contains information about activity performed upon an NPC (e.g. casting a status effect like Scourge).
    /// </summary>
    public class NpcActivity
    {
        #region Properties

        /// <summary>
        /// Gets the activity data for the Blindness debuff.
        /// </summary>
        public NpcDebuffActivity Blind { get; internal set; }

        /// <summary>
        /// Gets the activity data for a Curse debuff (i.e. Vex or Scourge).
        /// </summary>
        public NpcDebuffActivity Curse { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Dishearten debuff.
        /// </summary>
        public NpcDebuffActivity Dishearten { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Doze debuff.
        /// </summary>
        public NpcDebuffActivity Doze { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Paralyze debuff.
        /// </summary>
        public NpcDebuffActivity Paralyze { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Sleep debuff.
        /// </summary>
        public NpcDebuffActivity Sleep { get; internal set; }

        /// <summary>
        /// Gets the activity data for the Venom debuff.
        /// </summary>
        public NpcDebuffActivity Venom { get; internal set; }

        #endregion Properties
    }
}
