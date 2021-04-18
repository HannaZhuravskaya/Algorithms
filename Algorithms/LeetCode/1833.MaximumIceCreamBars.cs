using System;

namespace Algorithms.LeetCode
{
    public class MaximumIceCreamBars
    {
        public int MaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);

            int cnt = 0;
            for (int i = 0; i < costs.Length; ++i)
            {
                if (coins - costs[i] < 0)
                    break;

                coins -= costs[i];
                ++cnt;
            }

            return cnt;
        }
    }
}