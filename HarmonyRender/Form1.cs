using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HarmonyRender
{
    public partial class Form1 : Form
    {

        //private string harmonyPath = "C:\\Program Files (x86)\\Toon Boom Animation\\Toon Boom Harmony 20 Premium\\win64\\bin\\HarmonyPremium.exe";
        private string harmonyPath = Properties.Settings.Default["HarmonyPath"] as string;

        private string m_defaultOutputFolder = "";
        private int renderFileNum = 0;
        private bool renderAllFiles = false;
        private int importXMListNum = 0;
        private int renderProres = 0;
        private int renderMaxNum = 0;

        //stall check
        private static int countDown = 350;
        private static System.Threading.Timer threadTimer;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tBfilesBindingSource.Add(new TBfiles() { Name = "File1", ExportName = "K01", ExportPath = "File/File/File", Frames = 78 });
            //dataGridView.DefaultCellStyle.ForeColor = Color.LightGray;
            //dataGridView.DefaultCellStyle.BackColor = Color.DarkGray;

            //progressBar.BackColor = Color.Black;

            videoCodec.SelectedItem = "proresHQ";


        }

        //add folder files button
        private void addDir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Add folder with Harmony animations";
            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.FileName = "Folder Selection.";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var fileArray = Directory.GetDirectories(@ofd.FileName.Replace(ofd.SafeFileName, "")).SelectMany(d => Directory.GetFiles(d, "*.xstage"));
                //string[] fileArray = Directory.GetFiles(@ofd.FileName.Replace(ofd.SafeFileName, ""), "*.xstage", SearchOption.AllDirectories); //malo sporiji
                foreach (String file in fileArray)
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(file).Contains("_render"))
                        continue;

                    TBfiles TBfile = new TBfiles();
                    TBfile.Id = dataGridView.Rows.Count;
                    TBfile.Name = System.IO.Path.GetFileNameWithoutExtension(file);
                    TBfile.Path = System.IO.Path.GetDirectoryName(file) + "\\";
                    TBfile.Frames = int.Parse(getFileFrameNumber(System.IO.Path.GetFullPath(file)));

                    if (TBfile.Name.Contains("S"))
                        TBfile.ExportName = "S" + TBfile.Name.Substring(TBfile.Name.Length - 2);
                    else
                        TBfile.ExportName = "K" + TBfile.Name.Substring(TBfile.Name.Length - 2);

                    if (!string.IsNullOrEmpty(m_defaultOutputFolder))
                        TBfile.ExportPath = m_defaultOutputFolder;

                    tBfilesBindingSource.Add(new TBfiles() { Id = TBfile.Id, Name = TBfile.Name, ExportName = TBfile.ExportName, ExportPath = TBfile.ExportPath, Frames = TBfile.Frames, Path = TBfile.Path });

                    //Console.WriteLine("File: " + Path.GetFileName(file) + "   Path: " + Path.GetDirectoryName(file));
                    //Console.WriteLine(TBfile.Path);
                }
            }
        }

        //add file button
        private void addFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Add Harmony File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xstage",
                Filter = "xstage files (*.xstage)|*.xstage",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TBfiles TBfile = new TBfiles();
                TBfile.Id = dataGridView.Rows.Count;
                TBfile.Name = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                TBfile.Path = ofd.FileName.Replace(ofd.SafeFileName, "");

                if (TBfile.Name.Contains("S"))
                    TBfile.ExportName = "S" + TBfile.Name.Substring(TBfile.Name.Length - 2);
                else
                    TBfile.ExportName = "K" + TBfile.Name.Substring(TBfile.Name.Length - 2);

                TBfile.Frames = int.Parse(getFileFrameNumber(System.IO.Path.GetFullPath(ofd.FileName)));

                if (!string.IsNullOrEmpty(m_defaultOutputFolder))
                    TBfile.ExportPath = m_defaultOutputFolder;

                tBfilesBindingSource.Add(new TBfiles() { Id = TBfile.Id, Name = TBfile.Name, ExportName = TBfile.ExportName, ExportPath = TBfile.ExportPath, Frames = TBfile.Frames, Path = TBfile.Path });

                //Console.WriteLine("File path: " + System.IO.Path.GetFullPath(ofd.FileName) + " Path: " + TBfile.Path);
                //Console.WriteLine(TBfile.Path);
            }
        }

        // render and remove cell buttons
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  // ignore header row and any column
                return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            if (dataGridView.Columns[e.ColumnIndex].Name == "Remove")
            {
                if (MessageBox.Show("Remove " + row.Cells[2].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //TODO renew TBfiles - Id
                    tBfilesBindingSource.RemoveCurrent();
                    resetDataBindSourceID();
                }
                    
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "Render")
            {
                if (MessageBox.Show("Render " + row.Cells[2].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    renderAllFiles = false;

                    TBfiles file = row.DataBoundItem as TBfiles;
                    parseAndSaveXMLfile(file);
                }
            }

            //if (dataGridView.Columns[e.ColumnIndex].Name == "Select")
            //{
            //    DataGridViewCheckBoxCell chk = row.Cells[1] as DataGridViewCheckBoxCell;

            //    //if (Convert.ToBoolean(chk.Value) == true) chkInt++;
            //    //bool check = Convert.ToBoolean(chk.Value);

            //    Console.WriteLine(dataGridView.Columns[e.ColumnIndex].Name);
            //    Console.WriteLine(chk.EditedFormattedValue);

            //}

        }

        //drag select rows
        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Console.WriteLine("SELECTED ROWS " + dataGridView.SelectedRows.Count);

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                if (Convert.ToBoolean(chk.Value) == true) // || chk.Value == null
                {
                    chk.Value = false;
                    Console.WriteLine("true null " + chk.EditedFormattedValue);
                }
                else
                {
                    chk.Value = true;
                    Console.WriteLine("false " + chk.EditedFormattedValue);
                }
            }
        }

        private void resetDataBindSourceID()
        {
            for(int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                TBfiles file = row.DataBoundItem as TBfiles;
                file.Id = i;

                Console.WriteLine("ID: " + file.Id);
            }
        }

        // select folder button
        private void buttBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.FileName = "Folder Selection.";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                m_defaultOutputFolder = ofd.FileName.Replace(ofd.SafeFileName, "");
                defaultOutputFolder.Text = m_defaultOutputFolder;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                TBfiles file = row.DataBoundItem as TBfiles;
                file.ExportPath = m_defaultOutputFolder;
            }

            dataGridView.Refresh();
        }

        //render all files button
        private void renderAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Render all files?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!renderAllFiles)
                {
                    renderAllFiles = true;
                    renderAll();
                }
            }
        }

        //render all files button
        private void buttDelSelected_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove selected files?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    dataGridView.Rows.Cast<DataGridViewRow>().Where(row => (bool?)row.Cells[1].Value == true).ToList().ForEach(row =>
                    {
                        dataGridView.Rows.Remove(row);
                    });
                }

                resetDataBindSourceID();
            }
        }

        private void buttRenameSelected_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Rename all files to Story?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 
            }
        }

        private void renderAll()
        {
            DataGridViewRow row = dataGridView.Rows[renderFileNum];
            TBfiles file = row.DataBoundItem as TBfiles;

            parseAndSaveXMLfile(file);

            Console.WriteLine("Render file: " + file.ExportName);
            Console.WriteLine("Render all files: " + tBfilesBindingSource.Count);
        }

        //RENDER
        public static string getFileFrameNumber(string filePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);

            var scene = document.SelectSingleNode("//scenes/scene[@name='Top']", nsmgr);
            var frameNumber = scene.Attributes["nbframes"]?.Value;

            //Console.WriteLine("Frame number: " + frameNumber);

            return frameNumber;
        }

        void parseAndSaveXMLfile(TBfiles file)
        {
            var newFileName = file.Path + file.Name + "_render.xstage";

            try
            {
                XDocument document = XDocument.Load(file.Path + file.Name + ".xstage");
                document.XPathSelectElement("//scenes/scene[@name = 'Top']//module[@name = 'Write']/attrs").Remove();
                
                var writeNode = document.XPathSelectElement("//scenes/scene[@name = 'Top']//module[@name = 'Write']");

                var rendName = file.ExportPath + file.ExportName;
                //writeNode.Add(exporVideoSettings(rendName));
                //writeNode.Add(exporVideoProresHQ(rendName));

                //TODO add formats menu
                switch (renderProres)
                {
                    case 0:
                        writeNode.Add(exporVideoProresHQ(rendName));
                        Console.WriteLine("HQ index " + renderProres);
                        break;

                    case 1:
                        writeNode.Add(exporVideoProresLT(rendName));
                        Console.WriteLine("LT index " + renderProres);
                        break;

                    case 2:
                        writeNode.Add(exporVideoProres444(rendName));
                        Console.WriteLine("444 index " + renderProres);
                        break;

                    case 3:
                        writeNode.Add(exporVideoProres444Alpha(rendName));
                        break;

                    default:
                        writeNode.Add(exporVideoProresHQ(rendName));
                        Console.WriteLine("default index " + renderProres);
                        break;
                };

                FileStream fs = File.OpenWrite(newFileName);
                document.Save(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modifying harmony file failed - " + file.Name);
            }

            Console.WriteLine("Exported file: " + newFileName);

            if (File.Exists(newFileName))
            {
                string folder = Directory.GetCurrentDirectory();
                //var executedOk = ExecuteCommandWithFile(folder, newFileName, file);

                //rederingTextOutput.Text = "RENDERING " + file.ExportName;
                //progressBar.Maximum = file.Frames;
                renderMaxNum = file.Frames;
                SetProgresBar(progressBar, 0, file.Frames);
                SetTextBox(rederingTextOutput, "RENDERING " + file.ExportName);

                thread1done.Set();

                Thread t = new Thread(() => StartRendering(folder, newFileName, file));
                t.Start();
                thread1done.WaitOne();
            }
            else
            {
                Console.WriteLine("File not ready for rendering!");
            }
        }

        XElement exporVideoSettings(string movieName)
        {
            var xmlTree = new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.quicktime.legacy")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", "Enable Sound(false)Enable Video(true)QT(000000000000000000000000000004297365616E0000000100000005000000000000022F76696465000000010000001200000000000000227370746C000000010000000000000000706E672000000000002000000200000000207470726C000000010000000000000000000000000000000000000000000000246472617400000001000000000000000000000000000000000000000000000000000000156D70736F00000001000000000000000000000000186D66726100000001000000000000000000000000000000187073667200000001000000000000000000000000000000156266726100000001000000000000000000000000166D70657300000001000000000000000000000000002868617264000000010000000000000000000000000000000000000000000000000000000000000016656E647300000001000000000000000000000000001663666C67000000010000000000000000004400000018636D66720000000100000000000000006170706C00000014636C75740000000100000000000000000000006463646563000000010000000000000000000000000000000000000000000000447365616E00000001000000020000000000000018696C61630000000100000000000000000000000000000018706E676600000001000000000000000062666C740000001C766572730000000100000000000000000003001C000100000000001574726E630000000100000000000000000000000018776474680000000100000000000000000F000000000000186865677400000001000000000000000008700000000001066973697A000000010000000900000000000000186977647400000001000000000000000000000F0000000018696867740000000100000000000000000000087000000018707764740000000100000000000000000000000000000018706867740000000100000000000000000000000000000034636C617000000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000001C706173700000000100000000000000000000000000000000000000187363616D000000010000000000000000000000000000001564696E74000000010000000000000000000000001575656E66000000010000000000000000000000008C736F756E0000000100000005000000000000001873736374000000010000000000000000736F777400000018737372740000000100000000000000005622000000000016737373730000000100000000000000000010000000167373636300000001000000000000000000010000001C76657273000000010000000000000000000300140001000000000015656E7669000000010000000000000000010000003F7361766500000001000000020000000000000015666173740000000100000000000000000000000016737374790000000100000000000000000001)")),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),

                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),

                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );

            return xmlTree;
        }

        //TODO color space withouth value new XElement("colorSpace"), or with new XElement("colorSpace", new XAttribute("val", "Rec.709")),

        // enableSound(1)com 
        // videoCodec(prores4444)com - prores4444 prores422HQ prores422LT
        // alpha(1)

        // resolution
        // new XElement("filterResX", new XAttribute("val", "720")),
        // new XElement("filterResY", new XAttribute("val", "540"))

        XElement exporVideoProres444Alpha(string movieName)
        {
            var xmlTree = new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.prores.mov.1.0")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", "com.toonboom.prores.mov.1.0:enableSound(1)com.toonboom.prores.mov.1.0:sampleRate(22050)com.toonboom.prores.mov.1.0:nChannels(2)com.toonboom.prores.mov.1.0:videoCodec(prores4444)com.toonboom.prores.mov.1.0:alpha(1)")),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),

                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),

                new XElement("scriptMovie", new XAttribute("val", "false")),
                new XElement("scriptEditor", new XAttribute("val", "")),
                new XElement("colorSpace"),

                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );

            return xmlTree;
        }

        XElement exporVideoProres444(string movieName)
        {
            var xmlTree = new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.prores.mov.1.0")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", "com.toonboom.prores.mov.1.0:enableSound(1)com.toonboom.prores.mov.1.0:sampleRate(22050)com.toonboom.prores.mov.1.0:nChannels(2)com.toonboom.prores.mov.1.0:videoCodec(prores4444)com.toonboom.prores.mov.1.0:alpha(0)")),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),

                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),

                new XElement("scriptMovie", new XAttribute("val", "false")),
                new XElement("scriptEditor", new XAttribute("val", "")),
                new XElement("colorSpace"),

                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );

            return xmlTree;
        }

        XElement exporVideoProresHQ(string movieName)
        {
            var xmlTree = new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.prores.mov.1.0")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", "com.toonboom.prores.mov.1.0:enableSound(1)com.toonboom.prores.mov.1.0:sampleRate(22050)com.toonboom.prores.mov.1.0:nChannels(2)com.toonboom.prores.mov.1.0:videoCodec(prores422HQ)com.toonboom.prores.mov.1.0:alpha(0)")),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),

                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),

                new XElement("scriptMovie", new XAttribute("val", "false")),
                new XElement("scriptEditor", new XAttribute("val", "")),
                new XElement("colorSpace"),

                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );

            return xmlTree;
        }

        XElement exporVideoProresLT(string movieName)
        {
            var xmlTree = new XElement("attrs",
                new XElement("exportToMovie", new XAttribute("val", "true")),
                new XElement("drawingName", new XAttribute("val", "frames/final-")),
                new XElement("moviePath", new XAttribute("val", movieName)),
                new XElement("movieFormat", new XAttribute("val", "com.toonboom.prores.mov.1.0")),
                new XElement("movieAudio"),
                new XElement("movieVideo"),
                new XElement("movieVideoaudio", new XAttribute("val", "com.toonboom.prores.mov.1.0:enableSound(1)com.toonboom.prores.mov.1.0:sampleRate(22050)com.toonboom.prores.mov.1.0:nChannels(2)com.toonboom.prores.mov.1.0:videoCodec(prores422LT)com.toonboom.prores.mov.1.0:alpha(0)")),
                new XElement("leadingZeros", new XAttribute("val", "3")),
                new XElement("start", new XAttribute("val", "1")),
                new XElement("drawingType", new XAttribute("val", "TGA")),

                new XElement("enabling",
                    new XElement("filter", new XAttribute("val", "ALWAYS")),
                    new XElement("filterName"),
                    new XElement("filterResX", new XAttribute("val", "720")),
                    new XElement("filterResY", new XAttribute("val", "540"))
                ),

                new XElement("scriptMovie", new XAttribute("val", "false")),
                new XElement("scriptEditor", new XAttribute("val", "")),
                new XElement("colorSpace"),

                new XElement("compositePartitioning", new XAttribute("val", "NoCompositePartitioning")),
                new XElement("zPartitionRange", new XAttribute("val", "1"), new XAttribute("defaultValue", "1")),
                new XElement("cleanUpPartitionFolders", new XAttribute("val", "true"))
            );

            return xmlTree;
        }


        //THREADS
        public void StartRendering(string folder, string filePath, TBfiles file)
        {
            var executedOk = ExecuteCommandWithFile(folder, filePath, file);

            if (executedOk)
            {
                thread1done.Set();
                SetProgresBar(progressBar, 0);
                SetTextBox(rederingTextOutput, " ");

                if (renderAllFiles)
                {
                    renderFileNum += 1;
                    if (renderFileNum <= tBfilesBindingSource.Count - 1)
                    {
                        renderAll();
                        Console.WriteLine("Render next animation: " + renderFileNum);
                    }
                    else
                    {
                        renderFileNum = 0;
                        renderAllFiles = false;

                        Console.WriteLine("Done rendering all files");
                    }
                }

                dataGridView.Rows[file.Id].Cells["Status"].Value = Properties.Resources.STATUS_DONE;
                //HarmonyRender.Properties.Resources.STATUS_EMPTY
                //HarmonyRender.Properties.Resources.STATUS_DONE

                Console.WriteLine("Done rendering " + file.Id);
            }
            else
            {
                if (renderAllFiles)
                {
                    thread1done.Set();
                    SetProgresBar(progressBar, 0);
                    SetTextBox(rederingTextOutput, " ");

                    renderFileNum += 1;
                    renderAll();

                    dataGridView.Rows[file.Id].Cells["Status"].Value = Properties.Resources.X;

                    Console.WriteLine("ERROR - skip to next animation");
                }
            }
        }

        public bool ExecuteCommandWithFile(string folder, string filePath, TBfiles file)
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                FileName = harmonyPath,
                Arguments = $" -user usabatch -batch {filePath}",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = folder
            };

            Process myProcess = new Process();
            myProcess.StartInfo = processInfo;
            //myProcess.SynchronizingObject = this;
            myProcess.EnableRaisingEvents = true;

            myProcess.OutputDataReceived += new DataReceivedEventHandler(RenderingOutputDataReceived);
            myProcess.ErrorDataReceived += new DataReceivedEventHandler(RenderingErrorDataReceived);

            myProcess.Start();
            myProcess.BeginErrorReadLine();
            //myProcess.BeginOutputReadLine();

            myProcess.WaitForExit();
            return myProcess.ExitCode == 0;
        }

        void RenderingOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine("ERROR? " + e.Data);
        }

        void RenderingErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.Contains("Rendered frame "))
                {
                    var num = int.Parse(e.Data.Substring(e.Data.LastIndexOf(' ') + 1));
                    Console.WriteLine("Rendered frame " + num);

                    //SetText(rederingTextOutput, "Rendering frame " + num);
                    SetProgresBar(progressBar, num);

                    //if (num == file.Frames)
                    //{
                    //    Console.WriteLine("RENDER COMPLETE!!!");
                    //}
                }
            }
        }

        public AutoResetEvent thread1done = new AutoResetEvent(false);

        delegate void SetValueOnControl(Control controlToChange, int value, int max = 0);
        delegate void SetTextOnControl(Control controlToChange, string value);
        public void SetProgresBar(Control controlToChange, int value, int max = 0)
        {
            if (value > renderMaxNum) value = renderMaxNum;

            if (controlToChange.InvokeRequired)
            {
                SetValueOnControl DDD = new SetValueOnControl(SetProgresBar);
                controlToChange.Invoke(DDD, controlToChange, value, max);
            }
            else
            {
                progressBar.Value = value;

                if(max > 0)
                    progressBar.Maximum = max;
            }
            if (threadTimer != null)
            {
                threadTimer.Dispose();
                countDown = 350;
            }

            threadTimer = new System.Threading.Timer(new TimerCallback(TickTimer), null, 0, 1000);
        }

        public void SetTextBox(Control controlToChange, string value)
        {
            if (controlToChange.InvokeRequired)
            {
                SetTextOnControl DDD = new SetTextOnControl(SetTextBox);
                controlToChange.Invoke(DDD, controlToChange, value);
            }
            else
            {
                rederingTextOutput.Text = value;
            }
        }

        private void TickTimer(object state)
        {
            --countDown;

            if (countDown == 0)
            {
                countDown = 350;
                threadTimer.Dispose();
                //Environment.Exit(0); //exit program

                if(renderAllFiles)
                {
                    renderFileNum += 1;
                    renderAll();

                    Console.Write("RESTART RENDERING!!!!!!!!!!!! ");
                }
            }

            //Console.Write("Tick! " + countDown + " thread ");
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            //Thread.Sleep(500);
        }

        //DRAG&DROP
        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            FileAttributes attr = File.GetAttributes(path);
            bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;

            if (isFolder)
            {
                //Console.WriteLine("FOLDER DROPPED!");

                var fileArray = Directory.GetDirectories(path).SelectMany(d => Directory.GetFiles(d, "*.xstage"));
                foreach (String file in fileArray)
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(file).Contains("_render"))
                        continue;

                    TBfiles TBfile = new TBfiles();
                    TBfile.Id = dataGridView.Rows.Count;
                    TBfile.Name = System.IO.Path.GetFileNameWithoutExtension(file);
                    TBfile.Path = System.IO.Path.GetDirectoryName(file) + "\\";
                    TBfile.Frames = int.Parse(getFileFrameNumber(System.IO.Path.GetFullPath(file)));

                    if (TBfile.Name.Contains("S"))
                        TBfile.ExportName = "S" + TBfile.Name.Substring(TBfile.Name.Length - 2);
                    else
                        TBfile.ExportName = "K" + TBfile.Name.Substring(TBfile.Name.Length - 2);

                    if (!string.IsNullOrEmpty(m_defaultOutputFolder))
                        TBfile.ExportPath = m_defaultOutputFolder;

                    tBfilesBindingSource.Add(new TBfiles() { Id = TBfile.Id, Name = TBfile.Name, ExportName = TBfile.ExportName, ExportPath = TBfile.ExportPath, Frames = TBfile.Frames, Path = TBfile.Path });

                    //Console.WriteLine("IN FOLDER DROPPED! " + file);
                }
            }
            else
            {
                TBfiles TBfile = new TBfiles();
                TBfile.Id = dataGridView.Rows.Count;
                TBfile.Name = System.IO.Path.GetFileNameWithoutExtension(path);
                TBfile.Path = System.IO.Path.GetDirectoryName(path) + "\\";
                TBfile.Frames = int.Parse(getFileFrameNumber(System.IO.Path.GetFullPath(path)));

                if (TBfile.Name.Contains("S"))
                    TBfile.ExportName = "S" + TBfile.Name.Substring(TBfile.Name.Length - 2);
                else
                    TBfile.ExportName = "K" + TBfile.Name.Substring(TBfile.Name.Length - 2);

                if (!string.IsNullOrEmpty(m_defaultOutputFolder))
                    TBfile.ExportPath = m_defaultOutputFolder;

                tBfilesBindingSource.Add(new TBfiles() { Id = TBfile.Id, Name = TBfile.Name, ExportName = TBfile.ExportName, ExportPath = TBfile.ExportPath, Frames = TBfile.Frames, Path = TBfile.Path });

                //Console.WriteLine("File path: " + System.IO.Path.GetFullPath(ofd.FileName) + " Path: " + TBfile.Path);
                //Console.WriteLine(TBfile.Path);

                Console.WriteLine("FILE DROPPED! " + path + "FILE DROPPED! " + TBfile.Id);
            }
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void defaultOutputFolder_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            m_defaultOutputFolder = $"{System.IO.Path.GetFullPath(path)}\\";
            defaultOutputFolder.Text = m_defaultOutputFolder;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                TBfiles file = row.DataBoundItem as TBfiles;
                file.ExportPath = m_defaultOutputFolder;
            }

            dataGridView.Refresh();

            Console.WriteLine("EXPORT FOLDER! " + path);
        }

        private void defaultOutputFolder_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start settings form

            ProgramSettings ps = new ProgramSettings();
            ps.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void renderListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><fileList></fileList>";
            XDocument doc = XDocument.Parse(header);
            XElement files = doc.Root;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                TBfiles file = row.DataBoundItem as TBfiles;

                XElement rd = new XElement("file", new object[] {
                    new XElement("id", file.Id),
                    new XElement("name", file.Name),
                    new XElement("path", file.Path),
                    new XElement("characterList", file.CharactersList),
                    new XElement("frames", file.Frames),
                    new XElement("exportName", file.ExportName),
                    new XElement("exportPath", file.ExportPath)
                });

                files.Add(rd);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.FileName = "XMLOutput";
            //saveFileDialog.InitialDirectory = "C:\\";
            //saveFileDialog.CheckFileExists = true;
            //saveFileDialog.Filter = "XML (*.xml)|*.xml|All (*.*)|*.*";
            //saveFileDialog.FilterIndex = 2;


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveFileDialog.FileName);
            }
        }

        private void importListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Add xml render list",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = false,
                ShowReadOnly = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.ReadOnlyChecked)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Refresh();
                }

                XDocument doc = XDocument.Load(ofd.FileName);
                //XElement files = doc.Root;

                //TODO add new numbering if multiple lists are imported
                int XMListNum = 0;

                foreach (XElement elem in doc.Descendants("file"))
                {
                    TBfiles TBfile = new TBfiles();
                    TBfile.Id = int.Parse(elem.Element("id").Value) + importXMListNum;
                    TBfile.Name = (string)elem.Element("name").Value;
                    TBfile.Path = (string)elem.Element("path").Value;
                    TBfile.ExportName = (string)elem.Element("exportName").Value;
                    TBfile.Frames = int.Parse(elem.Element("frames").Value);
                    TBfile.ExportPath = (string)elem.Element("exportPath").Value;

                    tBfilesBindingSource.Add(new TBfiles() { Id = TBfile.Id, Name = TBfile.Name, ExportName = TBfile.ExportName, ExportPath = TBfile.ExportPath, Frames = TBfile.Frames, Path = TBfile.Path });

                    XMListNum = TBfile.Id;

                    //Console.WriteLine(XMListNum);

                }

                importXMListNum = XMListNum + 1;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start help form
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void defaultOutputFolder_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void videoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {

            renderProres = videoCodec.SelectedIndex;

            //Console.WriteLine(videoCodec.Text + " index " + renderProres);
            
        }
    }
}
