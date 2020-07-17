using CommandLine;
using System;
using System.Threading.Tasks;
using TkMemory.Application.Common;

namespace TkMemory.Warrior
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<WarriorConfiguration>(args)
                .WithParsedAsync(async config =>
                {
                    try
                    {
                        var trainer = new WarriorTrainer(config);
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
