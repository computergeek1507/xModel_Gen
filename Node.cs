using System.Collections.Generic;

namespace xModel_Gen
{
    public class Node
    {
        //public Node(int id)
        //{
        //    Id = id;
        //    ClearWiring();
        //}

        public Node()
        {
            ClearWiring();
        }

        public int GridX { get; set; }
        public int GridY { get; set; }
        public int NodeNumber { get; set; }

        public int PrevId { get; set; }
        public int NextId { get; set; }

        public List<int> CloseIds = new List<int>();

        public int Id;

        public bool IsWired => NodeNumber != 0;

        private int _wireIndex = -1;

        public void ClearWiring()
        {
            NodeNumber = 0;
            PrevId = -1;
            NextId = -1;
            Id = -1;
            CloseIds.Clear();
        }

        public int GetNextId()
        {
            _wireIndex++;
            if (_wireIndex >= CloseIds.Count)
            {
                return -1;
            }
            return CloseIds[_wireIndex];
        }

        public int GetPrevId()
        {
            RestAutoWire();
            return PrevId;
        }

        public void RestAutoWire()
        {
            NodeNumber = 0;
            //PrevId = -1;
            _wireIndex = -1;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Id, GridX, GridY, NodeNumber);
        }

        
    }
}