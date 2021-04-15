using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class SingleNumberTask
    {
        public int SingleNumber(int[] nums)
        {
            var set = new HashSet<int>();

            foreach (var num in nums)
            {
                if (set.Contains(num))
                    set.Remove(num);
                else
                    set.Add(num);
            }

            var result = new int[1];
            set.CopyTo(result);

            return result[0];
        }
    }
}