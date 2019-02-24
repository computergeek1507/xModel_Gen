namespace xModel_Gen
{
    public class Node
    {
        public Node()
        {
            NodeNumber = 0;
        }

        public int GridX { get; set; }
        public int GridY { get; set; }
        public int NodeNumber { get; set; }

        public bool IsWired => NodeNumber != 0;

        public void ClearWiring()
        {
            NodeNumber = 0;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", GridX, GridY, NodeNumber);
        }
    }
}