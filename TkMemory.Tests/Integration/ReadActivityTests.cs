using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadActivityTests
    {
        [Test, Explicit]
        public void ReadActivity()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetPoet();

            Console.WriteLine("----------Activity----------");
#pragma warning disable 612
            Console.WriteLine($"LatestActivity = {tkMemory.Activity.LatestActivity}");
            Console.WriteLine($"StatusLatestChange = {tkMemory.Activity.LatestStatusEffectChanged}");
#pragma warning restore 612
            Console.WriteLine($"StatusActiveEffects =\n{tkMemory.Activity.ActiveStatusEffects}");
        }
    }
}
