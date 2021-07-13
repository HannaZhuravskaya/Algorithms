using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t)
        {
            var dict = new Dictionary<char, char>();
            var tSet = new HashSet<char>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    if (tSet.Contains(t[i]))
                        return false;

                    tSet.Add(t[i]);
                    dict[s[i]] = t[i];
                }

                if (dict[s[i]] != t[i])
                    return false;
            }

            return true;
        }
    }
}