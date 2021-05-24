using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Custom
{
    // By memory
    public class PrintFileSystemStructure
    {
        public void Print(string[] paths, IOutputProvider? outputProvider = null)
        {
            outputProvider ??= new ConsoleOutputProvider();
            var root = BuildTree(paths);
            PrintTree(root, outputProvider);
        }

        private TreeNode? BuildTree(string[] paths)
        {
            var root = new TreeNode();

            foreach (var path in paths)
            {
                var parts = path.Split('/');
                var cur = root;

                foreach (var part in parts)
                {
                    if (!cur.Children.ContainsKey(part))
                    {
                        cur.Children.Add(part, new TreeNode(part, cur.Depth + 1));
                    }

                    cur = cur.Children[part];
                }
            }

            return root;
        }

        private void PrintTree(TreeNode? root, IOutputProvider outputProvider)
        {
            if (root is null)
                return;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                foreach (var key in cur.Children.Keys)
                {
                    stack.Push(cur.Children[key]);
                }

                if (cur.Value != null)
                    outputProvider.AddLine($"{string.Concat(Enumerable.Repeat("\t", cur.Depth))}-- {cur.Value}");
            }
        }

        private class TreeNode
        {
            public string? Value;
            public int Depth;
            public Dictionary<string, TreeNode> Children = new();

            public TreeNode(string? value = null, int depth = 0)
            {
                Value = value;
                Depth = depth;
            }

        }

        public interface IOutputProvider
        {
            void AddLine(string? line);
        }

        public class ConsoleOutputProvider : IOutputProvider
        {
            public void AddLine(string? line) => Console.WriteLine(line);
        }

        public static void Test(){
            var obj = new PrintFileSystemStructure();
            var files = new string[]
            {
              "app/root",
              "folder/index.js",
              "app/components/newFolder",
              "app/root/root1"
            };

            var results = new List<string>();
            obj.Print(files, new ConsoleOutputProvider());
        }
    }
}