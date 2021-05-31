using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    public class SearchSuggestionsSystem
    {
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var trieRoot = BuildTrie(products);

            var results = new List<IList<string>>();
            var sb = new StringBuilder();

            foreach (var letter in searchWord)
            {
                sb.Append(letter);
                results.Add(Search(trieRoot, sb.ToString(), 3));
            }

            return results;
        }

        private class TrieNode
        {
            public TrieNode?[] Children = new TrieNode[26];
            public bool IsWord = false;
            public string? Word = null;
        }

        private TrieNode BuildTrie(string[] words)
        {
            var root = new TrieNode();

            foreach (var word in words)
            {
                var cur = root;

                for (int i = 0; i < word.Length; ++i)
                {
                    if (cur!.Children[word[i] - 'a'] is null)
                    {
                        cur.Children[word[i] - 'a'] = new TrieNode();
                    }

                    cur = cur.Children[word[i] - 'a'];

                    if (i == word.Length - 1)
                    {
                        cur!.IsWord = true;
                        cur.Word = word;
                    }
                }
            }

            return root;
        }

        private IList<string> Search(TrieNode root, string prefix, int n)
        {
            var result = new List<string>();

            var cur = root;

            for (int i = 0; i < prefix.Length; ++i)
            {
                if (cur!.Children[prefix[i] - 'a'] is null)
                    return result;

                cur = cur.Children[prefix[i] - 'a'];
            }

            Dfs(cur, n, result);

            return result;
        }

        private void Dfs(TrieNode? cur, int n, List<string> words)
        {
            if (cur is null || words.Count == n)
                return;

            if (cur.IsWord)
                words.Add(cur!.Word!);

            foreach (var child in cur.Children)
            {
                if (child != null && words.Count < n)
                    Dfs(child, n, words);
            }
        }
    }
}