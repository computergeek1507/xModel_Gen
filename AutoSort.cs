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

        public AutoSort(Model model)
        {
            _model = model;
        }

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
                OnProgressSent(first.ToString(), i);
                first.Id = i;
                for (int j = i + 1; j < _model.GetNodeCount(); j++)
                {
                    Node second = _model.GetNode(j);
                    int dist = ModelUtils.GetDistance(first, second);
                    if (dist < 9)
                    {
                        first.CloseIds.Add(j);
                        second.CloseIds.Add(i);
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

            //start.NodeNumber = count;
            //count++;

            return WireNodes(start, count);

            return true;
        }

        private bool WireNodes(Node start, int count)
        {
            OnProgressSent(_model.ToString(), _model.GetNodeCount() + count, start);
            Node newnode = GetNextNode(start);

            if (newnode != null)
            {
                start.NodeNumber = count;
                return WireNodes(newnode, count + 1);
            }

            if (_model.GetNodeCount() == count)
            {
                start.NodeNumber = count;
                return true;
            }

            if ((_model.GetNodeCount() + 1) == count)
            {
                start.NodeNumber = count;
                return true;
            }

            newnode = GetPrevousNode(start);
            //count--;
            //if (start.CloseIds.Count == 0)
             //   return false;
            //start.CloseIds.RemoveAt(0);
            //start.NodeNumber = 0;

            if (newnode != null)
            {
                return WireNodes(newnode, count - 1);
            }

            return false;
        }

        private Node GetNextNode(Node current)
        {
            Node newNode;
            do
            {
                int next = current.GetNextId();
                if (next == -1)
                {
                    return null;
                }
                newNode = _model.GetNode(next);
            } while (newNode.IsWired);
            newNode.PrevId = current.Id;
            return newNode;
        }
        private Node GetPrevousNode(Node current)
        {
            if (current.PrevId==-1)
            {
                return null;
            }

            int prev = current.GetPrevId();
            Node newNode = _model.GetNode(prev);
            return newNode;
        }
    }
}
