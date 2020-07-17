using CommandLine;
using System;
using System.Threading.Tasks;
using TkMemory.Application.Common;

namespace TkMemory.Mage
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<MageConfiguration>(args)
                .WithParsedAsync(async config =>
                {
                    try
                    {
                        var trainer = new MageTrainer(config);
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
