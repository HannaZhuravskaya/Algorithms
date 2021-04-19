using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /*
    https://leetcode.com/problems/number-of-submatrices-that-sum-to-target/discuss/303750/JavaC%2B%2BPython-Find-the-Subarray-with-Target-Sum
    */
    public class NumberOfSubmatricesThatSumToTargetTask2
    {
        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            for (int i = 0; i < m; ++i)
                for (int j = 1; j < n; ++j)
                    matrix[i][j] += matrix[i][j - 1];

            var result = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i; j < n; ++j)
                {
                    var sum = 0;
                    var dict = new Dictionary<int, int>();
                    dict.Add(0, 1);

                    for (int k = 0; k < m; ++k)
                    {
                        sum += matrix[k][j] - (i > 0 ? matrix[k][i - 1] : 0);

                        if (dict.ContainsKey(sum - target))
                            result += dict[sum - target];

                        if (dict.TryGetValue(sum, out var value))
                            dict[sum] = value + 1;
                        else
                            dict.Add(sum, 1);
                    }
                }
            }

            return result;
        }
    }
}