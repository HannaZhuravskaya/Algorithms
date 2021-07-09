using System;

namespace Algorithms.LeetCode
{
    public class MaximumLengthOfRepeatedSubarray
    {
        public int FindLength(int[] nums1, int[] nums2)
        {
            var res = 0;

            var dp = new int[nums1.Length + 1][];

            for (int i = 0; i < nums1.Length + 1; ++i)
            {
                dp[i] = new int[nums2.Length + 1];
            }

            for (var i = nums1.Length - 1; i >= 0; --i)
            {
                for (var j = nums2.Length - 1; j >= 0; --j)
                {
                    if (nums1[i] == nums2[j])
                    {
                        dp[i][j] = dp[i + 1][j + 1] + 1;
                        res = Math.Max(dp[i][j], res);
                    }
                }
            }

            return res;
        }
    }
}