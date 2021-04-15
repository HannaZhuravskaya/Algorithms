using System.Collections.Generic;
using FluentAssertions;

namespace Algorithms.LeetCode
{
    public class SingleNumber2Task
    {
        public int SingleNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                    dict.Add(num, 1);
                else
                    dict[num] = dict[num] + 1;
            }

            foreach (var (key, cnt) in dict)
            {
                if (cnt == 1)
                    return key;
            }

            return default;
        }

        public static void Check()
        {
            var obj = new SingleNumber2Task();

            obj.SingleNumber(new int[] { 2, 2, 3, 2 }).Should().Be(3);
            obj.SingleNumber(new int[] { 0, 1, 0, 1, 0, 1, 99 }).Should().Be(99);
            obj.SingleNumber(new int[] { 1 }).Should().Be(1);
            obj.SingleNumber(new int[] { 1, 2, 3, 2, 2, 1, 1 }).Should().Be(3);
        }
    }
}