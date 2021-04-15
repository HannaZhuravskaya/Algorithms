using System;

public class Solution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        var n = matrix.Length;
        var m = matrix[0].Length;
        var g = new Graph(n * m);

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                var num = VertexNum(i, j, m);

                if (j - 1 >= 0 && matrix[i][j - 1] > matrix[i][j])
                    g.AddEdge(num, VertexNum(i, j - 1, m));

                if (j + 1 < m && matrix[i][j + 1] > matrix[i][j])
                    g.AddEdge(num, VertexNum(i, j + 1, m));

                if (i - 1 >= 0 && matrix[i - 1][j] > matrix[i][j])
                    g.AddEdge(num, VertexNum(i - 1, j, m));

                if (i + 1 < n && matrix[i + 1][j] > matrix[i][j])
                    g.AddEdge(num, VertexNum(i + 1, j, m));
            }
        }

        return g.FindLongestPath();
    }

    private int VertexNum(int i, int j, int size) => (i * size) + j;

    private class AdjacencyNode
    {
        public AdjacencyNode(int destination)
        {
            Destination = destination;
        }

        public int Destination { get; }
        public AdjacencyNode? Next { get; set; }
    }

    private class Graph
    {
        private int _size;
        private AdjacencyNode?[] _vertexes;

        public Graph(int size)
        {
            _size = size;
            _vertexes = new AdjacencyNode[_size];
        }

        public void AddEdge(int vertexNum, int destination)
        {
            if (_vertexes[vertexNum] is null)
            {
                _vertexes[vertexNum] = new AdjacencyNode(destination);
            }
            else
            {
                var cur = _vertexes[vertexNum];
                while (cur!.Next != null)
                {
                    cur = cur.Next;
                }

                cur.Next = new AdjacencyNode(destination);
            }
        }

        public int FindLongestPath()
        {
            var dp = new int[_size];
            var visited = new bool[_size];

            for (int i = 0; i < _size; ++i)
            {
                if (!visited[i])
                    Dfs(visited, dp, i);
            }

            var result = dp[0];
            for (int i = 0; i < _size; ++i)
                result = Math.Max(result, dp[i]);

            return result + 1;
        }

        private void Dfs(bool[] visited, int[] dp, int nodeNum)
        {
            visited[nodeNum] = true;

            var cur = _vertexes[nodeNum];
            while (cur != null)
            {
                if (!visited[cur.Destination])
                    Dfs(visited, dp, cur.Destination);

                dp[nodeNum] = Math.Max(dp[nodeNum], dp[cur.Destination] + 1);
                cur = cur.Next;
            }
        }
    }
}