#nullable disable

namespace Algorithms.LeetCode
{
    public class NumberOfSubarraysWithBoundedMaximum
    {
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            int? prev = null;
            var cur = 0;
            var cnt = 0;

            while (cur < nums.Length)
            {
                if (nums[cur] <= right)
                {
                    prev ??= cur;
                }
                else if (prev.HasValue)
                {
                    cnt += FindNumOfSubarraysInSubarray(nums, prev.Value, cur - 1, left);
                    prev = null;
                }

                cur++;
            }

            if (nums[nums.Length - 1] <= right)
            {
                cnt += FindNumOfSubarraysInSubarray(nums, prev.Value, nums.Length - 1, left);
            }

            return cnt;
        }

        private int FindNumOfSubarraysInSubarray(int[] nums, int start, int end, int min)
        {
            if (start == end)
                return nums[start] >= min ? 1 : 0;

            var cnt = 0;

            for (int i = start; i <= end; ++i)
            {
                bool isGood = nums[i] >= min;

                if (isGood)
                {
                    cnt += end - i + 1;
                    continue;
                }

                for (int j = i + 1; j <= end; ++j)
                {
                    isGood = nums[j] >= min;

                    if (isGood)
                    {
                        cnt += end - j + 1;
                        break;
                    }
                }
            }

            return cnt;
        }
    }
}