using AutoHotkey.Interop.ClassMemory;
using System.Threading.Tasks;
using TkMemory.Domain.Spells;
using TkMemory.Integration.TkClient.Properties.Commands.Poet;
using TkMemory.Integration.TkClient.Properties.Npcs;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Poet by reading the memory of the application.
    /// </summary>
    public class PoetClient : CasterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Poet.
        /// </summary>
        /// <param name="classMemory">The application memory for the Poet's game client.</param>
        public PoetClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Poet;
            Spells = new PoetSpells(classMemory);
            Status = new PoetStatus(Activity);
            Commands = new PoetCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Poet.
        /// </summary>
        public PoetCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Poet.
        /// </summary>
        public PoetSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Poet.
        /// </summary>
        public PoetStatus Status { get; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Scans the current screen for NPCs and adds any that are not already in the bot's NPC
        /// list to that list. By default, this happens no more often than once every 10 seconds,
        /// but it can also be done on command by using the override parameter.
        /// </summary>
        /// <param name="targetableSpell">Any targetable spell.</param>
        /// <param name="overrideCooldown">Set to true for an on-demand scan regardless of current
        /// cooldown.</param>
        /// <returns>True if a scan is performed; false if the cooldown prevented a scan.</returns>
        public override async Task<bool> UpdateNpcs(Spell targetableSpell, bool overrideCooldown = false)
        {
            if (!await base.UpdateNpcs(targetableSpell, overrideCooldown))
            {
                return false;
            }

            foreach (var npc in Npcs)
            {
                if (npc.Activity.Curse == null)
                {
                    npc.Activity.Curse = new NpcDebuffActivity(Spells.KeySpells.Curse);
                }

                if (npc.Activity.Dishearten == null)
                {
                    npc.Activity.Dishearten = new NpcDebuffActivity(Spells.KeySpells.Dishearten);
                }
            }

            return true;
        }

        #endregion Public Methods
    }
}
