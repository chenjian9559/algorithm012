using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Combine
{
    /// <summary>
    /// 给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /**
             * 示例:
             * 
             * 输入: n = 4, k = 2
             * 输出:
             * [
             *   [2,4],
             *   [3,4],
             *   [2,3],
             *   [1,2],
             *   [1,3],
             *   [1,4],
             * ]
             */
            // n = 4 ,k = 2
            var result = Combine(4, 2);




            Console.WriteLine($"--------结果：");
            foreach (var item in result)
            {
                Console.WriteLine($"{String.Join(",", item)}");
            }
            Console.WriteLine($"--------The End");
            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }

        public static IList<IList<int>> Combine(int n, int k)
        {
            if (n < 1 || k < 1) return new List<IList<int>>();
            List<IList<int>> results = new List<IList<int>>();
            List<int> currentList = new List<int>();
            BuildNumberList(1, n, k, ref currentList, ref results);
            return results;
        }

        private static void BuildNumberList(int start, int end, int length, ref List<int> currentList, ref List<IList<int>> results)
        {
            if (currentList.Count == length)
            {
                results.Add(new List<int>(currentList));
                return;
            }

            for (int index = start; index <= end; index++)
            {
                currentList.Add(index);
                BuildNumberList(index + 1, end, length, ref currentList, ref results);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
