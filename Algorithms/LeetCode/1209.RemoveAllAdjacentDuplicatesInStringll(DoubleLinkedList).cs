using System.Text;

#pragma warning disable 

namespace Algorithms.LeetCode
{
    public class RemoveAllAdjacentDuplicatesInStringllTask
    {
        public string RemoveDuplicates(string s, int k)
        {
            var root = BuildDoubleLinkedList(s);
            var cur = root.Next;

            while (cur != null)
            {
                if (cur.Count < k)
                {
                    cur = cur.Next;
                    continue;
                }


                if (cur.Count > k && cur.Count % k != 0)
                {
                    cur.Count = cur.Count % k;
                    cur = cur.Next;
                    continue;
                }



                cur = Node.DeleteNode(cur);

                if (cur.Next != null && cur.Next.Value == cur.Value)
                {
                    cur.Count = cur.Count + cur.Next.Count;
                    Node.DeleteNode(cur.Next);
                }
            }

            return ToString(root.Next);
        }

        private Node BuildDoubleLinkedList(string s)
        {
            var root = new Node('!', 0);
            var prev = root;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == prev.Value)
                {
                    prev.Count = prev.Count + 1;
                }
                else
                {
                    var newNode = new Node(s[i]);
                    prev.Next = newNode;
                    newNode.Prev = prev;
                    prev = newNode;
                }
            }

            return root;
        }

        private string ToString(Node? root)
        {
            var cur = root;
            var sb = new StringBuilder();

            while (cur != null)
            {
                for (int i = 0; i < cur.Count; ++i)
                    sb.Append(cur.Value);
                cur = cur.Next;
            }

            return sb.ToString();
        }

        private class Node
        {
            public char Value;
            public int Count;
            public Node? Next;
            public Node? Prev;

            public Node(char value, int count = 1)
            {
                Value = value;
                Count = count;
            }

            public static Node? DeleteNode(Node node)
            {
                if (node.Prev is null && node.Next is null)
                {
                    return null;
                }
                else if (node.Prev is null)
                {
                    node = node.Next;
                    node.Prev = null;
                    return node;
                }
                else if (node.Next is null)
                {
                    node = node.Prev;
                    node.Next = null;
                    return node;
                }
                else
                {
                    var temp = node.Prev;
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                    return temp;
                }
            }
        }
    }
}