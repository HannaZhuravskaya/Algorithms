using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class MinCostClimbingStairsTask
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            return FindMinCost(cost.Length, cost, new Dictionary<int, int>());
        }

        private int FindMinCost(int i, int[] cost, Dictionary<int, int> minCosts)
        {
            if (i <= 1)
                return 0;

            if (minCosts.ContainsKey(i))
                return minCosts[i];

            var oneStep = cost[i - 1] + FindMinCost(i - 1, cost, minCosts);
            var twoStep = cost[i - 2] + FindMinCost(i - 2, cost, minCosts);
            minCosts[i] = Math.Min(oneStep, twoStep);

            return minCosts[i];
        }
    }
}