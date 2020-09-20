using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HammingWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"编写一个函数，输入是一个无符号整数，返回其二进制表达式中数字位数为 ‘1’ 的个数（也被称为汉明重量）。
示例 1：
    输入：00000000000000000000000000001011
    输出：3
解释：输入的二进制串 00000000000000000000000000001011 中，共有三位为 '1'。
示例 2：
    输入：00000000000000000000000010000000
    输出：1
    解释：输入的二进制串 00000000000000000000000010000000 中，共有一位为 '1'。
示例 3：
    输入：11111111111111111111111111111101
    输出：31
    解释：输入的二进制串 11111111111111111111111111111101 中，共有 31 位为 '1'。

提示：
    请注意，在某些语言（如 Java）中，没有无符号整数类型。在这种情况下，输入和输出都将被指定为有符号整数类型，并且不应影响您的实现，因为无论整数是有符号的还是无符号的，其内部的二进制表示形式都是相同的。
在 Java 中，编译器使用二进制补码记法来表示有符号整数。因此，在上面的 示例 3 中，输入表示有符号整数 -3。");

            uint testData = 00000000000000000000000000001011;
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = HammingWeight(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight(uint n)
        {
            var r = 0;
            uint mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) == mask) r++;
                mask = (uint)mask << 1;
            }
            return r;
        }
    }
}
