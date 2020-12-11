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
                    ClearGrid();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            _model.SetBoundingBox(minX, maxX, minY, maxY);

            listDataGridView.DataSource = _model.GetBinding();
            DrawGrid();
        }

        private void ClearGrid()
        {
            nodesDataGridView.Rows.Clear();
            nodesDataGridView.Refresh();
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

                nodesDataGridView[node.GridX, node.GridY].Value = value;
            }
        }

        private void GenerateCustomModel()
        {
            xModelSaveFileDialog.FileName = _model.Name;
            if (xModelSaveFileDialog.ShowDialog() == DialogResult.OK) {
                _model.ExportModel(xModelSaveFileDialog.FileName);
            }
        }

        private void BetterAutoWire(int wireGap)
        {
            _progess = new ProgressDialog();
            _progess.Show();
            AutoSort sort = new AutoSort(_model, wireGap);
            sort.ListSizeSent += ProgressSizeUpdated;
            sort.ProgressSent += ProgressUpdated;

            _model.ClearWiring();

            //get starting position
            var x = nodesDataGridView.CurrentCell.ColumnIndex;
            var y = nodesDataGridView.CurrentCell.RowIndex;

            sort.WireModel(x, y);
            bool worked = sort.GetWorked();
            _progess.Close();

            if (worked)
            {
                int order = 1;
                foreach (int index in sort.GetIndexes())
                {
                    _model.GetNode(index).NodeNumber = order;
                    order++;
                }
                _model.SortNodes();

            }
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

                nodesDataGridView[e.NodeUpdated.GridX, e.NodeUpdated.GridY].Value = value;
                nodesDataGridView.Rows[e.NodeUpdated.GridY].Cells[e.NodeUpdated.GridX].Selected = true;
            }
            listDataGridView.Refresh();
            Application.DoEvents();
        }

        private void betterAutoWireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int gap = (int)numericUpDownGap.Value;
            BetterAutoWire(gap);
        }    

    }
}