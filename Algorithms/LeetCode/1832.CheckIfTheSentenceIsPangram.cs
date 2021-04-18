using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class CheckIfTheSentenceIsPangram
    {
        public bool CheckIfPangram(string sentence)
        {
            var set = new HashSet<char>();

            foreach (var letter in sentence)
                set.Add(letter);

            return set.Count == 26;
        }
    }
}