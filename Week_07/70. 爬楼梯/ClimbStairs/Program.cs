using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClimbStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
注意：给定 n 是一个正整数。

示例 1：
    输入： 2
    输出： 2
解释： 有两种方法可以爬到楼顶。
    1.  1 阶 + 1 阶
    2.  2 阶
示例 2：
    输入： 3
    输出： 3
    解释： 有三种方法可以爬到楼顶。
    1.  1 阶 + 1 阶 + 1 阶
    2.  1 阶 + 2 阶
    3.  2 阶 + 1 阶");

            int testData = 40;
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = ClimbStairs(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();

        }

        public static int ClimbStairs(int n)
        {
            //return fib1(n);
            return Fib2(n, 1, 2);
            //return Fibo3(n);

        }

        public static int fib1(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            int[] fib1 = new int[n];
            fib1[0] = 1;
            fib1[1] = 2;
            for (int i = 2; i < n; i++)
            {
                fib1[i] = fib1[i - 2] + fib1[i - 1];
            }
            return fib1[n - 1];
        }

        public static int Fib2(int n, int first, int second)
        {
            if (n <= 1)
            {
                return first;
            }
            else
            {
                return Fib2(n - 1, second, first + second);
            }
        }

        public static int Fibo3(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            int first = 1;
            int second = 2;
            int third = 3;
            for (int i = 3; i <= n; i++)
            {
                third = first + second;
                first = second;
                second = third;
            }
            return third;
        }
    }
}
