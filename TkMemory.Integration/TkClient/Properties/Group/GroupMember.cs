namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Provides basic information about a group member, his/her position within the group,
    /// and his/her current buff/debuff activity.
    /// </summary>
    public class GroupMember
    {
        #region Constructors

        /// <summary>
        /// Initializes data about a group member.
        /// </summary>
        /// <param name="position">The group member's zero-indexed position within the group.</param>
        /// <param name="name">The name of the group member.</param>
        /// <param name="uid">The UID of the group member.</param>
        public GroupMember(int position, string name, uint uid)
        {
            Activity = new GroupMemberActivity();
            Position = position;
            Name = name;
            Uid = uid;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Describes the current state of buffs/debuffs affecting the group member.
        /// </summary>
        public GroupMemberActivity Activity { get; }

        /// <summary>
        /// The name of the group member.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The zero-indexed position of the group member within the group.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// The UID of the group member.
        /// </summary>
        public uint Uid { get; }

        #endregion Properties
    }
}
