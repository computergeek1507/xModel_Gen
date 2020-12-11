using System;
using System.Collections.Generic;

namespace xModel_Gen
{
    [Serializable()]
    public class Node
    {
        public Node()
        {
            ClearWiring();
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