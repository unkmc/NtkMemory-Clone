using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class SendTests
    {
        [Explicit]
        [TestCase("{Esc}{v}{Home}{Esc}")]
        public void SendKeystrokes(string keystrokes)
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetPoet();
            tkMemory.Send(keystrokes);
            Console.WriteLine($"Sent keystrokes: \"{keystrokes}\"");
        }
    }
}
