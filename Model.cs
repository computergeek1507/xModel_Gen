using System.Collections.Generic;
using System.Windows.Forms;

namespace xModel_Gen
{
    public class Model
    {
        private readonly List<Node> _nodes = new List<Node>();
        private readonly BindingSource _source = new BindingSource();

        public Model()
        {
            _source.DataSource = _nodes;
        }

        public string Name { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public void AddNode(Node newNode)
        {
            if (FindNode(newNode.GridX, newNode.GridY) != null)
                return;
            _nodes.Add(newNode);
            _source.ResetBindings(false);
        }

        public Node GetNode(int i)
        {
            if (i > _nodes.Count)
                return null;
            return _nodes[i];
        }

        public List<Node> GetNodes()
        {
            return _nodes;
        }

        public int GetNodeCount()
        {
            return _nodes.Count;
        }

        public void SortNodes()
        {
            _nodes.Sort((x, y) => x.NodeNumber.CompareTo(y.NodeNumber));
            _source.ResetBindings(false);
        }

        public Node FindNode(int x, int y)
        {
            foreach (var node in _nodes)
                if (x == node.GridX && y == node.GridY)
                    return node;

            return null;
        }

        public void SetNodeNumber(int i, int node)
        {
            if (i > _nodes.Count)
                return;
            _nodes[i].NodeNumber = node;
            _source.ResetBindings(false);
        }

        public void ClearWiring()
        {
            foreach (var node in _nodes) node.ClearWiring();
            _source.ResetBindings(false);
        }

        public BindingSource GetBinding()
        {
            return _source;
        }
    }
}