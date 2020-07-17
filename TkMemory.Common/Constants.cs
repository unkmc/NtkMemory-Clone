using System;
using System.IO;

namespace TkMemory.Application.Common
{
    public static class Constants
    {
        public const string AutoFollow = "AutoFollow";
        public const string Mage = "Mage";
        public const string Poet = "Poet";
        public const string Rogue = "Rogue";
        public const string Warrior = "Warrior";

        public static readonly string FileSinkPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TkMemory");
    }
}
