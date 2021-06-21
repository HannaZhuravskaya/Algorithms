using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    public class PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var rows = new List<IList<int>>();
            rows.Add(new List<int>() { 1 });

            for (int i = 1; i < numRows; ++i)
            {
                rows.Add(Enumerable.Repeat(1, i + 1).ToList());

                for (int j = 1; j < i; ++j)
                {
                    rows[i][j] = rows[i - 1][j - 1] + rows[i - 1][j];
                }
            }

            return rows;
        }
    }
}