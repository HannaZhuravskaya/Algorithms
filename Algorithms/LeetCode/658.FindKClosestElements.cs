using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    public class FindKClosestElements
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            var q = new LinkedList<int>();
            var i = Find(arr, 0, arr.Length - 1, x);

            var lD = i - 1 >= 0 ? Math.Abs(arr[i - 1] - x) : int.MaxValue;
            var cD = Math.Abs(arr[i] - x);
            var rD = i + 1 < arr.Length ? Math.Abs(arr[i + 1] - x) : int.MaxValue;

            var s = 0;
            var e = 0;

            if (lD < rD)
            {
                s = i - 1;
                e = i;
            }
            else
            {
                s = i;
                e = i + 1;
            }

            while (k > 0)
            {
                var sD = s >= 0 ? Math.Abs(arr[s] - x) : int.MaxValue;
                var eD = e < arr.Length ? Math.Abs(arr[e] - x) : int.MaxValue;

                if (sD > eD)
                {
                    q.AddLast(arr[e++]);
                }
                else if (sD < eD)
                {
                    q.AddFirst(arr[s--]);
                }
                else
                {
                    q.AddFirst(arr[s--]);
                }

                --k;
            }


            return q.ToList();
        }

        private int Find(int[] arr, int l, int r, int x)
        {
            if (l == r)
                return l;

            var m = (l + r) / 2;

            if (arr[m] < x)
                return Find(arr, m + 1, r, x);

            if (arr[m] > x)
                return Find(arr, l, m, x);

            return m;
        }
    }
}