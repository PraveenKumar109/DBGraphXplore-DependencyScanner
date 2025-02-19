namespace DBDependancyGenerationApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DBDependancyDataGridView = new DataGridView();
            NoColumn = new DataGridViewTextBoxColumn();
            SourceDatabaseNameColumn = new DataGridViewTextBoxColumn();
            SourceSchemaNameColumn = new DataGridViewTextBoxColumn();
            SourceTypeDescriptionColumn = new DataGridViewTextBoxColumn();
            SourceProcedureNameColumn = new DataGridViewTextBoxColumn();
            ReferencedDatabaseNameColumn = new DataGridViewTextBoxColumn();
            ReferencedSchemaNameColumn = new DataGridViewTextBoxColumn();
            ReferencedDataTypeColumn = new DataGridViewImageColumn();
            ReferencedTypeDescriptionColumn = new DataGridViewTextBoxColumn();
            ReferencedObjectColumn = new DataGridViewTextBoxColumn();
            DependenciesContextMenuStrip = new ContextMenuStrip(components);
            showAllChildDependencyToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            ScanToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            LoadDataToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            SaveToolStripButton = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            IngestDataToolStripButton = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            ExportToNeo4JToolStripButton = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            GenerateDocumentToolStripButton = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            ConfigurationToolStripButton = new ToolStripButton();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            statusStrip1 = new StatusStrip();
            StatusLabelToolStripStatusLabel = new ToolStripStatusLabel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            SourceRoutineDataGridView = new DataGridView();
            NoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DatabaseNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            SchemaNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            NameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ViewDefinitionColumn = new DataGridViewButtonColumn();
            DependencyViewColumn = new DataGridViewButtonColumn();
            Panel1 = new Panel();
            SourceObjectNameList1ComboBox = new ComboBox();
            label1 = new Label();
            SourceObjectTypeList1ComboBox = new ComboBox();
            label2 = new Label();
            SourceDatabaseList1ComboBox = new ComboBox();
            label3 = new Label();
            FilterPanel1Button = new Button();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            SourceObjectTypeList2ComboBox = new ComboBox();
            label9 = new Label();
            DependentDatabaseList2ComboBox = new ComboBox();
            label8 = new Label();
            DependentObjectNameList2ComboBox = new ComboBox();
            label7 = new Label();
            DependentObjectTypeList2ComboBox = new ComboBox();
            SourceObjectNameList2ComboBox = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            SourceDatabaseList2ComboBox = new ComboBox();
            label6 = new Label();
            FilterPanel2Button = new Button();
            imageList1 = new ImageList(components);
            AnalyseCodeToolStripButton = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)DBDependancyDataGridView).BeginInit();
            DependenciesContextMenuStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SourceRoutineDataGridView).BeginInit();
            Panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // DBDependancyDataGridView
            // 
            DBDependancyDataGridView.AllowUserToAddRows = false;
            DBDependancyDataGridView.AllowUserToDeleteRows = false;
            DBDependancyDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            DBDependancyDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DBDependancyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DBDependancyDataGridView.Columns.AddRange(new DataGridViewColumn[] { NoColumn, SourceDatabaseNameColumn, SourceSchemaNameColumn, SourceTypeDescriptionColumn, SourceProcedureNameColumn, ReferencedDatabaseNameColumn, ReferencedSchemaNameColumn, ReferencedDataTypeColumn, ReferencedTypeDescriptionColumn, ReferencedObjectColumn });
            DBDependancyDataGridView.ContextMenuStrip = DependenciesContextMenuStrip;
            DBDependancyDataGridView.Dock = DockStyle.Fill;
            DBDependancyDataGridView.Location = new Point(3, 72);
            DBDependancyDataGridView.Name = "DBDependancyDataGridView";
            DBDependancyDataGridView.RowHeadersVisible = false;
            DBDependancyDataGridView.RowHeadersWidth = 51;
            DBDependancyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBDependancyDataGridView.Size = new Size(1290, 508);
            DBDependancyDataGridView.TabIndex = 2;
            DBDependancyDataGridView.CellContentClick += DBDependancyDataGridView_CellContentClick;
            // 
            // NoColumn
            // 
            NoColumn.FillWeight = 50F;
            NoColumn.HeaderText = "No";
            NoColumn.MinimumWidth = 6;
            NoColumn.Name = "NoColumn";
            NoColumn.Width = 50;
            // 
            // SourceDatabaseNameColumn
            // 
            SourceDatabaseNameColumn.FillWeight = 150F;
            SourceDatabaseNameColumn.HeaderText = "Source DB Name";
            SourceDatabaseNameColumn.MinimumWidth = 6;
            SourceDatabaseNameColumn.Name = "SourceDatabaseNameColumn";
            SourceDatabaseNameColumn.Width = 150;
            // 
            // SourceSchemaNameColumn
            // 
            SourceSchemaNameColumn.HeaderText = "Schema Name";
            SourceSchemaNameColumn.MinimumWidth = 6;
            SourceSchemaNameColumn.Name = "SourceSchemaNameColumn";
            SourceSchemaNameColumn.Width = 125;
            // 
            // SourceTypeDescriptionColumn
            // 
            SourceTypeDescriptionColumn.FillWeight = 150F;
            SourceTypeDescriptionColumn.HeaderText = "Object Type";
            SourceTypeDescriptionColumn.MinimumWidth = 10;
            SourceTypeDescriptionColumn.Name = "SourceTypeDescriptionColumn";
            SourceTypeDescriptionColumn.Width = 150;
            // 
            // SourceProcedureNameColumn
            // 
            SourceProcedureNameColumn.FillWeight = 250F;
            SourceProcedureNameColumn.HeaderText = "Procedure Name";
            SourceProcedureNameColumn.MinimumWidth = 6;
            SourceProcedureNameColumn.Name = "SourceProcedureNameColumn";
            SourceProcedureNameColumn.Width = 250;
            // 
            // ReferencedDatabaseNameColumn
            // 
            ReferencedDatabaseNameColumn.HeaderText = "Dependant DB Name";
            ReferencedDatabaseNameColumn.MinimumWidth = 6;
            ReferencedDatabaseNameColumn.Name = "ReferencedDatabaseNameColumn";
            ReferencedDatabaseNameColumn.Width = 125;
            // 
            // ReferencedSchemaNameColumn
            // 
            ReferencedSchemaNameColumn.HeaderText = "Schema Name";
            ReferencedSchemaNameColumn.MinimumWidth = 6;
            ReferencedSchemaNameColumn.Name = "ReferencedSchemaNameColumn";
            ReferencedSchemaNameColumn.Width = 125;
            // 
            // ReferencedDataTypeColumn
            // 
            ReferencedDataTypeColumn.FillWeight = 30F;
            ReferencedDataTypeColumn.HeaderText = "T";
            ReferencedDataTypeColumn.MinimumWidth = 6;
            ReferencedDataTypeColumn.Name = "ReferencedDataTypeColumn";
            ReferencedDataTypeColumn.Resizable = DataGridViewTriState.True;
            ReferencedDataTypeColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            ReferencedDataTypeColumn.Width = 30;
            // 
            // ReferencedTypeDescriptionColumn
            // 
            ReferencedTypeDescriptionColumn.FillWeight = 150F;
            ReferencedTypeDescriptionColumn.HeaderText = "Object Type";
            ReferencedTypeDescriptionColumn.MinimumWidth = 6;
            ReferencedTypeDescriptionColumn.Name = "ReferencedTypeDescriptionColumn";
            ReferencedTypeDescriptionColumn.Width = 150;
            // 
            // ReferencedObjectColumn
            // 
            ReferencedObjectColumn.FillWeight = 250F;
            ReferencedObjectColumn.HeaderText = "Referenced Object";
            ReferencedObjectColumn.MinimumWidth = 50;
            ReferencedObjectColumn.Name = "ReferencedObjectColumn";
            ReferencedObjectColumn.Width = 250;
            // 
            // DependenciesContextMenuStrip
            // 
            DependenciesContextMenuStrip.ImageScalingSize = new Size(20, 20);
            DependenciesContextMenuStrip.Items.AddRange(new ToolStripItem[] { showAllChildDependencyToolStripMenuItem });
            DependenciesContextMenuStrip.Name = "contextMenuStrip1";
            DependenciesContextMenuStrip.Size = new Size(262, 28);
            // 
            // showAllChildDependencyToolStripMenuItem
            // 
            showAllChildDependencyToolStripMenuItem.Name = "showAllChildDependencyToolStripMenuItem";
            showAllChildDependencyToolStripMenuItem.Size = new Size(261, 24);
            showAllChildDependencyToolStripMenuItem.Text = "Show All Child Dependency";
            showAllChildDependencyToolStripMenuItem.Click += showAllChildDependencyToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.Control;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { ScanToolStripButton, toolStripSeparator2, LoadDataToolStripButton, toolStripSeparator1, SaveToolStripButton, toolStripSeparator3, IngestDataToolStripButton, toolStripSeparator4, ExportToNeo4JToolStripButton, toolStripSeparator5, GenerateDocumentToolStripButton, toolStripSeparator6, AnalyseCodeToolStripButton, toolStripSeparator7, ConfigurationToolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1304, 31);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // ScanToolStripButton
            // 
            ScanToolStripButton.Image = (Image)resources.GetObject("ScanToolStripButton.Image");
            ScanToolStripButton.ImageTransparentColor = Color.Magenta;
            ScanToolStripButton.Name = "ScanToolStripButton";
            ScanToolStripButton.Size = new Size(155, 28);
            ScanToolStripButton.Text = "Scan Dependancy";
            ScanToolStripButton.Click += ScanToolStripButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // LoadDataToolStripButton
            // 
            LoadDataToolStripButton.Image = (Image)resources.GetObject("LoadDataToolStripButton.Image");
            LoadDataToolStripButton.ImageTransparentColor = Color.Magenta;
            LoadDataToolStripButton.Name = "LoadDataToolStripButton";
            LoadDataToolStripButton.Size = new Size(106, 28);
            LoadDataToolStripButton.Text = "Load Data";
            LoadDataToolStripButton.Click += LoadDataToolStripButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // SaveToolStripButton
            // 
            SaveToolStripButton.Enabled = false;
            SaveToolStripButton.Image = (Image)resources.GetObject("SaveToolStripButton.Image");
            SaveToolStripButton.ImageTransparentColor = Color.Magenta;
            SaveToolStripButton.Name = "SaveToolStripButton";
            SaveToolStripButton.Size = new Size(68, 28);
            SaveToolStripButton.Text = "Save";
            SaveToolStripButton.Click += SaveToolStripButton_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // IngestDataToolStripButton
            // 
            IngestDataToolStripButton.Image = (Image)resources.GetObject("IngestDataToolStripButton.Image");
            IngestDataToolStripButton.ImageTransparentColor = Color.Magenta;
            IngestDataToolStripButton.Name = "IngestDataToolStripButton";
            IngestDataToolStripButton.Size = new Size(151, 28);
            IngestDataToolStripButton.Text = "Upload To Neo4J";
            IngestDataToolStripButton.Click += IngestDataToolStripButton_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 31);
            // 
            // ExportToNeo4JToolStripButton
            // 
            ExportToNeo4JToolStripButton.Image = (Image)resources.GetObject("ExportToNeo4JToolStripButton.Image");
            ExportToNeo4JToolStripButton.ImageTransparentColor = Color.Magenta;
            ExportToNeo4JToolStripButton.Name = "ExportToNeo4JToolStripButton";
            ExportToNeo4JToolStripButton.Size = new Size(196, 28);
            ExportToNeo4JToolStripButton.Text = "Export To Neo4J Format";
            ExportToNeo4JToolStripButton.Click += ExportToNeo4JToolStripButton_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 31);
            // 
            // GenerateDocumentToolStripButton
            // 
            GenerateDocumentToolStripButton.Image = (Image)resources.GetObject("GenerateDocumentToolStripButton.Image");
            GenerateDocumentToolStripButton.ImageTransparentColor = Color.Magenta;
            GenerateDocumentToolStripButton.Name = "GenerateDocumentToolStripButton";
            GenerateDocumentToolStripButton.Size = new Size(170, 28);
            GenerateDocumentToolStripButton.Text = "Generate Document";
            GenerateDocumentToolStripButton.Click += GenerateDocumentToolStripButton_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 31);
            // 
            // ConfigurationToolStripButton
            // 
            ConfigurationToolStripButton.Image = (Image)resources.GetObject("ConfigurationToolStripButton.Image");
            ConfigurationToolStripButton.ImageTransparentColor = Color.Magenta;
            ConfigurationToolStripButton.Name = "ConfigurationToolStripButton";
            ConfigurationToolStripButton.Size = new Size(128, 28);
            ConfigurationToolStripButton.Text = "Configuration";
            ConfigurationToolStripButton.Click += ConfigurationToolStripButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Dependancy File (Excel Files)|*.xlsx";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabelToolStripStatusLabel });
            statusStrip1.Location = new Point(0, 647);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1304, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelToolStripStatusLabel
            // 
            StatusLabelToolStripStatusLabel.Name = "StatusLabelToolStripStatusLabel";
            StatusLabelToolStripStatusLabel.Size = new Size(1289, 16);
            StatusLabelToolStripStatusLabel.Spring = true;
            StatusLabelToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 31);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1304, 616);
            tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(SourceRoutineDataGridView);
            tabPage1.Controls.Add(Panel1);
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1296, 585);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Source Object List";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // SourceRoutineDataGridView
            // 
            SourceRoutineDataGridView.AllowUserToAddRows = false;
            SourceRoutineDataGridView.AllowUserToDeleteRows = false;
            SourceRoutineDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.AliceBlue;
            SourceRoutineDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            SourceRoutineDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SourceRoutineDataGridView.Columns.AddRange(new DataGridViewColumn[] { NoDataGridViewTextBoxColumn, DatabaseNameDataGridViewTextBoxColumn, SchemaNameDataGridViewTextBoxColumn, TypeDataGridViewTextBoxColumn, NameDataGridViewTextBoxColumn, ViewDefinitionColumn, DependencyViewColumn });
            SourceRoutineDataGridView.Dock = DockStyle.Fill;
            SourceRoutineDataGridView.Location = new Point(3, 72);
            SourceRoutineDataGridView.Name = "SourceRoutineDataGridView";
            SourceRoutineDataGridView.RowHeadersVisible = false;
            SourceRoutineDataGridView.RowHeadersWidth = 51;
            SourceRoutineDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SourceRoutineDataGridView.Size = new Size(1290, 510);
            SourceRoutineDataGridView.TabIndex = 3;
            SourceRoutineDataGridView.CellClick += SourceRoutineDataGridView_CellClick;
            SourceRoutineDataGridView.CellContentClick += SourceRoutineDataGridView_CellContentClick;
            SourceRoutineDataGridView.Click += SourceRoutineDataGridView_Click;
            // 
            // NoDataGridViewTextBoxColumn
            // 
            NoDataGridViewTextBoxColumn.FillWeight = 50F;
            NoDataGridViewTextBoxColumn.HeaderText = "No";
            NoDataGridViewTextBoxColumn.MinimumWidth = 6;
            NoDataGridViewTextBoxColumn.Name = "NoDataGridViewTextBoxColumn";
            NoDataGridViewTextBoxColumn.Width = 50;
            // 
            // DatabaseNameDataGridViewTextBoxColumn
            // 
            DatabaseNameDataGridViewTextBoxColumn.FillWeight = 150F;
            DatabaseNameDataGridViewTextBoxColumn.HeaderText = "Database Name";
            DatabaseNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            DatabaseNameDataGridViewTextBoxColumn.Name = "DatabaseNameDataGridViewTextBoxColumn";
            DatabaseNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // SchemaNameDataGridViewTextBoxColumn
            // 
            SchemaNameDataGridViewTextBoxColumn.FillWeight = 200F;
            SchemaNameDataGridViewTextBoxColumn.HeaderText = "Schema Name";
            SchemaNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            SchemaNameDataGridViewTextBoxColumn.Name = "SchemaNameDataGridViewTextBoxColumn";
            SchemaNameDataGridViewTextBoxColumn.Width = 127;
            // 
            // TypeDataGridViewTextBoxColumn
            // 
            TypeDataGridViewTextBoxColumn.HeaderText = "Type";
            TypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn";
            TypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // NameDataGridViewTextBoxColumn
            // 
            NameDataGridViewTextBoxColumn.FillWeight = 200F;
            NameDataGridViewTextBoxColumn.HeaderText = "Name";
            NameDataGridViewTextBoxColumn.MinimumWidth = 6;
            NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn";
            NameDataGridViewTextBoxColumn.Width = 200;
            // 
            // ViewDefinitionColumn
            // 
            ViewDefinitionColumn.FillWeight = 150F;
            ViewDefinitionColumn.HeaderText = "Definition";
            ViewDefinitionColumn.MinimumWidth = 6;
            ViewDefinitionColumn.Name = "ViewDefinitionColumn";
            ViewDefinitionColumn.Text = "View";
            ViewDefinitionColumn.Width = 150;
            // 
            // DependencyViewColumn
            // 
            DependencyViewColumn.HeaderText = "Dependency";
            DependencyViewColumn.MinimumWidth = 6;
            DependencyViewColumn.Name = "DependencyViewColumn";
            DependencyViewColumn.Resizable = DataGridViewTriState.True;
            DependencyViewColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            DependencyViewColumn.Text = "Depencency";
            DependencyViewColumn.Width = 125;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.Transparent;
            Panel1.Controls.Add(SourceObjectNameList1ComboBox);
            Panel1.Controls.Add(label1);
            Panel1.Controls.Add(SourceObjectTypeList1ComboBox);
            Panel1.Controls.Add(label2);
            Panel1.Controls.Add(SourceDatabaseList1ComboBox);
            Panel1.Controls.Add(label3);
            Panel1.Controls.Add(FilterPanel1Button);
            Panel1.Dock = DockStyle.Top;
            Panel1.Location = new Point(3, 3);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(1290, 69);
            Panel1.TabIndex = 4;
            // 
            // SourceObjectNameList1ComboBox
            // 
            SourceObjectNameList1ComboBox.FormattingEnabled = true;
            SourceObjectNameList1ComboBox.Location = new Point(374, 36);
            SourceObjectNameList1ComboBox.Name = "SourceObjectNameList1ComboBox";
            SourceObjectNameList1ComboBox.Size = new Size(350, 26);
            SourceObjectNameList1ComboBox.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(374, 16);
            label1.Name = "label1";
            label1.Size = new Size(102, 19);
            label1.TabIndex = 25;
            label1.Text = "Object Name";
            // 
            // SourceObjectTypeList1ComboBox
            // 
            SourceObjectTypeList1ComboBox.FormattingEnabled = true;
            SourceObjectTypeList1ComboBox.Location = new Point(187, 36);
            SourceObjectTypeList1ComboBox.Name = "SourceObjectTypeList1ComboBox";
            SourceObjectTypeList1ComboBox.Size = new Size(181, 26);
            SourceObjectTypeList1ComboBox.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 16);
            label2.Name = "label2";
            label2.Size = new Size(95, 19);
            label2.TabIndex = 23;
            label2.Text = "Object Type";
            // 
            // SourceDatabaseList1ComboBox
            // 
            SourceDatabaseList1ComboBox.FormattingEnabled = true;
            SourceDatabaseList1ComboBox.Location = new Point(18, 36);
            SourceDatabaseList1ComboBox.Name = "SourceDatabaseList1ComboBox";
            SourceDatabaseList1ComboBox.Size = new Size(163, 26);
            SourceDatabaseList1ComboBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 16);
            label3.Name = "label3";
            label3.Size = new Size(125, 19);
            label3.TabIndex = 21;
            label3.Text = "Database Name";
            // 
            // FilterPanel1Button
            // 
            FilterPanel1Button.Image = (Image)resources.GetObject("FilterPanel1Button.Image");
            FilterPanel1Button.ImageAlign = ContentAlignment.MiddleLeft;
            FilterPanel1Button.Location = new Point(741, 32);
            FilterPanel1Button.Name = "FilterPanel1Button";
            FilterPanel1Button.Size = new Size(93, 30);
            FilterPanel1Button.TabIndex = 0;
            FilterPanel1Button.Text = "Filter";
            FilterPanel1Button.UseVisualStyleBackColor = true;
            FilterPanel1Button.Click += FilterPanel1Button_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(DBDependancyDataGridView);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1296, 583);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Dependencies List";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(SourceObjectTypeList2ComboBox);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(DependentDatabaseList2ComboBox);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(DependentObjectNameList2ComboBox);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(DependentObjectTypeList2ComboBox);
            panel3.Controls.Add(SourceObjectNameList2ComboBox);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(SourceDatabaseList2ComboBox);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(FilterPanel2Button);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1290, 69);
            panel3.TabIndex = 5;
            // 
            // SourceObjectTypeList2ComboBox
            // 
            SourceObjectTypeList2ComboBox.FormattingEnabled = true;
            SourceObjectTypeList2ComboBox.Location = new Point(184, 38);
            SourceObjectTypeList2ComboBox.Name = "SourceObjectTypeList2ComboBox";
            SourceObjectTypeList2ComboBox.Size = new Size(174, 26);
            SourceObjectTypeList2ComboBox.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.Maroon;
            label9.Location = new Point(182, 18);
            label9.Name = "label9";
            label9.Size = new Size(163, 19);
            label9.TabIndex = 21;
            label9.Text = "Source Object Type";
            // 
            // DependentDatabaseList2ComboBox
            // 
            DependentDatabaseList2ComboBox.FormattingEnabled = true;
            DependentDatabaseList2ComboBox.Location = new Point(597, 38);
            DependentDatabaseList2ComboBox.Name = "DependentDatabaseList2ComboBox";
            DependentDatabaseList2ComboBox.Size = new Size(167, 26);
            DependentDatabaseList2ComboBox.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label8.Location = new Point(595, 18);
            label8.Name = "label8";
            label8.Size = new Size(172, 19);
            label8.TabIndex = 19;
            label8.Text = "Dependent Database";
            // 
            // DependentObjectNameList2ComboBox
            // 
            DependentObjectNameList2ComboBox.FormattingEnabled = true;
            DependentObjectNameList2ComboBox.Location = new Point(950, 38);
            DependentObjectNameList2ComboBox.Name = "DependentObjectNameList2ComboBox";
            DependentObjectNameList2ComboBox.Size = new Size(210, 26);
            DependentObjectNameList2ComboBox.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label7.Location = new Point(947, 18);
            label7.Name = "label7";
            label7.Size = new Size(199, 19);
            label7.TabIndex = 17;
            label7.Text = "Dependent Object Name";
            // 
            // DependentObjectTypeList2ComboBox
            // 
            DependentObjectTypeList2ComboBox.FormattingEnabled = true;
            DependentObjectTypeList2ComboBox.Location = new Point(770, 38);
            DependentObjectTypeList2ComboBox.Name = "DependentObjectTypeList2ComboBox";
            DependentObjectTypeList2ComboBox.Size = new Size(174, 26);
            DependentObjectTypeList2ComboBox.TabIndex = 16;
            // 
            // SourceObjectNameList2ComboBox
            // 
            SourceObjectNameList2ComboBox.FormattingEnabled = true;
            SourceObjectNameList2ComboBox.Location = new Point(364, 38);
            SourceObjectNameList2ComboBox.Name = "SourceObjectNameList2ComboBox";
            SourceObjectNameList2ComboBox.Size = new Size(196, 26);
            SourceObjectNameList2ComboBox.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label4.Location = new Point(768, 18);
            label4.Name = "label4";
            label4.Size = new Size(192, 19);
            label4.TabIndex = 14;
            label4.Text = "Dependent Object Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Maroon;
            label5.Location = new Point(362, 18);
            label5.Name = "label5";
            label5.Size = new Size(170, 19);
            label5.TabIndex = 13;
            label5.Text = "Source Object Name";
            // 
            // SourceDatabaseList2ComboBox
            // 
            SourceDatabaseList2ComboBox.FormattingEnabled = true;
            SourceDatabaseList2ComboBox.Location = new Point(15, 38);
            SourceDatabaseList2ComboBox.Name = "SourceDatabaseList2ComboBox";
            SourceDatabaseList2ComboBox.Size = new Size(163, 26);
            SourceDatabaseList2ComboBox.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.Maroon;
            label6.Location = new Point(14, 18);
            label6.Name = "label6";
            label6.Size = new Size(143, 19);
            label6.TabIndex = 11;
            label6.Text = "Source Database";
            // 
            // FilterPanel2Button
            // 
            FilterPanel2Button.Image = (Image)resources.GetObject("FilterPanel2Button.Image");
            FilterPanel2Button.ImageAlign = ContentAlignment.MiddleLeft;
            FilterPanel2Button.Location = new Point(1166, 34);
            FilterPanel2Button.Name = "FilterPanel2Button";
            FilterPanel2Button.Size = new Size(93, 30);
            FilterPanel2Button.TabIndex = 10;
            FilterPanel2Button.Text = "    Filter";
            FilterPanel2Button.TextAlign = ContentAlignment.MiddleLeft;
            FilterPanel2Button.UseVisualStyleBackColor = true;
            FilterPanel2Button.Click += FilterPanel2Button_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "SQL_SCALAR_FUNCTION");
            imageList1.Images.SetKeyName(1, "view - details.ico");
            imageList1.Images.SetKeyName(2, "flag green.ico");
            imageList1.Images.SetKeyName(3, "TYPE");
            imageList1.Images.SetKeyName(4, "USER_TABLE");
            imageList1.Images.SetKeyName(5, "object bring to front-2.ico");
            imageList1.Images.SetKeyName(6, "SQL_STORED_PROCEDURE");
            // 
            // AnalyseCodeToolStripButton
            // 
            AnalyseCodeToolStripButton.Image = (Image)resources.GetObject("AnalyseCodeToolStripButton.Image");
            AnalyseCodeToolStripButton.ImageTransparentColor = Color.Magenta;
            AnalyseCodeToolStripButton.Name = "AnalyseCodeToolStripButton";
            AnalyseCodeToolStripButton.Size = new Size(123, 28);
            AnalyseCodeToolStripButton.Text = "AnalyseCode";
            AnalyseCodeToolStripButton.Click += AnalyseCodeToolStripButton_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 31);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1304, 669);
            Controls.Add(tabControl1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MainForm";
            Text = " Database Dependancy Generation Application";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)DBDependancyDataGridView).EndInit();
            DependenciesContextMenuStrip.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SourceRoutineDataGridView).EndInit();
            Panel1.ResumeLayout(false);
            Panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DBDependancyDataGridView;
        private ToolStrip toolStrip1;
        private ToolStripButton LoadDataToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SaveToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton ScanToolStripButton;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabelToolStripStatusLabel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView SourceRoutineDataGridView;
        private TabPage tabPage2;
        private Panel Panel1;
        private Panel panel3;
        private DataGridViewTextBoxColumn NoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DatabaseNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn SchemaNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn TypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn ViewDefinitionColumn;
        private DataGridViewButtonColumn DependencyViewColumn;
        private Button FilterPanel1Button;
        private ComboBox DependentDatabaseList2ComboBox;
        private Label label8;
        private ComboBox DependentObjectNameList2ComboBox;
        private Label label7;
        private ComboBox DependentObjectTypeList2ComboBox;
        private ComboBox SourceObjectNameList2ComboBox;
        private Label label4;
        private Label label5;
        private ComboBox SourceDatabaseList2ComboBox;
        private Label label6;
        private Button FilterPanel2Button;
        private ComboBox SourceObjectNameList1ComboBox;
        private Label label1;
        private ComboBox SourceObjectTypeList1ComboBox;
        private Label label2;
        private ComboBox SourceDatabaseList1ComboBox;
        private Label label3;
        private ContextMenuStrip DependenciesContextMenuStrip;
        private ToolStripMenuItem showAllChildDependencyToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton IngestDataToolStripButton;
        private ImageList imageList1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton ExportToNeo4JToolStripButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton ConfigurationToolStripButton;
        private DataGridViewTextBoxColumn NoColumn;
        private DataGridViewTextBoxColumn SourceDatabaseNameColumn;
        private DataGridViewTextBoxColumn SourceSchemaNameColumn;
        private DataGridViewTextBoxColumn SourceTypeDescriptionColumn;
        private DataGridViewTextBoxColumn SourceProcedureNameColumn;
        private DataGridViewTextBoxColumn ReferencedDatabaseNameColumn;
        private DataGridViewTextBoxColumn ReferencedSchemaNameColumn;
        private DataGridViewImageColumn ReferencedDataTypeColumn;
        private DataGridViewTextBoxColumn ReferencedTypeDescriptionColumn;
        private DataGridViewTextBoxColumn ReferencedObjectColumn;
        private ComboBox SourceObjectTypeList2ComboBox;
        private Label label9;
        private ToolStripButton GenerateDocumentToolStripButton;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton AnalyseCodeToolStripButton;
        private ToolStripSeparator toolStripSeparator7;
    }
}