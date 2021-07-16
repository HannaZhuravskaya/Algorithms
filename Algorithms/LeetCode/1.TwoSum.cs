using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class TwoSumTask
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                if (dict.ContainsKey(nums[i]))
                    return new int[2] { dict[nums[i]], i };

                dict[target - nums[i]] = i;
            }

            throw new InvalidOperationException();
        }
    }
}