using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class CountBinarySubstringsTask
    {
        public int CountBinarySubstrings(string s)
        {
            if (s.Length == 1)
                return 0;

            var list = new List<int>();
            var digit = s[0];
            var cnt = 1;
            for (int i = 1; i < s.Length; ++i)
            {
                if (s[i] == digit)
                {
                    cnt++;
                    continue;
                }

                list.Add(cnt);
                digit = s[i];
                cnt = 1;
            }

            list.Add(cnt);

            if (list.Count == 1)
                return 0;

            var result = 0;
            for (int i = 0; i < list.Count - 1; ++i)
            {
                result += Math.Min(list[i], list[i + 1]);
            }

            return result;
        }
    }
}