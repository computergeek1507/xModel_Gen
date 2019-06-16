using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using netDxf;
using netDxf.Collections;
using netDxf.Entities;

namespace xModel_Gen
{
    public partial class Form1 : Form
    {
        private DxfDocument _doc;

        private ProgressDialog _progess;

        private readonly Model _model = new Model();

        public Form1()
        {
            InitializeComponent();

            listDataGridView.AutoGenerateColumns = false;
            listDataGridView.DataSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadDXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dxfOpenFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    _model.GetNodes().Clear();
                    //Get the path of specified file
                    _doc = DxfDocument.Load(dxfOpenFileDialog.FileName);

                    if (_doc == null)
                    {
                        MessageBox.Show("Failed to Load DXF File", "Error");
                        return;
                    }

                    var fileName = new FileInfo(dxfOpenFileDialog.FileName);
                    Text = "xModel Gen \"" + fileName.Name + "\"";
                    DrawDxf(_doc);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    MessageBox.Show(exception.Message, "Error");
                }
        }

        private void LoadMattDXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dxfOpenFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    _model.GetNodes().Clear();
                    //Get the path of specified file

                    var fileName = new FileInfo(dxfOpenFileDialog.FileName);
                    Text = "xModel Gen \"" + fileName.Name + "\"";

                    ReadMattJohnsonFile(dxfOpenFileDialog.FileName, Path.GetFileNameWithoutExtension(fileName.Name));

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    MessageBox.Show(exception.Message, "Error");
                }
        }

        private void wireFromSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoWire();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void upAndDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WireUpandDowm();
        }

        private void leftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WireLeftToRight();
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

        private void NodesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var x = nodesDataGridView.CurrentCell.ColumnIndex;
            var y = nodesDataGridView.CurrentCell.RowIndex;
            if (Control.ModifierKeys == Keys.Shift)
            {
                _model.DeleteNode(x, y);
                nodesDataGridView[x, y].Value = string.Empty;
            }
            else
            {
                if (checkBoxActive.Checked)
                {
                    _model.SetNodeNumber(x, y, decimal.ToInt32(numericUpDownChannel.Value));
                    DrawGrid();
                    if (checkBoxIncrement.Checked)
                    {
                        numericUpDownChannel.Value = numericUpDownChannel.Value + 1;
                    }
                }
            }
        }

        private void NodesDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var x = nodesDataGridView.CurrentCell.ColumnIndex;
            var y = nodesDataGridView.CurrentCell.RowIndex;

            _model.DeleteNode(x, y);
            nodesDataGridView[x, y].Value = string.Empty;
        }

        private void DrawDxf(DxfDocument file)
        {
            _model.Name = file.Name;
            var minX = 10000000;
            var minY = 10000000;
            var maxX = 0;
            var maxY = 0;

            foreach (LwPolyline entity in _doc.LwPolylines)
            {
                if(!entity.IsClosed)
                    continue;
                int count = entity.Vertexes.Count;
                if (count == 10)
                {
                    double minNodeX = 10000000.0;
                    double minNodeY = 10000000.0;
                    double maxNodeX = 0.0;
                    double maxNodeY = 0.0;

                    foreach (LwPolylineVertex pt in entity.Vertexes)
                    {
                        if (pt.Position.X < minNodeX)
                            minNodeX = pt.Position.X;
                        if (pt.Position.Y < minNodeY)
                            minNodeY = pt.Position.Y;

                        if (pt.Position.X > maxNodeX)
                            maxNodeX = pt.Position.X;
                        if (pt.Position.Y > maxNodeY)
                            maxNodeY = pt.Position.Y;
                    }

                    double dist = maxNodeX - minNodeX;
                    if (0.4 > dist || dist > 0.7) continue;

                    double centerX = (maxNodeX + minNodeX) / 2.0;
                    double centerY = (maxNodeY + minNodeY) / 2.0;

                    int t = count;

                    var newX = (int)(centerX * 2.0);
                    var newY = (int)(centerY * 2.0);

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
            }

            foreach (var entity in _doc.Arcs)
            {
            }

            foreach (var entity in _doc.Circles)
            {
                //pixel hole are about 0.5 inches or 0.25
                if (0.2 > entity.Radius || entity.Radius > 0.3) continue;

                var newX = (int)(entity.Center.X * 2.0);
                var newY = (int)(entity.Center.Y * 2.0);

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
                //var scaleX = _model.SizeX / 2 + node.GridX;
                //var scaleY = _model.SizeY / 2 + node.GridY;
                var scaleX =  node.GridX - minX;
                var scaleY =  node.GridY - minY;
                Debug.WriteLine(scaleX);
                Debug.WriteLine(scaleY);
                node.GridX = scaleX;
                node.GridY = scaleY;
            }

            listDataGridView.DataSource = _model.GetBinding();
            DrawGrid();
        }

        private void ReadMattJohnsonFile(string filesPath, string fname)
        {
            _model.Name = fname;
            var minX = 10000000;
            var minY = 10000000;
            var maxX = 0;
            var maxY = 0;

            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(filesPath);
            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                if (line.StartsWith("AcDbBlockReference"))
                {
                    file.ReadLine();
                    string name = file.ReadLine();
                    if (!name.StartsWith("*U"))
                    {
                        continue;
                    }
                    file.ReadLine();
                    string strX = file.ReadLine();
                    file.ReadLine();
                    string strY = file.ReadLine();
                    double centX = double.Parse(strX);
                    double centY = double.Parse(strY);

                    var newX = (int)(centX);
                    var newY = (int)(centY);

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
            }

            file.Close();

            var width = maxX - minX;
            var heigth = maxY - minY;

            _model.SizeX = width;
            _model.SizeY = heigth;

            foreach (var node in _model.GetNodes())
            {
                //var scaleX = _model.SizeX / 2 + node.GridX;
                //var scaleY = _model.SizeY / 2 + node.GridY;
                var scaleX = node.GridX - minX;
                var scaleY = node.GridY - minY;
                Debug.WriteLine(scaleX);
                Debug.WriteLine(scaleY);
                node.GridX = scaleX;
                node.GridY = scaleY;
            }

            listDataGridView.DataSource = _model.GetBinding();
            DrawGrid();
        }

        private void DrawGrid()
        {
            while (nodesDataGridView.ColumnCount <= _model.SizeX)
            {
                nodesDataGridView.Columns.Add("", "");
                nodesDataGridView.Columns[nodesDataGridView.ColumnCount - 1].Width = 20;
            }

            while (nodesDataGridView.RowCount <= _model.SizeY) nodesDataGridView.Rows.Add();

            foreach (var node in _model.GetNodes())
            {
                var value = "X";
                if (node.IsWired)
                    value = node.NodeNumber.ToString();
                Debug.WriteLine(node.GridX);
                Debug.WriteLine(node.GridY);
                nodesDataGridView[node.GridX, node.GridY].Value = value;
            }
        }

        private void GenerateCustomModel()
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

        private void AutoWire()
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
                Node foundnode = null;
                foreach (var node in _model.GetNodes())
                {
                    if (node.IsWired)
                        continue;
                    var newdist = ModelUtils.GetDistance(x, y, node.GridX, node.GridY);
                    if (newdist < distance)
                    {
                        distance = newdist;
                        foundnode = node;
                    }
                }

                if (foundnode != null)
                {
                    num++;
                    foundnode.NodeNumber = num;
                    x = foundnode.GridX;
                    y = foundnode.GridY;
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

        private void BetterAutoWire()
        {
            _progess = new ProgressDialog();
            _progess.Show();
            AutoSort sort = new AutoSort(_model);
            sort.ListSizeSent += ProgressSizeUpdated;
            sort.ProgressSent += ProgressUpdated;

            _model.ClearWiring();

            var x = nodesDataGridView.CurrentCell.ColumnIndex;
            var y = nodesDataGridView.CurrentCell.RowIndex;

            bool worked = sort.WireModel(x, y);

            _progess.Close();

            _model.SortNodes();
            listDataGridView.Refresh();
            DrawGrid();
            MessageBox.Show(worked ? "Worked!" : "Didn't Work:(");
        }

        private void ProgressSizeUpdated(object sender, int e)
        {
            _progess.ProgressMaximum = e;
        }

        private void ProgressUpdated(object sender, ProgressEventArgs e)
        {
            _progess.Message = e.Message;
            _progess.ProgressValue = e.Progress;
            if (e.NodeUpdated != null)
            {
                var value = "X";
                if (e.NodeUpdated.IsWired)
                    value = e.NodeUpdated.NodeNumber.ToString();
                Debug.WriteLine(e.NodeUpdated.GridX);
                Debug.WriteLine(e.NodeUpdated.GridY);
                nodesDataGridView[e.NodeUpdated.GridX, e.NodeUpdated.GridY].Value = value;
                nodesDataGridView.Rows[e.NodeUpdated.GridY].Cells[e.NodeUpdated.GridX].Selected = true;
            }
            listDataGridView.Refresh();
            Application.DoEvents();
        }

        private void WireUpandDowm()
        {
            //clear old wiring
            _model.ClearWiring();
            int nodeNum = 1;
            for (int x = 0; x < nodesDataGridView.ColumnCount; x++ )
            {
                for (int y = 0; y < nodesDataGridView.RowCount; y++)
                {
                    var found = _model.FindNode(x, y);

                    if (found != null)
                    {
                        found.NodeNumber = nodeNum;
                        nodeNum++;
                    }
                }
            }

            _model.SortNodes();
            listDataGridView.Refresh();
            DrawGrid();
        }

        private void WireLeftToRight()
        {
            //clear old wiring
            _model.ClearWiring();
            int nodeNum = 1;
            for (int y = 0; y < nodesDataGridView.RowCount; y++)
            {
                for (int x = 0; x < nodesDataGridView.ColumnCount; x++)
                {
                    var found = _model.FindNode(x, y);

                    if (found != null)
                    {
                        found.NodeNumber = nodeNum;
                        nodeNum++;
                    }
                }
            }

            _model.SortNodes();
            listDataGridView.Refresh();
            DrawGrid();
        }

        private void betterAutoWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BetterAutoWire();
        }    

    }
}