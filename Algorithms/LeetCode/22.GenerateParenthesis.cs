using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    public class GenerateParenthesisTask
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var results = new List<string>();
            Generate(n, n, new StringBuilder(), results);
            return results;
        }

        private void Generate(int lNum, int rNum, StringBuilder str, IList<string> results)
        {
            if (lNum == 0 && rNum == 0)
                results.Add(str.ToString());

            if (rNum > lNum)
            {
                var copy = new StringBuilder(str.ToString());
                copy.Append(')');
                Generate(lNum, rNum - 1, copy, results);

            }

            if (lNum > 0)
            {
                var copy = new StringBuilder(
                str.ToString());
                copy.Append('(');
                Generate(lNum - 1, rNum, copy, results);
            }
        }
    }
}