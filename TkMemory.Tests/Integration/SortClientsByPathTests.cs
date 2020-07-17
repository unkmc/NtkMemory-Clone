using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class SortClientsByPathTests
    {
        [Test, Explicit]
        public void SortTkInstancesByPath()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);

            foreach (var mage in clients.Mages)
            {
                Console.WriteLine($"Mage: {mage.Self.Name}");
            }

            foreach (var poet in clients.Poets)
            {
                Console.WriteLine($"Poet: {poet.Self.Name}");
            }

            foreach (var rogue in clients.Rogues)
            {
                Console.WriteLine($"Rogue: {rogue.Self.Name}");
            }

            foreach (var warrior in clients.Warriors)
            {
                Console.WriteLine($"Warrior: {warrior.Self.Name}");
            }
        }
    }
}
