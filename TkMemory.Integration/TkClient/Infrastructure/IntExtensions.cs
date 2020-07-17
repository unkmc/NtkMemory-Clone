using System.Linq;

namespace TkMemory.Integration.TkClient.Infrastructure
{
    internal static class IntExtensions
    {
        public static int[] AddPositionOffset(this int[] offsets, int position, int positionFactor)
        {
            var positionOffset = position * positionFactor;
            return offsets.Select(offset => offset + positionOffset).ToArray();
        }
    }
}
