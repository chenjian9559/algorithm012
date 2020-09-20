using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstUniqChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。
示例：
    s = 'leetcode'
    返回 0

    s = 'loveleetcode'
    返回 2");

            string  testData = "loveleetcode";
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = FirstUniqChar(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }


        public static int FirstUniqChar(string s)
        {
            int[] arr = new int[26];  //26个字母的数组
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a'] += 1;  //a--0 b--1………… 对应位置数字+1
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (arr[s[i] - 'a'] == 1)  //当该位置数字为1
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
