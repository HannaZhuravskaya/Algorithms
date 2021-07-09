using System;

namespace Algorithms.LeetCode
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];

            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < dp.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }

                }
            }

            var res = 0;

            for (int i = 0; i < dp.Length; ++i)
            {
                res = Math.Max(dp[i], res);
            }

            return res;
        }
    }
}