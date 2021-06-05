using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LeetCode
{
    public class OpenTheLockTask
    {
        public int OpenLock(string[] deadends, string target)
        {
            var queue = new Queue<string>();
            var deads = new HashSet<string>(deadends);
            var visited = new HashSet<string>();

            queue.Enqueue("0000");
            visited.Add("0000");
            int level = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                while (size > 0)
                {
                    String s = queue.Dequeue();
                    if (deads.Contains(s))
                    {
                        size--;
                        continue;
                    }

                    if (s == target)
                        return level;

                    GoToNeighbours(s, deads, visited, queue);

                    size--;
                }

                level++;
            }

            return -1;
        }

        private void GoToNeighbours(string s, HashSet<string> deads, HashSet<string> visited, Queue<string> queue)
        {
            var sb = new StringBuilder(s);
            for (int i = 0; i < 4; i++)
            {
                char c = sb[i];
                String s1 = sb.ToString(0, i) + (c == '9' ? 0 : c - '0' + 1) + sb.ToString(i + 1, 4 - i - 1);
                String s2 = sb.ToString(0, i) + (c == '0' ? 9 : c - '0' - 1) + sb.ToString(i + 1, 4 - i - 1);

                if (!visited.Contains(s1) && !deads.Contains(s1))
                {
                    queue.Enqueue(s1);
                    visited.Add(s1);
                }
                if (!visited.Contains(s2) && !deads.Contains(s2))
                {
                    queue.Enqueue(s2);
                    visited.Add(s2);
                }
            }
        }
    }
}