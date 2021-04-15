using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class IsAlienSorted
    {
        public bool Check(string[] words, string order)
        {
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < order.Length; ++i)
            {
                dict.Add(order[i], i);
            }

            if (words.Length < 2)
                return true;

            var cnt = 0;
            while (cnt + 1 < words.Length)
            {
                if (Compare(words[cnt], words[cnt + 1], dict) > 0)
                    return false;
                ++cnt;
            }

            return true;
        }

        private int Compare(string s1, string s2, Dictionary<char, int> dict)
        {
            var len = Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < len; ++i)
            {
                var o1 = dict[s1[i]];
                var o2 = dict[s2[i]];

                if (o1 != o2)
                    return o1 - o2;
            }

            if (s1.Length != s2.Length)
                return s1.Length - s2.Length;

            return 0;
        }
    }
}