using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace DBDependancyGenerationApp
{
    public partial class ConfigutaionForm : Form
    {
        public ConfigutaionForm()
        {
            InitializeComponent();
        }

        private void ConfigutaionForm_Load(object sender, EventArgs e)
        {
            this.FillDatabaseNameList();
        }

        private void FillDatabaseNameList()
        {
            // Access the appSettings section
            var appSettings = ConfigurationManager.AppSettings;

            DatabaseNameDataGridView.Rows.Clear();
            // Iterate through all keys in appSettings
            foreach (var key in appSettings.AllKeys)
            {
                var row = DatabaseNameDataGridView.Rows.Add();
                DatabaseNameDataGridView.Rows[row].Cells[0].Value = DatabaseNameDataGridView.Rows.Count+1;
                DatabaseNameDataGridView.Rows[row].Cells[1].Value = key.ToString();
                DatabaseNameDataGridView.Rows[row].Cells[2].Value = appSettings.Get(key);
            }
            NameValueCollection neo4jConfigurations = ConfigurationManager.GetSection("Neo4jConfigurations") as NameValueCollection;
            var uri = neo4jConfigurations.Get("uri");
            var username = neo4jConfigurations.Get("username");
            var password = neo4jConfigurations.Get("password");


            UriTextBox.Text = uri;
            UserNameTextBox.Text = username;        
            PasswordTextBox.Text = password;    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
