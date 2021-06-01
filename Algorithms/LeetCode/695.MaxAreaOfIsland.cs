using System;

namespace Algorithms.LeetCode
{
    public class MaxAreaOfIslandTask
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            var visited = new bool[n][];
            for (int i = 0; i < n; ++i)
                visited[i] = new bool[m];

            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (!visited[i][j] && grid[i][j] == 0)
                    {
                        visited[i][j] = true;
                    }

                    if (visited[i][j])
                    {
                        continue;
                    }

                    max = Math.Max(max, FindIsland(i, j, visited, grid));
                }
            }

            return max;
        }

        private int FindIsland(int i, int j, bool[][] visited, int[][] grid)
        {
            visited[i][j] = true;
            var res = 1;

            if (i - 1 >= 0 && !visited[i - 1][j] && grid[i - 1][j] == 1)
            {
                res += FindIsland(i - 1, j, visited, grid);
            }

            if (j - 1 >= 0 && !visited[i][j - 1] && grid[i][j - 1] == 1)
            {
                res += FindIsland(i, j - 1, visited, grid);
            }

            if (i + 1 < grid.Length && !visited[i + 1][j] && grid[i + 1][j] == 1)
            {
                res += FindIsland(i + 1, j, visited, grid);
            }

            if (j + 1 < grid[0].Length && !visited[i][j + 1] && grid[i][j + 1] == 1)
            {
                res += FindIsland(i, j + 1, visited, grid);
            }

            return res;
        }
    }
}