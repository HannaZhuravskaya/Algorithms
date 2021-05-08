using System;

namespace Algorithms.LeetCode
{
    public class FindFirstAndLastPositionOfElementInSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var range = new int[2] { -1, -1 };

            if (nums.Length > 0)
            {
                var result = BinaryRangeSearch(nums, 0, nums.Length - 1, target);

                if (result.min != null && result.max != null)
                {
                    range[0] = result.min!.Value;
                    range[1] = result.max!.Value;
                }
            }

            return range;
        }

        private (int? min, int? max) BinaryRangeSearch(int[] nums, int left, int right, int target)
        {
            if (left == right)
                return nums[left] == target ? (left, left) : ((int?)null, (int?)null);

            int? min, max;
            var mid = (left + right) / 2;

            if (nums[mid] > target)
            {
                (min, max) = BinaryRangeSearch(nums, left, mid, target);
            }
            else if (nums[mid] < target)
            {
                (min, max) = BinaryRangeSearch(nums, mid + 1, right, target);
            }
            else
            {
                min = max = mid;

                var newMin = BinaryRangeSearch(nums, left, mid, target).min;
                var newMax = BinaryRangeSearch(nums, mid + 1, right, target).max;

                min = min.HasValue
                        ? newMin.HasValue
                            ? Math.Min(min.Value, newMin.Value)
                            : min
                        : newMin;

                max = max.HasValue
                        ? newMax.HasValue
                            ? Math.Max(max.Value, newMax.Value)
                            : max
                        : newMax;
            }

            return (min, max);
        }
    }
}