using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class CountOfSmallerNumbersAfterSelf
    {
        public IList<int> CountSmaller(int[] nums)
        {
            var newNums = new List<(int val, int index)>();
            var result = new List<int>();

            for (int i = 0; i < nums.Length; ++i)
            {
                newNums.Add((nums[i], i));
                result.Add(0);
            }

            MergeSort(newNums, 0, nums.Length - 1, result);

            return result;
        }

        private void MergeSort(List<(int val, int index)> nums, int start, int end, List<int> result)
        {
            if (start >= end)
                return;

            var mid = (start + end) / 2;
            MergeSort(nums, start, mid, result);
            MergeSort(nums, mid + 1, end, result);

            var li = start;
            var ri = mid + 1;

            var merged = new List<(int val, int index)>();
            var cnt = 0;

            while (li < mid + 1 && ri <= end)
            {
                if (nums[li].val > nums[ri].val)
                {
                    ++cnt;
                    merged.Add(nums[ri++]);
                }
                else
                {
                    result[nums[li].index] += cnt;
                    merged.Add(nums[li++]);
                }
            }

            while (li < mid + 1)
            {
                result[nums[li].index] += cnt;
                merged.Add(nums[li++]);
            }

            while (ri <= end)
            {
                merged.Add(nums[ri++]);
            }

            for (int i = 0; i < merged.Count; ++i)
            {
                nums[start + i] = merged[i];
            }
        }
    }
}