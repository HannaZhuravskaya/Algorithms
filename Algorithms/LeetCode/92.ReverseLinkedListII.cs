#nullable disable

namespace Algorithms.LeetCode
{
    public class ReverseLinkedListII
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var cnt = 0;

            head = new ListNode(-1, head);
            var cur = head;


            while (cnt < left - 1)
            {
                cur = cur.next;
                ++cnt;
            }

            var next = ReverseFirstNElements(cur.next, right - left + 1);
            cur.next = next;

            return head.next;
        }

        private ListNode ReverseFirstNElements(ListNode head, int n)
        {
            var cur = head;

            ListNode prev = null;
            ListNode end = null;

            int cnt = 0;

            while (cnt < n)
            {
                prev = new ListNode(cur.val, prev);
                end ??= prev;
                cur = cur.next;
                ++cnt;
            }

            end.next = cur;

            return prev;
        }

        #region Definition for singly-linked list.

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

    #endregion
}