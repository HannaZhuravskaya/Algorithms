using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class NumberOfMatchingSubsequencesTask
    {
        public int NumMatchingSubseq(string s, string[] words)
        {
            var dict = new Dictionary<char, Queue<string>>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                dict[i] = new Queue<string>();
            }

            for (int i = 0; i < words.Length; ++i)
            {
                dict[words[i][0]].Enqueue(words[i]);
            }

            var cnt = 0;

            foreach (var letter in s)
            {
                if (!dict.ContainsKey(letter))
                    continue;

                var queue = dict[letter];
                var size = queue.Count;

                for (int i = 0; i < size; ++i)
                {
                    var w = queue.Dequeue();

                    if (w.Length == 1)
                        cnt++;
                    else
                        dict[w[1]].Enqueue(w.Substring(1));
                }
            }

            return cnt;
        }
    }
}