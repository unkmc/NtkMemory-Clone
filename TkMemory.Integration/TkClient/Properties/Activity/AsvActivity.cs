using System.Collections.Generic;
using TkMemory.Domain.Spells;
using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Activity
{
    /// <summary>
    /// A collection of properties that describes the current status of a player
    /// in regard to the Harden Armor, Sanctuary, and Valor buffs.
    /// </summary>
    public class AsvActivity
    {
        #region Constructors

        /// <summary>
        /// Initializes tracking of Harden Armor, Sanctuary, and Valor buffs.
        /// </summary>
        /// <param name="activity">The player's activity data.</param>
        public AsvActivity(TkActivity activity)
        {
            var hardenArmorBuffs = new List<BuffKeySpell>();
            hardenArmorBuffs.AddRange(Caster.HardenArmor);
            hardenArmorBuffs.AddRange(Poet.Asv);
            hardenArmorBuffs.AddRange(Poet.AsvGroup);

            var sanctuaryBuffs = new List<BuffKeySpell>();
            sanctuaryBuffs.AddRange(Caster.Sanctuary);
            sanctuaryBuffs.AddRange(Poet.Asv);
            sanctuaryBuffs.AddRange(Poet.AsvGroup);

            var valorBuffs = new List<BuffKeySpell>();
            valorBuffs.AddRange(Caster.Valor);
            valorBuffs.AddRange(Rogue.Might);
            valorBuffs.AddRange(Poet.Asv);
            valorBuffs.AddRange(Poet.AsvGroup);

            HardenArmor = new BuffStatus(activity, hardenArmorBuffs);
            Sanctuary = new BuffStatus(activity, sanctuaryBuffs);
            Valor = new BuffStatus(activity, valorBuffs);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The current status of the Harden Armor buff.
        /// </summary>
        public BuffStatus HardenArmor { get; }

        /// <summary>
        /// The current status of the Sanctuary buff.
        /// </summary>
        public BuffStatus Sanctuary { get; }

        /// <summary>
        /// The current status of the Valor/Might buff.
        /// </summary>
        public BuffStatus Valor { get; }

        #endregion Properties
    }
}
