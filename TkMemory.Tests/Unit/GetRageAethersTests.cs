using NUnit.Framework;
using System;
using System.Linq;

// ReSharper disable StringLiteralTypo

namespace TkMemory.Tests.Unit
{
    [TestFixture]
    internal class GetRageAethersTests
    {
        private string _activeStatusEffects;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _activeStatusEffects = @"
Potence 123s
Greater Blessing  124 s
Chung Ryong's Rage   938s
Backstab34  s

 Flank   34s
------------------------------
Watchful Eye    4s

";
        }

        [Test]
        public void TestGetRageAethers()
        {
            var potence = GetRemainingAethers("Potence");
            var blessing = GetRemainingAethers("Greater Blessing");
            var rage = GetRemainingAethers("Chung Ryong's Rage");
            var backstab = GetRemainingAethers("Backstab");
            var flank = GetRemainingAethers("Flank");
            var watchfulEye = GetRemainingAethers("Watchful Eye");

            Console.WriteLine($"Potence: {potence}");
            Console.WriteLine($"Greater Blessing: {blessing}");
            Console.WriteLine($"Chung Ryong's Rage: {rage}");
            Console.WriteLine($"Backstab: {backstab}");
            Console.WriteLine($"Flank: {flank}");
            Console.WriteLine($"Watchful Eye: {watchfulEye}");

            Assert.That(potence == 123);
            Assert.That(blessing == 124);
            Assert.That(rage == 938);
            Assert.That(backstab == 34);
            Assert.That(flank == 34);
            Assert.That(watchfulEye == 4);
        }

        /// <summary>
        /// Admittedly a terrible way to test a private method, but this method should always be
        /// equivalent to RageStatus.GetRemainingAethers().
        /// </summary>
        private int GetRemainingAethers(string spellName)
        {
            var activeStatusEffects = _activeStatusEffects.Split(new[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var targetSpell = activeStatusEffects.FirstOrDefault(x => x.TrimStart().StartsWith(spellName));

            if (string.IsNullOrWhiteSpace(targetSpell))
            {
                return 0;
            }

            var remainingAethers = targetSpell
                .Replace(spellName, string.Empty)
                .Replace("s", string.Empty)
                .Trim();

            return Convert.ToInt32(remainingAethers);
        }
    }
}
