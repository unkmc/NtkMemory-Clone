using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// A collection of methods for getting information about group members' mana.
    /// </summary>
    public class GroupMana
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's group mana data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public GroupMana(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets the current mana of the group member at the specified position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The current mana of the group member at the specified position.</returns>
        public uint GetCurrent(int groupPosition)
        {
            var address = TkAddresses.Group.Mana.Current;
            var offsets = address.Offsets.AddPositionOffset(groupPosition, TkAddresses.Group.PositionOffset);
            return _classMemory.Read<uint>(address.BaseAddress, offsets);
        }

        /// <summary>
        /// Gets the difference between the max mana and current mana of the group member
        /// at the specified position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The current mana deficit of the group member at the specified position.</returns>
        /// <returns></returns>
        public uint GetDeficit(int groupPosition)
        {
            return GetMax(groupPosition) - GetCurrent(groupPosition);
        }

        /// <summary>
        /// Gets the maximum mana of the group member at the specified position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The max mana of the group member at the specified position.</returns>
        public uint GetMax(int groupPosition)
        {
            var address = TkAddresses.Group.Mana.Max;
            var offsets = address.Offsets.AddPositionOffset(groupPosition, TkAddresses.Group.PositionOffset);
            return _classMemory.Read<uint>(address.BaseAddress, offsets);
        }

        /// <summary>
        /// Gets the percentage of current mana to max mana of the group member at the specified
        /// position within the group.
        /// </summary>
        /// <param name="groupPosition">Zero-indexed position within the group.</param>
        /// <returns>The current mana percentage of the group member at the specified position.</returns>
        public double GetPercent(int groupPosition)
        {
            return (float)GetCurrent(groupPosition) / GetMax(groupPosition);
        }

        #endregion Public Methods
    }
}
