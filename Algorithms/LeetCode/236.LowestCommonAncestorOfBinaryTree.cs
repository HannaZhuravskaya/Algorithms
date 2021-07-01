using System;
using System.Collections.Generic;

#nullable disable

namespace Algorithms.LeetCode
{
    public class LowestCommonAncestorOfBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var path1 = new List<TreeNode>();
            FindPath(root, p, path1);

            var path2 = new List<TreeNode>();
            FindPath(root, q, path2);

            for (int i = Math.Min(path1.Count, path2.Count) - 1; i >= 0; --i)
            {
                if (path1[i].val == path2[i].val)
                    return path1[i];
            }

            throw new InvalidOperationException();
        }

        private bool FindPath(TreeNode cur, TreeNode target, List<TreeNode> path)
        {
            if (cur is null)
                return false;

            path.Add(cur);

            if (cur == target)
                return true;

            if (FindPath(cur.left, target, path))
                return true;

            if (FindPath(cur.right, target, path))
                return true;

            path.RemoveAt(path.Count - 1);

            return false;
        }

        #region Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        #endregion
    }
}