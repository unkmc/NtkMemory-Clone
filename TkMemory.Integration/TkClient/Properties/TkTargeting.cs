using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient.Properties
{
    /// <summary>
    /// A collection of properties to describe and/or set the entities currently being targeted by the player.
    /// </summary>
    public class TkTargeting
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's targeting data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkTargeting(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The current auto-target target ("Tab" targeting by default).
        /// </summary>
        public uint AutoTarget
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.AutoTarget);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.AutoTarget);
        }

        /// <summary>
        /// The current target of the player for using any targetable item (e.g. Mage orbs).
        /// </summary>
        public uint Item
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.Item);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.Item);
        }

        /// <summary>
        /// The current target of the player for casting any targetable spell.
        /// </summary>
        public uint Spell
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.Spell);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.Spell);
        }

        /// <summary>
        /// The current target lock target ("V" targeting by default).
        /// </summary>
        public uint TargetLock
        {
            get => _classMemory.Read<uint>(TkAddresses.Self.TargetUids.TargetLock);
            set => _classMemory.Write(value, TkAddresses.Self.TargetUids.TargetLock);
        }

        #endregion Properties
    }
}
