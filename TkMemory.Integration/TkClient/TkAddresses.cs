using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient {
    internal static class TkAddresses {
        private const string ProcessName = "NexusTK";

        public static class Chat {
            //public static readonly Address ChatOrBlueSpell = new Address(0x6FE788, new[] { 0x12C }); // VOld
            public static readonly Address ChatOrBlueSpell = new Address(ProcessName, 0x0029B9F8, new[] { 0x12C }); // V751

            //public static readonly Address SageOrWhisper = new Address(0x5C07D4, new[] { 0x174 }); // VOld
            public static readonly Address SageOrWhisper = new Address(ProcessName, 0x00040960, new[] { 0x1A4 }); // V751
        }

        public static class Environment {
            //public static readonly Address Time = new Address(0x6FE168, new[] { 0xF8 }); // VOld
            //public static readonly Address Time = new Address(0x69B408, new[] { 0xF8 }); // V751
            public static readonly Address Time = new Address(0x0029B418, new[] { 0xF8 }); // V752
            

            public static class Map {
                //public static readonly Address Name = new Address(0x6FE204, new[] { 0xF8 }); // VOld
                //public static readonly Address Name = new Address(ProcessName, 0x0029B4A4, new[] { 0xF8 }); // V751
                public static readonly Address Name = new Address(ProcessName, 0x0029B4B4, new[] { 0xF8 }); // V752

                public static class Coordinates {
                    //public static readonly Address X = new Address(0x6FE238, new[] { 0xFC }); // VOld
                    //public static readonly Address X = new Address(ProcessName, 0x0029BF2C, new[] { 0x104 }); // V751
                    public static readonly Address X = new Address(ProcessName, 0x0029BF3C, new[] { 0x104 }); // V752

                    //public static readonly Address Y = new Address(0x6FE238, new[] { 0x100 }); // VOld
                    //public static readonly Address Y = new Address(ProcessName, 0x0029BF2C, new[] { 0x108 }); // V751
                    public static readonly Address Y = new Address(ProcessName, 0x0029BF3C, new[] { 0x108 }); // V752
                }
            }
        }

        public static class Group {
            public const int PositionOffset = 0x12C; // VOld and V751

            //public static readonly Address Size = new Address(0x6DD490, new[] { 0x3CB0 }); // VOld
            //public static readonly Address Size = new Address(ProcessName, 0x0027A738, new[] { 0x3CB0 }); // V751
            public static readonly Address Size = new Address(ProcessName, 0x0027A748, new[] { 0x3CB0 }); // V752

            //public static readonly Address Name = new Address(0x6DD490, new[] { 0x21C }); // VOld
            //public static readonly Address Name = new Address(ProcessName, 0x0027A738, new[] { 0x21C }); // V751
            public static readonly Address Name = new Address(ProcessName, 0x0027A748, new[] { 0x21C }); // V752

            //public static readonly Address Uid = new Address(0x6DD490, new[] { 0x218 }); // VOld
            //public static readonly Address Uid = new Address(ProcessName, 0x0027A738, new[] { 0x218 }); // V751
            public static readonly Address Uid = new Address(ProcessName, 0x0027A748, new[] { 0x218 }); // V752

            public static class Mana {
                //public static readonly Address Current = new Address(0x6DD490, new[] { 0x340 }); // VOld
                //public static readonly Address Current = new Address(ProcessName, 0x0027A738, new[] { 0x340 }); // V751
                public static readonly Address Current = new Address(ProcessName, 0x0027A748, new[] { 0x340 }); // V752

                //public static readonly Address Max = new Address(0x6DD490, new[] { 0x33C }); // VOld
                //public static readonly Address Max = new Address(ProcessName, 0x0027A738, new[] { 0x33C }); // V751
                public static readonly Address Max = new Address(ProcessName, 0x0027A748, new[] { 0x33C }); // V752
            }

            public static class Vita {
                //public static readonly Address Current = new Address(0x6DD490, new[] { 0x338 }); // VOld
                //public static readonly Address Current = new Address(ProcessName, 0x0027A738, new[] { 0x338 }); // V751
                public static readonly Address Current = new Address(ProcessName, 0x0027A748, new[] { 0x338 }); // V752

                //public static readonly Address Max = new Address(0x6DD490, new[] { 0x334 }); // VOld
                //public static readonly Address Max = new Address(ProcessName, 0x0027A738, new[] { 0x334 }); // V751
                public static readonly Address Max = new Address(ProcessName, 0x0027A748, new[] { 0x334 }); // V752
            }
        }

        public static class Entity {
            public const int PositionOffset = 0x20C; // VOld and V751

            //public static readonly Address Count = new Address(0x6DD4AC, new[] { 0x424, 0x38, 0xC }); // VOld
            public static readonly Address Count = new Address(0x41A978, new[] { 0x310, 0x384, 0x20, 0x20, 0x64C }); // V751

            public static readonly Address Direction = new Address(0x6FE61C, new[] { 0x1C9 }); // VOld
            public static readonly Address Name = new Address(0x6FE61C, new[] { 0x12E }); // VOld

            //public static readonly Address Uid = new Address(0x6FE61C, new[] { 0x100 }); // VOld
            public static readonly Address Uid = new Address(0x6FE61C, new[] { 0xFC }); // V751

            public static class Coordinates {
                //public static readonly Address X = new Address(0x6FE61C, new[] { 0x104 }); // VOld
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x100 }); // V751

                //public static readonly Address Y = new Address(0x6FE61C, new[] { 0x108 }); // VOld
                public static readonly Address Y = new Address(ProcessName, 0x0027A754, new[] { 0x104 }); // V751
            }

            public static class Pixels {
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x10C }); // VOld
                public static readonly Address Y = new Address(0x6FE61C, new[] { 0x110 }); // VOld
            }
        }

        public static class Self {

            //public static readonly Address Exp = new Address(0x6FE238, new[] { 0x114 }); // VOld
            //public static readonly Address Exp = new Address(ProcessName, 0x0029B4D4, new[] { 0x114 }); // V751
            public static readonly Address Exp = new Address(ProcessName, 0x0029B4E4, new[] { 0x114 }); // V752

            //public static readonly Address Gold = new Address(0x6FE238, new[] { 0x11C }); // VOld
            //public static readonly Address Gold = new Address(ProcessName, 0x0029B4D4, new[] { 0x11C }); // V751
            public static readonly Address Gold = new Address(ProcessName, 0x0029B4E4, new[] { 0x11C }); // V752

            //public static readonly Address Legend = new Address(0x6DD5A8, new[] { 0x4, 0x104, 0x134, 0x10, 0x4 }); // VOld
            public static readonly Address Legend = new Address(ProcessName, 0x0027A864, new[] { 0x4, 0x104, 0x134, 0x10, 0x4 }); // V751

            //public static readonly Address Level = new Address(0x6FDB3C, new[] { 0x280 }); // VOld
            public static readonly Address Level = new Address(ProcessName, 0x0029ADFC, new[] { 0x280 }); // V751

            //public static readonly Address Name = new Address(0x6DD490, new[] { 0x12A }); // VOld
            //public static readonly Address Name = new Address(ProcessName, 0x0027A738, new[] { 0x12A }); // V751
            public static readonly Address Name = new Address(ProcessName, 0x0029BEE0); // V752

            //public static readonly Address NameAlt = new Address(0x6FEC70); // VOld
            //public static readonly Address NameAlt = new Address(ProcessName, 0x001A2AD4); // V751
            public static readonly Address NameAlt = new Address(ProcessName, 0x0029BEE0); // V752

            //public static readonly Address Partner = new Address(0x6DD5A8, new[] { 0x4, 0x1F38 }); // VOld
            public static readonly Address Partner = new Address(ProcessName, 0x0027A864, new[] { 0x4, 0x1F38 }); // V751

            //public static readonly Address Path = new Address(0x6FDB3C, new[] { 0x1FC }); // VOld
            //public static readonly Address Path = new Address(ProcessName, 0x0029ADFC, new[] { 0x1FC }); // V751
            public static readonly Address Path = new Address(ProcessName, 0x0029AE0C, new[] { 0x1FC }); // V752
            
            //public static readonly Address Uid = new Address(0x6DD490, new[] { 0xFC }); // VOld
            //public static readonly Address Uid = new Address(ProcessName, 0x0027A738, new[] { 0xFC }); // V751
            public static readonly Address Uid = new Address(ProcessName, 0x0027A748, new[] { 0xFC }); // V752

            public static class Inventory {
                public const int PositionOffset = 0x1FC; // VOld and V751

                //public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16410A }); // VOld
                //public static readonly Address DisplayName = new Address(ProcessName, 0x0027A738, new[] { 0x13410A }); // V751
                public static readonly Address DisplayName = new Address(ProcessName, 0x0027A748, new[] { 0x13410A }); // V751

                //public static readonly Address ItemName = new Address(0x6DD490, new[] { 0x1641AA }); // VOld
                //public static readonly Address ItemName = new Address(ProcessName, 0x0027A738, new[] { 0x1341AA }); // V751
                public static readonly Address ItemName = new Address(ProcessName, 0x0027A748, new[] { 0x1341AA }); // V751

                //public static readonly Address Quantity = new Address(0x6DD490, new[] { 0x1642EC }); // VOld
                //public static readonly Address Quantity = new Address(ProcessName, 0x0027A738, new[] { 0x1342EC }); // V751
                public static readonly Address Quantity = new Address(ProcessName, 0x0027A748, new[] { 0x1342EC }); // V751
            }

            public static class Mana {
                //public static readonly Address Current = new Address(0x6FE238, new[] { 0x10C }); // VOld
                //public static readonly Address Current = new Address(ProcessName, 0x0029B4D4, new[] { 0x10C }); // V751
                public static readonly Address Current = new Address(ProcessName, 0x0029B4E4, new[] { 0x10C }); // V752

                //public static readonly Address Max = new Address(0x6FE238, new[] { 0x110 }); // VOld
                //public static readonly Address Max = new Address(ProcessName, 0x0029B4D4, new[] { 0x110 }); // V751
                public static readonly Address Max = new Address(ProcessName, 0x0029B4E4, new[] { 0x110 }); // V752
            }

            public static class Spells {
                public const int PositionOffset = 0x148; // VOld and V751

                //public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16A83C }); // VOld
                //public static readonly Address DisplayName = new Address(ProcessName, 0x0027A738, new[] { 0x13A83C }); // V751
                public static readonly Address DisplayName = new Address(ProcessName, 0x0027A748, new[] { 0x13A83C }); // V751
            }

            public static class Status {
                //public static readonly Address ActiveEffects = new Address(0x4C1260, new[] { 0x4A4 }); // VOld
                //public static readonly Address ActiveEffects = new Address(ProcessName, 0x0003C050, new[] { 0xF0C }); // V751
                public static readonly Address ActiveEffects = new Address(ProcessName, 0x0004F6B0, new[] { 0xC }); // V752

                //public static readonly Address ActiveEffectsAlt = new Address(0x4278EC, new[] { 0xA4 }); // VOld
                //public static readonly Address[] PossibleActiveEffects = new[] {
                //    new Address(ProcessName, 0x000E0070, new[] { 0x790 }),
                //    new Address(ProcessName, 0x000380F0, new[] { 0x6B0 }),
                //    new Address(ProcessName, 0x00044554, new[] { 0x354 }),
                //    new Address(ProcessName, 0x0004F6B0, new[] { 0xFC }),
                //    new Address(ProcessName, 0x0003C050, new[] { 0xF0C }),
                //}; // V751
                public static readonly Address[] PossibleActiveEffects = new[] {
                    new Address(ProcessName, 0x00044554, new[] { 0x264 }),
                    new Address(ProcessName, 0x000380F0, new[] { 0x5C0 }),
                    new Address(ProcessName, 0x000E00F0, new[] { 0x790 }),
                    new Address(ProcessName, 0x0003C050, new[] { 0xE1C }),
                }; // V752

                //public static readonly Address LatestActivity = new Address(0x444724, new[] { 0x140 }); // VOld
                //public static readonly Address LatestActivity = new Address(ProcessName, 0x00037AF4, new[] { 0x190 }); // V751
                public static readonly Address LatestActivity = new Address(ProcessName, 0x00037AF4, new[] { 0x194 }); // V752

                //public static readonly Address LatestChange = new Address(0x6FE8C8, new[] { 0xC }); // VOld
                public static readonly Address LatestChange = new Address(0x69BB68, new[] { 0xC }); // V751
            }

            public static class TargetUids {
                //public static readonly Address AutoTarget = new Address(0x6FEC64); // VOld
                //public static readonly Address AutoTarget = new Address(ProcessName, 0x29BF1C); // V751
                public static readonly Address AutoTarget = new Address(ProcessName, 0x29BF2C); // V752

                //public static readonly Address IsTargetingSelf = new Address(0x6DD490, new[] { 0x1E8 }); // VOld
                //public static readonly Address IsTargetingSelf = new Address(ProcessName, 0x0027A738, new[] { 0x1E8 }); // V751
                public static readonly Address IsTargetingSelf = new Address(ProcessName, 0x0027A748, new[] { 0x1E8 }); // V752

                //public static readonly Address Item = new Address(0x6FEC5C); // VOld
                public static readonly Address Item = new Address(0x69BF14); // V751

                //public static readonly Address Spell = new Address(0x6FEC58); // VOld
                //public static readonly Address Spell = new Address(ProcessName, 0x29BF10); // V751
                public static readonly Address Spell = new Address(ProcessName, 0x29BF20); // V752

                //public static readonly Address TargetLock = new Address(0x6FEC60); // VOld
                //public static readonly Address TargetLock = new Address(ProcessName, 0x29BF18); // V751
                public static readonly Address TargetLock = new Address(ProcessName, 0x29BF28); // V752
            }

            public static class Vita {
                //public static readonly Address Current = new Address(0x6FE238, new[] { 0x104 }); // VOld
                //public static readonly Address Current = new Address(ProcessName, 0x0029B4D4, new[] { 0x104 }); // V751
                public static readonly Address Current = new Address(ProcessName, 0x0029B4E4, new[] { 0x104 }); // V752

                //public static readonly Address Max = new Address(0x6FE238, new[] { 0x108 }); // VOld
                //public static readonly Address Max = new Address(ProcessName, 0x0029B4D4, new[] { 0x108 }); // V751
                public static readonly Address Max = new Address(ProcessName, 0x0029B4E4, new[] { 0x108 }); // V752
            }
        }
    }
}
