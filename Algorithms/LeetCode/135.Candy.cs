using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    public class CandyTask
    {
        public int Candy(int[] ratings)
        {
            var l = Enumerable.Repeat(1, ratings.Length).ToList();
            var r = Enumerable.Repeat(1, ratings.Length).ToList();

            for (int i = 1; i < ratings.Length; ++i)
            {
                if (ratings[i] > ratings[i - 1])
                    l[i] = l[i - 1] + 1;
            }

            for (int i = ratings.Length - 2; i >= 0; --i)
            {
                if (ratings[i] > ratings[i + 1])
                    l[i] = l[i + 1] + 1;
            }

            var sum = 0;

            for (int i = 0; i < ratings.Length; ++i)
            {
                sum += Math.Max(l[i], r[i]);
            }

            return sum;
        }
    }
}