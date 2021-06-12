using System;

namespace Algorithms.LeetCode
{
    public class MinimumNumberOfRefuelingStops
    {
        // Priority queue solution O(N logN): https://leetcode.com/problems/minimum-number-of-refueling-stops/solution/

        // DP solution O(N^2). 
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            if (stations.Length == 0)
                return startFuel >= target ? 0 : -1;

            var dp = new long[stations.Length + 1];
            dp[0] = startFuel;

            for (int i = 0; i < stations.Length; ++i)
            {
                for (int t = i; t >= 0; --t)
                {
                    if (dp[t] < stations[i][0])
                        continue;

                    dp[t + 1] = Math.Max(dp[t + 1], dp[t] + stations[i][1]);
                }
            }

            for (int i = 0; i < dp.Length; ++i)
            {
                if (dp[i] >= target)
                    return i;
            }

            return -1;
        }
    }
}