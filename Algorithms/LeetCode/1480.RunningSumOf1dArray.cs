namespace Algorithms.LeetCode
{
    public class RunningSumOf1dArray
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; ++i)
                nums[i] = nums[i - 1] + nums[i];

            return nums;
        }
    }
}