using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadChatTests
    {
        [Test, Explicit]
        public void ReadChat()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine("----------Chat----------");
            Console.WriteLine($"Chat/Blue Spell = {tkMemory.Chat.ChatOrBlueSpell}");
            Console.WriteLine($"Sage/Whisper = {tkMemory.Chat.SageOrWhisper}");
        }
    }
}
