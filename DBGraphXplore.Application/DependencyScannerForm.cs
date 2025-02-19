namespace DBDependancyGenerationApp
{
    using DBGraphXplore.DatabaseScanner.DataLoader;
    using DBGraphXplore.DatabaseScanner.Entities;
    using DBGraphXplore.DatabaseScanner.Scanner;
    using DBGraphXplore.DatabaseScanner.Database;
    using DBGraphXplore.Core.EventHandlers;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Configuration;

    public partial class DependancyScannerForm : Form
    {
        public ScannedData ScannedData { get; private set; }
        //public List<ReferencingObject> ReferencingObjectList { get; private set; } = [];
        public List<SqlRoutine> SourceRoutineObjects { get; private set; } = [];

        public DependancyScannerForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FillDatabaseNameList();
        }

        private void FillDatabaseNameList()
        {
            // Access the appSettings section
            var appSettings = ConfigurationManager.AppSettings;
            this.DatabaseNameCheckedListBox.Items.Clear();

            // Iterate through all keys in appSettings
            foreach (var key in appSettings.AllKeys)
            {
                if(!key.StartsWith(".."))
                {
                    this.DatabaseNameCheckedListBox.Items.Add(key.ToString());
                }  
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SpNameListFileTextBox.Text = "";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                SpNameListFileTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var selectedSourceDatabaseNames = new List<string>();
            var loadedRoutines = new List<string>();
            var outputFileLocation = "\\Output\\Scanner_Output_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".xlsx";
            Directory.CreateDirectory("Output");

            var databaseHelper = new DatabaseHelper();
            var appSettings = ConfigurationManager.AppSettings;

            if (SelectedDatabaseRadioButton.Checked == true)
            {
                if (DatabaseNameCheckedListBox.CheckedItems.Count == 0)
                {
                    logViewerControl1.Add("Unable to continue, Please select atleast One database name to start the process.");
                    return;
                }
                foreach (var item in DatabaseNameCheckedListBox.CheckedItems)
                {
                    selectedSourceDatabaseNames.Add(item.ToString());
                }
                //if (this.DatabaseComboBox.SelectedItem == "")
                //{
                //    logViewerControl1.Add("Unable to continue, Select a Source Database Name");
                //    return;
                //}
                //var databaseName = this.DatabaseComboBox.SelectedItem;
                //if (databaseName is null)
                //{
                //    logViewerControl1.Add("Unable to continue, Select a Source Database Name");
                //    return;
                //}

                //var connectionString = appSettings.Get(databaseName.ToString());
                //logViewerControl1.Add("Loading routine information for " + databaseName + " database.");
                //this.SourceRoutineObjects = databaseHelper.GetAllRoutines(connectionString);
            }
            else if (this.GivenFileRadioButton.Checked == true)
            {
                var spFileName = SpNameListFileTextBox.Text;
                if (!File.Exists(spFileName))
                {
                    logViewerControl1.Add("Unable to continue, SP Name List File not found: " + spFileName);
                    return;
                }

                var procedures = new List<string>();
                var fileReader = new StoreProcedureNamesFileReader();
                procedures = fileReader.Load(spFileName);

                var givenRoutineObjects = new List<SqlRoutine>();
                foreach (var procedure in procedures)
                {
                    var _databaseName = procedure.Split('.')[0];
                    var _procedureName = procedure.Split(".")[1];
                    var routineInfoLoaded = loadedRoutines.Contains(_databaseName);
                    if (!routineInfoLoaded)
                    {
                        logViewerControl1.Add("Loading routine information for " + _databaseName + " database.");
                        var connectionString = appSettings.Get(_databaseName.ToString());
                        var routines = databaseHelper.GetAllRoutines(connectionString);
                        SourceRoutineObjects.AddRange(routines);
                        loadedRoutines.Add(_databaseName);
                    }

                    var routine = SourceRoutineObjects.FirstOrDefault(r => r.RoutineName.ToLower() == _procedureName.ToLower());
                    if (routine != null)
                    {
                        givenRoutineObjects.Add(routine);
                    }
                    else
                    {
                        logViewerControl1.Add("Error finding Object in INFORMATION_SCHEMA.ROUTINES :" + procedure);
                    }
                }
                SourceRoutineObjects = givenRoutineObjects;
            }
            else
            {
                logViewerControl1.Add("Unable to continue, Select the Source Stored Procedure Criteria.");
                return;
            }

            logViewerControl1.Add("Initlising the Process ...");

            var connectionStringsDictionary = new Dictionary<string, string>();
            foreach (var key in appSettings.AllKeys)
            {
                var _key = key.ToLower().ToString().Replace("..", "");
                connectionStringsDictionary.Add(_key, appSettings.Get(key.ToString()));
            }

            var scanner = new SQLServerScanner(connectionStringsDictionary, SourceRoutineObjects, outputFileLocation);
            scanner.Started += Generator_Started;
            scanner.Completed += Generator_Completed;
            scanner.ProgressChanged += Generator_ProgressChanged;
            scanner.ProgressPercentageChanged += Generator_ProgressPercentageChanged;
                      
            //generator.Generate();
            scanner.Generate(selectedSourceDatabaseNames);
            //this.ReferencingObjectList = scanner.ReferencingObjectList;
            this.ScannedData = scanner.DependancyData;


            if (File.Exists(outputFileLocation))
            {
                //Process.Start(outputFileLocation);
            }

            scanner.Started -= Generator_Started;
            scanner.Completed -= Generator_Completed;
            scanner.ProgressChanged -= Generator_ProgressChanged;
            scanner.ProgressPercentageChanged -= Generator_ProgressPercentageChanged;

        }


        private void Generator_ProgressPercentageChanged(object sender, GenericEventHandler<long> e)
        {
            this.toolStripProgressBar1.Value = (int)e.Value;
        }

        private void Generator_ProgressChanged(object sender, GenericEventHandler<string> e)
        {
            this.logViewerControl1.Add(e.Value);
        }

        private void Generator_Completed(object sender, EventArgs e)
        {
            this.logViewerControl1.Add("Process Completed");
            this.toolStripStatusLabel.Text = "Process Completed";
            this.statusStrip1.Refresh();
        }

        private void Generator_Started(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Value = 0;
            this.toolStripStatusLabel.Text = "Please wait process is running, It will take few minutes ... ";

            this.logViewerControl1.Add("Process Started");
            this.statusStrip1.Refresh();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GivenFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SpNameListFilePanel.Enabled = true;
            DatabaseListPanel.Enabled = false;
        }

        private void SelectedDatabaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SpNameListFilePanel.Enabled = false;
            DatabaseListPanel.Enabled = true;
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int index =0; index< DatabaseNameCheckedListBox.Items.Count; index++)
            {
                DatabaseNameCheckedListBox.SetItemChecked(index, SelectAllCheckBox.Checked);
            }
        }
    }
}
