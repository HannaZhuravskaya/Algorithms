using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class CountVowelsPermutation
    {
        public int CountVowelPermutation(int n)
        {
            var dp = new Dictionary<char, int[]>();

            var letters = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            foreach (var letter in letters)
            {
                dp.Add(letter, new int[n + 1]);
                dp[letter][1] = 1;
            }

            for (int i = 2; i <= n; ++i)
            {
                foreach (var letter in letters)
                {
                    var perm = dp[letter][i - 1];
                    var options = GetOptions(letter);

                    foreach (var option in options)
                    {
                        dp[option][i] = (dp[option][i] + perm) % 1000000007;
                    }
                }
            }

            var result = 0;

            foreach (var letter in letters)
            {
                result = (result + dp[letter][n]) % 1000000007;
            }

            return result;
        }

        private List<char> GetOptions(char prev)
        {
            return prev switch
            {
                'a' => new List<char>() { 'e' },
                'e' => new List<char>() { 'a', 'i' },
                'i' => new List<char>() { 'a', 'e', 'o', 'u' },
                'o' => new List<char>() { 'i', 'u' },
                'u' => new List<char>() { 'a' },
                _ => throw new InvalidOperationException()
            };
        }
    }
}