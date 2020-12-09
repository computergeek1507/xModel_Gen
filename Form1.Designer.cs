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
            this.betterAutoWireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dxfOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xModelSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.nodesDataGridView = new System.Windows.Forms.DataGridView();
            this.listDataGridView = new System.Windows.Forms.DataGridView();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.XGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxIncrement = new System.Windows.Forms.CheckBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.numericUpDownChannel = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGap = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGap)).BeginInit();
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
            this.loadDXFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadDXFToolStripMenuItem.Text = "Load DXF...";
            this.loadDXFToolStripMenuItem.Click += new System.EventHandler(this.loadDXFToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveXModelToolStripMenuItem
            // 
            this.saveXModelToolStripMenuItem.Name = "saveXModelToolStripMenuItem";
            this.saveXModelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveXModelToolStripMenuItem.Text = "Save xModel";
            this.saveXModelToolStripMenuItem.Click += new System.EventHandler(this.saveXModelToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // wiringToolStripMenuItem
            // 
            this.wiringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireFromSelectedToolStripMenuItem,
            this.leftToRightToolStripMenuItem,
            this.upAndDownToolStripMenuItem,
            this.betterAutoWireToolStripMenuItem});
            this.wiringToolStripMenuItem.Name = "wiringToolStripMenuItem";
            this.wiringToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.wiringToolStripMenuItem.Text = "Auto Wire";
            // 
            // wireFromSelectedToolStripMenuItem
            // 
            this.wireFromSelectedToolStripMenuItem.Name = "wireFromSelectedToolStripMenuItem";
            this.wireFromSelectedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.wireFromSelectedToolStripMenuItem.Text = "Selected to Closest";
            this.wireFromSelectedToolStripMenuItem.ToolTipText = "Start at Selected then to Next Closest";
            this.wireFromSelectedToolStripMenuItem.Click += new System.EventHandler(this.wireFromSelectedToolStripMenuItem_Click);
            // 
            // leftToRightToolStripMenuItem
            // 
            this.leftToRightToolStripMenuItem.Name = "leftToRightToolStripMenuItem";
            this.leftToRightToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.leftToRightToolStripMenuItem.Text = "Left to Right";
            this.leftToRightToolStripMenuItem.ToolTipText = "Wire Left To Right on the Whole Grid";
            this.leftToRightToolStripMenuItem.Click += new System.EventHandler(this.leftToRightToolStripMenuItem_Click);
            // 
            // upAndDownToolStripMenuItem
            // 
            this.upAndDownToolStripMenuItem.Name = "upAndDownToolStripMenuItem";
            this.upAndDownToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.upAndDownToolStripMenuItem.Text = "Up and Down";
            this.upAndDownToolStripMenuItem.ToolTipText = "Wire Up To Down on the Whole Grid";
            this.upAndDownToolStripMenuItem.Click += new System.EventHandler(this.upAndDownToolStripMenuItem_Click);
            // 
            // betterAutoWireToolStripMenuItem
            // 
            this.betterAutoWireToolStripMenuItem.Name = "betterAutoWireToolStripMenuItem";
            this.betterAutoWireToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.betterAutoWireToolStripMenuItem.Text = "Better AutoWire";
            this.betterAutoWireToolStripMenuItem.Click += new System.EventHandler(this.betterAutoWireToolStripMenuItem_Click);
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
            this.nodesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
            this.nodesDataGridView.Size = new System.Drawing.Size(945, 536);
            this.nodesDataGridView.TabIndex = 2;
            this.nodesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NodesDataGridView_CellContentClick);
            this.nodesDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NodesDataGridView_CellContentDoubleClick);
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
            this.listDataGridView.Size = new System.Drawing.Size(196, 594);
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.nodesDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1169, 594);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxIncrement);
            this.groupBox1.Controls.Add(this.checkBoxActive);
            this.groupBox1.Controls.Add(this.numericUpDownChannel);
            this.groupBox1.Location = new System.Drawing.Point(119, 542);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 49);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Increment";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.numericUpDownGap);
            this.groupBox2.Location = new System.Drawing.Point(3, 542);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 49);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light Spacing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Node Count";
            // 
            // checkBoxIncrement
            // 
            this.checkBoxIncrement.AutoSize = true;
            this.checkBoxIncrement.Checked = true;
            this.checkBoxIncrement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncrement.Location = new System.Drawing.Point(68, 17);
            this.checkBoxIncrement.Name = "checkBoxIncrement";
            this.checkBoxIncrement.Size = new System.Drawing.Size(73, 17);
            this.checkBoxIncrement.TabIndex = 10;
            this.checkBoxIncrement.Text = "Increment";
            this.checkBoxIncrement.UseVisualStyleBackColor = true;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(6, 17);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 9;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // numericUpDownChannel
            // 
            this.numericUpDownChannel.Location = new System.Drawing.Point(217, 17);
            this.numericUpDownChannel.Name = "numericUpDownChannel";
            this.numericUpDownChannel.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownChannel.TabIndex = 8;
            this.numericUpDownChannel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownGap
            // 
            this.numericUpDownGap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownGap.Location = new System.Drawing.Point(6, 16);
            this.numericUpDownGap.Name = "numericUpDownGap";
            this.numericUpDownGap.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownGap.TabIndex = 13;
            this.numericUpDownGap.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 633);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGap)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem betterAutoWireToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownGap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxIncrement;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.NumericUpDown numericUpDownChannel;
    }
}

