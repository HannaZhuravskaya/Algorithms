using System;
using System.Collections.Generic;
using System.Linq;

/*
                 Algorithm	Time Complexity	           Space Complexity
              Best	         Average	   Worst	       Worst
Mergesort	Ω(n log(n))	   Θ(n log(n))	O(n log(n))	       O(n)
*/

public static class MergeSort
{
    public static void Sort(List<int> array, int left, int right)
    {
        if(array.Count < 2)
            return;

        var middle = (left + right) / 2;
        if(left < middle)
            Sort(array, left, middle);

        if(middle + 1 < right)
            Sort(array, middle + 1, right);

        Merge(array, left, middle, right);
    }

    private static void Merge(List<int> array, int left, int middle, int right)
    {
        var n1 = middle - left + 1;
        var n2 = right - middle;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for(int i = 0; i < n1; ++i)
            L[i] = array[left + i];

        for(int i = 0; i < n2; ++i)
            R[i] = array[middle + 1 + i];

        int lIndex = 0, rIndex = 0, cur = left;
        while(lIndex < n1 && rIndex < n2)
        {
            if(L[lIndex] <= R[rIndex])
                array[cur++] = L[lIndex++];
            else
                array[cur++] = R[rIndex++];
        }

        while(lIndex < n1)
            array[cur++] = L[lIndex++];

        while(rIndex < n2)
            array[cur++] = R[rIndex++];
    }
}