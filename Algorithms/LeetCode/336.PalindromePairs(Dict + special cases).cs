using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    //TODO: Solve with Trie structure
    
    public class PalindromePairsTask
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
                dict.Add(words[i], i);

            var results = new List<IList<int>>();
            int index;

            if (dict.TryGetValue("", out  index))
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == index || !IsPalindrome(words[i]))
                        continue;

                    results.Add(new List<int>() { index, i });
                    results.Add(new List<int>() { i, index });
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                var reversed = ReverseString(words[i]);
                if (dict.TryGetValue(reversed, out  index) && index != i)
                {
                    results.Add(new List<int>() { i, index });
                }
            }

            for (int i = 0; i < words.Length; i++)
            {
                var curWord = words[i];
                for (int cut = 1; cut < curWord.Length; cut++)
                {
                    if (IsPalindrome(curWord.Substring(0, cut)))
                    {
                        var palindromePair = ReverseString(curWord.Substring(cut));
                        if (dict.TryGetValue(palindromePair, out int found) && found != i)
                        {
                            results.Add(new List<int>() { found, i });
                        }
                    }

                    if (IsPalindrome(curWord.Substring(cut)))
                    {
                        var palindromePair = ReverseString(curWord.Substring(0, cut));
                        if (dict.TryGetValue(palindromePair, out int found) && found != i)
                        {
                            results.Add(new List<int>() { i, found });
                        }
                    }
                }
            }

            return results;
        }

        public string ReverseString(string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public bool IsPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i <= j; ++i, --j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}