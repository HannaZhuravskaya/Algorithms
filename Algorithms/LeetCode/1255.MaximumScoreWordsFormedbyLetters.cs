
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Algorithms.LeetCode
{
    // Input: words = ["dog","cat","dad","good"], letters = ["a","a","c","d","d","d","g","o","o"], score = [1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0]
    // Output: 23
    // Explanation:
    // Score  a=1, c=9, d=5, g=3, o=2
    // Given letters, we can form the words "dad" (5+1+5) and "good" (3+2+2+5) with a score of 23.
    // Words "dad" and "dog" only get a score of 21.

    public class MaxScoreWordsTask
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            int[] lettersCount = new int[26];

            foreach (var letter in letters)
            {
                var index = letter - 'a';
                lettersCount[index] = lettersCount[index] + 1;
            }

            var wordsValues = new int[words.Length];
            var root = BuildTree(words, lettersCount, score, wordsValues);
            return FindMax(root, 0, wordsValues);
        }

        private bool TryAddWord(int[] lettersCount, int[] score, string word, int[] words, int wordIndex)
        {
            int value = 0;

            foreach (var letter in word)
            {
                var index = letter - 'a';
                if (lettersCount[index] == 0)
                    return false;

                lettersCount[index] = lettersCount[index] - 1;
                value += score[index];
            }

            words[wordIndex] = value;

            return true;
        }

        private TreeNode BuildTree(string[] words, int[] lettersCount, int[] score, int[] wordsValues)
        {
            var root = new TreeNode();

            var queue = new Queue<(TreeNode, int, int[])>();
            queue.Enqueue((root, 0, lettersCount));

            while (queue.Count > 0)
            {
                var (cur, index, letCount) = queue.Dequeue();

                var copy = new int[26];
                letCount.CopyTo(copy, 0);

                if (index >= words.Length)
                    continue;

                if (TryAddWord(copy, score, words[index], wordsValues, index))
                {
                    cur.left = new TreeNode(index);
                    queue.Enqueue((cur.left, index + 1, copy));
                    cur.right = new TreeNode();
                    queue.Enqueue((cur.right, index + 1, letCount));
                }
                else
                {
                    queue.Enqueue((cur, index + 1, letCount));
                }
            }

            return root;
        }

        private int FindMax(TreeNode? node, int max, int[] wordsValues)
        {
            if (node is null)
                return max;

            if (node.wordIndex != null)
                max += wordsValues[node.wordIndex.Value];

            var leftMax = FindMax(node.left, max, wordsValues);
            var rightMax = FindMax(node.right, max, wordsValues);
            return Math.Max(leftMax, rightMax);
        }

        private class TreeNode
        {
            public TreeNode? left;
            public TreeNode? right;
            public int? wordIndex;
            public TreeNode(int? wordIndex = null) => this.wordIndex = wordIndex;
        }

        public static void Check()
        {
            var obj = new MaxScoreWordsTask();

            var words = new List<string> { "dog", "cat", "dad", "good" };
            var letters = new List<char> { 'a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o' };
            var score = new List<int> { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            obj.MaxScoreWords(words.ToArray(), letters.ToArray(), score.ToArray()).Should().Be(23);
            // Words "dad" and "dog" only get a score of 21.

            words = new List<string> { "xxxz", "ax", "bx", "cx" };
            letters = new List<char> { 'z', 'a', 'b', 'c', 'x', 'x', 'x' };
            score = new List<int> { 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10 };
            obj.MaxScoreWords(words.ToArray(), letters.ToArray(), score.ToArray()).Should().Be(27);
            // Given letters, we can form the words "ax" (4+5), "bx" (4+5) and "cx" (4+5) with a score of 27.

            words = new List<string> { "leetcode" };
            letters = new List<char> { 'l', 'e', 't', 'c', 'o', 'd' };
            score = new List<int> { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            obj.MaxScoreWords(words.ToArray(), letters.ToArray(), score.ToArray()).Should().Be(0);
            // Letter "e" can only be used once.
        }
    }
}