namespace Algorithms.LeetCode
{
    public class ReverseBitsTask
    {
        public uint reverseBits(uint n)
        {
            uint result = 0;
            int cnt = 32;
            while (cnt > 0)
            {
                var digit = n & 1;
                result |= digit;
                n = n >> 1;

                --cnt;

                if (cnt > 0)
                    result = result << 1;
            }

            return result;
        }
    }
}