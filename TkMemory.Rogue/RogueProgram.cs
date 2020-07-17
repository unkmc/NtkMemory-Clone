using CommandLine;
using System;
using System.Threading.Tasks;
using TkMemory.Application.Common;

namespace TkMemory.Rogue
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<RogueConfiguration>(args)
                .WithParsedAsync(async config =>
                {
                    try
                    {
                        var trainer = new RogueTrainer(config);
                        await trainer.AutoHunt();
                    }
                    catch (Exception ex)
                    {
                        TkTrainerFactory.Terminate(ex);
                    }
                });
        }
    }
}
