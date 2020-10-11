using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._589
{
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
    public static class _589
    {
        public static IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);
                if (node.children != null)
                {
                    if (node.children.Any())
                    {
                        for (int i = node.children.Count - 1; i >= 0; i--)
                        {
                            stack.Push(node.children[i]);
                        }
                    }
                }
            }
            return result;
        }
    }
}
