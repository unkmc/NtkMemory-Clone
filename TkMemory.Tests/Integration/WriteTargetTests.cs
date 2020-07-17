using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class WriteTargetsTests
    {
        [Test, Explicit]
        public void WriteSpellTarget()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            tkMemory.Targeting.Spell = 12211;
            Assert.AreEqual(tkMemory.Targeting.Spell, 12211);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.Spell}");

            tkMemory.Targeting.Spell = 831791;
            Assert.AreEqual(tkMemory.Targeting.Spell, 831791);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.Spell}");
        }

        [Test, Explicit]
        public void WriteTabTarget()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            tkMemory.Targeting.AutoTarget = 12211;
            Assert.AreEqual(tkMemory.Targeting.AutoTarget, 12211);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.AutoTarget}");

            tkMemory.Targeting.AutoTarget = 831791;
            Assert.AreEqual(tkMemory.Targeting.AutoTarget, 831791);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.AutoTarget}");
        }

        [Test, Explicit]
        public void WriteVTarget()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            tkMemory.Targeting.TargetLock = 12211;
            Assert.AreEqual(tkMemory.Targeting.TargetLock, 12211);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.TargetLock}");

            tkMemory.Targeting.TargetLock = 831791;
            Assert.AreEqual(tkMemory.Targeting.TargetLock, 831791);
            Console.WriteLine($"TargetUidSpell = {tkMemory.Targeting.TargetLock}");
        }
    }
}
