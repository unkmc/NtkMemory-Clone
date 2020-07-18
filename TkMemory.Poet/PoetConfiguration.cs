using CommandLine;

namespace TkMemory.Poet
{
    internal class PoetConfiguration
    {
        [Option('p', "process",
            Required = true,
            HelpText = "The name of the TK client application.")]
        public string Process { get; set; }

        [Option('i', "interval",
            Required = true,
            HelpText = "The number of milliseconds to wait in between sending commands.")]
        public int CommandDelay { get; set; }

        [Option('n', "name",
            Required = false,
            HelpText = "The name of the Poet.")]
        public string Name { get; set; }

        [Option('h', "hardenBody",
            Required = true,
            HelpText = "Whether or not the Poet should constantly cast Harden Body.")]
        public bool? HardenBody { get; set; }
    }
}
