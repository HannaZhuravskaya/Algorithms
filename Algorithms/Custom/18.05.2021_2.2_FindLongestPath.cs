using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class FindLongestPathTask
    {
        public int FindLongestPath(bool[][] matrix)
        {
            var maxPath = 0;

            // Error: forgot j++ part
            // for (int j = 0; j < matrix[0].Length)
            for (int j = 0; j < matrix[0].Length; ++j)
            {
                //Error: () in wrong place
                // var visited = VisitAllPaths(0, j, matrix, new HashSet<(int, int)>)();
                var visited = VisitAllPaths(0, j, matrix, new HashSet<(int, int)>());
                maxPath = Math.Max(maxPath, visited.Count);
            }

            return maxPath;
        }

        public HashSet<(int, int)> VisitAllPaths(int i, int j, bool[][] matrix, HashSet<(int, int)> visited)
        {
            var curVisited = new HashSet<(int, int)>(visited);

            if (!matrix[i][j])
                // Error: return value
                // return;
                return curVisited;

            if (visited.Contains((i, j)))
            {
                return curVisited;
            }
            else
            {
                curVisited.Add((i, j));
            }

            // Error: Contains tuple -> forgot ()
            // if (matrix.Length - 1 == i && (curVisited.Contains((i, j - 1)) || j - 1 < 0) && (curVisited.Contains(i, j + 1) || j + 1 == matrix[0].Length))
            if (matrix.Length - 1 == i && (curVisited.Contains((i, j - 1)) || j - 1 < 0) && (curVisited.Contains((i, j + 1)) || j + 1 == matrix[0].Length))
                return curVisited;

            // Error: remove () and initialize
            //HashSet<(int, int)>() temp;
            HashSet<(int, int)> temp = new HashSet<(int, int)>();

            if (j - 1 >= 0)
                temp = VisitAllPaths(i, j - 1, matrix, curVisited);

            if (j + 1 < matrix[0].Length)
            {
                var t = VisitAllPaths(i, j + 1, matrix, curVisited);
                if (t.Count > temp.Count)
                    temp = t;
            }

            if (i < matrix.Length - 1)
            {
                var t = VisitAllPaths(i + 1, j, matrix, curVisited);
                if (t.Count > temp.Count)
                    temp = t;
            }

            return temp;
        }

        public static void Test()
        {
            var obj = new FindLongestPathTask();

            // [..]  result: 4
            // [..]
            var data = new bool[2][]{
               new bool[]{ true, true},
               new bool[]{ true, true}
               };

            obj.FindLongestPath(data);

            // #.#..# result: 9
            // #.#..#
            // #.##.#
            // #..#.#
            // #..#.#
            // #..#.#

            data = new bool[6][]{
               new bool[]{ false, true, false, true, true, false},
               new bool[]{ false, true, false, true, true, false},
               new bool[]{ false, true, false, false, true, false},
               new bool[]{ false, true, true, false, true, false},
               new bool[]{ false, true, true, false, true, false},
               new bool[]{ false, true, true, false, true, false},
            };

            obj.FindLongestPath(data);
        }
    }
}