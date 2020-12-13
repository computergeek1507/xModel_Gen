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

        List<int> _doneIndexs = new List<int>();

        int _wireGap = 5;

        public AutoSort(Model model, int wireGap)
        {
            _model = model;
            _wireGap = wireGap;
        }

        public bool GetWorked() { return _worked; }

        public List<int> GetIndexes() { return _doneIndexs; }

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
            OnListSizeSent(_model.GetNodeCount() + 1);

            List<Node> Nodes = (List<Node>)Model.DeepClone(_model.GetNodes());

            int index = _model.FindNodeIndex(startX, startY);

            if (index == -1)
                return false;

            List<int> nodesUsed = new List<int>();
            nodesUsed.Add(index);
            int count = 0;

            wireNode(Nodes, count, nodesUsed);

            return true;
        }

        void wireNode(List<Node> nodes, int count,  List<int> wiredIndex)
        {
            if (count + 1 >= nodes.Count())
            {
                if (wiredIndex.Count() == nodes.Count())
                {
                    _doneIndexs = wiredIndex;
                    _worked = true;

                }
                return;
            }
            OnProgressSent(wiredIndex.Count().ToString(), count);

            for (int i = 0; i < nodes.Count(); ++i)
            {
                if (wiredIndex.Contains(i))
                    continue;

                double dist = ModelUtils.GetDistance(nodes[wiredIndex[count]], nodes[i]);
                if (dist <= _wireGap)
                {
                    List<int> newwiredIndex = new List<int>(wiredIndex.ToArray());
                    newwiredIndex.Add(i);
                    int newCount = count;
                    newCount++;
                    wireNode(nodes, newCount, newwiredIndex);
                }
            }
        }
    }
}
