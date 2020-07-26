using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permute
{
    /// <summary>
    /// 给定一个 没有重复 数字的序列，返回其所有可能的全排列。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * 示例:
             *    输入: [1,2,3]
             *    输出:
             *    [
             *      [1,2,3],
             *      [1,3,2],
             *      [2,1,3],
             *      [2,3,1],
             *      [3,1,2],
             *      [3,2,1]
             *    ]
             **/
            int[] testData = new int[] { 1, 2, 3 };
            var reuslt = Permute(testData);
            Console.WriteLine($"--------结果：");
            foreach (var item in reuslt)
            {
                Console.WriteLine($"{String.Join(",", item)}");
            }
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> res = new List<IList<int>>(); //存放所有解
            LinkedList<int> track = new LinkedList<int>(); //存放临时解，用了链表
            backrack(nums, track, res);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="track"></param>
        /// <param name="res"></param>
        public static void backrack(int[] nums, LinkedList<int> track, IList<IList<int>> res)
        {
            if (track.Count == nums.Length) //判断临时解的个数是否等于num的个数
            {
                res.Add(new List<int>(track)); //是就直接添加并返回
                return;
            }
            for (int i = 0; i < nums.Length; i++)  //从第一个数开始
            {
                if (track.Contains(nums[i]))  //临时链表包涵这个数，说明就是这个数已经选择过作为结点的了
                {
                    continue; ;
                }
                track.AddLast(nums[i]); //不包含这个数，就把这个数插进链表最后
                backrack(nums, track, res);//继续下一个
                track.RemoveLast();//为了维护临时链表的正确，离开这层循环，都要删除这层选择的数
            }
        }

    }
}
