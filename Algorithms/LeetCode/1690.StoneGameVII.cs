using System;

namespace Algorithms.LeetCode
{
    public class StoneGameVIITask
    {
        /* dpLast and dpCur - alternative for int[][] dp matrix. We do not need to keep all the table */
        public int StoneGameVII(int[] stones)
        {
            var len = stones.Length;

            var dpCurr = new int[len];
            var dpLast = new int[len];

            for (int i = len - 2; i >= 0; i--)
            {
                int sum = stones[i];
                var temp = dpLast;
                dpLast = dpCurr;
                dpCurr = temp;

                for (int j = i + 1; j < len; j++)
                {
                    sum += stones[j];
                    dpCurr[j] = Math.Max(sum - stones[i] - dpLast[j], sum - stones[j] - dpCurr[j - 1]);
                }
            }

            return dpCurr[len - 1];
        }
    }
}