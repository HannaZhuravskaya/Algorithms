using System.Text;

namespace Algorithms.LeetCode
{
    public class ToLowerCaseTask
    {
        public string ToLowerCase(string s)
        {
            var sb = new StringBuilder();
            foreach (var letter in s)
            {
                if ((int)letter >= 65 && (int)letter <= 90)
                {
                    sb.Append((char)(letter - 'A' + 'a'));
                }
                else
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}