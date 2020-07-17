using CommandLine;
using System;
using System.Threading.Tasks;
using TkMemory.Application.Common;

namespace TkMemory.Poet
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<PoetConfiguration>(args)
                .WithParsedAsync(async config =>
                {
                    try
                    {
                        var trainer = new PoetTrainer(config);
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
