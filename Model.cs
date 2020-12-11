using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace xModel_Gen
{
    public class Model
    {
        public static object DeepClone(object obj)
        {
            object objResult = null;

            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }

            return objResult;
        }


        private List<Node> _nodes = new List<Node>();
        private readonly BindingSource _source = new BindingSource();

        public Model()
        {
            _source.DataSource = _nodes;
        }

        public void SetBoundingBox(int minX, int maxX, int minY, int maxY)
        {
            var width = (maxX - minX) + 1;
            var heigth = (maxY - minY) + 1;

            SizeX = width;
            SizeY = heigth;

            foreach (var node in GetNodes())
            {
                var scaleX = node.GridX - minX;
                var scaleY = node.GridY - minY;
                node.GridX = scaleX;
                node.GridY = scaleY;
            }
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

        public int FindNodeIndex(int x, int y)
        {
            int i = 0;
            foreach (var node in _nodes)
            {
                if (x == node.GridX && y == node.GridY)
                    return i;
                i++;
            }
            return -1;
        }

        public void DeleteNode(int x, int y)
        {
            Node test = FindNode(x, y);
            if (test == null)
                return;
            _nodes.Remove(test);
            _source.ResetBindings(false);
        }

        public void SetNodeNumber(int x, int y, int node)
        {
            Node test = FindNode(x, y);
            if (test == null)
                return;
            test.NodeNumber = node;
            _source.ResetBindings(false);
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

        public void ExportModel(string filename)
        {
            var cm = "";

            for (var x = 0; x <= SizeX + 1; x++) {
                for (var y = 0; y <= SizeY + 1; y++) {
                    var cell = "";
                    Node node = FindNode(y, x);
                    if (node != null) {
                        if (node.IsWired) {
                            cell = node.NodeNumber.ToString();
                        }
                        else {
                            cell = "1";
                        }
                    }
                    cm += cell + ",";
                }
                cm += ";";
            }

            cm = cm.TrimEnd(';');

            using (var f = new StreamWriter(filename))
            {
                f.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<custommodel \n");
                f.Write("name=\"{0}\" ", Name);
                f.Write("parm1=\"{0}\" ", SizeX);
                f.Write("parm2=\"{0}\" ", SizeY);
                f.Write("StringType=\"RGB Nodes\" ");
                f.Write("Transparency=\"0\" ");
                f.Write("PixelSize=\"2\" ");
                f.Write("ModelBrightness=\"\" ");
                f.Write("Antialias=\"1\" ");
                f.Write("StrandNames=\"\" ");
                f.Write("NodeNames=\"\" ");

                f.Write("CustomModel=\"");
                f.Write(cm);
                f.Write("\" ");
                f.Write("SourceVersion=\"2020.6\" ");
                f.Write(" >\n");

                f.Write("</custommodel>");
                f.Close();
            }
        }

        public BindingSource GetBinding()
        {
            return _source;
        }
    }
}