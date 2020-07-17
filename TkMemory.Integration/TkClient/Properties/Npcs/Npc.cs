namespace TkMemory.Integration.TkClient.Properties.Npcs
{
    /// <summary>
    /// Provides identifying information for an NPC as well as information about the activity
    /// performed upon an NPC (e.g. casting a status effect like Scourge).
    /// </summary>
    public class Npc
    {
        #region Constructors

        /// <summary>
        /// Initializes the activity data for a specified NPC.
        /// </summary>
        /// <param name="uid">The UID of the NPC.</param>
        public Npc(uint uid)
        {
            Activity = new NpcActivity();
            Uid = uid;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the activity data of the NPC.
        /// </summary>
        public NpcActivity Activity { get; }

        /// <summary>
        /// Gets the UID of the NPC.
        /// </summary>
        public uint Uid { get; }

        #endregion Properties
    }
}
