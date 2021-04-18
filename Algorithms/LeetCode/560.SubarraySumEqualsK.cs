using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    // Check different approaches
    // 1. O(n^3) time and O(1) space
    // 2. O(n^2) time and O(n) space
    // 3. O(n^2) time and O(1) space
    // 4. O(n) time and O(n) space
    public class SubarraySumEqualsK
    {
        // Approach #4: hashtable 
        public int SubarraySum(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            dict.Add(0, 1);

            var cnt = 0;
            var sum = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];

                if (dict.ContainsKey(sum - k))
                    cnt += dict[sum - k];

                if (dict.ContainsKey(sum))
                    dict[sum] = dict[sum] + 1;
                else
                    dict.Add(sum, 1);
            }

            return cnt;
        }
    }
}