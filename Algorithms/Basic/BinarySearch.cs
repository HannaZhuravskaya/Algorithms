using System.Collections.Generic;

namespace Algorithms.Basic
{
    public static class BinarySearch
    {
        public static int FindIndex(List<int> array, int left, int right, int value)
        {
            if (left > right)
                return -1;

            var cur = (left + right) / 2;

            if (array[cur] == value)
                return cur;

            if (array[cur] > value)
                return FindIndex(array, left, cur - 1, value);

            return FindIndex(array, cur + 1, right, value);
        }

        // I can use while cycle with reassigning left and right variables (to avoid recursion)
    }
}