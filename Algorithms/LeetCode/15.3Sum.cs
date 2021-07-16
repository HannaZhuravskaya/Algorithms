using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    public class Sum3
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();

            var sorted = nums.OrderBy(e => e).ToList();

            var res = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; ++i)
            {
                if (i > 0 && sorted[i] == sorted[i - 1])
                    continue;

                var l = i + 1;
                var r = nums.Length - 1;
                var sum = -sorted[i];

                while (l < r)
                {
                    if (sorted[l] + sorted[r] > sum) r--;
                    else if (sorted[l] + sorted[r] < sum) l++;
                    else
                    {
                        var temp = new List<int>() { sorted[i], sorted[l], sorted[r] };
                        res.Add(temp);

                        while (l < r && sorted[l] == sorted[l + 1]) l++;
                        while (l < r && sorted[r] == sorted[r - 1]) r--;
                        l++; r--;
                    }
                }
            }

            return res;
        }
    }
}