namespace xModel_Gen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveXModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wiringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireFromSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upAndDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxfOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xModelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.nodesDataGridView = new System.Windows.Forms.DataGridView();
            this.listDataGridView = new System.Windows.Forms.DataGridView();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.XGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.wiringToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1193, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDXFToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveXModelToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDXFToolStripMenuItem
            // 
            this.loadDXFToolStripMenuItem.Name = "loadDXFToolStripMenuItem";
            this.loadDXFToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.loadDXFToolStripMenuItem.Text = "Load DXF...";
            this.loadDXFToolStripMenuItem.Click += new System.EventHandler(this.loadDXFToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // saveXModelToolStripMenuItem
            // 
            this.saveXModelToolStripMenuItem.Name = "saveXModelToolStripMenuItem";
            this.saveXModelToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveXModelToolStripMenuItem.Text = "Save xModel";
            this.saveXModelToolStripMenuItem.Click += new System.EventHandler(this.saveXModelToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // wiringToolStripMenuItem
            // 
            this.wiringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireFromSelectedToolStripMenuItem,
            this.leftToRightToolStripMenuItem,
            this.upAndDownToolStripMenuItem});
            this.wiringToolStripMenuItem.Name = "wiringToolStripMenuItem";
            this.wiringToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.wiringToolStripMenuItem.Text = "Auto Wire";
            // 
            // wireFromSelectedToolStripMenuItem
            // 
            this.wireFromSelectedToolStripMenuItem.Name = "wireFromSelectedToolStripMenuItem";
            this.wireFromSelectedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wireFromSelectedToolStripMenuItem.Text = "Selected to Closest";
            this.wireFromSelectedToolStripMenuItem.ToolTipText = "Start at Selected then to Next Closest";
            this.wireFromSelectedToolStripMenuItem.Click += new System.EventHandler(this.wireFromSelectedToolStripMenuItem_Click);
            // 
            // leftToRightToolStripMenuItem
            // 
            this.leftToRightToolStripMenuItem.Name = "leftToRightToolStripMenuItem";
            this.leftToRightToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.leftToRightToolStripMenuItem.Text = "Left to Right";
            this.leftToRightToolStripMenuItem.ToolTipText = "Wire Left To Right on the Whole Grid";
            this.leftToRightToolStripMenuItem.Click += new System.EventHandler(this.leftToRightToolStripMenuItem_Click);
            // 
            // upAndDownToolStripMenuItem
            // 
            this.upAndDownToolStripMenuItem.Name = "upAndDownToolStripMenuItem";
            this.upAndDownToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.upAndDownToolStripMenuItem.Text = "Up and Down";
            this.upAndDownToolStripMenuItem.ToolTipText = "Wire Up To Down on the Whole Grid";
            this.upAndDownToolStripMenuItem.Click += new System.EventHandler(this.upAndDownToolStripMenuItem_Click);
            // 
            // dxfOpenFileDialog
            // 
            this.dxfOpenFileDialog.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*";
            this.dxfOpenFileDialog.RestoreDirectory = true;
            // 
            // xModelSaveFileDialog
            // 
            this.xModelSaveFileDialog.DefaultExt = "xmodel";
            this.xModelSaveFileDialog.Filter = "xmodel files (*.xmodel)|*.xmodel|All files (*.*)|*.*";
            this.xModelSaveFileDialog.RestoreDirectory = true;
            // 
            // nodesDataGridView
            // 
            this.nodesDataGridView.AllowUserToAddRows = false;
            this.nodesDataGridView.AllowUserToDeleteRows = false;
            this.nodesDataGridView.AllowUserToResizeColumns = false;
            this.nodesDataGridView.AllowUserToResizeRows = false;
            this.nodesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.nodesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodesDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.nodesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.nodesDataGridView.MultiSelect = false;
            this.nodesDataGridView.Name = "nodesDataGridView";
            this.nodesDataGridView.ReadOnly = true;
            this.nodesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.nodesDataGridView.ShowCellErrors = false;
            this.nodesDataGridView.ShowCellToolTips = false;
            this.nodesDataGridView.ShowEditingIcon = false;
            this.nodesDataGridView.ShowRowErrors = false;
            this.nodesDataGridView.Size = new System.Drawing.Size(963, 537);
            this.nodesDataGridView.TabIndex = 2;
            // 
            // listDataGridView
            // 
            this.listDataGridView.AllowUserToAddRows = false;
            this.listDataGridView.AllowUserToDeleteRows = false;
            this.listDataGridView.AllowUserToResizeColumns = false;
            this.listDataGridView.AllowUserToResizeRows = false;
            this.listDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.Wired,
            this.XGrid,
            this.YGrid});
            this.listDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDataGridView.Location = new System.Drawing.Point(0, 0);
            this.listDataGridView.MultiSelect = false;
            this.listDataGridView.Name = "listDataGridView";
            this.listDataGridView.RowHeadersVisible = false;
            this.listDataGridView.ShowCellErrors = false;
            this.listDataGridView.ShowCellToolTips = false;
            this.listDataGridView.ShowEditingIcon = false;
            this.listDataGridView.ShowRowErrors = false;
            this.listDataGridView.Size = new System.Drawing.Size(196, 537);
            this.listDataGridView.TabIndex = 3;
            this.listDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellContentClick);
            this.listDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellContentClick);
            this.listDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.listDataGridView_CellValueChanged);
            // 
            // Node
            // 
            this.Node.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Node.DataPropertyName = "NodeNumber";
            this.Node.HeaderText = "Node";
            this.Node.Name = "Node";
            this.Node.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Node.Width = 58;
            // 
            // Wired
            // 
            this.Wired.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Wired.DataPropertyName = "IsWired";
            this.Wired.FalseValue = "False";
            this.Wired.HeaderText = "Wired";
            this.Wired.Name = "Wired";
            this.Wired.ReadOnly = true;
            this.Wired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Wired.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Wired.TrueValue = "True";
            this.Wired.Width = 60;
            // 
            // XGrid
            // 
            this.XGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.XGrid.DataPropertyName = "GridX";
            this.XGrid.HeaderText = "LocX";
            this.XGrid.Name = "XGrid";
            this.XGrid.ReadOnly = true;
            this.XGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.XGrid.Width = 57;
            // 
            // YGrid
            // 
            this.YGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.YGrid.DataPropertyName = "GridY";
            this.YGrid.HeaderText = "LocY";
            this.YGrid.Name = "YGrid";
            this.YGrid.ReadOnly = true;
            this.YGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.YGrid.Width = 57;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nodesDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1169, 537);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 576);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "xModel Gen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDXFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveXModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wiringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftToRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upAndDownToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dxfOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog xModelSaveFileDialog;
        private System.Windows.Forms.DataGridView nodesDataGridView;
        private System.Windows.Forms.DataGridView listDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Wired;
        private System.Windows.Forms.DataGridViewTextBoxColumn XGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn YGrid;
        private System.Windows.Forms.ToolStripMenuItem wireFromSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

