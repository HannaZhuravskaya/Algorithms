#nullable disable

namespace Algorithms.LeetCode
{
    public class NumArray
    {
        private TreeNode _root;

        public NumArray(int[] nums)
        {
            _root = BuildTree(nums, 0, nums.Length - 1);
        }

        public void Update(int index, int val) => Update(_root, index, val);

        public int SumRange(int left, int right) => SumRange(_root, left, right);

        private TreeNode BuildTree(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            var node = new TreeNode()
            {
                Start = start,
                End = end
            };

            if (start == end)
            {
                node.Sum = nums[start];
            }
            else
            {
                var mid = (start + end) / 2;

                node.Left = BuildTree(nums, start, mid);
                node.Right = BuildTree(nums, mid + 1, end);
                node.Sum = node.Left.Sum + node.Right.Sum;
            }

            return node;
        }

        private void Update(TreeNode node, int index, int val)
        {
            if (node.Start == node.End)
            {
                node.Sum = val;
                return;
            }

            var mid = (node.Start + node.End) / 2;
            Update(index <= mid ? node.Left : node.Right, index, val);

            node.Sum = node.Left.Sum + node.Right.Sum;
        }

        private int SumRange(TreeNode node, int left, int right)
        {
            if (node.Start == left && node.End == right)
                return node.Sum;

            var mid = (node.Start + node.End) / 2;

            if (right <= mid)
            {
                return SumRange(node.Left, left, right);
            }
            else if (left >= mid + 1)
            {
                return SumRange(node.Right, left, right);
            }
            else
            {
                return SumRange(node.Left, left, mid) + SumRange(node.Right, mid + 1, right);
            }
        }

        private class TreeNode
        {
            public int Sum { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Start { get; set; }
            public int End { get; set; }
        }
    }
}