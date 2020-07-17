using NUnit.Framework;
using System;
using System.Configuration;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    [TestFixture]
    internal class ReadEnvironmentTests
    {
        [Test, Explicit]
        public void ReadEnvironment()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetRogue();

            Console.WriteLine("----------Environment----------");
            Console.WriteLine($"MapCoordinateX = {tkMemory.Environment.Map.Coordinates.X}");
            Console.WriteLine($"MapCoordinateY = {tkMemory.Environment.Map.Coordinates.Y}");
            Console.WriteLine($"MapName = {tkMemory.Environment.Map.Name}");
            Console.WriteLine($"Time = {tkMemory.Environment.Time}");
        }
    }
}
