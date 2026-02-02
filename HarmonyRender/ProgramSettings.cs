using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarmonyRender
{
    public partial class ProgramSettings : Form
    {
        private string harmonyPath;

        public ProgramSettings()
        {
            InitializeComponent();            
        }

        private void ProgramSettings_Load(object sender, EventArgs e)
        {
            //private string harmonyPath = Properties.Settings.Default["HarmonyPath"] as string;
            //HarmonyPathTextBox.Text = harmonyPath;

            harmonyPathTextBox.Text = Properties.Settings.Default["HarmonyPath"] as string;

            videoExport.SelectedIndex = 0;

            exportPrefix1.Text = Properties.Settings.Default["ExportPrefix1"] as string;
            exportPrefix2.Text = Properties.Settings.Default["ExportPrefix2"] as string;
            exportFileName.Value = Convert.ToInt32(Properties.Settings.Default["ExportNameDecimal"]);
        }

        private void HarmonyPathTextBox_TextChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default["HarmonyPath"] = "Some Value";
            //Properties.Settings.Default.Save();
        }

        private void browseHarmonyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Find Harmony EXE",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "exe",
                Filter = "exe files (*.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(ofd.FileName);
                harmonyPath = path.Replace(@"\", @"\\");

                harmonyPathTextBox.Text = harmonyPath;
                Console.WriteLine(harmonyPath);
            }
        }

        private void ComputerSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ProgramSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.Save();

            if (MessageBox.Show("Do you want to save changes?", "Settings", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //e.Cancel = true;
                Properties.Settings.Default["HarmonyPath"] = harmonyPath;
                Properties.Settings.Default.Save();
            }

            Console.WriteLine("SETTINGS CLOSING");
        }

        private void ProgramSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("SETTINGS CLOSED");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
