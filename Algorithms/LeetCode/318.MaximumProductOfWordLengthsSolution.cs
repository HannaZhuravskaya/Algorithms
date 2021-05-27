using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class MaximumProductOfWordLengthsTask
    {
        public int MaxProduct(string[] words)
        {
            var wordsMask = new List<(int len, int mask)>();
            foreach (var word in words)
            {
                var arr = new byte[26];
                foreach (var letter in word)
                {
                    arr[letter - 'a'] = 1;
                }

                wordsMask.Add((word.Length, ConvertBitArrayToNumber(arr)));
            }

            var max = 0;

            for (int i = 0; i < wordsMask.Count - 1; ++i)
            {
                for (int j = i + 1; j < wordsMask.Count; ++j)
                {
                    if ((wordsMask[i].mask & wordsMask[j].mask) == 0)
                    {
                        max = Math.Max(max, wordsMask[i].len * wordsMask[j].len);
                    }
                }
            }

            return max;
        }

        private int ConvertBitArrayToNumber(byte[] arr)
        {
            int number = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                number <<= 1;
                number |= arr[i];
            }

            return number;
        }
    }
}