namespace FINAL_PROJECT_CPE262.UserControls
{
    partial class UC_Section
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Section));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.sbSec = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.MSDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.dgvSection = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRADEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sECTIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.tblSectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet2 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.tblTeacherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet1 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.SchoolYearTableAdapter();
            this.tblTeacherTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.tblTeacherTableAdapter();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.cbxGrade = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSection = new Guna.UI2.WinForms.Guna2TextBox();
            this.tblSectionTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.tblSectionTableAdapter();
            this.lblID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTeacherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.tbxSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderColor = System.Drawing.Color.White;
            this.btnAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(41)))), ((int)(((byte)(74)))));
            this.btnAdd.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.btnAdd.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnAdd.CustomImages.CheckedImage = ((System.Drawing.Image)(resources.GetObject("resource.CheckedImage")));
            this.btnAdd.CustomImages.HoveredImage = ((System.Drawing.Image)(resources.GetObject("resource.HoveredImage")));
            this.btnAdd.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.CustomImages.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.btnAdd.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.btnAdd.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnAdd.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAdd.Size = new System.Drawing.Size(171, 50);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "ADD NEW";
            this.btnAdd.TextOffset = new System.Drawing.Point(25, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.AutoRoundedCorners = true;
            this.tbxSearch.BackColor = System.Drawing.Color.Transparent;
            this.tbxSearch.BorderColor = System.Drawing.Color.White;
            this.tbxSearch.BorderRadius = 19;
            this.tbxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxSearch.DefaultText = "";
            this.tbxSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.tbxSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.tbxSearch.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.ForeColor = System.Drawing.Color.White;
            this.tbxSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(65)))), ((int)(((byte)(206)))));
            this.tbxSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbxSearch.IconLeft")));
            this.tbxSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.tbxSearch.Location = new System.Drawing.Point(735, 5);
            this.tbxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PasswordChar = '\0';
            this.tbxSearch.PlaceholderText = "Search";
            this.tbxSearch.SelectedText = "";
            this.tbxSearch.Size = new System.Drawing.Size(270, 40);
            this.tbxSearch.TabIndex = 64;
            this.tbxSearch.TextOffset = new System.Drawing.Point(50, 0);
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // sbSec
            // 
            this.sbSec.AllowDragging = false;
            this.sbSec.AllowMultipleViews = true;
            this.sbSec.ClickToClose = true;
            this.sbSec.DoubleClickToClose = true;
            this.sbSec.DurationAfterIdle = 1500;
            this.sbSec.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.ErrorOptions.ActionBorderRadius = 1;
            this.sbSec.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbSec.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbSec.ErrorOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sbSec.ErrorOptions.BorderColor = System.Drawing.Color.Black;
            this.sbSec.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.sbSec.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbSec.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.sbSec.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.sbSec.ErrorOptions.IconLeftMargin = 12;
            this.sbSec.FadeCloseIcon = false;
            this.sbSec.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.sbSec.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.InformationOptions.ActionBorderRadius = 1;
            this.sbSec.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbSec.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbSec.InformationOptions.BackColor = System.Drawing.Color.White;
            this.sbSec.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.sbSec.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.sbSec.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbSec.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.sbSec.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.sbSec.InformationOptions.IconLeftMargin = 12;
            this.sbSec.Margin = 10;
            this.sbSec.MaximumSize = new System.Drawing.Size(0, 0);
            this.sbSec.MaximumViews = 7;
            this.sbSec.MessageRightMargin = 15;
            this.sbSec.MessageTopMargin = 0;
            this.sbSec.MinimumSize = new System.Drawing.Size(0, 0);
            this.sbSec.ShowBorders = false;
            this.sbSec.ShowCloseIcon = false;
            this.sbSec.ShowIcon = true;
            this.sbSec.ShowShadows = true;
            this.sbSec.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.SuccessOptions.ActionBorderRadius = 1;
            this.sbSec.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbSec.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbSec.SuccessOptions.BackColor = System.Drawing.Color.PaleGreen;
            this.sbSec.SuccessOptions.BorderColor = System.Drawing.Color.Black;
            this.sbSec.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.sbSec.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbSec.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.sbSec.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.sbSec.SuccessOptions.IconLeftMargin = 12;
            this.sbSec.ViewsMargin = 7;
            this.sbSec.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbSec.WarningOptions.ActionBorderRadius = 1;
            this.sbSec.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbSec.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbSec.WarningOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sbSec.WarningOptions.BorderColor = System.Drawing.Color.Black;
            this.sbSec.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.sbSec.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbSec.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.sbSec.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.sbSec.WarningOptions.IconLeftMargin = 12;
            this.sbSec.ZoomCloseIcon = true;
            // 
            // MSDialog
            // 
            this.MSDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MSDialog.Caption = null;
            this.MSDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.MSDialog.Parent = null;
            this.MSDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.MSDialog.Text = null;
            // 
            // dgvSection
            // 
            this.dgvSection.AllowUserToAddRows = false;
            this.dgvSection.AllowUserToDeleteRows = false;
            this.dgvSection.AllowUserToResizeColumns = false;
            this.dgvSection.AllowUserToResizeRows = false;
            this.dgvSection.AutoGenerateColumns = false;
            this.dgvSection.ColumnHeadersHeight = 30;
            this.dgvSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.secIDDataGridViewTextBoxColumn,
            this.gRADEDataGridViewTextBoxColumn,
            this.sECTIONDataGridViewTextBoxColumn,
            this.colEdit,
            this.colDel});
            this.dgvSection.DataSource = this.tblSectionBindingSource;
            this.dgvSection.Location = new System.Drawing.Point(112, 251);
            this.dgvSection.MultiSelect = false;
            this.dgvSection.Name = "dgvSection";
            this.dgvSection.ReadOnly = true;
            this.dgvSection.RowHeadersVisible = false;
            this.dgvSection.RowHeadersWidth = 51;
            this.dgvSection.RowTemplate.Height = 24;
            this.dgvSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSection.Size = new System.Drawing.Size(815, 283);
            this.dgvSection.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvSection.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvSection.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvSection.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DodgerBlue;
            this.dgvSection.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvSection.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSection.StateNormal.Background.Color1 = System.Drawing.Color.White;
            this.dgvSection.StateNormal.Background.Color2 = System.Drawing.Color.White;
            this.dgvSection.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.dgvSection.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.dgvSection.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvSection.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.Black;
            this.dgvSection.TabIndex = 38;
            this.dgvSection.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSection_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "#";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 51;
            // 
            // secIDDataGridViewTextBoxColumn
            // 
            this.secIDDataGridViewTextBoxColumn.DataPropertyName = "Sec_ID";
            this.secIDDataGridViewTextBoxColumn.HeaderText = "Sec_ID";
            this.secIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.secIDDataGridViewTextBoxColumn.Name = "secIDDataGridViewTextBoxColumn";
            this.secIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.secIDDataGridViewTextBoxColumn.Visible = false;
            this.secIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // gRADEDataGridViewTextBoxColumn
            // 
            this.gRADEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gRADEDataGridViewTextBoxColumn.DataPropertyName = "GRADE";
            this.gRADEDataGridViewTextBoxColumn.HeaderText = "GRADE";
            this.gRADEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.gRADEDataGridViewTextBoxColumn.Name = "gRADEDataGridViewTextBoxColumn";
            this.gRADEDataGridViewTextBoxColumn.ReadOnly = true;
            this.gRADEDataGridViewTextBoxColumn.Width = 93;
            // 
            // sECTIONDataGridViewTextBoxColumn
            // 
            this.sECTIONDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sECTIONDataGridViewTextBoxColumn.DataPropertyName = "SECTION";
            this.sECTIONDataGridViewTextBoxColumn.HeaderText = "SECTION NAME";
            this.sECTIONDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sECTIONDataGridViewTextBoxColumn.Name = "sECTIONDataGridViewTextBoxColumn";
            this.sECTIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 7;
            // 
            // colDel
            // 
            this.colDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDel.HeaderText = "";
            this.colDel.Image = ((System.Drawing.Image)(resources.GetObject("colDel.Image")));
            this.colDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colDel.MinimumWidth = 6;
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Width = 7;
            // 
            // tblSectionBindingSource
            // 
            this.tblSectionBindingSource.DataMember = "tblSection";
            this.tblSectionBindingSource.DataSource = this.sMSDataSet2;
            // 
            // sMSDataSet2
            // 
            this.sMSDataSet2.DataSetName = "SMSDataSet";
            this.sMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblTeacherBindingSource
            // 
            this.tblTeacherBindingSource.DataMember = "tblTeacher";
            this.tblTeacherBindingSource.DataSource = this.sMSDataSet1;
            // 
            // sMSDataSet1
            // 
            this.sMSDataSet1.DataSetName = "SMSDataSet";
            this.sMSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schoolYearBindingSource
            // 
            this.schoolYearBindingSource.DataMember = "SchoolYear";
            this.schoolYearBindingSource.DataSource = this.sMSDataSet;
            // 
            // sMSDataSet
            // 
            this.sMSDataSet.DataSetName = "SMSDataSet";
            this.sMSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // schoolYearTableAdapter
            // 
            this.schoolYearTableAdapter.ClearBeforeFill = true;
            // 
            // tblTeacherTableAdapter
            // 
            this.tblTeacherTableAdapter.ClearBeforeFill = true;
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.AllowMouseEffects = true;
            this.btnSave.AllowToggling = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoRoundBorders = true;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.ButtonText = "SAVE";
            this.btnSave.ButtonTextMarginLeft = 0;
            this.btnSave.ColorContrastOnClick = 45;
            this.btnSave.ColorContrastOnHover = 45;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSave.CustomizableEdges = borderEdges1;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnSave.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnSave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconLeft = null;
            this.btnSave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSave.IconMarginLeft = 11;
            this.btnSave.IconPadding = 10;
            this.btnSave.IconRight = null;
            this.btnSave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSave.IconSize = 25;
            this.btnSave.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnSave.IdleBorderRadius = 0;
            this.btnSave.IdleBorderThickness = 0;
            this.btnSave.IdleFillColor = System.Drawing.Color.Empty;
            this.btnSave.IdleIconLeftImage = null;
            this.btnSave.IdleIconRightImage = null;
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(660, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.OnDisabledState.BorderRadius = 39;
            this.btnSave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnDisabledState.BorderThickness = 1;
            this.btnSave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.OnDisabledState.IconLeftImage = null;
            this.btnSave.OnDisabledState.IconRightImage = null;
            this.btnSave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.BorderRadius = 39;
            this.btnSave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.onHoverState.BorderThickness = 1;
            this.btnSave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnSave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.onHoverState.IconLeftImage = null;
            this.btnSave.onHoverState.IconRightImage = null;
            this.btnSave.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.btnSave.OnIdleState.BorderRadius = 39;
            this.btnSave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnIdleState.BorderThickness = 1;
            this.btnSave.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.btnSave.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnIdleState.IconLeftImage = null;
            this.btnSave.OnIdleState.IconRightImage = null;
            this.btnSave.OnPressedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnPressedState.BorderRadius = 39;
            this.btnSave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnPressedState.BorderThickness = 1;
            this.btnSave.OnPressedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnPressedState.IconLeftImage = null;
            this.btnSave.OnPressedState.IconRightImage = null;
            this.btnSave.Size = new System.Drawing.Size(100, 39);
            this.btnSave.TabIndex = 86;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxGrade
            // 
            this.cbxGrade.AutoRoundedCorners = true;
            this.cbxGrade.BackColor = System.Drawing.Color.Transparent;
            this.cbxGrade.BorderRadius = 17;
            this.cbxGrade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrade.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxGrade.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxGrade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxGrade.ItemHeight = 30;
            this.cbxGrade.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10"});
            this.cbxGrade.Location = new System.Drawing.Point(304, 101);
            this.cbxGrade.Name = "cbxGrade";
            this.cbxGrade.Size = new System.Drawing.Size(413, 36);
            this.cbxGrade.TabIndex = 84;
            this.cbxGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAd
            // 
            this.btnAd.AllowAnimations = true;
            this.btnAd.AllowMouseEffects = true;
            this.btnAd.AllowToggling = false;
            this.btnAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAd.AnimationSpeed = 200;
            this.btnAd.AutoGenerateColors = false;
            this.btnAd.AutoRoundBorders = true;
            this.btnAd.AutoSizeLeftIcon = true;
            this.btnAd.AutoSizeRightIcon = true;
            this.btnAd.BackColor = System.Drawing.Color.Transparent;
            this.btnAd.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.btnAd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAd.BackgroundImage")));
            this.btnAd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAd.ButtonText = "ADD";
            this.btnAd.ButtonTextMarginLeft = 0;
            this.btnAd.ColorContrastOnClick = 45;
            this.btnAd.ColorContrastOnHover = 45;
            this.btnAd.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnAd.CustomizableEdges = borderEdges2;
            this.btnAd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAd.DisabledFillColor = System.Drawing.Color.Empty;
            this.btnAd.DisabledForecolor = System.Drawing.Color.Empty;
            this.btnAd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAd.ForeColor = System.Drawing.Color.White;
            this.btnAd.IconLeft = null;
            this.btnAd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnAd.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnAd.IconMarginLeft = 11;
            this.btnAd.IconPadding = 10;
            this.btnAd.IconRight = null;
            this.btnAd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnAd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnAd.IconSize = 25;
            this.btnAd.IdleBorderColor = System.Drawing.Color.Empty;
            this.btnAd.IdleBorderRadius = 0;
            this.btnAd.IdleBorderThickness = 0;
            this.btnAd.IdleFillColor = System.Drawing.Color.Empty;
            this.btnAd.IdleIconLeftImage = null;
            this.btnAd.IdleIconRightImage = null;
            this.btnAd.IndicateFocus = true;
            this.btnAd.Location = new System.Drawing.Point(785, 197);
            this.btnAd.Name = "btnAd";
            this.btnAd.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnAd.OnDisabledState.BorderRadius = 39;
            this.btnAd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAd.OnDisabledState.BorderThickness = 1;
            this.btnAd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAd.OnDisabledState.IconLeftImage = null;
            this.btnAd.OnDisabledState.IconRightImage = null;
            this.btnAd.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.btnAd.onHoverState.BorderRadius = 39;
            this.btnAd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAd.onHoverState.BorderThickness = 1;
            this.btnAd.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(62)))), ((int)(((byte)(120)))));
            this.btnAd.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnAd.onHoverState.IconLeftImage = null;
            this.btnAd.onHoverState.IconRightImage = null;
            this.btnAd.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnAd.OnIdleState.BorderRadius = 39;
            this.btnAd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAd.OnIdleState.BorderThickness = 1;
            this.btnAd.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.btnAd.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnAd.OnIdleState.IconLeftImage = null;
            this.btnAd.OnIdleState.IconRightImage = null;
            this.btnAd.OnPressedState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAd.OnPressedState.BorderRadius = 39;
            this.btnAd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAd.OnPressedState.BorderThickness = 1;
            this.btnAd.OnPressedState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnAd.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnAd.OnPressedState.IconLeftImage = null;
            this.btnAd.OnPressedState.IconRightImage = null;
            this.btnAd.Size = new System.Drawing.Size(100, 39);
            this.btnAd.TabIndex = 83;
            this.btnAd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAd.TextMarginLeft = 0;
            this.btnAd.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnAd.UseDefaultRadiusAndThickness = true;
            this.btnAd.Click += new System.EventHandler(this.btnAd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.label2.Location = new System.Drawing.Point(155, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 82;
            this.label2.Text = "SECTION NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(155, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 81;
            this.label1.Text = "GRADE";
            // 
            // tbxSection
            // 
            this.tbxSection.BackColor = System.Drawing.Color.Transparent;
            this.tbxSection.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.tbxSection.BorderRadius = 15;
            this.tbxSection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxSection.DefaultText = "";
            this.tbxSection.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbxSection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbxSection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSection.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbxSection.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxSection.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.tbxSection.ForeColor = System.Drawing.Color.Black;
            this.tbxSection.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbxSection.Location = new System.Drawing.Point(304, 148);
            this.tbxSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxSection.Multiline = true;
            this.tbxSection.Name = "tbxSection";
            this.tbxSection.PasswordChar = '\0';
            this.tbxSection.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbxSection.PlaceholderText = "";
            this.tbxSection.SelectedText = "";
            this.tbxSection.Size = new System.Drawing.Size(413, 36);
            this.tbxSection.TabIndex = 87;
            this.tbxSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tblSectionTableAdapter
            // 
            this.tblSectionTableAdapter.ClearBeforeFill = true;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(155, 197);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(60, 18);
            this.lblID.TabIndex = 88;
            this.lblID.Text = "GRADE";
            // 
            // UC_Section
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.tbxSection);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxGrade);
            this.Controls.Add(this.btnAd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSection);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Section";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1047, 571);
            this.Load += new System.EventHandler(this.UC_Section_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblSectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTeacherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        public Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private SMSDataSet sMSDataSet;
        private SMSDataSetTableAdapters.SchoolYearTableAdapter schoolYearTableAdapter;
        private Bunifu.UI.WinForms.BunifuSnackbar sbSec;
        private Guna.UI2.WinForms.Guna2MessageDialog MSDialog;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvSection;
        private System.Windows.Forms.BindingSource tblTeacherBindingSource;
        private SMSDataSet sMSDataSet1;
        private SMSDataSetTableAdapters.tblTeacherTableAdapter tblTeacherTableAdapter;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Guna.UI2.WinForms.Guna2ComboBox cbxGrade;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbxSection;
        private System.Windows.Forms.BindingSource tblSectionBindingSource;
        private SMSDataSet sMSDataSet2;
        private SMSDataSetTableAdapters.tblSectionTableAdapter tblSectionTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn secIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRADEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sECTIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
        private System.Windows.Forms.Label lblID;
    }
}
