using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadSpellsTests
    {
        [Test, Explicit]
        public void ReadSpells()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetWarrior();
            Console.WriteLine(tkMemory.Spells.ToString());
        }
    }
}
