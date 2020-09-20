using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumDecodings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"一条包含字母 A-Z 的消息通过以下方式进行了编码：
'A' -> 1
'B' -> 2
...
'Z' -> 26
给定一个只包含数字的非空字符串，请计算解码方法的总数。
示例 1:
    输入: '12'
    输出: 2
    解释: 它可以解码为 'AB'（1 2）或者 'L'（12）。
示例 2:
    输入: '226'
    输出: 3
    解释: 它可以解码为 'BZ'(2 26), 'VF'(22 6), 或者 'BBF'(2 2 6) 。");

            string testData = "12";
            Console.Write($"--------测试用例：");
            Console.WriteLine($"{testData}");

            var result = NumDecodings(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }

        public static int NumDecodings(string s)
        {

            if (s[0] == '0')
            {
                return 0;
            }
            int[] sa = new int[s.Length + 1];
            sa[0] = 1;
            sa[1] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                //后面一个位置为0时，和前一个相同
                if (i + 1 < s.Length && s[i + 1] == '0')
                {
                    sa[i + 1] = sa[i];
                    continue;
                }
                //当前位置为0时
                if (s[i] == '0')
                {
                    //0前面如果是1/2 ,则和前一个相同；否则，编码有误返回0
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                    {
                        sa[i + 1] = sa[i];
                        continue;
                    }
                    else
                    {
                        return 0;
                    }
                }
                //前一个位置为0时，计算到当前位置时，解码方法数不变，和前一个形同
                if (s[i - 1] == '0')
                {
                    sa[i + 1] = sa[i];
                    continue;
                }
                //普通不含0 的情况下，当前位置及前一位，构成的 2位数如果 小于等于26 ，则 解码数 是前两个解码数之和；否则和前一个相同
                int cur = (s[i - 1] - '0') * 10 + (s[i] - '0');
                if (cur <= 26)
                {
                    sa[i + 1] = sa[i] + sa[i - 1];
                }
                else
                {
                    sa[i + 1] = sa[i];
                }
            }
            return sa[s.Length];
        }

        //public static int NumDecodings(string s)
        //{
        //    if (s[0] == '0')
        //    {
        //        return 0;
        //    }
        //    if (s.Length <= 1)
        //    {
        //        return s.Length;
        //    }
        //    int[] nums = s.Select(p => (int)(p - '0')).ToArray();

        //    int last = 1;
        //    int lastlast = 1;
        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        int _1 = 0;
        //        int _2 = 0;

        //        int num = nums[i - 1] * 10 + nums[i];//前两位数
        //        if (num == 0)//连续两个0，直接返回0
        //        {
        //            return 0;
        //        }

        //        if (nums[i] > 0)
        //        {
        //            _1 = last;
        //        }

        //        if (nums[i - 1] != 0 && num <= 26)//前两位数小于26
        //        {
        //            _2 = lastlast;
        //        }
        //        lastlast = last;
        //        last = _1 + _2;
        //    }
        //    return last;
        //}
    }
}
