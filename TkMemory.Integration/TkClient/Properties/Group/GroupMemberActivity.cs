using TkMemory.Domain.Spells.KeySpells.Priorities;

namespace TkMemory.Integration.TkClient.Properties.Group
{
    /// <summary>
    /// Contains information about activity performed upon a group member (e.g. casting a status effect like Sanctuary).
    /// </summary>
    public class GroupMemberActivity
    {
        #region Constructors

        /// <summary>
        /// Initializes a group member's buff/debuff activity data.
        /// </summary>
        public GroupMemberActivity()
        {
            HardenArmor = new GroupMemberBuffActivity(Caster.HardenArmor);
            Sanctuary = new GroupMemberBuffActivity(Caster.Sanctuary);
            Valor = new GroupMemberBuffActivity(Caster.Valor);

            Blindness = new GroupMemberDebuffActivity();
            Paralysis = new GroupMemberDebuffActivity();
            Scourge = new GroupMemberDebuffActivity();
            Venom = new GroupMemberDebuffActivity();
            Vex = new GroupMemberDebuffActivity();
        }

        #endregion Constructors

        #region Properties

        #region Buffs

        /// <summary>
        /// Gets information about a group member's current status in regard to the Harden Armor buff.
        /// </summary>
        public GroupMemberBuffActivity HardenArmor { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Sanctuary buff.
        /// </summary>
        public GroupMemberBuffActivity Sanctuary { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Valor/Might buff.
        /// </summary>
        public GroupMemberBuffActivity Valor { get; }

        #endregion Buffs

        #region Debuffs

        /// <summary>
        /// Gets information about a group member's current status in regard to the Blindness debuff.
        /// </summary>
        public GroupMemberDebuffActivity Blindness { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Paralysis debuff.
        /// </summary>
        public GroupMemberDebuffActivity Paralysis { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Scourge debuff.
        /// </summary>
        public GroupMemberDebuffActivity Scourge { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Venom debuff.
        /// </summary>
        public GroupMemberDebuffActivity Venom { get; }

        /// <summary>
        /// Gets information about a group member's current status in regard to the Vex debuff.
        /// </summary>
        public GroupMemberDebuffActivity Vex { get; }

        #endregion Debuffs

        #endregion Properties
    }
}
