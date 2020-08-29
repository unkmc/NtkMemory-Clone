using AutoHotkey.Interop.ClassMemory;

namespace TkMemory.Integration.TkClient {
    internal static class TkAddresses {
        public static class Chat {
            public static readonly Address ChatOrBlueSpell = new Address(0x6FE788, new[] { 0x12C }); // VOld
            public static readonly Address SageOrWhisper = new Address(0x5C07D4, new[] { 0x174 }); // VOld
        }

        public static class Environment {
            public static readonly Address Time = new Address(0x6FE168, new[] { 0xF8 }); // VOld

            public static class Map {
                //public static readonly Address Name = new Address(0x6FE204, new[] { 0xF8 }); // VOld
                public static readonly Address Name = new Address("NexusTK.exe", 0x0029B4A4, new[] { 0xF8 }); // V751

                public static class Coordinates {
                    //public static readonly Address X = new Address(0x6FE238, new[] { 0xFC }); // VOld
                    public static readonly Address X = new Address("NexusTK.exe", 0x0029BF2C, new[] { 0x104 }); // VOld
                    //public static readonly Address Y = new Address(0x6FE238, new[] { 0x100 }); // VOld
                    public static readonly Address Y = new Address("NexusTK.exe", 0x0029BF2C, new[] { 0x108 }); // VOld
                }
            }
        }

        public static class Group {
            //public const int PositionOffset = 0x12C; // VOld
            public const int PositionOffset = 0x12C; // V751

            //public static readonly Address Size = new Address(0x6DD490, new[] { 0x3CB0 }); // VOld
            public static readonly Address Size = new Address("NexusTK.exe", 0x0027A738, new[] { 0x3CB0 }); // V751
            //public static readonly Address Name = new Address(0x6DD490, new[] { 0x21C }); // VOld
            public static readonly Address Name = new Address("NexusTK.exe", 0x0027A738, new[] { 0x21C }); // V751
            //public static readonly Address Uid = new Address(0x6DD490, new[] { 0x218 }); // VOld
            public static readonly Address Uid = new Address("NexusTK.exe", 0x0027A738, new[] { 0x218 }); // V751

            public static class Mana {
                //public static readonly Address Current = new Address(0x6DD490, new[] { 0x340 }); // VOld
                public static readonly Address Current = new Address("NexusTK.exe", 0x0027A738, new[] { 0x340 }); // V751
                //public static readonly Address Max = new Address(0x6DD490, new[] { 0x33C }); // VOld
                public static readonly Address Max = new Address("NexusTK.exe", 0x0027A738, new[] { 0x33C }); // V751
            }

            public static class Vita {
                //public static readonly Address Current = new Address(0x6DD490, new[] { 0x338 }); // VOld
                public static readonly Address Current = new Address("NexusTK.exe", 0x0027A738, new[] { 0x338 }); // V751
                //public static readonly Address Max = new Address(0x6DD490, new[] { 0x334 }); // VOld
                public static readonly Address Max = new Address("NexusTK.exe", 0x0027A738, new[] { 0x334 }); // V751
            }
        }

        public static class Entity {
            public const int PositionOffset = 0x20C; // VOld

            public static readonly Address Count = new Address(0x6DD4AC, new[] { 0x424, 0x38, 0xC }); // VOld
            public static readonly Address Direction = new Address(0x6FE61C, new[] { 0x1C9 }); // VOld
            public static readonly Address Name = new Address(0x6FE61C, new[] { 0x12E }); // VOld
            //public static readonly Address Uid = new Address(0x6FE61C, new[] { 0x100 }); // VOld
            public static readonly Address Uid = new Address(0x6FE61C, new[] { 0xFC }); // V751

            public static class Coordinates {
                //public static readonly Address X = new Address(0x6FE61C, new[] { 0x104 }); // VOld
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x100 }); // V751
                //public static readonly Address Y = new Address(0x6FE61C, new[] { 0x108 }); // VOld
                public static readonly Address Y = new Address(0x6FE61C, new[] { 0x104 }); // V751
            }

            public static class Pixels {
                public static readonly Address X = new Address(0x6FE61C, new[] { 0x10C }); // VOld
                public static readonly Address Y = new Address(0x6FE61C, new[] { 0x110 }); // VOld
            }
        }

        public static class Self {
            //public static readonly Address Exp = new Address(0x6FE238, new[] { 0x114 }); // VOld
            public static readonly Address Exp = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x114 }); // V751
            //public static readonly Address Gold = new Address(0x6FE238, new[] { 0x11C }); // VOld
            public static readonly Address Gold = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x11C }); // V751
            public static readonly Address Legend = new Address(0x6DD5A8, new[] { 0x4, 0x104, 0x134, 0x10, 0x4 }); // VOld
            //public static readonly Address Level = new Address(0x6FDB3C, new[] { 0x280 }); // VOld
            public static readonly Address Level = new Address("NexusTK.exe", 0x0029ADFC, new[] { 0x280 }); // VOld
            //public static readonly Address Name = new Address(0x6DD490, new[] { 0x12A }); // VOld
            public static readonly Address Name = new Address("NexusTK.exe", 0x0027A738, new[] { 0x12A }); // VOld
            //public static readonly Address NameAlt = new Address(0x6FEC70); // VOld
            public static readonly Address NameAlt = new Address("NexusTK.exe", 0x001A2AD4); // V751
            public static readonly Address Partner = new Address(0x6DD5A8, new[] { 0x4, 0x1F38 }); // VOld
            //public static readonly Address Path = new Address(0x6FDB3C, new[] { 0x1FC }); // VOld
            public static readonly Address Path = new Address("NexusTK.exe", 0x0029ADFC, new[] { 0x1FC }); // V751

            //public static readonly Address Uid = new Address(0x6DD490, new[] { 0xFC }); // VOld
            public static readonly Address Uid = new Address("NexusTK.exe", 0x0027A738, new[] { 0xFC }); // V751

            public static class Inventory {
                public const int PositionOffset = 0x1FC; // VOld

                public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16410A }); // VOld
                public static readonly Address ItemName = new Address(0x6DD490, new[] { 0x1641AA }); // VOld
                public static readonly Address Quantity = new Address(0x6DD490, new[] { 0x1642EC }); // VOld
            }

            public static class Mana {
                //public static readonly Address Current = new Address(0x6FE238, new[] { 0x10C }); // VOld
                public static readonly Address Current = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x10C }); // V751
                //public static readonly Address Max = new Address(0x6FE238, new[] { 0x110 }); // VOld
                public static readonly Address Max = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x110 }); // V751
            }

            public static class Spells {
                public const int PositionOffset = 0x148; // VOld

                //public static readonly Address DisplayName = new Address(0x6DD490, new[] { 0x16A83C }); // VOld
                public static readonly Address DisplayName = new Address("NexusTK.exe", 0x0027A738, new[] { 0x13A83C }); // V751
            }

            public static class Status {
                public static readonly Address ActiveEffects = new Address(0x4C1260, new[] { 0x4A4 }); // VOld
                public static readonly Address ActiveEffectsAlt = new Address(0x4278EC, new[] { 0xA4 }); // VOld
                public static readonly Address LatestActivity = new Address(0x444724, new[] { 0x140 }); // VOld
                public static readonly Address LatestChange = new Address(0x6FE8C8, new[] { 0xC }); // VOld
            }

            public static class TargetUids {
                //public static readonly Address AutoTarget = new Address(0x6FEC64); // VOld
                public static readonly Address AutoTarget = new Address("NexusTK.exe", 0x29BF1C); // V751
                //public static readonly Address IsTargetingSelf = new Address(0x6DD490, new[] { 0x1E8 }); // VOld
                public static readonly Address IsTargetingSelf = new Address("NexusTK.exe", 0x0027A738, new[] { 0x1E8 }); // V751
                public static readonly Address Item = new Address(0x6FEC5C); // VOld
                //public static readonly Address Spell = new Address(0x6FEC58); // VOld
                public static readonly Address Spell = new Address("NexusTK.exe", 0x29BF10); // V751
                //public static readonly Address TargetLock = new Address(0x6FEC60); // VOld
                public static readonly Address TargetLock = new Address("NexusTK.exe", 0x29BF18); // V751
            }

            public static class Vita {
                //public static readonly Address Current = new Address(0x6FE238, new[] { 0x104 }); // VOld
                public static readonly Address Current = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x104 }); // V751
                //public static readonly Address Max = new Address(0x6FE238, new[] { 0x108 }); // VOld
                public static readonly Address Max = new Address("NexusTK.exe", 0x0029B4D4, new[] { 0x108 }); // V751
            }
        }
    }
}
