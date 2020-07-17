namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Provides information about the current effects of a detrimental status effect upon a group member.
    /// This is only required for external group members as the status of multibox group members can be read
    /// directly instead of being tracked this way.
    /// </summary>
    public class GroupMemberDebuffActivity
    {
        #region Properties

        /// <summary>
        /// Gets whether or not the status effect is currently affecting the player.
        /// </summary>
        public bool IsActive { get; internal set; }

        #endregion Properties
    }
}
