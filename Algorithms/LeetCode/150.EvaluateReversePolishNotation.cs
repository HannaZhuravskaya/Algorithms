using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    public class EvaluateReversePolishNotationTask
    {
        public int EvalRPN(string[] tokens)
        {
            var operationsDict = new Dictionary<string, Func<int, int, int>>(){
                { "+", (int num2, int num1) => num1 + num2 },
                { "-", (int num2, int num1) => num1 - num2 },
                { "*", (int num2, int num1) => num1 * num2 },
                { "/", (int num2, int num1) => num1 / num2 },
            };

            var numbers = new Stack<int>();

            for (int i = 0; i < tokens.Length; ++i)
            {
                if (operationsDict.ContainsKey(tokens[i]))
                {
                    numbers.Push(operationsDict[tokens[i]].Invoke(numbers.Pop(), numbers.Pop()));
                }
                else
                {
                    numbers.Push(int.Parse(tokens[i]));
                }
            }

            return numbers.Pop();
        }
    }
}