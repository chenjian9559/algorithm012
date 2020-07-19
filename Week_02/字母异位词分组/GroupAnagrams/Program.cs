using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testData = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            Console.WriteLine($"测试数据{String.Join(",", testData)}");
            var reuslt = GroupAnagrams(testData);
            Console.WriteLine($"--------GroupAnagrams  分组后结果：");
            foreach (var item in reuslt)
            {
                Console.WriteLine($"{String.Join(",", item)}");
            }
            Console.WriteLine($"--------GroupAnagrams  The End");


            var reuslt2 = GroupAnagrams2(testData);
            Console.WriteLine($"--------GroupAnagrams2  分组后结果：");
            foreach (var item in reuslt2)
            {
                Console.WriteLine($"{String.Join(",", item)}");
            }
            Console.WriteLine($"--------GroupAnagrams2  The End");


            Console.WriteLine($"按任意键结束！");
            Console.ReadKey();

        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                int[] characters = new int[26];
                for (int i = 0; i < 26; i++)
                {
                    characters[i] = 0;
                }
                for (int j = 0; j < item.Length; j++)
                {
                    var ascii = System.Text.Encoding.ASCII.GetBytes(item.Substring(j, 1));
                    characters[ascii[0] - 97]++;
                }
                StringBuilder key = new StringBuilder();
                for (int z = 0; z < characters.Length; z++)
                {
                    key.Append(characters[z].ToString());
                }
                if (dic.ContainsKey(key.ToString()))
                {
                    dic[key.ToString()].Add(item);
                }
                else
                {
                    List<string> demo1 = new List<string>();
                    demo1.Add(item);
                    dic.Add(key.ToString(), demo1);
                }
            }
            return dic.Values.ToList();
        }


        public static IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            var res = new List<IList<string>>();
            var grp = new Dictionary<string, IList<string>>();
            // 遍历每一个字符串
            foreach (var str in strs)
            {
                // Concat:将指定字符串连接到此字符串的结尾
                // OrderBy 将char升序排列
                // rt是排序过的字母 eat -> aet
                string rt = String.Concat(str.OrderBy(ch => ch));

                // 放入字典中
                if (grp.ContainsKey(rt))
                {
                    grp[rt].Add(str);
                }
                else
                {
                    grp[rt] = new List<string> { str };
                }
            }
            foreach (var key in grp.Keys)
            {
                res.Add(grp[key]);
            }
            return res;
        }


    }

}
