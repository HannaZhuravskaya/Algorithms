using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    // https://en.wikipedia.org/wiki/Gray_code

    public class GrayCodeTask
    {
        public IList<int> GrayCode(int n)
        {
            var result = new List<int>();
            var nums = 1 << n;

            for (int i = 0; i < nums; i++)
            {
                int num = i ^ i >> 1;
                result.Add(num);
            }

            return result;
        }
    }
}