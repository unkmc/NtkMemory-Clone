using AutoHotkey.Interop.ClassMemory;
using System.Collections.Generic;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// A collection of properties and methods for obtaining information about
    /// a player's group, its current members, and their available stats.
    /// </summary>
    public class TkGroup
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's group data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkGroup(ClassMemory classMemory)
        {
            _classMemory = classMemory;

            Mana = new GroupMana(_classMemory);
            Vita = new GroupVita(_classMemory);

            MultiboxMembers = new List<TkClient>();
            ExternalMembers = new List<GroupMember>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets information about group members' mana.
        /// </summary>
        public GroupMana Mana { get; }

        /// <summary>
        /// A list of group members being operated from the same PC as the player.
        /// </summary>
        public List<TkClient> MultiboxMembers { get; internal set; }

        /// <summary>
        /// A list of group members being operated from different PCs than the player.
        /// </summary>
        public List<GroupMember> ExternalMembers { get; }

        /// <summary>
        /// The current size of the group (including the player).
        /// </summary>
        public int Size => _classMemory.Read<int>(TkAddresses.Group.Size);

        /// <summary>
        /// Gets information about group members' vita.
        /// </summary>
        public GroupVita Vita { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets the name of the group member at the specified position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The name of the group member at the specified position.</returns>
        public string GetName(int groupPosition)
        {
            var address = TkAddresses.Group.Name;
            var offsets = address.Offsets.AddPositionOffset(groupPosition, TkAddresses.Group.PositionOffset);
            return _classMemory.ReadString(address.BaseAddress, offsets, Constants.DefaultEncoding);
        }

        /// <summary>
        /// Gets the UID of the group member at the specified position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The UID of the group member at the specified position.</returns>
        public uint GetUid(int groupPosition)
        {
            var address = TkAddresses.Group.Uid;
            var offsets = address.Offsets.AddPositionOffset(groupPosition, TkAddresses.Group.PositionOffset);
            return _classMemory.Read<uint>(address.BaseAddress, offsets);
        }

        #endregion Public Methods
    }
}
