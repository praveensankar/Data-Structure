namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public static class BuildTreeFromTraversal<T> 
    {
        private static int PreOrderIndex { get; set; }= 0;
        public static Node<T> BuildTree(T[] inorder,T[] preorder,int inStart,int inEnd)
        {
            
            if (inStart > inEnd)
                return null;
            Node<T> node = new Node<T>(preorder[PreOrderIndex++]);

            if (inStart == inEnd)
                return node;
            int inOrderIndex = SearchInorderIndex(inorder, node.Data);
            node.Left = BuildTree(inorder, preorder, inStart, inOrderIndex - 1);
            node.Right = BuildTree(inorder, preorder, inOrderIndex+1, inEnd);

            return node;
        }

        public  static int SearchInorderIndex(T[] inorder,T element)
        {
            for(int i=0;i<inorder.Length;i++)
            {
                if ((char)(object)inorder[i]==(char)(object)element)
                    return i;
            }
            return default(int);
        }

       
    }
}
