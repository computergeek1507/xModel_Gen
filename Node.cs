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

        public List<int> CloseIds = new List<int>();

        public int Id;

        public bool IsWired => NodeNumber != 0;

        private int _wireIndex = -1;


        public void ClearWiring()
        {
            NodeNumber = 0;
            Id = -1;
            CloseIds.Clear();
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Id, GridX, GridY, NodeNumber);
        }

        
    }
}