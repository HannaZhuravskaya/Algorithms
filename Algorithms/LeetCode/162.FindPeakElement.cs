namespace Algorithms.LeetCode
{
    public class FindPeakElementTask
    {
        public int FindPeakElement(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }

            return nums.Length - 1;
        }
    }
}