using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class ThreeEqualPartsTask
    {
        public int[] ThreeEqualParts(int[] arr)
        {
            var cnt = 0;

            for (int j = 0; j < arr.Length; ++j)
            {
                if (arr[j] == 1)
                    ++cnt;
            }

            if (cnt == 0)
                return new int[] { 0, arr.Length - 1 };

            if (cnt % 3 != 0)
                return new int[] { -1, -1 };

            var used = cnt / 3;
            var num = new List<int>();

            for (int j = arr.Length - 1; j >= 0 && used > 0; --j)
            {
                num.Add(arr[j]);

                if (arr[j] == 1)
                    --used;
            }


            var i = 0;

            while (i < arr.Length && arr[i] != 1)
                ++i;

            if (i == arr.Length)
                return new int[] { -1, -1 };

            for (int j = num.Count - 1; j >= 0; --j)
            {
                if (arr[i] != num[j])
                    return new int[] { -1, -1 };

                ++i;
            }

            var first = i - 1;

            while (i < arr.Length && arr[i] != 1)
                ++i;

            if (i == arr.Length)
                return new int[] { -1, -1 };

            for (int j = num.Count - 1; j >= 0; --j)
            {
                if (arr[i] != num[j])
                    return new int[] { -1, -1 };

                ++i;
            }

            var second = i;

            return new int[] { first, second };
        }
    }
}