using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = new int[] { 2, 7, 11, 15 };
            int target = 9;
            Console.WriteLine("------暴力解法执行------");
            var result = TwoSum(testData, target);//暴力
            if (result.Length > 0)
            {
                Console.WriteLine($"{result[0]},{result[1]}");
            }
            Console.WriteLine("------一编哈希表解法结束------");

            Console.WriteLine("------一编哈希表解法执行------");
            var result2 = TwoSumByHashOne(testData, target);//暴力
            if (result.Length > 0)
            {
                Console.WriteLine($"{result2[0]},{result2[1]}");
            }
            Console.WriteLine("------一编哈希表解法结束------");

            Console.WriteLine("任意键结束！");
            Console.ReadKey();
        }

        /// <summary>
        /// 暴力解法两数之和
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="taget">目标数</param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 0, 0 };
            // throw new Exception($"未找到数组中两数之和为：{target} 的两个数.");
        }

        /// <summary>
        /// 一编哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSumByHashOne(int[] nums, int target)
        {
            int[] result = new int[2];
            Dictionary<int, int> tempkvs = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (tempkvs.ContainsKey(complement) && tempkvs[complement] != i)//看题解时  tempkvs[complement] != i 不是很理解
                {
                    return new int[] { i, tempkvs[complement] };
                }
               
                if (!tempkvs.ContainsKey(nums[i]))
                {
                    tempkvs.Add(nums[i], i);
                }
            }

            return result;
        }

    }
}
