using System.Collections.Generic;
using System;

namespace Algorithms.LeetCode
{
    public class MaximumErasureValue
    {
        public int MaximumUniqueSubarray(int[] nums)
        {
            var dp = new int[nums.Length];
            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                dp[i] = dp[i - 1] + nums[i];
            }

            var usedNumbers = new Dictionary<int, int>();
            var max = 0;
            var startPos = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                if (!usedNumbers.ContainsKey(nums[i]) || usedNumbers[nums[i]] < startPos)
                {
                    if (i == nums.Length - 1)
                    {
                        var lastSum = dp[i] - (startPos - 1 < 0 ? 0 : dp[startPos - 1]);
                        max = Math.Max(lastSum, max);
                    }

                    usedNumbers[nums[i]] = i;
                    continue;
                }

                var sum = dp[i - 1] - (startPos - 1 < 0 ? 0 : dp[startPos - 1]);
                max = Math.Max(sum, max);

                startPos = usedNumbers[nums[i]] + 1;
                usedNumbers[nums[i]] = i;
            }

            return max;
        }
    }
}