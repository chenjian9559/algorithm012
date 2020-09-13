using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
示例 1:
    输入: '(()'
    输出: 2
    解释: 最长有效括号子串为 '()'
示例 2:
    输入: ')()())'
    输出: 4
    解释: 最长有效括号子串为 '()()'");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("以下是该程序实现执行的结果：");

           string testData = ")()())";
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = LongestValidParentheses(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestValidParentheses(string s)
        {
            Stack<int> leftC = new Stack<int>();
            var step = 0;
            var ans = 0;
            leftC.Push(-1);
            while (step < s.Length)
            {
                if (s[step] == '(')
                {
                    leftC.Push(step);
                }
                else if (s[step] == ')')
                {
                    leftC.Pop();
                    if (leftC.Count > 0)
                    {
                        ans = Math.Max(ans, step - leftC.Peek());
                    }
                    else
                    {
                        leftC.Push(step);
                    }
                }
                step++;
            }
            return ans;
        }
    }
}
