namespace DBDependancyGenerationApp
{
    partial class DocumentGenerationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentGenerationForm));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            splitContainer1 = new SplitContainer();
            label2 = new Label();
            CloseButton = new Button();
            OutputFilesLocationTextBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            GenerateButton = new Button();
            logViewerControl1 = new LogViewer.UserControl.LogViewerControl();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, toolStripStatusLabel2, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 673);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1077, 29);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(942, 24);
            toolStripStatusLabel.Spring = true;
            toolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(18, 24);
            toolStripStatusLabel2.Text = " | ";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 23);
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
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(CloseButton);
            splitContainer1.Panel1.Controls.Add(OutputFilesLocationTextBox);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(GenerateButton);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(logViewerControl1);
            splitContainer1.Size = new Size(1077, 673);
            splitContainer1.SplitterDistance = 287;
            splitContainer1.TabIndex = 14;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 129);
            label2.Name = "label2";
            label2.Size = new Size(214, 21);
            label2.TabIndex = 19;
            label2.Text = "Document Generation Location";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.DialogResult = DialogResult.Cancel;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(950, 233);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(110, 38);
            CloseButton.TabIndex = 18;
            CloseButton.Text = "Cancel";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // OutputFilesLocationTextBox
            // 
            OutputFilesLocationTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            OutputFilesLocationTextBox.Location = new Point(27, 152);
            OutputFilesLocationTextBox.Name = "OutputFilesLocationTextBox";
            OutputFilesLocationTextBox.Size = new Size(884, 23);
            OutputFilesLocationTextBox.TabIndex = 1;
            OutputFilesLocationTextBox.Text = "C:\\Output\\Documentation";
            // 
            // label3
            // 
            label3.Location = new Point(27, 51);
            label3.Name = "label3";
            label3.Size = new Size(943, 74);
            label3.TabIndex = 14;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(221, 24);
            label1.TabIndex = 16;
            label1.Text = "Document Generator";
            // 
            // GenerateButton
            // 
            GenerateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GenerateButton.Image = (Image)resources.GetObject("GenerateButton.Image");
            GenerateButton.ImageAlign = ContentAlignment.MiddleLeft;
            GenerateButton.Location = new Point(737, 232);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(207, 41);
            GenerateButton.TabIndex = 0;
            GenerateButton.Text = "Generate Document";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // logViewerControl1
            // 
            logViewerControl1.Dock = DockStyle.Fill;
            logViewerControl1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logViewerControl1.Location = new Point(0, 0);
            logViewerControl1.Margin = new Padding(5, 6, 5, 6);
            logViewerControl1.Name = "logViewerControl1";
            logViewerControl1.Size = new Size(1077, 382);
            logViewerControl1.TabIndex = 13;
            // 
            // DocumentGenerationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 702);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Font = new Font("Arial", 10F);
            Name = "DocumentGenerationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Document Generation";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripProgressBar toolStripProgressBar1;
        private SplitContainer splitContainer1;
        private TextBox OutputFilesLocationTextBox;
        private Label label3;
        private Label label1;
        private Button GenerateButton;
        private LogViewer.UserControl.LogViewerControl logViewerControl1;
        private Button CloseButton;
        private Label label2;
    }
}