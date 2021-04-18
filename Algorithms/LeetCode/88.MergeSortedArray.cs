namespace Algorithms.LeetCode
{
    public class MergeSortedArrayTask
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums1Copy = new int[m];

            for (int i = 0; i < m; ++i)
                nums1Copy[i] = nums1[i];

            int i1 = 0, i2 = 0, cnt = 0;
            while (i1 < m && i2 < n)
            {
                if (nums1Copy[i1] < nums2[i2])
                    nums1[cnt++] = nums1Copy[i1++];
                else
                    nums1[cnt++] = nums2[i2++];
            }

            while (i1 < m)
            {
                nums1[cnt++] = nums1Copy[i1++];
            }

            while (i2 < n)
            {
                nums1[cnt++] = nums2[i2++];
            }
        }
    }
}