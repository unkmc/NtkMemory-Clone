// This file is part of TkMemory.

// TkMemory is free software. You can redistribute it and/or modify it
// under the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License or (at your
// option) any later version.

// TkMemory is distributed in the hope that it will be useful but WITHOUT
// ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License
// for more details.

// You should have received a copy of the GNU General Public License
// along with TkMemory. If not, please refer to:
// https://www.gnu.org/licenses/gpl-3.0.en.html

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
