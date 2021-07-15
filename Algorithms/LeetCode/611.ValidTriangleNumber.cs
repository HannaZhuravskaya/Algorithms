using System;

namespace Algorithms.LeetCode
{
    public class ValidTriangleNumber
    {
        public int TriangleNumber(int[] nums)
        {
            var cnt = 0;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] == 0)
                    continue;

                int k = i + 2;
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    k = BinarySearch(nums, k, nums.Length - 1, nums[i] + nums[j]);
                    cnt += k - j - 1;
                }
            }

            return cnt;
        }

        private int BinarySearch(int[] nums, int l, int r, int x)
        {
            while (r >= l && r < nums.Length)
            {
                int mid = (l + r) / 2;

                if (nums[mid] >= x)
                    r = mid - 1;
                else
                    l = mid + 1;
            }

            return l;
        }
    }
}