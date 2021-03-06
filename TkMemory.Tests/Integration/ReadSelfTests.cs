﻿using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadSelfTests
    {
        [Test, Explicit]
        public void ReadSelf()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine("----------Self----------");
            Console.WriteLine($"Name = {tkMemory.Self.Name}");
            Console.WriteLine($"Uid = {tkMemory.Self.Uid}");
            Console.WriteLine($"Path = {tkMemory.Self.Path}");
            Console.WriteLine($"Level = {tkMemory.Self.Level}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Vita Current = {tkMemory.Self.Vita.Current:N0}");
            Console.WriteLine($"Vita Deficit = {tkMemory.Self.Vita.Deficit:N0}");
            Console.WriteLine($"Vita Max = {tkMemory.Self.Vita.Max:N0}");
            Console.WriteLine($"Vita Percent = {tkMemory.Self.Vita.Percent:P}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Mana Current = {tkMemory.Self.Mana.Current:N0}");
            Console.WriteLine($"Mana Deficit = {tkMemory.Self.Mana.Deficit:N0}");
            Console.WriteLine($"Mana Max = {tkMemory.Self.Mana.Max:N0}");
            Console.WriteLine($"Mana Percent = {tkMemory.Self.Mana.Percent:P}");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Gold = {tkMemory.Self.Gold:N0}");
            Console.WriteLine($"Exp = {tkMemory.Self.Exp:N0}");
        }
    }
}
