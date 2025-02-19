namespace DBDependancyGenerationApp
{
    partial class DefinitionViewerForm
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
            ObjectDefinitionRichTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ObjectDefinitionRichTextBox
            // 
            ObjectDefinitionRichTextBox.Dock = DockStyle.Fill;
            ObjectDefinitionRichTextBox.Location = new Point(0, 0);
            ObjectDefinitionRichTextBox.Name = "ObjectDefinitionRichTextBox";
            ObjectDefinitionRichTextBox.ReadOnly = true;
            ObjectDefinitionRichTextBox.Size = new Size(749, 727);
            ObjectDefinitionRichTextBox.TabIndex = 0;
            ObjectDefinitionRichTextBox.Text = "";
            // 
            // DefinitionViewerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 727);
            Controls.Add(ObjectDefinitionRichTextBox);
            Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "DefinitionViewerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Object Definition Viewer";
            Load += DefinitionViewerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox ObjectDefinitionRichTextBox;
    }
}