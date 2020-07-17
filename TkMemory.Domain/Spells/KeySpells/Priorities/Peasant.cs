namespace TkMemory.Domain.Spells.KeySpells.Priorities
{
    /// <summary>
    /// Key spell selection priorities for spells known to all paths.
    /// </summary>
    public class Peasant
    {
        /// <summary>
        /// Used to teleport to people. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public static readonly KeySpell Approach = new KeySpell("Approach", "Approach", 30);

        /// <summary>
        /// Teleport to North, South, East, or West Gate.
        /// </summary>
        public static readonly KeySpell Gateway = new KeySpell("Gateway", "Gateway", 0);

        /// <summary>
        /// Used to teleport people to you. Person must be in an area that allows approaching, citizenship in the same kingdom,
        /// and be in your group to approach or else a "Fizzle" message is seen.
        /// </summary>
        public static readonly KeySpell Summon = new KeySpell("Summon", "Summon", 30);
    }
}
