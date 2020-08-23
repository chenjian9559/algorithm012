using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LadderLength
{
    class Program
    {
        //BFS

        static void Main(string[] args)
        {

            Console.WriteLine(@"给定两个单词（beginWord 和 endWord）和一个字典，找到从 beginWord 到 endWord 的最短转换序列的长度。转换需遵循如下规则：
每次转换只能改变一个字母。
转换过程中的中间单词必须是字典中的单词。
说明:
    如果不存在这样的转换序列，返回 0。
    所有单词具有相同的长度。
    所有单词只由小写字母组成。
    字典中不存在重复的单词。
    你可以假设 beginWord 和 endWord 是非空的，且二者不相同。
示例 1:
    输入:
        beginWord = 'hit',
        endWord = 'cog',
        wordList = ['hot', 'dot', 'dog', 'lot', 'log', 'cog']
    
    输出: 5
    解释: 一个最短转换序列是 'hit'-> 'hot'-> 'dot'-> 'dog'-> 'cog',返回它的长度 5。
示例 2:
    输入:
        beginWord = 'hit'
        endWord = 'cog'
        wordList = ['hot', 'dot', 'dog', 'lot', 'log']

    输出: 0
    解释: endWord 'cog' 不在字典中，所以无法进行转换。");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("以下是该程序实现执行的结果：");

            string testBegin = "hit";
            string testEnd = "cog";
            string[] testData = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            Console.WriteLine($"--------测试用例：");
            Console.WriteLine($"beginWord ：{testBegin}");
            Console.WriteLine($"endWord ：{testEnd}");
            Console.WriteLine($"wordList ：{String.Join(",", testData)}");

            var result = LadderLength(testBegin, testEnd, testData);

            Console.WriteLine($"--------结果：");
            Console.WriteLine($"{result}");
            Console.WriteLine($"--------The End");



            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();
        }


        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int len = wordList.Count;
            int wordLength = wordList[0].Length;

            // 看看endWord存不存在
            if (!wordList.Contains(endWord))
                return 0;

            // endWord存在，准备参数
            int result = 1;
            int inIndex = 1;
            int outIndex = 0;
            List<string> words = new List<string>();
            words.Add(beginWord);
            int neighborCount = 1;
            int oldpig = 0;
            bool[] isVisited = new bool[len];

            // bfs循环
            while (inIndex > outIndex)
            {
                for (int i = 0; i < neighborCount; i++)
                {
                    if (words[outIndex] == endWord)
                    {
                        return result;
                    }
                    for (int j = 0; j < len; j++)
                    {
                        if (!isVisited[j] && isNeighbor(words[outIndex], wordList[j], wordLength))
                        {
                            words.Add(wordList[j]);
                            inIndex++;
                            isVisited[j] = true;
                            oldpig++;
                        }
                    }
                    outIndex++;
                }
                neighborCount = oldpig;
                oldpig = 0;
                result++;
            }
            return 0;
        }

        public static bool isNeighbor(string hostWord, string testWord, int wordLength)
        {
            int difference = 0;
            for (int i = 0; i < wordLength; i++)
            {
                if (hostWord[i] != testWord[i])
                    difference++;
                if (difference > 1)
                    return false;
            }
            if (difference == 1)
                return true;
            return false;
        }

    }
}
