using CommandLine;

namespace TkMemory.AutoFollow
{
    internal class AutoFollowConfiguration
    {
        [Option('p', "process",
            Required = false,
            Default = "ClassicTK",
            HelpText = "The name of the TK client application.")]
        public string Process { get; set; }

        [Option('l', "leader",
            Required = true,
            HelpText = "The name of the character to follow.")]
        public string Leader { get; set; }

        [Option('d', "distance",
            Required = false,
            Default = 3,
            HelpText = "The maximum allowable number of spaces away from the leader before automatically moving in his/her direction.")]
        public uint Distance { get; set; }
    }
}
