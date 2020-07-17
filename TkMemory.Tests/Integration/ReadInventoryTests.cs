using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadInventoryTests
    {
        [Test, Explicit]
        public void ReadInventory()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();
            tkMemory.Inventory.Update();
            Console.WriteLine(tkMemory.Inventory.ToString());
        }
    }
}
