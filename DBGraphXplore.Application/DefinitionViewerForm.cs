using DBGraphXplore.DatabaseScanner.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBDependancyGenerationApp
{
    public partial class DefinitionViewerForm : Form
    {
        private readonly SqlRoutine routineObject;

        public DefinitionViewerForm(SqlRoutine routineObject)
        {
            InitializeComponent();
            this.routineObject = routineObject;
        }

        private void DefinitionViewerForm_Load(object sender, EventArgs e)
        {
            this.Text = this.routineObject.DatabaseName +"."+ this.routineObject.SchemaName+"."+this.routineObject.RoutineName;
            this.ObjectDefinitionRichTextBox.Text = this.routineObject.RoutineDefinition;
        }
    }
}
