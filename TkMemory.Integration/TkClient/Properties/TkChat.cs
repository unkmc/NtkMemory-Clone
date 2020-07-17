using AutoHotkey.Interop.ClassMemory;
using TkMemory.Integration.TkClient.Infrastructure;

namespace TkMemory.Integration.TkClient.Properties
{
    /// <summary>
    /// A collection of properties to describe the latest activity in the chat window.
    /// </summary>
    public class TkChat
    {
        #region Fields

        private readonly ClassMemory _classMemory;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a player's chat data.
        /// </summary>
        /// <param name="classMemory">The application memory for the player's game client.</param>
        public TkChat(ClassMemory classMemory)
        {
            _classMemory = classMemory;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The latest normal chat entry in the chat window. Blue spell text is also considered normal chat.
        /// </summary>
        public string ChatOrBlueSpell => _classMemory.ReadString(TkAddresses.Chat.ChatOrBlueSpell, Constants.DefaultEncoding);

        /// <summary>
        /// The latest Sage or whisper in the chat window.
        /// </summary>
        public string SageOrWhisper => _classMemory.ReadString(TkAddresses.Chat.SageOrWhisper, Constants.DefaultEncoding);

        #endregion Properties
    }
}
