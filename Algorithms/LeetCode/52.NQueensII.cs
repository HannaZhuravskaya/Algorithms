using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    // Not the best approach? The same as 51.NQueens but without field view.
    public class NQueensII
    {
        public int TotalNQueens(int n)
        {
            var result = 0;

            var cells = Enumerable.Range(0, n).ToDictionary(v => v, v => Enumerable.Range(0, n).ToHashSet());
            FindPermissions(cells, new List<(int, int)>(), n, ref result, new HashSet<(int, int)>());

            return result;
        }

        private void FindPermissions(Dictionary<int, HashSet<int>> cells, List<(int, int)> field, int n, ref int result, HashSet<(int, int)> used)
        {
            if (cells.Count == 0 && field.Count != n)
                return;

            if (field.Count == n)
            {
                result++;
                return;
            }

            foreach (var row in cells.Keys)
            {
                foreach (var col in cells[row])
                {
                    var copyField = new List<(int, int)>(field);
                    var copyCells = new Dictionary<int, HashSet<int>>();
                    var copyUsed = new HashSet<(int, int)>(used);

                    foreach (var rowKey in cells.Keys)
                    {
                        foreach (var colKey in cells[rowKey])
                        {
                            var rowDiff = Math.Abs(row - rowKey);
                            var colDiff = Math.Abs(col - colKey);
                            if (colKey != col && rowKey != row && rowDiff != colDiff && !used.Contains((rowKey, colKey)))
                            {
                                if (copyCells.ContainsKey(rowKey))
                                {
                                    copyCells[rowKey].Add(colKey);
                                }
                                else
                                {
                                    copyCells[rowKey] = new HashSet<int>() { colKey };
                                }
                            }
                        }
                    }


                    copyField.Add((row, col));

                    if (!used.Contains((row, col)))
                    {
                        copyUsed.Add((row, col));
                        FindPermissions(copyCells, copyField, n, ref result, copyUsed);
                        used.Add((row, col));
                    }
                }
            }
        }
    }
}