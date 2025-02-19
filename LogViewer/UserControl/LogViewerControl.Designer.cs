namespace LogViewer.UserControl
{
    partial class LogViewerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewerControl));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            output = new System.Windows.Forms.RichTextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonSave, toolStripSeparator2, toolStripButtonCopy, toolStripSeparator1, toolStripButtonClear });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(635, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.TabStop = true;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            toolStripButtonSave.Enabled = false;
            toolStripButtonSave.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonSave.Image");
            toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonSave.Name = "toolStripButtonSave";
            toolStripButtonSave.Size = new System.Drawing.Size(55, 22);
            toolStripButtonSave.Text = "Save";
            toolStripButtonSave.ToolTipText = "Save output in text format";
            toolStripButtonSave.Click += toolStripButtonSave_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCopy
            // 
            toolStripButtonCopy.Enabled = false;
            toolStripButtonCopy.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonCopy.Image");
            toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonCopy.Name = "toolStripButtonCopy";
            toolStripButtonCopy.Size = new System.Drawing.Size(55, 22);
            toolStripButtonCopy.Text = "Copy";
            toolStripButtonCopy.ToolTipText = "Copy output content in clipboard";
            toolStripButtonCopy.Click += toolStripButtonCopy_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonClear
            // 
            toolStripButtonClear.Enabled = false;
            toolStripButtonClear.Image = (System.Drawing.Image)resources.GetObject("toolStripButtonClear.Image");
            toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonClear.Name = "toolStripButtonClear";
            toolStripButtonClear.Size = new System.Drawing.Size(54, 22);
            toolStripButtonClear.Text = "Clear";
            toolStripButtonClear.ToolTipText = "Clear output";
            toolStripButtonClear.Click += toolStripButtonClear_Click;
            // 
            // output
            // 
            output.BackColor = System.Drawing.Color.White;
            output.Dock = System.Windows.Forms.DockStyle.Fill;
            output.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            output.Location = new System.Drawing.Point(0, 25);
            output.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            output.Name = "output";
            output.ReadOnly = true;
            output.Size = new System.Drawing.Size(635, 203);
            output.TabIndex = 1;
            output.TabStop = false;
            output.Text = "";
            // 
            // LogViewerControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(output);
            Controls.Add(toolStrip1);
            Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LogViewerControl";
            Size = new System.Drawing.Size(635, 228);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}