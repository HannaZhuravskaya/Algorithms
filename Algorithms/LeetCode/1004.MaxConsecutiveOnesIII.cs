using System;

namespace Algorithms.LeetCode
{
    public class MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            var start = 0;
            var max = 0;
            var cur = 0;

            while (cur != nums.Length)
            {
                if (nums[cur] == 1)
                {
                    cur++;
                    continue;
                }

                if (nums[cur] == 0)
                {
                    if (k > 0)
                    {
                        k--;
                        cur++;
                    }
                    else
                    {
                        max = Math.Max(max, cur - start);

                        if (nums[start] == 0)
                            k++;

                        start++;
                    }
                }
            }

            max = Math.Max(max, cur - start);

            return max;
        }
    }
}