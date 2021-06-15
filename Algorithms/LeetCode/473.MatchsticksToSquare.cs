namespace Algorithms.LeetCode
{
    public class MatchsticksToSquare
    {
        public bool Makesquare(int[] matchsticks)
        {
            if (matchsticks.Length < 4)
                return false;

            var sum = 0;
            for (int i = 0; i < matchsticks.Length; ++i)
            {
                sum += matchsticks[i];
            }

            if (sum % 4 != 0)
                return false;

            return MakeSquare(matchsticks, 0, 0, 0, 0, 0, sum / 4);
        }

        private bool MakeSquare(int[] matchsticks, int i, int a1, int a2, int a3, int a4, int len)
        {
            if (i == matchsticks.Length)
                return a1 == a2 && a2 == a3 && a3 == a4;

            if (a1 > len || a2 > len || a3 > len || a4 > len)
                return false;

            return MakeSquare(matchsticks, i + 1, a1 + matchsticks[i], a2, a3, a4, len)
                || MakeSquare(matchsticks, i + 1, a1, a2 + matchsticks[i], a3, a4, len)
                || MakeSquare(matchsticks, i + 1, a1, a2, a3 + matchsticks[i], a4, len)
                || MakeSquare(matchsticks, i + 1, a1, a2, a3, a4 + matchsticks[i], len);

        }
    }
}