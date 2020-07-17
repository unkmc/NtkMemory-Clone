using NUnit.Framework;
using System;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using TkMemory.Integration.TkClient;

namespace TkMemory.Tests.Integration
{
    internal class TargetingTests
    {
        [Explicit]
        [TestCase((uint)1561)]
        public async Task IsTargetOffScreen(uint uid)
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();

            var result = await tkMemory.IsTargetOffScreen(uid, tkMemory.Spells.KeySpells.Zap)
                ? "Target is off screen."
                : "Target is on screen.";

            Console.WriteLine(result);
        }

        [Test, Explicit]
        public async Task ReadNpcs()
        {
            var clients = new ActiveClients(ConfigurationManager.AppSettings["ProcessName"]);
            var tkMemory = clients.GetMage();
            await tkMemory.UpdateNpcs(tkMemory.Spells.KeySpells.Zap);

            var sb = new StringBuilder();
            sb.AppendLine("NPC UIDs:");
            foreach (var npc in tkMemory.Npcs)
            {
                sb.AppendLine(npc.Uid.ToString());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
