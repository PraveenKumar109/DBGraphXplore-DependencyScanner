namespace DBDependancyGenerationApp
{
    partial class ConfigutaionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigutaionForm));
            label1 = new Label();
            DatabaseNameDataGridView = new DataGridView();
            NoColumn = new DataGridViewTextBoxColumn();
            DatabaseNameColumn = new DataGridViewTextBoxColumn();
            ConnectionStringColumn = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            PasswordTextBox = new TextBox();
            label5 = new Label();
            UserNameTextBox = new TextBox();
            label4 = new Label();
            UriTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            CloseButton = new Button();
            ShowButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DatabaseNameDataGridView).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 15);
            label1.Name = "label1";
            label1.Size = new Size(343, 19);
            label1.TabIndex = 18;
            label1.Text = "Source Database Connections (SQL Server)";
            label1.Click += label1_Click;
            // 
            // DatabaseNameDataGridView
            // 
            DatabaseNameDataGridView.AllowUserToAddRows = false;
            DatabaseNameDataGridView.AllowUserToDeleteRows = false;
            DatabaseNameDataGridView.AllowUserToOrderColumns = true;
            DatabaseNameDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = Color.AliceBlue;
            DatabaseNameDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            DatabaseNameDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DatabaseNameDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatabaseNameDataGridView.Columns.AddRange(new DataGridViewColumn[] { NoColumn, DatabaseNameColumn, ConnectionStringColumn });
            DatabaseNameDataGridView.Location = new Point(6, 53);
            DatabaseNameDataGridView.Name = "DatabaseNameDataGridView";
            DatabaseNameDataGridView.RowHeadersVisible = false;
            DatabaseNameDataGridView.Size = new Size(1062, 506);
            DatabaseNameDataGridView.TabIndex = 17;
            // 
            // NoColumn
            // 
            NoColumn.FillWeight = 50F;
            NoColumn.HeaderText = "No";
            NoColumn.Name = "NoColumn";
            NoColumn.Width = 50;
            // 
            // DatabaseNameColumn
            // 
            DatabaseNameColumn.FillWeight = 150F;
            DatabaseNameColumn.HeaderText = "DatabaseName";
            DatabaseNameColumn.Name = "DatabaseNameColumn";
            DatabaseNameColumn.Width = 150;
            // 
            // ConnectionStringColumn
            // 
            ConnectionStringColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ConnectionStringColumn.HeaderText = "ConnectionString";
            ConnectionStringColumn.Name = "ConnectionStringColumn";
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1082, 595);
            tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(DatabaseNameDataGridView);
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1074, 566);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "SQL Connections";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1074, 566);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Neo4J Configuration";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(PasswordTextBox);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(UserNameTextBox);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(UriTextBox);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1068, 560);
            panel2.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(177, 161);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(341, 22);
            PasswordTextBox.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(84, 164);
            label5.Name = "label5";
            label5.Size = new Size(64, 16);
            label5.TabIndex = 24;
            label5.Text = "Password";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(177, 127);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(341, 22);
            UserNameTextBox.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 130);
            label4.Name = "label4";
            label4.Size = new Size(72, 16);
            label4.TabIndex = 22;
            label4.Text = "User Name";
            // 
            // UriTextBox
            // 
            UriTextBox.Location = new Point(177, 90);
            UriTextBox.Name = "UriTextBox";
            UriTextBox.Size = new Size(518, 22);
            UriTextBox.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 93);
            label3.Name = "label3";
            label3.Size = new Size(87, 16);
            label3.TabIndex = 20;
            label3.Text = "Database URI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 15);
            label2.Name = "label2";
            label2.Size = new Size(243, 19);
            label2.TabIndex = 19;
            label2.Text = "Neo4J Database Configuration";
            // 
            // panel1
            // 
            panel1.Controls.Add(CloseButton);
            panel1.Controls.Add(ShowButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 595);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 78);
            panel1.TabIndex = 20;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(960, 28);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(110, 38);
            CloseButton.TabIndex = 19;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // ShowButton
            // 
            ShowButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowButton.DialogResult = DialogResult.OK;
            ShowButton.Image = (Image)resources.GetObject("ShowButton.Image");
            ShowButton.ImageAlign = ContentAlignment.MiddleLeft;
            ShowButton.Location = new Point(844, 28);
            ShowButton.Name = "ShowButton";
            ShowButton.Size = new Size(110, 38);
            ShowButton.TabIndex = 18;
            ShowButton.Text = "Save";
            ShowButton.UseVisualStyleBackColor = true;
            // 
            // ConfigutaionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 673);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ConfigutaionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configutaion";
            Load += ConfigutaionForm_Load;
            ((System.ComponentModel.ISupportInitialize)DatabaseNameDataGridView).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView DatabaseNameDataGridView;
        private DataGridViewTextBoxColumn NoColumn;
        private DataGridViewTextBoxColumn DatabaseNameColumn;
        private DataGridViewTextBoxColumn ConnectionStringColumn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private Panel panel2;
        private TextBox PasswordTextBox;
        private Label label5;
        private TextBox UserNameTextBox;
        private Label label4;
        private TextBox UriTextBox;
        private Label label3;
        private Label label2;
        private Button CloseButton;
        private Button ShowButton;
    }
}