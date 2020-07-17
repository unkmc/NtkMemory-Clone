using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadTargetsTests
    {
        [Test, Explicit]
        public void ReadTargets()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            Console.WriteLine("----------TargetUids----------");
            Console.WriteLine($"Auto-Target UID = {tkMemory.Targeting.AutoTarget}");
            Console.WriteLine($"Item/Orb Target UID = {tkMemory.Targeting.Item}");
            Console.WriteLine($"Spell Target UID = {tkMemory.Targeting.Spell}");
            Console.WriteLine($"Target Lock UID = {tkMemory.Targeting.TargetLock}");
        }
    }
}
