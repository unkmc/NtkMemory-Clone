using CommandLine;

namespace TkMemory.Mage
{
    internal class MageConfiguration
    {
        [Option('p', "process",
            Required = true,
            HelpText = "The name of the TK client application.")]
        public string Process { get; set; }

        [Option('i', "interval",
            Required = true,
            HelpText = "The number of milliseconds to wait in between sending commands.")]
        public int CommandDelay { get; set; }

        [Option('h', "heal",
            Required = true,
            HelpText = "Whether or not the Mage should heal self and allies.")]
        public bool? Heal { get; set; }

        [Option('b', "blind",
            Required = true,
            HelpText = "Whether or not the Mage should blind enemies.")]
        public bool? Blind { get; set; }

        [Option('f', "freeze",
            Required = true,
            HelpText = "Whether or not the Mage should paralyze enemies.")]
        public bool? Paralyze { get; set; }

        [Option('v', "venom",
            Required = true,
            HelpText = "Whether or not the Mage should poison enemies.")]
        public bool? Venom { get; set; }

        [Option('c', "curse",
            Required = true,
            HelpText = "Whether or not the Mage should curse enemies.")]
        public bool? Vex { get; set; }

        [Option('z', "zap",
            Required = true,
            HelpText = "Whether or not the Mage should zap enemies.")]
        public bool? Zap { get; set; }
    }
}
