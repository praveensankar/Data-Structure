namespace LinkedList
{
    public class NodeFactory<T>
    {
        public object GenerateNode(object obj)
        {
            if(obj is LinkedList<T>)
            return new Node<T>();
            if (obj is OtherApproach.LinkedList1<T>)
                return new OtherApproach.Node<T>();
            return null;
        }
    }
}
