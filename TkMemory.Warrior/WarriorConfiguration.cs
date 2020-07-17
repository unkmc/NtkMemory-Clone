using CommandLine;

namespace TkMemory.Warrior
{
    internal class WarriorConfiguration
    {
        [Option('p', "process",
            Required = true,
            HelpText = "The name of the TK client application.")]
        public string Process { get; set; }

        [Option('i', "interval",
            Required = true,
            HelpText = "The number of milliseconds to wait in between sending commands.")]
        public int CommandDelay { get; set; }

        [Option('m', "melee",
            Required = true,
            HelpText = "Whether or not the Warrior should automatically perform melee attacks.")]
        public bool? Attack { get; set; }

        [Option('b', "berserk",
            Required = true,
            HelpText = "Whether or not the Warrior should use Berserk during automated melee attacks.")]
        public bool? Berserk { get; set; }

        [Option('w', "whirlwind",
            Required = true,
            HelpText = "Whether or not the Warrior should use Whirlwind during automated melee attacks.")]
        public bool? Whirlwind { get; set; }
    }
}
