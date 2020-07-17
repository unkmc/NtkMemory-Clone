using CommandLine;

namespace TkMemory.Rogue
{
    internal class RogueConfiguration
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
            HelpText = "Whether or not the Rogue should automatically perform melee attacks.")]
        public bool? Attack { get; set; }

        [Option('a', "ambush",
            Required = true,
            HelpText = "Whether or not the Rogue should used Ambush during automated melee attacks.")]
        public bool? Ambush { get; set; }

        [Option('d', "desperateAttack",
            Required = true,
            HelpText = "Whether or not the Rogue should use Desperate Attack during automated melee attacks.")]
        public bool? DesperateAttack { get; set; }

        [Option('l', "lethalStrike",
            Required = true,
            HelpText = "Whether or not the Rogue should use Lethal Strike during automated melee attacks.")]
        public bool? LethalStrike { get; set; }
    }
}
