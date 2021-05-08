namespace Algorithms.LeetCode
{
    public class UniquePathsllTask
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var n = obstacleGrid.Length;
            var m = obstacleGrid[0].Length;

            if (obstacleGrid[n - 1][m - 1] == 1)
                return 0;

            var matrix = new int[n, m];

            matrix[0, 0] = 1;

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;

                    var left = j - 1 < 0 || obstacleGrid[i][j - 1] == 1 ? 0 : matrix[i, j - 1];
                    var right = i - 1 < 0 || obstacleGrid[i - 1][j] == 1 ? 0 : matrix[i - 1, j];
                    matrix[i, j] = left + right;
                }
            }

            return matrix[n - 1, m - 1];
        }
    }
}