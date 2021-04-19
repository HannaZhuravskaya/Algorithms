using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class CombinationSumIVTask
    {
        public int CombinationSum4(int[] nums, int target)
        {
            return GetSum(target, nums, new Dictionary<int, int>());
        }

        public int GetSum(int n, int[] nums, Dictionary<int, int> cache)
        {
            if (n == 0)
                return 1;

            if (!cache.TryGetValue(n, out var value))
            {
                value = 0;
                foreach (var num in nums)
                {
                    if (n - num >= 0)
                    {
                        var result =  GetSum(n - num, nums, cache);
                        value += result;
                        cache.TryAdd(n-num, result);
                    }
                }
            }

            return value;
        }
    }
}