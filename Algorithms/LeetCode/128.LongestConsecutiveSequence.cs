using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;

            var set = new HashSet<int>(nums);
            var maxLen = 0;

            foreach (var num in nums)
            {
                if (set.Contains(num - 1))
                    continue;

                var curLen = 1;
                var curNum = num + 1;
                while (set.Contains(curNum))
                {
                    curNum++;
                    curLen++;
                }

                maxLen = Math.Max(maxLen, curLen);
            }

            return maxLen;
        }
    }
}