using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
说明：每次只能向下或者向右移动一步。

示例:
	输入:
    [
        [1,3,1],
        [1,5,1],
        [4,2,1]
    ]
	输出: 7
	解释: 因为路径 1→3→1→1→1 的总和最小。");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("以下是该程序实现执行的结果：");

            int[][] testData = new int[][] {
                new int[]{1, 3, 1},
               new int[]{ 1, 5, 1},
                new int[]{ 4, 2, 1}
            };
            Console.WriteLine($"--------测试用例：");
            Console.WriteLine($"[{String.Join(",", testData[0])}]");
            Console.WriteLine($"[{String.Join(",", testData[1])}]");
            Console.WriteLine($"[{String.Join(",", testData[2])}]");

            var result = MinPathSum(testData); // 算法实现

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");

            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();

        }


        public static int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }
            int m = grid.Length;
            int n = grid[0].Length;
            //遍历grid数组，动态规划计算每个格子的最小值
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (x == 0 && y == 0) { continue; }
                    int curMin = -1;
                    //从当前格子的上边和左边的格子里选出最小值并与当前格相加
                    if (x - 1 >= 0 && y - 1 >= 0)
                    {
                        curMin = Math.Min(grid[x - 1][y], grid[x][y - 1]);
                    }
                    else
                    {
                        curMin = x - 1 >= 0 ? grid[x - 1][y] : grid[x][y - 1];
                    }
                    grid[x][y] = curMin + grid[x][y];
                }
            }
            //输出终点计算出的值即为路径最小值
            return grid[m - 1][n - 1];
        }
    }
}
