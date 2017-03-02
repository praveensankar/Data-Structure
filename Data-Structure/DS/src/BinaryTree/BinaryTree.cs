namespace BinaryTree
{
    public class BinaryTree<T> 
    {
        public Node<T> Root { get; set; } = null;

        public BinaryTree(T data)
        {
            Root = new Node<T>(data);
        }

        public BinaryTree()
        {

        }

        public int Height(Node<T> root)
        {
            if (root == null)
                return 0;
            else
            {
                int lheight = Height(root.Left);
                int rheight = Height(root.Right);
                return (lheight > rheight) ? lheight + 1 : rheight + 1;
            }
        }

        public int DiameterOptimized(Node<T> root,ref int height)
        {
            if(root==null)
            {
                height = 0;
                return 0;
            }
            int lh = 0, rh = 0,ld=0,rd=0;
            ld = DiameterOptimized(root.Left,ref lh);
            rd = DiameterOptimized(root.Right, ref rh);

            height = (ld > rd ? ld : rd) + 1;
            return ((lh + rh + 1) > (ld > rd ? ld : rd) ? (lh+rh+1): (ld > rd ? ld : rd));
        }
    }
}
