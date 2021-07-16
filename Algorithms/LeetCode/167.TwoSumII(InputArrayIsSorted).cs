namespace Algorithms.LeetCode
{
    public class TwoSumII
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var l = 0;
            var r = numbers.Length - 1;

            while (numbers[l] + numbers[r] != target)
            {
                if (numbers[l] + numbers[r] > target)
                    r--;
                else
                    l++;
            }

            return new int[2] { l + 1, r + 1 };
        }
    }
}