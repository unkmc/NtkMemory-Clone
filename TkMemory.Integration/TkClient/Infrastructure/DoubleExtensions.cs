using Serilog;

// ReSharper disable once InvertIf

namespace TkMemory.Integration.TkClient.Infrastructure
{
    internal static class DoubleExtensions
    {
        public static double EvaluateAsPercentage(this double value)
        {
            if (value >= 1 || value <= -1)
            {
                value /= 100;
            }

            if (value < 0)
            {
                Log.Warning($"Negative percentages are not allowed. {value:P2} was replaced with {0:P2}.");
                value = 0;
            }

            return value;
        }
    }
}
