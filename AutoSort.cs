using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModel_Gen
{

    public class AutoSort
    {
        public event EventHandler<int> ListSizeSent;
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);
        public ProgressEventHandler ProgressSent;
        //public event EventHandler<int> ProgressSent;

        private readonly Model _model;

        bool _worked = false;

        List<Node> _doneNodes = new List<Node>();

        int _wireGap = 5;

        public AutoSort(Model model, int wireGap)
        {
            _model = model;
            _wireGap = wireGap;
        }

        public bool GetWorked() { return _worked; }

        public List<Node> GetNodes() { return _doneNodes; }

        void OnListSizeSent(int size) => ListSizeSent.Invoke(this, size);
        void OnProgressSent(ProgressEventArgs progress) => ProgressSent.Invoke(this, progress);

        void OnProgressSent(string message, int progress, Node node = null)
        {
            OnProgressSent(new ProgressEventArgs
            {
                Message = message,
                Progress = progress,
                NodeUpdated = node
            });
        }

        public bool WireModel(int startX, int startY)
        {
            OnListSizeSent(_model.GetNodeCount() * 2);
            for (int i = 0; i < _model.GetNodeCount(); i++)
            {
                //find nodes within 6 inches
                Node first = _model.GetNode(i);
                //OnProgressSent(first.ToString(), i);
                first.Id = i;
                for (int j = 0; j < _model.GetNodeCount(); j++)
                {
                    Node second = _model.GetNode(j);
                    if (first.GridX == second.GridX && first.GridY == second.GridY)
                        continue;

                    int dist = ModelUtils.GetDistance(first, second);
                    if (dist <= _wireGap)
                    {
                        first.CloseIds.Add(j);
                        //second.CloseIds.Add(i);
                    }
                }
            }

            //OnListSizeSent()
            int count = 1;
            Node start = _model.FindNode(startX, startY);
            if (start == null)
            {
                return false;
            }

            start.NodeNumber = count;
            count++;

            return WireNodes(start, count, _model.GetNodes());

            return true;
        }

        private bool WireNodes(Node start, int count, List<Node> nodes)
        {
            if ((_model.GetNodeCount() + 1) == count )
            {
                //start.NodeNumber = count;
                _doneNodes = (List<Node>)Model.DeepClone(nodes);
                _worked = true;
                return true;
            }
            //if ((_model.GetNodeCount()) == count)
            //{
            //    //start.NodeNumber = count;
            //    _doneNodes = (List<Node>)Model.DeepClone(nodes);
            //    return true;
            //}

            bool returnValue = false;

            for (int i = 0; i < start.CloseIds.Count(); ++i)
            {
                if (nodes[start.CloseIds[i]].IsWired)
                    continue;
                List<Node> newNodes = (List<Node>)Model.DeepClone(nodes);

                Node node = (Node)Model.DeepClone(newNodes[start.CloseIds[i]]);
                newNodes[start.CloseIds[i]].NodeNumber = count;
                int newcount = count;
                newcount++;
                returnValue =! WireNodes(node, newcount, newNodes);
            }
            //OnProgressSent(_model.ToString(), _model.GetNodeCount() + count, start);

            //if (_model.GetNodeCount() == count)
            //{
                //start.NodeNumber = count;
               // _doneNodes = (List<Node>)Model.DeepClone(nodes);
               // return true;
            //}



            return returnValue;
        }

    }
}
