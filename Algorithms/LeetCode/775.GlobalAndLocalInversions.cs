using System;

namespace Algorithms.LeetCode
{

    // Local inversions = Global inversions
    // Local inversion - global inversion with step 1
    // Check that there is no global inversion with step greater than 1
    public class GlobalAndLocalInversionsTask
    {
        public bool IsIdealPermutation(int[] nums)
        {
            var max = 0;

            for (int i = 0; i < nums.Length - 2; ++i)
            {
                max = Math.Max(nums[i], max);

                if (max > nums[i + 2])
                    return false;
            }

            return true;
        }
    }
}