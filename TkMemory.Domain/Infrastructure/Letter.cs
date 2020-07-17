using System;

namespace TkMemory.Domain.Infrastructure
{
    internal static class Letter
    {
        internal static string Parse(int index, int upperBound = 51)
        {
            return TryParse(index, out var result, upperBound)
                ? result
                : throw new Exception($"Failed to parse index '{index}' into a letter. Values must be between '0' and '51'.");
        }

        internal static bool TryParse(int index, out string result, int upperBound = 51)
        {
            if (upperBound < 0 || upperBound > 51)
            {
                throw new Exception($"Invalid letter parsing upper bound '{upperBound}'. Value must be between '0' and '51'.");
            }

            if (index < 0 || index > upperBound)
            {
                result = null;
                return false;
            }

            var letter = index < 26
                ? (char)(index + 97)
                : (char)(index + 39);

            result = letter.ToString();
            return true;
        }
    }
}
