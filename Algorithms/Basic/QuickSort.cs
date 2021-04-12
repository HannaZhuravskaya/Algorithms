using System.Collections.Generic;

namespace Algorithms.Algorithms
{
    /*
                    Algorithm	Time Complexity	     Space Complexity
                   Best	       Average	   Worst	    Worst
    Quicksort	Ω(n log(n))	Θ(n log(n))	 O(n^2)	      O(log(n))
    */

    public static class QuickSort
    {
        public static void Sort(List<int> array, int left, int right)
        {
            var pivot = Partition(array, left, right);

            if (left < pivot - 1)
                Sort(array, left, pivot - 1);

            if (pivot + 1 < right)
                Sort(array, pivot + 1, right);
        }

        private static void Swap(List<int> array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        private static int Partition(List<int> array, int left, int right)
        {
            var last = array[right];
            var lastLessElem = left - 1;

            for (int j = left; j < right; ++j)
            {
                if (array[j] <= last)
                {
                    ++lastLessElem;
                    Swap(array, lastLessElem, j);
                }
            }

            lastLessElem++;
            Swap(array, lastLessElem, right);

            return lastLessElem;
        }
    }
}