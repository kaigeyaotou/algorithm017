using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._127
{
    public static class _127
    {
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            #region 1
            //int L = beginWord.Length;
            //Dictionary<String, List<String>> allComboDict = new Dictionary<string, List<string>>();
            //foreach (var word in wordList)
            //{
            //    for (int i = 0; i < L; i++)
            //    {
            //        string newWord = word.Substring(0, i) + '*' + word.Substring(i + 1);
            //        List<string> transformations = new List<string>();
            //        if (allComboDict.ContainsKey(newWord))
            //        {
            //            transformations = allComboDict[newWord];
            //            transformations.Add(word);
            //            allComboDict[newWord] = transformations;
            //        }
            //        else
            //        {
            //            transformations.Add(word);
            //            allComboDict.Add(newWord, transformations);
            //        }
            //    }
            //}
            //Queue<(string, int)> Q = new Queue<(string, int)>();
            //Q.Enqueue((beginWord, 1));
            //Dictionary<string, bool> visited = new Dictionary<string, bool>();
            //visited.Add(beginWord, true);

            //while (Q.Any())
            //{
            //    (string, int) node = Q.Dequeue();
            //    string word = node.Item1;
            //    int level = node.Item2;
            //    for (int i = 0; i < L; i++)
            //    {

            //        string newWord = word.Substring(0, i) + '*' + word.Substring(i + 1);
            //        if (!allComboDict.ContainsKey(newWord)) continue;
            //        foreach (var adjacentWord in allComboDict[newWord])
            //        {
            //            if (adjacentWord == endWord)
            //            {
            //                return level + 1;
            //            }
            //            if (!visited.ContainsKey(adjacentWord))
            //            {
            //                visited.Add(adjacentWord, true);
            //                Q.Enqueue((adjacentWord, level + 1));
            //            }
            //        }
            //    }
            //}

            //return 0;

            #endregion

            #region 2
            Dictionary<string, IList<string>> dics = new Dictionary<string, IList<string>>();
            foreach (var word in wordList)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    var list = new List<string>();
                    if (dics.ContainsKey(newWord))
                    {
                        list = dics[newWord].ToList();
                        list.Add(word);
                        dics[newWord] = list;
                    }
                    else
                    {
                        list.Add(word);
                        dics.Add(newWord, list);
                    }
                }
            }

            List<string> visited = new List<string>();
            Queue<(string node, int count)> q = new Queue<(string node, int count)>();
            q.Enqueue((beginWord, 0));
            visited.Add(beginWord);
            while (q.Any())
            {
                var node = q.Dequeue();
                string word = node.node;
                int count = node.count;
                for (int i = 0; i < word.Length; i++)
                {
                    string newWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    if (dics.ContainsKey(newWord))
                    {
                        var list = dics[newWord];
                        foreach (var item in list)
                        {
                            if (item == endWord)
                            {
                                return count + 1;
                            }
                            if (!visited.Any(a => a == item))
                            {
                                q.Enqueue((item, count + 1));
                                visited.Add(item);
                            }
                        }
                    }


                }
            }
            return -1;

            #endregion
        }
    }


}
