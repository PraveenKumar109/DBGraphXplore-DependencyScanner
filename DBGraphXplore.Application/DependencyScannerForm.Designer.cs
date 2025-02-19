namespace DBDependancyGenerationApp
{
    partial class DependancyScannerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DependancyScannerForm));
            GenerateButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            DatabaseListPanel = new Panel();
            SelectAllCheckBox = new CheckBox();
            DatabaseNameCheckedListBox = new CheckedListBox();
            label4 = new Label();
            SpNameListFilePanel = new Panel();
            SpNameListFileTextBox = new TextBox();
            button2 = new Button();
            GivenFileRadioButton = new RadioButton();
            SelectedDatabaseRadioButton = new RadioButton();
            label2 = new Label();
            CloseButton = new Button();
            label3 = new Label();
            label1 = new Label();
            ShowButton = new Button();
            logViewerControl1 = new LogViewer.UserControl.LogViewerControl();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            DatabaseListPanel.SuspendLayout();
            SpNameListFilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // GenerateButton
            // 
            GenerateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GenerateButton.Image = (Image)resources.GetObject("GenerateButton.Image");
            GenerateButton.ImageAlign = ContentAlignment.MiddleLeft;
            GenerateButton.Location = new Point(716, 428);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(117, 38);
            GenerateButton.TabIndex = 0;
            GenerateButton.Text = "Scan";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Text File|*.txt";
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripStatusLabel2, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 674);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1077, 28);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(911, 23);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(18, 23);
            toolStripStatusLabel2.Text = " | ";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 22);
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(CloseButton);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(ShowButton);
            splitContainer1.Panel1.Controls.Add(GenerateButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(logViewerControl1);
            splitContainer1.Size = new Size(1077, 674);
            splitContainer1.SplitterDistance = 471;
            splitContainer1.TabIndex = 13;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // panel1
            // 
            panel1.Controls.Add(DatabaseListPanel);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(SpNameListFilePanel);
            panel1.Controls.Add(GivenFileRadioButton);
            panel1.Controls.Add(SelectedDatabaseRadioButton);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(44, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(964, 331);
            panel1.TabIndex = 18;
            // 
            // DatabaseListPanel
            // 
            DatabaseListPanel.Controls.Add(SelectAllCheckBox);
            DatabaseListPanel.Controls.Add(DatabaseNameCheckedListBox);
            DatabaseListPanel.Location = new Point(19, 25);
            DatabaseListPanel.Name = "DatabaseListPanel";
            DatabaseListPanel.Size = new Size(464, 242);
            DatabaseListPanel.TabIndex = 19;
            // 
            // SelectAllCheckBox
            // 
            SelectAllCheckBox.AutoSize = true;
            SelectAllCheckBox.Location = new Point(3, 213);
            SelectAllCheckBox.Name = "SelectAllCheckBox";
            SelectAllCheckBox.Size = new Size(83, 20);
            SelectAllCheckBox.TabIndex = 22;
            SelectAllCheckBox.Text = "Select All";
            SelectAllCheckBox.UseVisualStyleBackColor = true;
            SelectAllCheckBox.CheckedChanged += SelectAllCheckBox_CheckedChanged;
            // 
            // DatabaseNameCheckedListBox
            // 
            DatabaseNameCheckedListBox.CheckOnClick = true;
            DatabaseNameCheckedListBox.FormattingEnabled = true;
            DatabaseNameCheckedListBox.Location = new Point(3, 5);
            DatabaseNameCheckedListBox.Name = "DatabaseNameCheckedListBox";
            DatabaseNameCheckedListBox.Size = new Size(458, 202);
            DatabaseNameCheckedListBox.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(216, 270);
            label4.Name = "label4";
            label4.Size = new Size(434, 16);
            label4.TabIndex = 21;
            label4.Text = "[This Option will use all Stored Procedures given in the selected file]";
            // 
            // SpNameListFilePanel
            // 
            SpNameListFilePanel.Controls.Add(SpNameListFileTextBox);
            SpNameListFilePanel.Controls.Add(button2);
            SpNameListFilePanel.Enabled = false;
            SpNameListFilePanel.Location = new Point(19, 292);
            SpNameListFilePanel.Name = "SpNameListFilePanel";
            SpNameListFilePanel.Size = new Size(900, 36);
            SpNameListFilePanel.TabIndex = 20;
            // 
            // SpNameListFileTextBox
            // 
            SpNameListFileTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SpNameListFileTextBox.Location = new Point(3, 5);
            SpNameListFileTextBox.Name = "SpNameListFileTextBox";
            SpNameListFileTextBox.Size = new Size(807, 23);
            SpNameListFileTextBox.TabIndex = 1;
            SpNameListFileTextBox.Text = "StoreProcedureList.txt";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(820, 2);
            button2.Name = "button2";
            button2.Size = new Size(43, 31);
            button2.TabIndex = 10;
            button2.Text = "...";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = true;
            // 
            // GivenFileRadioButton
            // 
            GivenFileRadioButton.AutoSize = true;
            GivenFileRadioButton.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GivenFileRadioButton.Location = new Point(3, 268);
            GivenFileRadioButton.Name = "GivenFileRadioButton";
            GivenFileRadioButton.Size = new Size(214, 20);
            GivenFileRadioButton.TabIndex = 18;
            GivenFileRadioButton.Text = "Custom Stored Procedure List";
            GivenFileRadioButton.UseVisualStyleBackColor = true;
            GivenFileRadioButton.CheckedChanged += GivenFileRadioButton_CheckedChanged;
            // 
            // SelectedDatabaseRadioButton
            // 
            SelectedDatabaseRadioButton.AutoSize = true;
            SelectedDatabaseRadioButton.Checked = true;
            SelectedDatabaseRadioButton.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectedDatabaseRadioButton.Location = new Point(3, 4);
            SelectedDatabaseRadioButton.Name = "SelectedDatabaseRadioButton";
            SelectedDatabaseRadioButton.Size = new Size(315, 20);
            SelectedDatabaseRadioButton.TabIndex = 17;
            SelectedDatabaseRadioButton.TabStop = true;
            SelectedDatabaseRadioButton.Text = "Select a Database from Stored Procedure List";
            SelectedDatabaseRadioButton.UseVisualStyleBackColor = true;
            SelectedDatabaseRadioButton.CheckedChanged += SelectedDatabaseRadioButton_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(315, 6);
            label2.Name = "label2";
            label2.Size = new Size(434, 16);
            label2.TabIndex = 16;
            label2.Text = "[This Option will use all Stored Procedures from selected database ]";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(955, 428);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(110, 38);
            CloseButton.TabIndex = 17;
            CloseButton.Text = "Cancel";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click_1;
            // 
            // label3
            // 
            label3.Location = new Point(27, 48);
            label3.Name = "label3";
            label3.Size = new Size(981, 41);
            label3.TabIndex = 14;
            label3.Text = "The Dependency Scanner helps user to deep scan all the dependencies (dependant objects) for given database or custom list of Stored Procedures/Functions under cross referenced database environment.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 21);
            label1.Name = "label1";
            label1.Size = new Size(226, 24);
            label1.TabIndex = 16;
            label1.Text = "Dependency Scanner";
            // 
            // ShowButton
            // 
            ShowButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowButton.DialogResult = DialogResult.OK;
            ShowButton.Image = (Image)resources.GetObject("ShowButton.Image");
            ShowButton.ImageAlign = ContentAlignment.MiddleLeft;
            ShowButton.Location = new Point(839, 428);
            ShowButton.Name = "ShowButton";
            ShowButton.Size = new Size(110, 38);
            ShowButton.TabIndex = 11;
            ShowButton.Text = "Show";
            ShowButton.UseVisualStyleBackColor = true;
            ShowButton.Click += CloseButton_Click;
            // 
            // logViewerControl1
            // 
            logViewerControl1.Dock = DockStyle.Fill;
            logViewerControl1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logViewerControl1.Location = new Point(0, 0);
            logViewerControl1.Margin = new Padding(5, 6, 5, 6);
            logViewerControl1.Name = "logViewerControl1";
            logViewerControl1.Size = new Size(1077, 199);
            logViewerControl1.TabIndex = 13;
            // 
            // DependancyScannerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = ShowButton;
            ClientSize = new Size(1077, 702);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "DependancyScannerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dependancy Scanner";
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            DatabaseListPanel.ResumeLayout(false);
            DatabaseListPanel.PerformLayout();
            SpNameListFilePanel.ResumeLayout(false);
            SpNameListFilePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GenerateButton;
        private OpenFileDialog openFileDialog1;
        private Button ShowButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripProgressBar1;
        private SplitContainer splitContainer1;
        private LogViewer.UserControl.LogViewerControl logViewerControl1;
        private Label label3;
        private Label label1;
        private Button CloseButton;
        private Panel panel1;
        private Panel SpNameListFilePanel;
        private TextBox SpNameListFileTextBox;
        private Button button2;
        private RadioButton GivenFileRadioButton;
        private RadioButton SelectedDatabaseRadioButton;
        private Label label2;
        private Label label4;
        private Panel DatabaseListPanel;
        private CheckedListBox DatabaseNameCheckedListBox;
        private CheckBox SelectAllCheckBox;
    }
}
