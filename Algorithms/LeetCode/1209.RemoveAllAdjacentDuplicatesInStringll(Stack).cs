using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    // O(s.Length) time and space
    public class RemoveAllAdjacentDuplicatesInStringllTask2
    {
        public string RemoveDuplicates(string s, int k)
        {
            var stack = new Stack<(char letter, int cnt)>();

            foreach (var letter in s)
            {
                if (!stack.TryPeek(out var pair) || pair.letter != letter)
                {
                    stack.Push((letter, 1));
                    continue;
                }

                pair = stack.Pop();
                pair.cnt = (pair.cnt + 1) % k;

                if (pair.cnt != 0)
                    stack.Push(pair);
            }

            // Stack to string
            var chars = new List<char>();
            foreach (var pair in stack)
            {
                for (int i = 0; i < pair.cnt; ++i)
                    chars.Add(pair.letter);
            }

            chars.Reverse();
            return string.Concat(chars);
        }
    }
}