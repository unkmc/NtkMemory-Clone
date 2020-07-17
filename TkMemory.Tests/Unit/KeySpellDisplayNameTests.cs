using NUnit.Framework;
using System;
using TkMemory.Domain.Spells;

// ReSharper disable StringLiteralTypo

namespace TkMemory.Tests.Unit
{
    [TestFixture]
    internal class KeySpellDisplayNameTests
    {
        [TestCase("Abritrary Unaligned Spell", "Abritrary unaligned spell", "Abritrary Unaligned Spell")]
        [TestCase("Call of the Wild", "Summon Legend", "Call of the Wild (Summon Legend)")]
        [TestCase("Call of the Wild", "Call of the Wild (Okapi)", "Call of the Wild (Okapi)")]
        [TestCase("Baekho's Cunning 1", "Baekho's Cunning", "Baekho's Cunning 1")]
        [TestCase("Dispel", "Dispell", "Dispel")]
        [TestCase("Chung Ryong's Rage 1", "Chung Ryong's Rage", "Chung Ryong's Rage 1")]
        public void TestDisplayName(string unalignedName, string alignedName, string expectedDisplayName)
        {
            var actualDisplayName = new KeySpell(unalignedName, alignedName, 0).DisplayName;

            Console.WriteLine($@"Actual: {actualDisplayName}");
            Console.WriteLine($@"Expect: {expectedDisplayName}");

            var result = actualDisplayName == expectedDisplayName;
            Console.WriteLine($@"Result: {result}");

            Assert.IsTrue(result);
        }
    }
}
