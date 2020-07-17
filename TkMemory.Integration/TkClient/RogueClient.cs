using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Properties.Commands.Rogue;
using TkMemory.Integration.TkClient.Properties.Spells;
using TkMemory.Integration.TkClient.Properties.Status;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Rogue by reading the memory of the application.
    /// </summary>
    public class RogueClient : FighterClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Rogue.
        /// </summary>
        /// <param name="classMemory">The application memory for the Rogue's game client.</param>
        public RogueClient(ClassMemory classMemory) : base(classMemory)
        {
            Self.BasePath = BasePath.Rogue;
            Spells = new RogueSpells(classMemory);
            Status = new RogueStatus(this);
            Commands = new RogueCommands(this);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets commands that can be performed by the Rogue.
        /// </summary>
        public RogueCommands Commands { get; }

        /// <summary>
        /// Gets spells known to the Rogue.
        /// </summary>
        public RogueSpells Spells { get; }

        /// <summary>
        /// Gets the current status of the Rogue.
        /// </summary>
        public RogueStatus Status { get; }

        #endregion Properties
    }
}
