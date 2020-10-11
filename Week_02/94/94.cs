using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeCodeTur._94
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public static class _94
    {
        public static IList<int> InorderTraversal(TreeNode root)
        {
            #region old
            //List<int> ret = new List<int>();
            //Stack<TreeNode> st = new Stack<TreeNode>();
            //while (root != null)
            //{
            //    st.Push(root);
            //    root = root.left;
            //}
            //while (st.Count > 0)
            //{
            //    var node = st.Pop();
            //    ret.Add(node.val);
            //    if (node.right != null)
            //    {
            //        st.Push(node.right);
            //        var ritnode = node.right.left;

            //        while (ritnode != null)
            //        {
            //            st.Push(ritnode);
            //            ritnode = ritnode.left;
            //        }
            //    }
            //}

            //return ret;
            #endregion
            #region 迭代方式
            //List<int> result = new List<int>();
            //Stack<TreeNode> st = new Stack<TreeNode>();
            //while (root != null || st.Any())
            //{
            //    while (root != null)
            //    {
            //        st.Push(root);
            //        root = root.left;
            //    }
            //    var node = st.Pop();
            //    result.Add(node.val);
            //    root = node.right;
            //}
            //return result;
            #endregion
            #region 迭代3
            var result = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            while (root != null || st.Any())
            {
                while (root != null)
                {
                    st.Push(root);
                    root = root.left;
                }

                root = st.Pop();
                result.Add(root.val);
                root = root.right;
            }
            return result;
            #endregion
            #region 递归方式

            #endregion
        }
    }


}
