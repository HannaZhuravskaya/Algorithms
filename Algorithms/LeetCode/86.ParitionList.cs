#nullable disable

namespace Algorithms.LeetCode
{
    public class PartitionListTask
    {
        public ListNode Partition(ListNode head, int x)
        {
            if (head is null || head.next is null)
                return head;

            ListNode lStart = null;
            ListNode lCur = null;

            ListNode gStart = null;
            ListNode gCur = null;

            var cur = head;
            while (cur != null)
            {
                var newNode = new ListNode(cur.val);

                if (cur.val >= x)
                {
                    if (gStart is null)
                        gStart = newNode;
                    else
                        gCur.next = newNode;

                    gCur = newNode;
                }
                else
                {
                    if (lStart is null)
                        lStart = newNode;
                    else
                        lCur.next = newNode;

                    lCur = newNode;
                }

                cur = cur.next;
            }

            if (lStart != null)
                lCur.next = gStart;
            else
                lStart = gStart;

            return lStart;
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

        /* Another accepted submission
        public ListNode Partition(ListNode head, int x) {
        ListNode lStart = new ListNode(int.MinValue);
        ListNode lCur = lStart;
        
        ListNode gStart = new ListNode(int.MinValue);
        ListNode gCur = gStart;
        
        var cur = head;
        while(cur != null)
        {
            if(cur.val >= x)
            {
                gCur.next = cur; 
                gCur = cur;
            }
            else
            {
                lCur.next = cur;
                lCur = cur;
            }
            
            cur = cur.next;
        }
        
        
        lCur.next = gStart.next;
        gCur.next = null;
        
        return lStart.next;
        }
        */
    }
}