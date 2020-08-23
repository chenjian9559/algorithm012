using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。

示例：
    输入：n = 3
    输出：[
            '((()))',
            '(()())',
            '(())()',
            '()(())',
            '()()()'
          ]");

            int testData = 3;
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = GenerateParenthesis(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{string.Join("\n",result)}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }
        public  static IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            void GetNext(int l, int r)
            {
                if (l > r && l == n)
                {
                    sb.Append(')');
                    GetNext(l, r + 1);
                }
                else if (l > r && l < n)
                {
                    sb.Append('(');
                    GetNext(l + 1, r);
                    sb.Append(')');
                    GetNext(l, r + 1);
                }
                else if (l == r && l < n)
                {
                    sb.Append('(');
                    GetNext(l + 1, r);
                }
                else if (l == r && l == n)
                {
                    result.Add(sb.ToString());
                }
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append('(');
            GetNext(1, 0);
            return result;
        }
    }
}
