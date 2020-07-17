using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Activity
{
    /// <summary>
    /// A collection of properties that describes the current status of a player
    /// in regard to various debuffs.
    /// </summary>
    public class DebuffActivity
    {
        #region Constructors

        /// <summary>
        /// Initializes tracking of debuffs.
        /// </summary>
        /// <param name="activity"></param>
        public DebuffActivity(TkActivity activity)
        {
            var paralyzeDebuffs = new List<BuffKeySpell>();
            paralyzeDebuffs.AddRange(Mage.Paralyze);
            paralyzeDebuffs.AddRange(Mage.MassParalyze);

            Blindness = new DebuffStatus(activity, Mage.Blind);
            Paralysis = new DebuffStatus(activity, paralyzeDebuffs);
            Scourge = new DebuffStatus(activity, Poet.Scourge);
            Venom = new DebuffStatus(activity, Mage.Venom);
            Vex = new DebuffStatus(activity, Mage.Vex);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The current status of the Blindness debuff.
        /// </summary>
        public DebuffStatus Blindness { get; }

        /// <summary>
        /// The current status of the Paralysis debuff.
        /// </summary>
        public DebuffStatus Paralysis { get; }

        /// <summary>
        /// The current status of the Scourge curse debuff.
        /// </summary>
        public DebuffStatus Scourge { get; }

        /// <summary>
        /// The current status of the Venom debuff.
        /// </summary>
        public DebuffStatus Venom { get; }

        /// <summary>
        /// The current status of the Vex curse debuff.
        /// </summary>
        public DebuffStatus Vex { get; }

        #endregion Properties
    }
}
