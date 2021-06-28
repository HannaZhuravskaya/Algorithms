using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class RemoveAllAdjacentDuplicatesInString
    {
        public string RemoveDuplicates(string s)
        {
            var st = new Stack<char>();

            for (int i = 0; i < s.Length; ++i)
            {
                if (st.Count == 0)
                {
                    st.Push(s[i]);
                    continue;
                }

                var prev = st.Pop();

                if (prev == s[i])
                    continue;

                st.Push(prev);
                st.Push(s[i]);
            }

            var rev = new Stack<char>();

            while (st.Count > 0)
                rev.Push(st.Pop());

            return string.Join("", rev);
        }
    }
}