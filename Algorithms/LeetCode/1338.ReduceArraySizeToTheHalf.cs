using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    public class ReduceArraySizeToTheHalf
    {
        public int MinSetSize(int[] arr)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; ++i)
            {
                dict[arr[i]] = !dict.ContainsKey(arr[i]) ? 1 : dict[arr[i]] + 1;
            }

            var coll = dict.OrderByDescending(el => el.Value);

            var cnt = 0;
            var res = 0;

            foreach (var el in coll)
            {
                res++;
                cnt += el.Value;

                if (cnt >= arr.Length / 2)
                    break;
            }

            return res;
        }
    }
}