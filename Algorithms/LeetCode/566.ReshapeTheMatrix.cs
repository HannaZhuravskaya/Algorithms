namespace Algorithms.LeetCode
{
    public class ReshapeTheMatrix
    {
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            if (mat.Length == r && mat[0].Length == c)
                return mat;

            var n = mat.Length;
            var m = mat[0].Length;

            if (n * m != r * c)
                return mat;

            var res = new int[r][];

            for (int i = 0; i < r; ++i)
            {
                res[i] = new int[c];
            }

            for (int i = 0; i < n * m; ++i)
            {
                res[i / c][i % c] = mat[i / m][i % m];
            }

            return res;
        }
    }
}