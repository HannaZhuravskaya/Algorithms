using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    // Bad custom backtracking
    public class NQueensTask
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var results = new List<IList<string>>();

            var cells = Enumerable.Range(0, n).ToDictionary(v => v, v => Enumerable.Range(0, n).ToHashSet());
            FindPermissions(cells, new List<(int, int)>(), n, results, new HashSet<(int, int)>());

            return results;
        }

        private void FindPermissions(Dictionary<int, HashSet<int>> cells, List<(int, int)> field, int n, IList<IList<string>> results, HashSet<(int, int)> used)
        {
            if (cells.Count == 0 && field.Count != n)
                return;

            if (field.Count == n)
            {
                results.Add(GenerateField(field, n));
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
                        FindPermissions(copyCells, copyField, n, results, copyUsed);
                        used.Add((row, col));
                    }
                }
            }
        }


        private IList<string> GenerateField(List<(int, int)> field, int n)
        {
            var result = new List<string>();

            for (int i = 0; i < n; ++i)
            {
                result.Add(string.Empty);
            }

            foreach (var queen in field)
            {
                var row = Enumerable.Repeat('.', n).ToList();
                row[queen.Item2] = 'Q';
                result[queen.Item1] = string.Join("", row);
            }

            return result;
        }
    }
}