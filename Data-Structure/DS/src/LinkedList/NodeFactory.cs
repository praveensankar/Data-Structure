namespace LinkedList
{
    public class NodeFactory<T>
    {
        public Node<T> GenerateNode()
        {
            return new Node<T>();
        }
    }
}
