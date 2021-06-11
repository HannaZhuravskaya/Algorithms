using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /**
    * Your MyCalendar object will be instantiated and called as such:
    * MyCalendar obj = new MyCalendar();
    * bool param_1 = obj.Book(start,end);
    */

    public class MyCalendar
    {
        private List<(int start, int end)> intervals = new List<(int, int)>();

        public bool Book(int start, int end)
        {
            for (int i = 0; i < intervals.Count; ++i)
            {
                if (!IsNotIntersect(start, end, intervals[i].start, intervals[i].end))
                    return false;
            }

            intervals.Add((start, end));
            return true;
        }

        private bool IsNotIntersect(int s1, int e1, int s2, int e2) =>
            s2 <= s1 && e2 <= s1 || s2 >= e1 || s1 <= s2 && e1 <= s2 || s1 >= e2;
    }
}