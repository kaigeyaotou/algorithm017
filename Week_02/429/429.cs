using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._429
{

    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public static class _429
    {
        public static IList<IList<int>> LevelOrder(Node root)
        {

            #region 广度优先+size实现
            //if (root == null)
            //    return new List<IList<int>>();
            //List<IList<int>> result = new List<IList<int>>();
            //Queue<Node> queue = new Queue<Node>();
            //queue.Enqueue(root);
            //while (queue.Any())
            //{
            //    int size = queue.Count;
            //    List<int> temp = new List<int>();
            //    for (int i = 0; i < size; i++)
            //    {
            //        var node = queue.Dequeue();
            //        temp.Add(node.val);
            //        if (node.children != null)
            //        {
            //            foreach (var child in node.children)
            //            {
            //                queue.Enqueue(child);
            //            }
            //        }
            //    }
            //    result.Add(temp);
            //}

            //return result;
            #endregion

            #region 广度优先优化
            if (root == null)
                return new List<IList<int>>();

            var result = new List<IList<int>>();
            List<Node> levelNodes = new List<Node>();
            levelNodes.Add(root);
            while (levelNodes.Any())
            {
                List<Node> currentNodes = new List<Node>();
                List<int> values = new List<int>();
                foreach (var item in levelNodes)
                {
                    values.Add(item.val);
                    if (item.children != null)
                    {
                        currentNodes.AddRange(item.children);
                    }

                }
                result.Add(values);
                levelNodes = currentNodes;
            }

            return result;
            #endregion
        }
    }
}
