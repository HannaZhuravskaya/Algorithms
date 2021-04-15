using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    public class LetterCombinationsTask
    {
        private string?[] _chars = new string?[10] { null, null, "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrWhiteSpace(digits))
                return new List<string>();

            var root = CreateTree(digits);

            var queue = new Queue<(TreeNode, StringBuilder)>();
            queue.Enqueue((root, new StringBuilder()));
            IList<string> results = new List<string>();

            while (queue.Count > 0)
            {
                var (cur, sb) = queue.Dequeue();
                if (cur.Children.Count > 0)
                {
                    foreach (var child in cur.Children)
                        queue.Enqueue((child, new StringBuilder().Append(sb).Append(child.Value)));
                }
                else
                {
                    results.Add(sb.ToString());
                }
            }

            return results;
        }

        private TreeNode CreateTree(string digits)
        {
            var digit = digits[0] - '0';
            var root = new TreeNode();
            var queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root, 0));

            while (queue.Count > 0)
            {
                var (cur, index) = queue.Dequeue();
                if (index < digits.Length)
                {
                    digit = digits[index] - '0';

                    foreach (var character in _chars[digit]!)
                    {
                        var node = new TreeNode(character);
                        cur.Children.AddLast(node);
                        queue.Enqueue((node, index + 1));
                    }
                }
            }

            return root;
        }

        private class TreeNode
        {
            public TreeNode(char? value = null)
            {
                Value = value;
                Children = new LinkedList<TreeNode>();
            }

            public char? Value;
            public LinkedList<TreeNode> Children { get; set; }
        }
    }
}