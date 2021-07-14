using System.Linq;

namespace Algorithms.LeetCode
{
    public class CustomSortStringTask
    {
        public string CustomSortString(string order, string str)
        {
            var dict = new int[26];

            for (int i = 0; i < 26; ++i)
                dict[i] = -1;

            for (int i = 0; i < order.Length; ++i)
                dict[order[i] - 'a'] = i;

            var cnt = order.Length;

            for (int i = 0; i < 26; ++i)
                if (dict[i] == -1)
                    dict[i] = cnt++;

            var arr = str.ToCharArray();

            var ordered = arr.OrderBy(o => dict[o - 'a']);

            return string.Join("", ordered);
        }
    }
}