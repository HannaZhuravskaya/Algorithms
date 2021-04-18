#nullable disable

namespace Algorithms.LeetCode
{
    public class RemoveNthNodeFromEndOfListTask
    {
        // Another way to handle head deleting is introduce new head and then return it next
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var cur = head;
            ListNode prev = null;

            var cnt = 0;
            while (cur != null)
            {
                if (cnt == n)
                    prev = head;

                if (cnt > n)
                    prev = prev.next;

                cur = cur.next;
                ++cnt;
            }

            if (prev != null)
                prev.next = prev?.next?.next;
            else
                head = head.next;

            return head;
        }


        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}