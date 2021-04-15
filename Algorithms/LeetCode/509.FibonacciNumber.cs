namespace Algorithms.LeetCode
{
    public class FibonacciNumberTask
    {
        public int Fib(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            int prev = 0, cur = 1, i = 1;
            while (i < n)
            {
                var temp = cur;
                cur += prev;
                prev = temp;
                ++i;
            }

            return cur;
        }
    }
}