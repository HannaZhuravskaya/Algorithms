using System;

namespace Algorithms.Basic
{
    public class DijkstraMatrix
    {
        public int[] Dijkstra(int[][] g, int source)
        {
            var dist = new int[g.Length];
            for (int i = 0; i < g.Length; ++i)
                dist[i] = int.MaxValue;

            dist[source] = 0;

            var visited = new bool[g.Length];

            for (int i = 0; i < g.Length - 1; ++i)
            {
                var v = MinDistance(dist, visited);

                visited[v] = true;

                for (int u = 0; u < g.Length; ++u)
                {
                    if (!visited[u] && g[v][u] != 0 && dist[v] != int.MaxValue)
                        dist[u] = Math.Min(dist[v] + g[v][u], dist[u]);
                }
            }

            return dist;
        }

        private int MinDistance(int[] dist, bool[] visited)
        {
            var min = int.MaxValue;
            var min_i = -1;

            for (int i = 0; i < dist.Length; ++i)
            {
                if (visited[i])
                    continue;

                if (dist[i] <= min)
                {
                    min = dist[i];
                    min_i = i;
                }
            }

            return min_i;
        }
    }
}