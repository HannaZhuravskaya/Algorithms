using System;
using System.Collections.Generic;

namespace Algorithms.Custom
{
    public class FindTheMostSafestPathTask
    {
        /*
            S E
            0 3
            0 -> 2, 1
            1 -> 2
            2 -> 3
            3 -> 1

            locked -> 1
        */

        public bool IsPathAvailable(int start, int end, List<List<int>> edges, HashSet<int> lockedCities)
        {
            if (start == end)
                return true;

            if (lockedCities.Contains(start) || lockedCities.Contains(end))
                return false;

            var stack = new Stack<int>();
            stack.Push(start);

            var visited = new bool[edges.Count];

            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                visited[cur] = true;

                foreach (var child in edges[cur])
                {
                    if (!lockedCities.Contains(child) && !visited[child])
                    {
                        if (child == end)
                            return true;

                        stack.Push(child);
                    }
                }
            }

            return false;
        }

        public int FindTheMostSafestPath(int start, int end, List<List<int>> edges, HashSet<int> lockedCities)
        {
            if (start == end)
                return 0;

            //Error: edges - List, use Count instead of Length 
            // var v = edges.Length;
            var v = edges.Count;

            var dist = new int[v];
            var visited = new bool[v];

            //Error: forgot create visited array

            for (int i = 0; i < v; ++i)
                //Error: int.MaxValue instead of int.Max
                // dist[i] = int.Max;
                dist[i] = int.MaxValue;

            dist[start] = 0;

            for (int j = 0; j < v - 1; ++j)
            {
                int u = MinDistance(dist, visited);

                visited[u] = true;

                //Error: foreach instead of for
                // for(var w in edges[u])
                foreach (var w in edges[u])
                {
                    if (dist[u] != int.MaxValue && !visited[w])
                    {
                        dist[w] = Math.Min(dist[w], dist[u] + (lockedCities.Contains(w) ? 1 : 0));
                    }
                }
            }

            return dist[end];
        }

        public int MinDistance(int[] dist, bool[] visited)
        {
            var min_i = -1;
            var min = int.MaxValue;

            for (int i = 0; i < dist.Length; ++i)
            {
                if (min >= dist[i] && !visited[i])
                {
                    min_i = i;
                    min = dist[i];
                }
            }

            return min_i;
        }

        #region Tests

        public static void Test()
        {
            var obj = new FindTheMostSafestPathTask();

            var start = 0;
            var end = 3;
            List<List<int>> edges = new List<List<int>>()
            {
                new List<int>(){2, 1},
                new List<int>(){2},
                new List<int>(){3},
                new List<int>(){1}
            };
            var lockedCities = new HashSet<int>() { 1 };

            obj.IsPathAvailable(start, end, edges, lockedCities);
            obj.FindTheMostSafestPath(start, end, edges, lockedCities);
        }

        #endregion
    }
}