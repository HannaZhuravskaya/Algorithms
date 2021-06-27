using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class NumberOfMatchingSubsequences
    {
        public int NumMatchingSubseq(string s, string[] words)
        {
            var root = new TrieNode();
            for (int i = 0; i < words.Length; ++i)
            {
                AddWord(root, words[i], i);
            }

            var cnt = 0;
            IsWord(s, 0, root, ref cnt);

            return cnt;
        }

        private void IsWord(string s, int i, TrieNode prev, ref int cnt)
        {
            if (i >= s.Length)
                return;

            if (prev.Children.ContainsKey(s[i]))
            {
                var cur = prev.Children[s[i]];

                if (cur.Index.HasValue)
                    cnt++;

                IsWord(s, i + 1, cur, ref cnt);
            }

            IsWord(s, i + 1, prev, ref cnt);
        }

        private void AddWord(TrieNode root, string word, int index)
        {
            var cur = root;

            foreach (var letter in word)
            {
                if (!cur.Children.ContainsKey(letter))
                    cur.Children[letter] = new TrieNode();

                cur = cur.Children[letter];
            }

            cur.Index = index;
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
            public int? Index { get; set; }
        }
    }
}