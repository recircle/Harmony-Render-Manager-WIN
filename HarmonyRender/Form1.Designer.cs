
namespace HarmonyRender
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.defaultOutputFolder = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Frames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Render = new System.Windows.Forms.DataGridViewImageColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.exportPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.framesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.framesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportPathDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttBrowse = new System.Windows.Forms.Button();
            this.rederingTextOutput = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.PanelForBar = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttDelSelected = new System.Windows.Forms.Button();
            this.buttAddDir = new System.Windows.Forms.Button();
            this.buttAddFile = new System.Windows.Forms.Button();
            this.buttRenderAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.videoCodec = new System.Windows.Forms.ComboBox();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportPathDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBfilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.PanelForBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBfilesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultOutputFolder
            // 
            this.defaultOutputFolder.AllowDrop = true;
            this.defaultOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultOutputFolder.Location = new System.Drawing.Point(138, 41);
            this.defaultOutputFolder.MaximumSize = new System.Drawing.Size(290, 20);
            this.defaultOutputFolder.MinimumSize = new System.Drawing.Size(290, 20);
            this.defaultOutputFolder.Name = "defaultOutputFolder";
            this.defaultOutputFolder.Size = new System.Drawing.Size(290, 20);
            this.defaultOutputFolder.TabIndex = 1;
            this.defaultOutputFolder.Text = "Set default export dir";
            this.defaultOutputFolder.TextChanged += new System.EventHandler(this.defaultOutputFolder_TextChanged);
            this.defaultOutputFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.defaultOutputFolder_DragDrop);
            this.defaultOutputFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.defaultOutputFolder_DragEnter);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Select,
            this.nameDataGridViewTextBoxColumn2,
            this.exportNameDataGridViewTextBoxColumn2,
            this.exportPathDataGridViewTextBoxColumn2,
            this.Frames,
            this.Path,
            this.Render,
            this.Remove,
            this.Status});
            this.dataGridView.DataSource = this.tBfilesBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.Location = new System.Drawing.Point(15, 79);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
            this.dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1124, 760);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseUp);
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Selected";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Select.DefaultCellStyle = dataGridViewCellStyle2;
            this.Select.FillWeight = 30F;
            this.Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 30;
            // 
            // Frames
            // 
            this.Frames.DataPropertyName = "Frames";
            this.Frames.HeaderText = "Frames";
            this.Frames.Name = "Frames";
            this.Frames.Width = 40;
            // 
            // Path
            // 
            this.Path.DataPropertyName = "Path";
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.Visible = false;
            // 
            // Render
            // 
            this.Render.HeaderText = "Render";
            this.Render.Image = global::HarmonyRender.Properties.Resources.RENDER_FILE;
            this.Render.Name = "Render";
            this.Render.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Render.ToolTipText = "Render this file";
            this.Render.Width = 60;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "Remove";
            this.Remove.Image = global::HarmonyRender.Properties.Resources.X;
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.ToolTipText = "Remove this file";
            this.Remove.Width = 60;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Image = global::HarmonyRender.Properties.Resources.STATUS_EMPTY;
            this.Status.Name = "Status";
            this.Status.Width = 60;
            // 
            // exportPathDataGridViewTextBoxColumn
            // 
            this.exportPathDataGridViewTextBoxColumn.DataPropertyName = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn.HeaderText = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn.Name = "exportPathDataGridViewTextBoxColumn";
            // 
            // exportNameDataGridViewTextBoxColumn
            // 
            this.exportNameDataGridViewTextBoxColumn.DataPropertyName = "ExportName";
            this.exportNameDataGridViewTextBoxColumn.HeaderText = "ExportName";
            this.exportNameDataGridViewTextBoxColumn.Name = "exportNameDataGridViewTextBoxColumn";
            // 
            // framesDataGridViewTextBoxColumn
            // 
            this.framesDataGridViewTextBoxColumn.DataPropertyName = "Frames";
            this.framesDataGridViewTextBoxColumn.HeaderText = "Frames";
            this.framesDataGridViewTextBoxColumn.Name = "framesDataGridViewTextBoxColumn";
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // pathDataGridViewTextBoxColumn1
            // 
            this.pathDataGridViewTextBoxColumn1.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn1.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn1.Name = "pathDataGridViewTextBoxColumn1";
            // 
            // framesDataGridViewTextBoxColumn1
            // 
            this.framesDataGridViewTextBoxColumn1.DataPropertyName = "Frames";
            this.framesDataGridViewTextBoxColumn1.HeaderText = "Frames";
            this.framesDataGridViewTextBoxColumn1.Name = "framesDataGridViewTextBoxColumn1";
            // 
            // exportNameDataGridViewTextBoxColumn1
            // 
            this.exportNameDataGridViewTextBoxColumn1.DataPropertyName = "ExportName";
            this.exportNameDataGridViewTextBoxColumn1.HeaderText = "ExportName";
            this.exportNameDataGridViewTextBoxColumn1.Name = "exportNameDataGridViewTextBoxColumn1";
            // 
            // exportPathDataGridViewTextBoxColumn1
            // 
            this.exportPathDataGridViewTextBoxColumn1.DataPropertyName = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn1.HeaderText = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn1.Name = "exportPathDataGridViewTextBoxColumn1";
            // 
            // buttBrowse
            // 
            this.buttBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttBrowse.ForeColor = System.Drawing.Color.Silver;
            this.buttBrowse.Location = new System.Drawing.Point(429, 39);
            this.buttBrowse.Name = "buttBrowse";
            this.buttBrowse.Size = new System.Drawing.Size(85, 23);
            this.buttBrowse.TabIndex = 7;
            this.buttBrowse.Text = "Browse";
            this.buttBrowse.UseVisualStyleBackColor = true;
            this.buttBrowse.Click += new System.EventHandler(this.buttBrowse_Click);
            // 
            // rederingTextOutput
            // 
            this.rederingTextOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rederingTextOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rederingTextOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rederingTextOutput.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.rederingTextOutput.Location = new System.Drawing.Point(535, 41);
            this.rederingTextOutput.Name = "rederingTextOutput";
            this.rederingTextOutput.Size = new System.Drawing.Size(142, 13);
            this.rederingTextOutput.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.progressBar.Location = new System.Drawing.Point(-1, -1);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.MaximumSize = new System.Drawing.Size(602, 8);
            this.progressBar.MinimumSize = new System.Drawing.Size(602, 8);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(602, 8);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // PanelForBar
            // 
            this.PanelForBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelForBar.Controls.Add(this.progressBar);
            this.PanelForBar.Location = new System.Drawing.Point(535, 55);
            this.PanelForBar.MaximumSize = new System.Drawing.Size(600, 6);
            this.PanelForBar.MinimumSize = new System.Drawing.Size(600, 6);
            this.PanelForBar.Name = "PanelForBar";
            this.PanelForBar.Size = new System.Drawing.Size(600, 6);
            this.PanelForBar.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1161, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderListToolStripMenuItem,
            this.importListToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // renderListToolStripMenuItem
            // 
            this.renderListToolStripMenuItem.Name = "renderListToolStripMenuItem";
            this.renderListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.renderListToolStripMenuItem.Text = "Export xml list";
            this.renderListToolStripMenuItem.Click += new System.EventHandler(this.renderListToolStripMenuItem_Click);
            // 
            // importListToolStripMenuItem
            // 
            this.importListToolStripMenuItem.Name = "importListToolStripMenuItem";
            this.importListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.importListToolStripMenuItem.Text = "Import xml list";
            this.importListToolStripMenuItem.Click += new System.EventHandler(this.importListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Render";
            this.dataGridViewImageColumn1.Image = global::HarmonyRender.Properties.Resources.YES;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.ToolTipText = "Render this file";
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DividerWidth = 10;
            this.dataGridViewImageColumn2.FillWeight = 90F;
            this.dataGridViewImageColumn2.HeaderText = "Remove";
            this.dataGridViewImageColumn2.Image = global::HarmonyRender.Properties.Resources.X;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.ToolTipText = "Remove this file";
            this.dataGridViewImageColumn2.Width = 60;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Status";
            this.dataGridViewImageColumn3.Image = global::HarmonyRender.Properties.Resources.STATUS_EMPTY;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 60;
            // 
            // buttDelSelected
            // 
            this.buttDelSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttDelSelected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttDelSelected.FlatAppearance.BorderSize = 0;
            this.buttDelSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttDelSelected.Image = global::HarmonyRender.Properties.Resources.REMOVE_FILE;
            this.buttDelSelected.Location = new System.Drawing.Point(15, 857);
            this.buttDelSelected.Margin = new System.Windows.Forms.Padding(0);
            this.buttDelSelected.MaximumSize = new System.Drawing.Size(30, 30);
            this.buttDelSelected.MinimumSize = new System.Drawing.Size(30, 30);
            this.buttDelSelected.Name = "buttDelSelected";
            this.buttDelSelected.Size = new System.Drawing.Size(30, 30);
            this.buttDelSelected.TabIndex = 11;
            this.buttDelSelected.UseVisualStyleBackColor = true;
            this.buttDelSelected.Click += new System.EventHandler(this.buttDelSelected_Click);
            // 
            // buttAddDir
            // 
            this.buttAddDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttAddDir.FlatAppearance.BorderSize = 0;
            this.buttAddDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAddDir.Image = global::HarmonyRender.Properties.Resources.ADD_FOLDER;
            this.buttAddDir.Location = new System.Drawing.Point(55, 35);
            this.buttAddDir.Margin = new System.Windows.Forms.Padding(0);
            this.buttAddDir.MaximumSize = new System.Drawing.Size(30, 30);
            this.buttAddDir.Name = "buttAddDir";
            this.buttAddDir.Size = new System.Drawing.Size(30, 30);
            this.buttAddDir.TabIndex = 6;
            this.buttAddDir.UseVisualStyleBackColor = true;
            this.buttAddDir.Click += new System.EventHandler(this.addDir_Click);
            // 
            // buttAddFile
            // 
            this.buttAddFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttAddFile.FlatAppearance.BorderSize = 0;
            this.buttAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttAddFile.Image = global::HarmonyRender.Properties.Resources.ADD_FILE;
            this.buttAddFile.Location = new System.Drawing.Point(15, 35);
            this.buttAddFile.Margin = new System.Windows.Forms.Padding(0);
            this.buttAddFile.Name = "buttAddFile";
            this.buttAddFile.Size = new System.Drawing.Size(30, 30);
            this.buttAddFile.TabIndex = 5;
            this.buttAddFile.UseVisualStyleBackColor = true;
            this.buttAddFile.Click += new System.EventHandler(this.addFile_Click);
            // 
            // buttRenderAll
            // 
            this.buttRenderAll.FlatAppearance.BorderSize = 0;
            this.buttRenderAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttRenderAll.Image = global::HarmonyRender.Properties.Resources.RENDER_ALL;
            this.buttRenderAll.Location = new System.Drawing.Point(95, 35);
            this.buttRenderAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttRenderAll.Name = "buttRenderAll";
            this.buttRenderAll.Size = new System.Drawing.Size(30, 30);
            this.buttRenderAll.TabIndex = 4;
            this.buttRenderAll.UseVisualStyleBackColor = true;
            this.buttRenderAll.Click += new System.EventHandler(this.renderAll_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(70, 864);
            this.label5.MaximumSize = new System.Drawing.Size(120, 15);
            this.label5.MinimumSize = new System.Drawing.Size(120, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Export settings";
            // 
            // videoCodec
            // 
            this.videoCodec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.videoCodec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoCodec.FormattingEnabled = true;
            this.videoCodec.Items.AddRange(new object[] {
            "proresHQ",
            "proresLT",
            "prores444",
            "prores4444Alpha"});
            this.videoCodec.Location = new System.Drawing.Point(187, 862);
            this.videoCodec.Name = "videoCodec";
            this.videoCodec.Size = new System.Drawing.Size(208, 21);
            this.videoCodec.TabIndex = 20;
            this.videoCodec.SelectedIndexChanged += new System.EventHandler(this.videoCodec_SelectedIndexChanged);
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.nameDataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.nameDataGridViewTextBoxColumn2.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            this.nameDataGridViewTextBoxColumn2.Width = 200;
            // 
            // exportNameDataGridViewTextBoxColumn2
            // 
            this.exportNameDataGridViewTextBoxColumn2.DataPropertyName = "ExportName";
            this.exportNameDataGridViewTextBoxColumn2.HeaderText = "ExportName";
            this.exportNameDataGridViewTextBoxColumn2.Name = "exportNameDataGridViewTextBoxColumn2";
            this.exportNameDataGridViewTextBoxColumn2.Width = 200;
            // 
            // exportPathDataGridViewTextBoxColumn2
            // 
            this.exportPathDataGridViewTextBoxColumn2.DataPropertyName = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn2.FillWeight = 200F;
            this.exportPathDataGridViewTextBoxColumn2.HeaderText = "ExportPath";
            this.exportPathDataGridViewTextBoxColumn2.Name = "exportPathDataGridViewTextBoxColumn2";
            this.exportPathDataGridViewTextBoxColumn2.Width = 450;
            // 
            // tBfilesBindingSource
            // 
            this.tBfilesBindingSource.DataSource = typeof(HarmonyRender.TBfiles);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1161, 911);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.videoCodec);
            this.Controls.Add(this.buttDelSelected);
            this.Controls.Add(this.PanelForBar);
            this.Controls.Add(this.rederingTextOutput);
            this.Controls.Add(this.buttBrowse);
            this.Controls.Add(this.buttAddDir);
            this.Controls.Add(this.buttAddFile);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.defaultOutputFolder);
            this.Controls.Add(this.buttRenderAll);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HarmonyRender 22";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.PanelForBar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBfilesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox defaultOutputFolder;
        private System.Windows.Forms.Button buttRenderAll;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn framesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn framesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportPathDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource tBfilesBindingSource;
        private System.Windows.Forms.Button buttAddFile;
        private System.Windows.Forms.Button buttAddDir;
        private System.Windows.Forms.Button buttBrowse;
        private System.Windows.Forms.TextBox rederingTextOutput;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Panel PanelForBar;
        private System.Windows.Forms.Button buttDelSelected;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderListToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn exportPathDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewImageColumn Render;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.ToolStripMenuItem importListToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox videoCodec;
    }
}

