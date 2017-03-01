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
    }
}
