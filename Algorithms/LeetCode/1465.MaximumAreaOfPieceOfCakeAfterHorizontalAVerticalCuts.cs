using System;

namespace Algorithms.LeetCode
{
    public class MaximumAreaOfPieceOfCakeAfterHorizontalAVerticalCuts
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            long maxW = verticalCuts[0];
            for (int i = 1; i < verticalCuts.Length; ++i)
            {
                maxW = Math.Max(maxW, verticalCuts[i] - verticalCuts[i - 1]);
            }
            maxW = Math.Max(maxW, w - verticalCuts[verticalCuts.Length - 1]);

            long maxH = horizontalCuts[0];
            for (int i = 1; i < horizontalCuts.Length; ++i)
            {
                maxH = Math.Max(maxH, horizontalCuts[i] - horizontalCuts[i - 1]);
            }
            maxH = Math.Max(maxH, h - horizontalCuts[horizontalCuts.Length - 1]);

            return (int)((maxW * maxH) % 1000000007);
        }
    }
}