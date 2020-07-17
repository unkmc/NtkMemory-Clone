using TkMemory.Domain.Spells.KeySpells.Priorities;
using TkMemory.Integration.TkClient.Properties.Status.KeySpells;

namespace TkMemory.Integration.TkClient.Properties.Status
{
    /// <summary>
    /// Contains information about status effects that are at least partially within control of the Warrior
    /// (e.g. status effects like Sanctuary that can be cast on the player with or without the player's consent).
    /// Several properties are cross-listed with TkActivity properties, but this class is the only access to
    /// fully player-controlled status effects (e.g. Fury, Rage, etc.).
    /// </summary>
    public class WarriorStatus : FighterStatus
    {
        #region Constructors

        /// <summary>
        /// Initializes a Warrior's status data.
        /// </summary>
        /// <param name="self">All game client data for the Warrior.</param>
        public WarriorStatus(WarriorClient self) : base(self.Activity)
        {
            Backstab = new BuffStatus(Activity, Warrior.Backstab);
            Berserk = new BuffStatus(Activity, Warrior.Berserk);
            Blessing = new BuffStatus(Activity, Warrior.Blessing);
            Flank = new BuffStatus(Activity, Warrior.Flank);
            Fury = new BuffStatus(Activity, Warrior.Fury);
            Potence = new BuffStatus(Activity, Warrior.Potence);
            SpotTraps = new BuffStatus(Activity, Warrior.SpotTraps);
            Whirlwind = new BuffStatus(Activity, Warrior.Whirlwind);

            switch (self.Spells.KeySpells.Rage?.AlignedName)
            {
                case "Sonhi Rage":
                    Rage = new RageStatus(self, Warrior.SonhiRage);
                    break;

                default:
                    Rage = new RageStatus(self, Warrior.Rage);
                    break;
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the status of the Backstab buff.
        /// </summary>
        public BuffStatus Backstab { get; }

        /// <summary>
        /// Gets the status of the Berserk key spell.
        /// </summary>
        public BuffStatus Berserk { get; }

        /// <summary>
        /// Gets the status of the Blessing buff.
        /// </summary>
        public BuffStatus Blessing { get; }

        /// <summary>
        /// Gets the status of the Flank buff.
        /// </summary>
        public BuffStatus Flank { get; }

        /// <summary>
        /// Gets the status of the Potence buff.
        /// </summary>
        public BuffStatus Potence { get; }

        /// <summary>
        /// Gets the status of the Spot Traps key spell.
        /// </summary>
        public BuffStatus SpotTraps { get; }

        /// <summary>
        /// Gets the status of the Whirlwind key spell.
        /// </summary>
        public BuffStatus Whirlwind { get; }

        #endregion Properties
    }
}
