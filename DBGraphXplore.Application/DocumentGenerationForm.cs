using DBGraphXplore.CodeDocument.AzureOpenAI;
using DBGraphXplore.DatabaseScanner.Entities;

namespace DBDependancyGenerationApp
{
    public partial class DocumentGenerationForm : Form
    {
        private readonly List<SqlRoutine> sourceRoutineObjects;

        public DocumentGenerationForm(List<SqlRoutine> sourceRoutineObjects)
        {
            InitializeComponent();
            this.sourceRoutineObjects = sourceRoutineObjects;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var exportFileName = OutputFilesLocationTextBox.Text;
            this.GenerateTechnicalDocument(this.sourceRoutineObjects, exportFileName);
        }

        private async void GenerateTechnicalDocument(List<SqlRoutine> sourceRoutineObjects, string exportLocation)
        {
            this.toolStripProgressBar1.Value = 0;
            this.toolStripStatusLabel.Text = "Please wait process is running, It will take few minutes ... ";
            this.statusStrip1.Refresh();
            this.logViewerControl1.Add("Process Started ...");

            var documentGenerator = new DocumentGenerator();
            var index = 0;
            foreach (SqlRoutine routine in sourceRoutineObjects)
            {
                var documentationLocation = exportLocation + "\\" + routine.DatabaseName;
                Directory.CreateDirectory(documentationLocation);

                var definition = routine.RoutineDefinition;
                if (!string.IsNullOrEmpty(definition))
                {
                    // Call the async method to generate the technical document
                    string technicalDocument = await documentGenerator.GenerateTechnicalDocumentAsync(definition);

                    // Display the result in a TextBox or save it
                    var result = technicalDocument;
                    var fileName = documentationLocation +"\\"+ routine.DatabaseName + "." + routine.RoutineName + ".md";
                    File.WriteAllText(fileName, result);

                    this.logViewerControl1.Add("Document Generated: " + fileName);
                    
                    index = index + 1;
                    var percentage = ((double)index / (double) sourceRoutineObjects.Count) * 100;
                    this.toolStripProgressBar1.Value = (int) percentage;
                }
            }

            this.toolStripStatusLabel.Text = "";
            this.logViewerControl1.Add("Process Completed.");
            this.statusStrip1.Refresh();

        }
    }
}
