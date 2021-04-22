using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class BrickWallTask
    {
        public int LeastBricks(IList<IList<int>> wall)
        {
            var dict = new Dictionary<int, int>();
            var notIntersected = 0;
            foreach (var row in wall)
            {
                var width = 0;
                for (int i = 0; i < row.Count; ++i)
                {
                    width += row[i];

                    if (i == row.Count - 1)
                        continue;

                    if (!dict.TryGetValue(width, out var num))
                    {
                        dict.Add(width, 1);
                    }
                    else
                    {
                        dict[width] = num + 1;
                    }

                    notIntersected = Math.Max(notIntersected, dict[width]);
                }
            }

            return wall.Count - notIntersected;
        }
    }
}