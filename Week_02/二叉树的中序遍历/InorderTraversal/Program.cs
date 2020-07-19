using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {

        }


        #region 递归形式
        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> TraversedNode = new List<int>();
            Helper(root, TraversedNode);
            return TraversedNode;
        }

        public static void Helper(TreeNode root, IList<int> TraverserNode)
        {
            if (root != null)
            {
                if (root.left != null)
                {
                    Helper(root.left, TraverserNode);
                }
                TraverserNode.Add(root.val);
                if (root.right != null)
                {
                    Helper(root.right, TraverserNode);
                }
            }
        }

        #endregion 


    }

    /// <summary>
    ///  Definition for a binary tree node.
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode() { }
        public TreeNode(int x) { val = x; }
    }

}
