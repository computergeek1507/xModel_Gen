using System;
using System.IO;
using System.Windows.Forms;
using netDxf;

namespace xModel_Gen
{
    public partial class Form1 : Form
    {
        private DxfDocument _doc;

        private readonly Model _model = new Model();

        public Form1()
        {
            InitializeComponent();

            listDataGridView.AutoGenerateColumns = false;
            listDataGridView.DataSource = null;
        }

        private void loadDXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dxfOpenFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    //Get the path of specified file
                    _doc = DxfDocument.Load(dxfOpenFileDialog.FileName);

                    var fileName = new FileInfo(dxfOpenFileDialog.FileName);
                    Text = "xModel Gen \"" + fileName.Name + "\"";
                    DrawDxf(_doc);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void DrawDxf(DxfDocument file)
        {
            _model.Name = file.Name;
            var minX = 10000000;
            var minY = 10000000;
            var maxX = 0;
            var maxY = 0;

            //foreach (Line entity in _doc.Lines)
            //{

            //}

            foreach (var entity in _doc.Arcs)
            {
            }

            foreach (var entity in _doc.Circles)
            {
                //pixel hole are about 0.5 inches or 0.25
                if (0.2 > entity.Radius || entity.Radius > 0.3) continue;

                var newX = (int) (entity.Center.X * 2.0);
                var newY = (int) (entity.Center.Y * 2.0);

                if (newX < minX)
                    minX = newX - 1;
                if (newY < minY)
                    minY = newY - 1;

                if (newX > maxX)
                    maxX = newX + 1;
                if (newY > maxY)
                    maxY = newY + 1;

                var newNode = new Node
                {
                    GridX = newX,
                    GridY = newY
                };
                _model.AddNode(newNode);
            }

            var width = maxX - minX;
            var heigth = maxY - minY;

            _model.SizeX = width;
            _model.SizeY = heigth;

            foreach (var node in _model.GetNodes())
            {
                var scaleX = _model.SizeX / 2 + node.GridX;
                var scaleY = _model.SizeY / 2 + node.GridY;
                node.GridX = scaleX;
                node.GridY = scaleY;
            }

            listDataGridView.DataSource = _model.GetBinding();
            DrawGrid();
        }

        private void DrawGrid()
        {
            while (nodesDataGridView.ColumnCount < _model.SizeX)
            {
                nodesDataGridView.Columns.Add("", "");
                nodesDataGridView.Columns[nodesDataGridView.ColumnCount - 1].Width = 20;
            }

            while (nodesDataGridView.RowCount < _model.SizeY) nodesDataGridView.Rows.Add();

            foreach (var node in _model.GetNodes())
            {
                var value = "X";
                if (node.IsWired)
                    value = node.NodeNumber.ToString();
                nodesDataGridView[node.GridX, node.GridY].Value = value;
            }
        }

        private void listDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > _model.GetNodeCount() - 1)
                return;
            if (e.RowIndex < 0)
                return;

            var x = _model.GetNode(e.RowIndex).GridX;
            var y = _model.GetNode(e.RowIndex).GridY;

            nodesDataGridView.ClearSelection();
            nodesDataGridView.Rows[y].Cells[x].Selected = true;
        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private async void GenerateCustomModel()
        {
            xModelSaveFileDialog.FileName = _model.Name;
            if (xModelSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var cm = "";

                var filename = xModelSaveFileDialog.FileName;
                for (var i = 0; i < nodesDataGridView.RowCount; i++)
                {
                    for (var j = 0; j < nodesDataGridView.ColumnCount; j++)
                    {
                        var cell = "";
                        if (nodesDataGridView[j, i].Value != null)
                        {
                            cell = nodesDataGridView[j, i].Value.ToString();
                            if (cell == "X")
                                cell = "1";
                        }

                        cm += cell + ",";
                    }

                    cm += ";";
                }

                cm = cm.TrimEnd(';');

                using (var f = new StreamWriter(filename))
                {
                    f.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<custommodel \n");
                    f.Write("name=\"{0}\" ", _model.Name);
                    f.Write("parm1=\"{0}\" ", _model.SizeX);
                    f.Write("parm2=\"{0}\" ", _model.SizeY);
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
                    f.Write("SourceVersion=\"2019.13\" ");
                    f.Write(" >\n");

                    f.Write("</custommodel>");
                    f.Close();
                }
            }
        }

        private void saveXModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateCustomModel();
        }

        private void listDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > _model.GetNodeCount() - 1)
                return;
            if (e.RowIndex < 0)
                return;
            var text = listDataGridView.Columns[e.ColumnIndex].Name;
            if (text == "Node")
            {
                var newNode = listDataGridView.Rows[e.RowIndex]
                    .Cells["Node"].Value.ToString();
                var worked = int.TryParse(newNode, out var node);
                if (worked)
                    _model.SetNodeNumber(e.RowIndex, node);
            }

            listDataGridView.Refresh();

            DrawGrid();
        }

        private void wireFromSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoWire();
        }

        private async void AutoWire()
        {
            //clear old wiring
            _model.ClearWiring();

            var x = nodesDataGridView.CurrentCell.ColumnIndex;
            var y = nodesDataGridView.CurrentCell.RowIndex;

            var num = 1;
            //find first cell
            var found = _model.FindNode(x, y);

            if (found == null)
            {
                MessageBox.Show("Starting Node Not Found", "Starting Node Not Found");
                return;
            }

            found.NodeNumber = 1;

            var i = 0;
            while (num < _model.GetNodeCount())
            {
                i++;
                var distance = 10000;
                Node _foundnode = null;
                foreach (var node in _model.GetNodes())
                {
                    if (node.IsWired)
                        continue;
                    var newdist = GetDistance(x, y, node.GridX, node.GridY);
                    if (newdist < distance)
                    {
                        distance = newdist;
                        _foundnode = node;
                    }
                }

                if (_foundnode != null)
                {
                    num++;
                    _foundnode.NodeNumber = num;
                    x = _foundnode.GridX;
                    y = _foundnode.GridY;
                }
                else
                {
                    MessageBox.Show("Node is Null", "Node is Null");
                    break;
                }

                if (i > 10000000)
                {
                    MessageBox.Show("Loop error", "Loop error");
                    break;
                }
            }

            _model.SortNodes();
            listDataGridView.Refresh();
            DrawGrid();
        }

        private static int GetDistance(double x1, double y1, double x2, double y2)
        {
            return (int) Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}