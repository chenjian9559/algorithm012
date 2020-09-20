using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsPowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
示例 1:
    输入: 1
    输出: true
    解释: 20 = 1
示例 2:
    输入: 16
    输出: true
    解释: 24 = 16
示例 3:
    输入: 218
    输出: false");

            int testData = 16;
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = IsPowerOfTwo(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(int n)
        {
            return (n > 0) && ((n & (-n)) == n);
        }
    }
}
