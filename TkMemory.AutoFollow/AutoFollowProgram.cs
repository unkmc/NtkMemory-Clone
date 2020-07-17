using CommandLine;
using System;
using System.Threading.Tasks;
using TkMemory.Application.Common;

namespace TkMemory.AutoFollow
{
    internal class AutoFollowProgram
    {
        private static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<AutoFollowConfiguration>(args)
                .WithParsedAsync(async config =>
                {
                    try
                    {
                        var trainer = new AutoFollowTrainer(config);
                        await trainer.AutoFollow();
                    }
                    catch (Exception ex)
                    {
                        TkTrainerFactory.Terminate(ex);
                    }
                });
        }
    }
}
