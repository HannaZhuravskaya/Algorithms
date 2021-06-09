using System.Collections.Generic;

#nullable disable

namespace Algorithms.LeetCode
{
    public class ConstructBinaryTreeFromPreorderAndInorderTraversal
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var rootIndexes = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; ++i)
                rootIndexes.Add(inorder[i], i);

            var preorderIndex = 0;
            return BuildTree(preorder, ref preorderIndex, 0, inorder.Length - 1, rootIndexes);
        }

        private TreeNode BuildTree(int[] preorder, ref int preorderIndex, int left, int right, Dictionary<int, int> rootIndexes)
        {
            if (left > right)
                return null;

            var rootValue = preorder[preorderIndex++];

            var rootIndex = rootIndexes[rootValue];

            var root = new TreeNode(rootValue);

            root.left = BuildTree(preorder, ref preorderIndex, left, rootIndex - 1, rootIndexes);
            root.right = BuildTree(preorder, ref preorderIndex, rootIndex + 1, right, rootIndexes);

            return root;
        }

        #region Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        #endregion
    }
}