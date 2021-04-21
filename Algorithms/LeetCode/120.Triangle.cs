using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class TriangleTask
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1)
                return triangle[0][0];

            var min = int.MaxValue;
            for (int i = 1; i < triangle.Count; ++i)
            {
                for (int j = 0; j < triangle[i].Count; ++j)
                {
                    var left = j == 0 ? int.MaxValue : triangle[i - 1][j - 1] + triangle[i][j];
                    var right = j == triangle[i].Count - 1 ? int.MaxValue : triangle[i - 1][j] + triangle[i][j];
                    triangle[i][j] = Math.Min(left, right);

                    if (i == triangle.Count - 1)
                        min = Math.Min(min, triangle[i][j]);
                }
            }

            return min;
        }
    }
}