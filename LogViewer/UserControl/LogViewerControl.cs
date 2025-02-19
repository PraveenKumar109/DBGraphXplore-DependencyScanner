namespace LogViewer.UserControl
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using DataTypes;
    using EventArgsTypes;
    using Facades;

    /// <summary>
    /// Represent LogViewerControl
    /// </summary>
    public partial class LogViewerControl : UserControl
    {
        /// <summary>
        /// Represent Log
        /// </summary>
        private readonly ILog log;
        
        #region Void Delegate

        /// <summary>
        /// Represent VoidDelegate used to reomove cross refrence exception.
        /// </summary>
        private delegate void VoidDelegate();

        #endregion

        /// <summary>
        /// Initializes a new instance of the LogViewerControl class.
        /// </summary>
        public LogViewerControl()
        {
            InitializeComponent();

            this.log = new Log();
            this.log.ItemAdded += this.Log_ItemAdded;
            this.log.ItemsCleared += this.Log_ItemsCleared;
        }

        #region Public Functions

        /// <summary>
        /// Clear the Log viewer
        /// </summary>
        public void Clear()
        {
            this.log.Clear();
        }

        /// <summary>
        /// Add Log to the control
        /// </summary>
        /// <param name="value"> The log value </param>
        public void Add(string value)
        {
            this.log.Add(new LogItem(value));
        }

        /// <summary>
        /// Save content on given file path
        /// </summary>
        /// <param name="fileName">Target file path </param>
        /// <param name="append">Option to append file on the given path or not</param>
        public void Save(string fileName, bool append)
        {
            var streamWriter = new StreamWriter(fileName, append);

            foreach (LogItem item in this.log.Items)
            {
                streamWriter.WriteLine(item.Data);
            }

            streamWriter.Flush();
            streamWriter.Close();
        }

       #endregion

        /// <summary>
        /// Dispose LogViwer object
        /// </summary>
        /// <param name="disposing"> The disposing. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                this.log.ItemAdded -= this.Log_ItemAdded;
                this.log.ItemsCleared -= this.Log_ItemsCleared;
            }

            base.Dispose(disposing);
        }

       #region Private Fnctions

        /// <summary>
        /// Method to Add Log Item Add
        /// </summary>
        /// <param name="e">
        /// The LogItemBaseEventArgs e.
        /// </param>
        private void SafeLogItemAdded(LogItemBaseEventArgs e)
        {
            var logItem = (LogItem) e.Item;

            var value = logItem.Data;
            this.output.AppendText(value + "\n");
            this.output.ScrollToCaret();
            toolStripButtonSave.Enabled = true;
            toolStripButtonClear.Enabled = true;
            toolStripButtonCopy.Enabled = true;
        }

       #endregion

        #region EvenHandler

        /// <summary>
        /// Event Initializer to Save the data into the LogViewer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs e.</param>
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".log",
                Filter = "Log files (*.log)|*.log|All files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var fileName = saveFileDialog.FileName;
            this.Save(fileName, false);
        }

        /// <summary>
        /// Event Initializer to Copy the LogViewer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs e.</param>
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            this.CopyToClipBoard();
        }

        private void CopyToClipBoard()
        {
            var data = new StringBuilder();
            foreach (LogItem item in this.log.Items)
            {
                if (item.Data != null)
                {
                    data.AppendLine(item.Data);
                }
            }

            Clipboard.SetData(DataFormats.Text, data.ToString());
        }

        /// <summary>
        /// Event Initializer to Clear the LogViewer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs e.</param>
        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        /// <summary>
        /// Event Raised to Clear the LogViewer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs e.</param>
        private void Log_ItemsCleared(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((VoidDelegate)delegate
                {
                    this.output.Clear();
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonClear.Enabled = false;
                    toolStripButtonCopy.Enabled = false;
                });
            }
            else
            {
                this.output.Clear();
                toolStripButtonSave.Enabled = false;
                toolStripButtonClear.Enabled = false;
                toolStripButtonCopy.Enabled = false;
            }


        }

        /// <summary>
        /// Event Raised to Added the item into the LogViewer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The LogItemBase Event Argument</param>
        private void Log_ItemAdded(object sender, LogItemBaseEventArgs e)
        {
            this.SafeLogItemAdded(e);
        }

        #endregion

       
    }
}