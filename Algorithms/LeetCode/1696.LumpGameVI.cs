using System;
using System.Collections.Generic;

#nullable disable

namespace Algorithms.LeetCode
{
    // https://leetcode.com/problems/jump-game-vi/discuss/?currentPage=1&orderBy=most_votes&query=
    public class JumpGameVI
    {
        public int MaxResult(int[] nums, int k)
        {
            var prevStairs = new LinkedList<int>();
            prevStairs.AddLast(0);

            for (int i = 1; i < nums.Length; ++i)
            {
                // Delete all steps except prev k steps
                while (i - prevStairs.First.Value > k)
                    prevStairs.RemoveFirst();

                nums[i] = nums[prevStairs.First.Value] + nums[i];

                while (prevStairs.Count > 0 && nums[prevStairs.Last.Value] <= nums[i])
                    prevStairs.RemoveLast();

                prevStairs.AddLast(i);
            }

            return nums[nums.Length - 1];
        }

        public int MaxResult_O_NK(int[] nums, int k)
        {
            var prevStairs = new LinkedList<int>();
            prevStairs.AddLast(0);

            for (int i = 1; i < nums.Length; ++i)
            {
                // Delete all steps except prev k steps
                while (i - prevStairs.First!.Value > k)
                    prevStairs.RemoveFirst();

                var bestStep = int.MinValue;

                foreach (var prevStair in prevStairs)
                {
                    bestStep = Math.Max(bestStep, nums[prevStair]);
                }

                nums[i] = bestStep + nums[i];

                prevStairs.AddLast(i);
            }

            return nums[nums.Length - 1];
        }
    }
}