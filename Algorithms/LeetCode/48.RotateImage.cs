namespace Algorithms.LeetCode
{
    public class RotateImageTask
    {
        public void Rotate(int[][] matrix)
        {
            var n = matrix.Length;

            for (int i = 0; i < (n + 1) / 2; ++i)
            {
                int start = i, end = n - 1 - i;

                for (int step = 0; step < n - 2 * i - 1; ++step)
                {
                    var temp = matrix[start][start + step];

                    matrix[i][start + step] = matrix[end - step][start];
                    matrix[end - step][start] = matrix[end][end - step];
                    matrix[end][end - step] = matrix[start + step][end];
                    matrix[start + step][end] = temp;
                }
            }
        }
    }
}