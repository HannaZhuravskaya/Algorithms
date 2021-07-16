using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class Sum4
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length < 4)
                return new List<IList<int>>();

            Array.Sort(nums);

            var res = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 3; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length - 2; ++j)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;

                    var l = j + 1;
                    var r = nums.Length - 1;
                    var sum = target - nums[i] - nums[j];

                    while (l < r)
                    {
                        if (nums[l] + nums[r] < sum) ++l;
                        else if (nums[l] + nums[r] > sum) --r;
                        else
                        {
                            res.Add(new List<int>() { nums[i], nums[j], nums[l], nums[r] });
                            while (l < r && nums[l] == nums[l + 1]) ++l;
                            while (l < r && nums[r] == nums[r + -1]) --r;
                            ++l;
                            --r;
                        }
                    }
                }
            }

            return res;
        }
    }
}