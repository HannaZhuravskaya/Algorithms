namespace Algorithms.LeetCode
{
    public class ConstructArrayTask
    {
        public int[] ConstructArray(int n, int k)
        {
            var array = new int[n];
            for (int i = 0; i < n - k - 1; ++i)
                array[i] = i + 1;

            bool isAdd = false;
            int curK = k;
            array[n - 1] = n;
            for (int i = n - 2; i >= n - k - 1; --i)
            {
                array[i] = isAdd ? array[i + 1] + curK : array[i + 1] - curK;
                isAdd = !isAdd;
                curK--;
            }

            return array;
        }


        /*
        other Solution
        n = 10, k = 7
        [1, 8, 2, 7, 3, 6, 4, 5, ||| 9, 10]
                            [k+1]   [k+2]
        k+1 elems by logic +(k-i) - (k-i)
        [k+1] element = (k+3)/2 if (k+1) odd and (k+2)/2 if (k+1) even
        diff between [k+1] and [k+2] less than k, so the rest element from [k+2] ... [n] will be appropriate for task
        */
    }
}