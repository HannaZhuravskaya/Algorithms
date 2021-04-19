namespace Algorithms.LeetCode
{
    public class NumberOfSubmatricesThatSumToTargetTask
    {
        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            var sum = Create2DPrefixMatrix(matrix, m, n);

            var cnt = 0;
            for (int x1 = 0; x1 < n; ++x1)
            {
                for (int x2 = x1; x2 < n; ++x2)
                {
                    for (int y1 = 0; y1 < m; ++y1)
                    {
                        for (int y2 = y1; y2 < m; ++y2)
                        {
                            var rectSum = GetRectSum(sum, x1, x2, y1, y2);
                            if (rectSum == target)
                                ++cnt;
                        }
                    }
                }
            }

            return cnt;
        }

        //   x1-1,y1-1   ...    ...    x2,y1-1
        //   ...         x1y1   ...    ...
        //   y2,x1-1     ...    ...    x2y2
        private int GetRectSum(int[][] sum, int x1, int x2, int y1, int y2)
        {
            // Method isn't nessesary if matrix has additional zeros row and column.
            var result = sum[y2][x2];

            if (x1 - 1 >= 0)
                result -= sum[y2][x1 - 1];

            if (y1 - 1 >= 0)
                result -= sum[y1 - 1][x2];

            if (x1 - 1 >= 0 && y1 - 1 >= 0)
                result += sum[y1 - 1][x1 - 1];

            return result;
        }

        private int[][] Create2DPrefixMatrix(int[][] matrix, int m, int n)
        {
            // Next time create matrix [m+1][n+1] and fill matrix[0][j] and matrix[i][0] with 0. Use one for cycle to fil matrix.
            int[][] sum = new int[m][];

            for (int i = 0; i < m; ++i)
            {
                sum[i] = new int[n];
                sum[i][0] = i == 0 ? matrix[i][0] : sum[i - 1][0] + matrix[i][0];
            }

            for (int i = 0; i < n; ++i)
            {
                sum[0][i] = i == 0 ? matrix[0][i] : sum[0][i - 1] + matrix[0][i];
            }

            for (int i = 1; i < m; ++i)
            {
                for (int j = 1; j < n; ++j)
                {
                    sum[i][j] = matrix[i][j] + sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1];
                }
            }

            return sum;
        }
    }
}