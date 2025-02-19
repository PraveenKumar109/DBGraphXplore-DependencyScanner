using System.Data;
using DBGraphXplore.Core.FileHelpers;
using System.Collections.Specialized;
using System.Configuration;
using System;
using DBGraphXplore.DatabaseScanner.Entities;
using DBGraphXplore.DatabaseScanner.DependancyData.Loader;
using DBGraphXplore.KnowledgeGraph.Neo4j.DataHelper;
using DBGraphXplore.CodeAnalysis.DotNet;
using System.Diagnostics;

namespace DBDependancyGenerationApp
{
    public partial class MainForm : Form
    {
        private ScannedData scannedData;

        public MainForm()
        {
            InitializeComponent();
            //this.scannedData = new ScannedData();
            this.Text = " Database Dependancy Generation Application Version(" + Application.ProductVersion + ")";
        }

        private void LoadDataToolStripButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                this.StatusLabelToolStripStatusLabel.Text = "Please wait while loading file data ...";
                this.statusStrip1.Refresh();

                IDataFileLoader loader = new ExcelFileFormatLoader();
                this.scannedData = loader.Load(filename);
                this.LoadDataList();

                this.StatusLabelToolStripStatusLabel.Text = "";
                this.statusStrip1.Refresh();
            }

        }

        private void LoadDataList()
        {
            if (this.scannedData != null)
            {
                this.FillList1FilterComboBox(this.scannedData.SourceRoutineObjects);
                this.FillSourceRoutineDataGridView(this.scannedData.SourceRoutineObjects);

                this.FillList2FilterComboBox(this.scannedData.ReferencingObjects);
                this.FillDBDependancyGrid(this.scannedData.ReferencingObjects);
            }
        }


        private void FillList1FilterComboBox(List<SqlRoutine> routineObjects)
        {
            var databaseNames = routineObjects.DistinctBy(p => p.DatabaseName).Select(p => p.DatabaseName).ToList();
            var routineTypes = routineObjects.DistinctBy(p => p.RoutineType).Select(p => p.RoutineType).ToList();
            var routineNames = routineObjects.DistinctBy(p => p.RoutineName).Select(p => p.RoutineName).ToList();

            this.SourceDatabaseList1ComboBox.DataSource = databaseNames;
            this.SourceObjectTypeList1ComboBox.DataSource = routineTypes;
            this.SourceObjectNameList1ComboBox.DataSource = routineNames;


            this.SourceDatabaseList1ComboBox.SelectedIndex = -1;
            this.SourceObjectTypeList1ComboBox.SelectedIndex = -1;
            this.SourceObjectNameList1ComboBox.SelectedIndex = -1;
        }


        private void FillList2FilterComboBox(List<ReferencingObject> referencingObjects)
        {
            var sourceDatabaseNames = referencingObjects.DistinctBy(p => p.SourceDatabaseName).Select(p => p.SourceDatabaseName).ToList();
            var sourceObjectTypes = referencingObjects.DistinctBy(p => p.SourceObjectType).Select(p => p.SourceObjectType).ToList();
            var sourceObjectNames = referencingObjects.DistinctBy(p => p.SourceObjectName).Select(p => p.SourceObjectName).ToList();

            var dependentObjectDatabaseNames = referencingObjects.Select(p => p.DependentObjectDatabaseName.ToLower()).Distinct().ToList();
            var dependentObjectTypes = referencingObjects.DistinctBy(p => p.DependentObjectType).Select(p => p.DependentObjectType).ToList();
            var dependentObjectNames = referencingObjects.DistinctBy(p => p.DependentObjectName).Select(p => p.DependentObjectName).ToList();

            this.SourceDatabaseList2ComboBox.DataSource = sourceDatabaseNames;
            this.SourceObjectTypeList2ComboBox.DataSource = sourceObjectTypes;
            this.SourceObjectNameList2ComboBox.DataSource = sourceObjectNames;
            this.DependentDatabaseList2ComboBox.DataSource = dependentObjectDatabaseNames;
            this.DependentObjectTypeList2ComboBox.DataSource = dependentObjectTypes;
            this.DependentObjectNameList2ComboBox.DataSource = dependentObjectNames;

            this.SourceDatabaseList2ComboBox.SelectedIndex = -1;
            this.SourceObjectTypeList2ComboBox.SelectedIndex = -1;
            this.SourceObjectNameList2ComboBox.SelectedIndex = -1;
            this.DependentDatabaseList2ComboBox.SelectedIndex = -1;
            this.DependentObjectTypeList2ComboBox.SelectedIndex = -1;
            this.DependentObjectNameList2ComboBox.SelectedIndex = -1;
        }

        private void FillSourceRoutineDataGridView(List<SqlRoutine> list)
        {
            this.SourceRoutineDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            this.SourceRoutineDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            this.SourceRoutineDataGridView.Rows.Clear();
            var index = 0;
            foreach (var item in list)
            {
                var row = this.SourceRoutineDataGridView.Rows.Add();
                SourceRoutineDataGridView.Rows[index].Tag = item;
                SourceRoutineDataGridView.Rows[index].Cells[0].Value = index + 1;
                SourceRoutineDataGridView.Rows[index].Cells[1].Value = item.DatabaseName;
                SourceRoutineDataGridView.Rows[index].Cells[2].Value = item.SchemaName;
                SourceRoutineDataGridView.Rows[index].Cells[3].Value = item.RoutineType;
                SourceRoutineDataGridView.Rows[index].Cells[4].Value = item.RoutineName;
                SourceRoutineDataGridView.Rows[index].Cells[5].Value = "View";
                SourceRoutineDataGridView.Rows[index].Cells[6].Value = "Dependency";

                index++;
            }

            this.SourceRoutineDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.SourceRoutineDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void FillDBDependancyGrid(List<ReferencingObject> list)
        {
            // this.DBDependancyDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            // this.DBDependancyDataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            this.DBDependancyDataGridView.Rows.Clear();
            var index = 0;
            foreach (var item in list)
            {
                var row = this.DBDependancyDataGridView.Rows.Add();
                DBDependancyDataGridView.Rows[index].Tag = item;
                DBDependancyDataGridView.Rows[index].Cells[0].Value = index + 1;
                DBDependancyDataGridView.Rows[index].Cells[1].Value = item.SourceDatabaseName;
                DBDependancyDataGridView.Rows[index].Cells[2].Value = item.SourceObjectSchemaName;
                DBDependancyDataGridView.Rows[index].Cells[3].Value = item.SourceObjectType;
                DBDependancyDataGridView.Rows[index].Cells[4].Value = item.SourceObjectName;
                DBDependancyDataGridView.Rows[index].Cells[5].Value = item.DependentObjectDatabaseName;
                DBDependancyDataGridView.Rows[index].Cells[6].Value = item.DependentObjectSchemaName;
                DBDependancyDataGridView.Rows[index].Cells[7].Value = imageList1.Images[item.DependentObjectType];
                DBDependancyDataGridView.Rows[index].Cells[8].Value = item.DependentObjectType;

                DBDependancyDataGridView.Rows[index].Cells[9].Value = item.DependentObjectName;


                if (item.SourceDatabaseName == "NA")
                {
                    DBDependancyDataGridView.Rows[index].Cells[1].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[2].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[3].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[4].Style.BackColor = Color.LightSteelBlue;
                }
                if (item.DependentObjectDatabaseName == "NA")
                {
                    DBDependancyDataGridView.Rows[index].Cells[5].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[6].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[7].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[8].Style.BackColor = Color.LightSteelBlue;
                    DBDependancyDataGridView.Rows[index].Cells[9].Style.BackColor = Color.LightSteelBlue;
                }

                index++;
            }

            // this.DBDependancyDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // this.DBDependancyDataGridView.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void ScanToolStripButton_Click(object sender, EventArgs e)
        {

            var scannerForm = new DependancyScannerForm();
            var result = scannerForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (scannerForm.ScannedData != null)
                {
                    this.StatusLabelToolStripStatusLabel.Text = "Please wait while loading data ...";
                    this.statusStrip1.Refresh();

                    this.scannedData = scannerForm.ScannedData;
                    this.LoadDataList();

                    this.StatusLabelToolStripStatusLabel.Text = "";
                    this.statusStrip1.Refresh();
                }
            }
        }

        private void DBDependancyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SourceRoutineDataGridView_Click(object sender, EventArgs e)
        {

        }

        private void SourceRoutineDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var routine = (SqlRoutine)SourceRoutineDataGridView.Rows[e.RowIndex].Tag;
                var definitionViewerForm = new DefinitionViewerForm(routine);
                definitionViewerForm.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                var routine = (SqlRoutine)SourceRoutineDataGridView.Rows[e.RowIndex].Tag;

                var referencingObject = this.scannedData.ReferencingObjects.FirstOrDefault(p => p.SourceObjectName.ToLower() == routine.RoutineName.ToLower());
                this.FillChildDependency(referencingObject);

                this.tabControl1.SelectedTab = this.tabPage2;

                this.tabPage2.Show();
            }
        }

        private void RefereshDataButton_Click(object sender, EventArgs e)
        {

        }

        private void SourceRoutineDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FilterPanel2Button_Click(object sender, EventArgs e)
        {
            if (this.scannedData == null)
            {
                return;
            }
            if (this.scannedData.ReferencingObjects == null)
            {
                return;
            }

            var list = this.scannedData.ReferencingObjects.ToList();
            if (SourceDatabaseList2ComboBox.Text != "")
                list = list.Where(p => p.SourceDatabaseName.ToLower().Equals(SourceDatabaseList2ComboBox.Text.ToLower())).ToList();
            if (SourceObjectTypeList2ComboBox.Text != "")
                list = list.Where(p => p.SourceObjectType.ToLower().Equals(SourceObjectTypeList2ComboBox.Text.ToLower())).ToList();
            if (SourceObjectNameList2ComboBox.Text != "")
                list = list.Where(p => p.SourceObjectName.ToLower().Equals(SourceObjectNameList2ComboBox.Text.ToLower())).ToList();

            if (DependentDatabaseList2ComboBox.Text != "")
                list = list.Where(p => p.DependentObjectDatabaseName.ToLower().Equals(DependentDatabaseList2ComboBox.Text.ToLower())).ToList();
            if (DependentObjectTypeList2ComboBox.Text != "")
                list = list.Where(p => p.DependentObjectType.ToLower().Equals(DependentObjectTypeList2ComboBox.Text.ToLower())).ToList();
            if (DependentObjectNameList2ComboBox.Text != "")
                list = list.Where(p => p.DependentObjectName.ToLower().Equals(DependentObjectNameList2ComboBox.Text.ToLower())).ToList();

            this.FillDBDependancyGrid(list);
        }

        private void showAllChildDependencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DBDependancyDataGridView.SelectedRows[0].Selected = true;
            var referencingObject = (ReferencingObject)this.DBDependancyDataGridView.SelectedRows[0].Tag;
            this.FillChildDependency(referencingObject);
        }

        private void FillChildDependency(ReferencingObject referencingObject)
        {
            var list = this.FindAllChildDependency(referencingObject);
            this.FillDBDependancyGrid(list);

        }

        private List<ReferencingObject> FindAllChildDependency(ReferencingObject? referencingObject)
        {
            var list = new List<ReferencingObject>();
            if (referencingObject == null)
            {
                return list;
            }
            var rootList = this.scannedData.ReferencingObjects.Where(p => p.SourceObjectName.ToLower() == referencingObject.SourceObjectName.ToLower()).ToList();
            foreach (var _referencingObject in rootList)
            {
                list.Add(_referencingObject);
                this.GetChildReference(list, _referencingObject);

            }

            return list;
        }

        private void GetChildReference(List<ReferencingObject> list, ReferencingObject? referencingObject)
        {
            List<ReferencingObject> childs = this.scannedData.ReferencingObjects.Where(p => p.SourceObjectName.ToLower() == referencingObject.DependentObjectName.ToLower()).ToList();
            foreach (var child in childs)
            {
                //Application.DoEvents(); 
                this.GetChildReference(list, child);
                list.Add(child);
            }
        }

        //private async Task IngestDataToolStripButton_Click(object sender, EventArgs e)
        private void IngestDataToolStripButton_Click(object sender, EventArgs e)
        {
            NameValueCollection neo4jConfigurations = ConfigurationManager.GetSection("Neo4jConfigurations") as NameValueCollection;
            var uri = neo4jConfigurations.Get("uri");
            var username = neo4jConfigurations.Get("username");
            var password = neo4jConfigurations.Get("password");

            if (this.scannedData == null)
            {
                var result = MessageBox.Show("Please scan/load the data first.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var result = MessageBox.Show("Would you like to upload data into neo4J database? \nUri:" + uri, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.StatusLabelToolStripStatusLabel.Text = "Please wait while Ingesting data into Neo4J Database ...";
                    this.statusStrip1.Refresh();

                    var neo4JDataHelper = new Neo4JDataHelper(uri, username, password);
                    var task = neo4JDataHelper.UploadDataToNeo4J(this.scannedData);

                    this.StatusLabelToolStripStatusLabel.Text = "";
                    this.statusStrip1.Refresh();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.SourceRoutineDataGridView.SelectedRows[0].Selected = true;
            var referencingObject = (ReferencingObject)this.DBDependancyDataGridView.SelectedRows[0].Tag;
            this.FillChildDependency(referencingObject);
        }

        private void FilterPanel1Button_Click(object sender, EventArgs e)
        {
            if (this.scannedData.SourceRoutineObjects == null)
            {
                return;
            }

            var list = this.scannedData.SourceRoutineObjects.ToList();
            if (SourceDatabaseList1ComboBox.Text != "")
                list = list.Where(p => p.DatabaseName.ToLower().StartsWith(SourceDatabaseList1ComboBox.Text.ToLower())).ToList();

            if (SourceObjectTypeList1ComboBox.Text != "")
                list = list.Where(p => p.RoutineType.ToLower().StartsWith(SourceObjectTypeList1ComboBox.Text.ToLower())).ToList();

            if (SourceObjectNameList1ComboBox.Text != "")
                list = list.Where(p => p.RoutineName.ToLower().StartsWith(SourceObjectNameList1ComboBox.Text.ToLower())).ToList();

            this.FillSourceRoutineDataGridView(list);
        }

        private void ExportToNeo4JToolStripButton_Click(object sender, EventArgs e)
        {
            var outputFileLocation = "\\Output\\Object_Graph_Data_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            Directory.CreateDirectory(outputFileLocation);

            this.StatusLabelToolStripStatusLabel.Text = "Please wait while Transforming Dependency data into Object Graph Model ...";
            this.statusStrip1.Refresh();
            TransformRefencingDataToObjectGraphModelAndSavetoCSVFormat(outputFileLocation, this.scannedData);

            this.StatusLabelToolStripStatusLabel.Text = "";
            this.statusStrip1.Refresh();

            MessageBox.Show("Dependency Data has been transformed into Object Graph Model Successfully. \nOn the below location - \n" + outputFileLocation, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TransformRefencingDataToObjectGraphModelAndSavetoCSVFormat(string outputFileLocation, ScannedData dependancyData)
        {
            var dataTransformer = new DataTransformer();
            var objectGraphData = dataTransformer.Transform(dependancyData);

            CsvWriter.WriteToCsvFile(objectGraphData.Databases, outputFileLocation + "\\Databases.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.DatabaseObjects, outputFileLocation + "\\DatabaseObjects.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.Tables, outputFileLocation + "\\Tables.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.Columns, outputFileLocation + "\\Columns.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.Keys, outputFileLocation + "\\Keys.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.TableIndexes, outputFileLocation + "\\TableIndexes.csv");

            CsvWriter.WriteToCsvFile(objectGraphData.Views, outputFileLocation + "\\Views.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.UserTypes, outputFileLocation + "\\UserTypes.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.StoredProcedures, outputFileLocation + "\\StoredProcedures.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.Functions, outputFileLocation + "\\Functions.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.InlineTableValuedFunctions, outputFileLocation + "\\InlineTableValuedFunctions.csv");
            CsvWriter.WriteToCsvFile(objectGraphData.TableValuedFunctions, outputFileLocation + "\\TableValuedFunctions.csv");

            CsvWriter.WriteToCsvFile(objectGraphData.Relationships, outputFileLocation + "\\Relationships.csv");
        }

        private void ConfigurationToolStripButton_Click(object sender, EventArgs e)
        {
            ConfigutaionForm configutaionForm = new ConfigutaionForm();
            configutaionForm.ShowDialog();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void toolStripButton1_ClickAsync(object sender, EventArgs e)
        {


        }

        private void GenerateDocumentToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.scannedData == null)
            {
                MessageBox.Show("Please first scan/load the data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                var documentGeneratorForm = new DocumentGenerationForm(this.scannedData.SourceRoutineObjects);
                var result = documentGeneratorForm.ShowDialog();
            }
        }

        private void AnalyseCodeToolStripButton_Click(object sender, EventArgs e)
        {
            var solutionPath = @"C:\Github\easyJet-dev\eres-apps-eres-net-api\easyjet.VT100\easyjet.VT100.sln";
            var databaseObjectExtractor = new DatabaseObjectExtractor();
            List<DatabaseReference> dbReferences = databaseObjectExtractor.ExtractDatabaseObjects(solutionPath);


            foreach (var obj in dbReferences)
            {
                Debug.Print($"{obj.AssemblyName}." +
                                  $"{obj.ClassName}." +
                                  $"{obj.FunctionName} -> " +
                                  $"{obj.DatabaseName ?? "N/A"}." +
                                  $"{obj.DatabaseObjectName} " +
                                  $"[{obj.DatabaseObjectType}] " );
            }
        }
    }
}
