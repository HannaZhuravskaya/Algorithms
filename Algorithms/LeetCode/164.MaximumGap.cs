using System;

namespace Algorithms.LeetCode
{
    // Bucket sort
    public class MaximumGapTask
    {
        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2)
                return 0;

            var n = nums.Length;
            var max = 0;
            var min = int.MaxValue;

            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > max)
                    max = nums[i];

                if (nums[i] < min)
                    min = nums[i];
            }

            int gap = (int)Math.Ceiling((double)(max - min) / (n - 1));

            var bucketMins = new int?[n - 1];
            var bucketMaxs = new int?[n - 1];

            for (int i = 0; i < n; ++i)
            {
                if (nums[i] == min || nums[i] == max)
                    continue;

                int bucketNum = (nums[i] - min) / gap;
                bucketMins[bucketNum] = bucketMins[bucketNum].HasValue ? Math.Min(nums[i], bucketMins[bucketNum]!.Value) : nums[i];
                bucketMaxs[bucketNum] = bucketMaxs[bucketNum].HasValue ? Math.Max(nums[i], bucketMaxs[bucketNum]!.Value) : nums[i];
            }

            var maxGap = int.MinValue;
            int prev = min;

            for (int i = 0; i < n - 1; ++i)
            {
                if (bucketMins[i] is null && bucketMaxs[i] is null)
                    continue;

                maxGap = Math.Max(maxGap, bucketMins[i]!.Value - prev);
                prev = bucketMaxs[i]!.Value;
            }

            maxGap = Math.Max(maxGap, max - prev);

            return maxGap;
        }
    }
}