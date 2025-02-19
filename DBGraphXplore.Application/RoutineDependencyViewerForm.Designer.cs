namespace DBDependancyGenerationApp
{
    partial class RoutineDependencyViewerForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DBDependancyDataGridView = new DataGridView();
            NoColumn = new DataGridViewTextBoxColumn();
            DependantDatabaseNameColumn = new DataGridViewTextBoxColumn();
            SchemaNameColumn = new DataGridViewTextBoxColumn();
            TypeDescriptionColumn = new DataGridViewTextBoxColumn();
            ReferencedObjectClassDescriptionColumn = new DataGridViewTextBoxColumn();
            ReferencedObjectColumn = new DataGridViewTextBoxColumn();
            CloseButton = new Button();
            treeView = new TreeView();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DBDependancyDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DBDependancyDataGridView
            // 
            DBDependancyDataGridView.AllowUserToAddRows = false;
            DBDependancyDataGridView.AllowUserToDeleteRows = false;
            DBDependancyDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.AliceBlue;
            DBDependancyDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            DBDependancyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DBDependancyDataGridView.Columns.AddRange(new DataGridViewColumn[] { NoColumn, DependantDatabaseNameColumn, SchemaNameColumn, TypeDescriptionColumn, ReferencedObjectClassDescriptionColumn, ReferencedObjectColumn });
            DBDependancyDataGridView.Dock = DockStyle.Fill;
            DBDependancyDataGridView.Location = new Point(0, 0);
            DBDependancyDataGridView.Name = "DBDependancyDataGridView";
            DBDependancyDataGridView.RowHeadersVisible = false;
            DBDependancyDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DBDependancyDataGridView.Size = new Size(704, 570);
            DBDependancyDataGridView.TabIndex = 3;
            // 
            // NoColumn
            // 
            NoColumn.FillWeight = 50F;
            NoColumn.HeaderText = "No";
            NoColumn.Name = "NoColumn";
            NoColumn.Width = 50;
            // 
            // DependantDatabaseNameColumn
            // 
            DependantDatabaseNameColumn.HeaderText = "DatabaseName";
            DependantDatabaseNameColumn.Name = "DependantDatabaseNameColumn";
            // 
            // SchemaNameColumn
            // 
            SchemaNameColumn.HeaderText = "SchemaName";
            SchemaNameColumn.Name = "SchemaNameColumn";
            // 
            // TypeDescriptionColumn
            // 
            TypeDescriptionColumn.HeaderText = "Type";
            TypeDescriptionColumn.Name = "TypeDescriptionColumn";
            // 
            // ReferencedObjectClassDescriptionColumn
            // 
            ReferencedObjectClassDescriptionColumn.HeaderText = "ClassDescription";
            ReferencedObjectClassDescriptionColumn.Name = "ReferencedObjectClassDescriptionColumn";
            // 
            // ReferencedObjectColumn
            // 
            ReferencedObjectColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReferencedObjectColumn.HeaderText = "ObjectName";
            ReferencedObjectColumn.Name = "ReferencedObjectColumn";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(969, 13);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 24);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(353, 570);
            treeView.TabIndex = 5;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DBDependancyDataGridView);
            splitContainer1.Size = new Size(1061, 570);
            splitContainer1.SplitterDistance = 353;
            splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(CloseButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 570);
            panel1.Name = "panel1";
            panel1.Size = new Size(1061, 51);
            panel1.TabIndex = 7;
            // 
            // RoutineDependencyViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 621);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "RoutineDependencyViewer";
            Text = "Object Dependency Viewer";
            ((System.ComponentModel.ISupportInitialize)DBDependancyDataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DBDependancyDataGridView;
        private DataGridViewTextBoxColumn NoColumn;
        private DataGridViewTextBoxColumn DependantDatabaseNameColumn;
        private DataGridViewTextBoxColumn SchemaNameColumn;
        private DataGridViewTextBoxColumn TypeDescriptionColumn;
        private DataGridViewTextBoxColumn ReferencedObjectClassDescriptionColumn;
        private DataGridViewTextBoxColumn ReferencedObjectColumn;
        private Button CloseButton;
        private TreeView treeView;
        private SplitContainer splitContainer1;
        private Panel panel1;
    }
}