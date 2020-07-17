using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Properties.Commands.Warrior;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Warrior by reading the memory of the application.
    /// </summary>
    public class WarriorClient : FighterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Warrior.
        /// </summary>
        /// <param name="classMemory">The application memory for the Warrior's game client.</param>
        public WarriorClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Warrior;
            Spells = new WarriorSpells(classMemory);
            Status = new WarriorStatus(this);
            Commands = new WarriorCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Warrior.
        /// </summary>
        public WarriorCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Warrior.
        /// </summary>
        public WarriorSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Warrior.
        /// </summary>
        public WarriorStatus Status { get; }

        #endregion Properties
    }
}
