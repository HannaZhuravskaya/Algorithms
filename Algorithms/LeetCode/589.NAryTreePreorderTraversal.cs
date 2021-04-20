using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class NAryTreePreorderTraversalTask
    {
        public IList<int> Preorder(Node root)
        {
            if (root is null)
                return new List<int>();

            var list = new List<int>();
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var cur = stack.Pop();
                list.Add(cur.val);

                for (int i = cur.children.Count - 1; i >= 0; --i)
                    stack.Push(cur.children[i]);
            }

            return list;
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> children = new List<Node>();
        public Node(int _val) => val = _val;
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}