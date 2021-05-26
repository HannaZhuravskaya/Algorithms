using System;

namespace Algorithms.LeetCode
{
    public class PartitioningIntoMinimumNumberOfDeciBinaryNumbersTask
    {
        public int MinPartitions(string n)
        {
            int maxDigit = 0;

            foreach (var digit in n)
            {
                maxDigit = Math.Max(maxDigit, digit - '0');
            }

            return maxDigit;
        }
    }
}