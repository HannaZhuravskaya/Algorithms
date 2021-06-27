namespace Algorithms.LeetCode
{
    public class OutOfBoundaryPaths
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            var dp = new int[m, n, maxMove + 1];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    for (int k = 0; k <= maxMove; ++k)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            return FindPaths(m, n, maxMove, startRow, startColumn, dp);
        }

        public int FindPaths(int m, int n, int moves, int i, int j, int[,,] dp)
        {
            if (i == m || j == n || i < 0 || j < 0)
                return 1;

            if (moves == 0)
                return 0;

            if (dp[i, j, moves] >= 0)
                return dp[i, j, moves];

            dp[i, j, moves] = ((FindPaths(m, n, moves - 1, i - 1, j, dp) + FindPaths(m, n, moves - 1, i + 1, j, dp)) % 1000000007 + (FindPaths(m, n, moves - 1, i, j - 1, dp) + FindPaths(m, n, moves - 1, i, j + 1, dp)) % 1000000007) % 1000000007;

            return dp[i, j, moves];
        }
    }
}