using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient
{
    /// <summary>
    /// Provides data about a TK client for a Rogue or Warrior by reading the memory of the application.
    /// </summary>
    public class FighterClient : TkClient
    {
        #region Constructors

        /// <summary>
        /// Initializes all game client data associated with a Rogue or Warrior.
        /// </summary>
        /// <param name="classMemory">The application memory for the Rogue's or Warrior's game client.</param>
        public FighterClient(ClassMemory classMemory) : base(classMemory) { }

        #endregion Constructors
    }
}
