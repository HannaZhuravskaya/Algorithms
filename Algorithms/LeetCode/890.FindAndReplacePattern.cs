using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class FindAndReplacePatternTask
    {
        public IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            var mathes = new List<string>();

            foreach (var word in words)
            {
                if (MathesPattern(word, pattern))
                    mathes.Add(word);
            }

            return mathes;
        }

        private bool MathesPattern(string word, string pattern)
        {
            var wordToPattern = new int?[26];
            var patternToWord = new int?[26];

            for (int i = 0; i < word.Length; ++i)
            {
                var wIndex = word[i] - 'a';
                var pIndex = pattern[i] - 'a';

                if (wordToPattern[wIndex] is null && patternToWord[pIndex] is null)
                {
                    wordToPattern[wIndex] = pIndex;
                    patternToWord[pIndex] = wIndex;
                }
                else if (wordToPattern[wIndex] != pIndex || patternToWord[pIndex] != wIndex)
                    return false;
            }

            return true;
        }
    }
}