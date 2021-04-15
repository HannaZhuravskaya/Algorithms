using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class DeepestLeavesSumTask
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            var height = FindTreeHeight(root);
            return FindSumOfLeaves(root, height);
        }

        private int FindTreeHeight(TreeNode root)
        {
            var stack = new Stack<(TreeNode, int)>();
            stack.Push((root, 1));
            var result = 1;
            while (stack.Count > 0)
            {
                var (cur, i) = stack.Pop();
                result = Math.Max(result, i);

                if (cur.left != null)
                    stack.Push((cur.left, i + 1));

                if (cur.right != null)
                    stack.Push((cur.right, i + 1));

            }

            return result;
        }

        private int FindSumOfLeaves(TreeNode root, int height)
        {
            var stack = new Stack<(TreeNode, int)>();
            stack.Push((root, 1));
            var sum = 0;
            while (stack.Count > 0)
            {
                var (cur, i) = stack.Pop();

                if (height == i)
                    sum += cur.val;

                if (cur.left != null)
                    stack.Push((cur.left, i + 1));

                if (cur.right != null)
                    stack.Push((cur.right, i + 1));

            }

            return sum;
        }


        public class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public static TreeNode CreateTree(int?[] array)
        {
            var root = new TreeNode(array[0]!.Value);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                if (i < array.Length && array[i] != null)
                {
                    cur.left = new TreeNode(array[i]!.Value);
                    queue.Enqueue(cur.left);
                }

                if (i + 1 < array.Length && array[i + 1] != null)
                {
                    cur.right = new TreeNode(array[i + 1]!.Value);
                    queue.Enqueue(cur.right);
                }

                i += 2;
            }

            return root;
        }
    }
}