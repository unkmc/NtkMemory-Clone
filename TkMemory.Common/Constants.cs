using System;
using System.IO;

namespace TkMemory.Application.Common
{
    public static class Constants
    {
        public const string AutoFollowExe = "AutoFollow";
        public const string MageExe = "Mage";
        public const string PoetExe = "Poet";
        public const string RogueExe = "Rogue";
        public const string WarriorExe = "Warrior";

        public static readonly string TkMemoryAppDataPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TkMemory");
    }
}
