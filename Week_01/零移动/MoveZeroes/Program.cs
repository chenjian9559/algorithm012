using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoveZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroes(testData);
            String s = String.Join(",", testData);
            Console.WriteLine(s);
            Console.WriteLine("任意键结束");
            Console.ReadKey();

        }

        /// <summary>
        /// 零移动
        /// </summary>
        /// <param name="nums">数组源数据</param>
        public static void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    if (i != j)
                    {
                        nums[i] = 0;
                    }
                    j++;
                }
            }


        }

    }
}
