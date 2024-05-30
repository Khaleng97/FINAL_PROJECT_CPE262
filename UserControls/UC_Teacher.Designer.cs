namespace FINAL_PROJECT_CPE262.UserControls
{
    partial class UC_Teacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Teacher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.tbxSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.sbOC = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.MSDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.dgvTeacher = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fULLNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gENDERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aGEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pHONEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDDRESSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMAILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMAGEDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.tblTeacherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet1 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.SchoolYearTableAdapter();
            this.tblTeacherTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.tblTeacherTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
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
            // sbOC
            // 
            this.sbOC.AllowDragging = false;
            this.sbOC.AllowMultipleViews = true;
            this.sbOC.ClickToClose = true;
            this.sbOC.DoubleClickToClose = true;
            this.sbOC.DurationAfterIdle = 1500;
            this.sbOC.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.ErrorOptions.ActionBorderRadius = 1;
            this.sbOC.ErrorOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbOC.ErrorOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbOC.ErrorOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sbOC.ErrorOptions.BorderColor = System.Drawing.Color.Black;
            this.sbOC.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.sbOC.ErrorOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbOC.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.sbOC.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.sbOC.ErrorOptions.IconLeftMargin = 12;
            this.sbOC.FadeCloseIcon = false;
            this.sbOC.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.sbOC.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.InformationOptions.ActionBorderRadius = 1;
            this.sbOC.InformationOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbOC.InformationOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbOC.InformationOptions.BackColor = System.Drawing.Color.White;
            this.sbOC.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.sbOC.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.sbOC.InformationOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbOC.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.sbOC.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.sbOC.InformationOptions.IconLeftMargin = 12;
            this.sbOC.Margin = 10;
            this.sbOC.MaximumSize = new System.Drawing.Size(0, 0);
            this.sbOC.MaximumViews = 7;
            this.sbOC.MessageRightMargin = 15;
            this.sbOC.MessageTopMargin = 0;
            this.sbOC.MinimumSize = new System.Drawing.Size(0, 0);
            this.sbOC.ShowBorders = false;
            this.sbOC.ShowCloseIcon = false;
            this.sbOC.ShowIcon = true;
            this.sbOC.ShowShadows = true;
            this.sbOC.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.SuccessOptions.ActionBorderRadius = 1;
            this.sbOC.SuccessOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbOC.SuccessOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbOC.SuccessOptions.BackColor = System.Drawing.Color.PaleGreen;
            this.sbOC.SuccessOptions.BorderColor = System.Drawing.Color.Black;
            this.sbOC.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.sbOC.SuccessOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbOC.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.sbOC.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.sbOC.SuccessOptions.IconLeftMargin = 12;
            this.sbOC.ViewsMargin = 7;
            this.sbOC.WarningOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sbOC.WarningOptions.ActionBorderRadius = 1;
            this.sbOC.WarningOptions.ActionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbOC.WarningOptions.ActionForeColor = System.Drawing.Color.Black;
            this.sbOC.WarningOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sbOC.WarningOptions.BorderColor = System.Drawing.Color.Black;
            this.sbOC.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.sbOC.WarningOptions.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.sbOC.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.sbOC.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.sbOC.WarningOptions.IconLeftMargin = 12;
            this.sbOC.ZoomCloseIcon = true;
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
            // dgvTeacher
            // 
            this.dgvTeacher.AllowUserToAddRows = false;
            this.dgvTeacher.AllowUserToDeleteRows = false;
            this.dgvTeacher.AllowUserToResizeColumns = false;
            this.dgvTeacher.AllowUserToResizeRows = false;
            this.dgvTeacher.AutoGenerateColumns = false;
            this.dgvTeacher.ColumnHeadersHeight = 30;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeacher.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.iDDataGridViewTextBoxColumn,
            this.tIDDataGridViewTextBoxColumn,
            this.lNAMEDataGridViewTextBoxColumn,
            this.fNAMEDataGridViewTextBoxColumn,
            this.mNAMEDataGridViewTextBoxColumn,
            this.fULLNAMEDataGridViewTextBoxColumn,
            this.gENDERDataGridViewTextBoxColumn,
            this.dOBDataGridViewTextBoxColumn,
            this.aGEDataGridViewTextBoxColumn,
            this.pHONEDataGridViewTextBoxColumn,
            this.aDDRESSDataGridViewTextBoxColumn,
            this.eMAILDataGridViewTextBoxColumn,
            this.iMAGEDataGridViewImageColumn,
            this.colEdit,
            this.colDel});
            this.dgvTeacher.DataSource = this.tblTeacherBindingSource;
            this.dgvTeacher.Location = new System.Drawing.Point(35, 90);
            this.dgvTeacher.MultiSelect = false;
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.ReadOnly = true;
            this.dgvTeacher.RowHeadersVisible = false;
            this.dgvTeacher.RowHeadersWidth = 51;
            this.dgvTeacher.RowTemplate.Height = 24;
            this.dgvTeacher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeacher.Size = new System.Drawing.Size(980, 433);
            this.dgvTeacher.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvTeacher.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvTeacher.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvTeacher.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DodgerBlue;
            this.dgvTeacher.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTeacher.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeacher.StateNormal.Background.Color1 = System.Drawing.Color.White;
            this.dgvTeacher.StateNormal.Background.Color2 = System.Drawing.Color.White;
            this.dgvTeacher.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.dgvTeacher.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.dgvTeacher.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvTeacher.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.Black;
            this.dgvTeacher.TabIndex = 38;
            this.dgvTeacher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeacher_CellContentClick);
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
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 59;
            // 
            // tIDDataGridViewTextBoxColumn
            // 
            this.tIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tIDDataGridViewTextBoxColumn.DataPropertyName = "TID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.tIDDataGridViewTextBoxColumn.HeaderText = "TID";
            this.tIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tIDDataGridViewTextBoxColumn.Name = "tIDDataGridViewTextBoxColumn";
            this.tIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lNAMEDataGridViewTextBoxColumn
            // 
            this.lNAMEDataGridViewTextBoxColumn.DataPropertyName = "LNAME";
            this.lNAMEDataGridViewTextBoxColumn.HeaderText = "LNAME";
            this.lNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lNAMEDataGridViewTextBoxColumn.Name = "lNAMEDataGridViewTextBoxColumn";
            this.lNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lNAMEDataGridViewTextBoxColumn.Visible = false;
            this.lNAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // fNAMEDataGridViewTextBoxColumn
            // 
            this.fNAMEDataGridViewTextBoxColumn.DataPropertyName = "FNAME";
            this.fNAMEDataGridViewTextBoxColumn.HeaderText = "FNAME";
            this.fNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fNAMEDataGridViewTextBoxColumn.Name = "fNAMEDataGridViewTextBoxColumn";
            this.fNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.fNAMEDataGridViewTextBoxColumn.Visible = false;
            this.fNAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // mNAMEDataGridViewTextBoxColumn
            // 
            this.mNAMEDataGridViewTextBoxColumn.DataPropertyName = "MNAME";
            this.mNAMEDataGridViewTextBoxColumn.HeaderText = "MNAME";
            this.mNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mNAMEDataGridViewTextBoxColumn.Name = "mNAMEDataGridViewTextBoxColumn";
            this.mNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.mNAMEDataGridViewTextBoxColumn.Visible = false;
            this.mNAMEDataGridViewTextBoxColumn.Width = 125;
            // 
            // fULLNAMEDataGridViewTextBoxColumn
            // 
            this.fULLNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fULLNAMEDataGridViewTextBoxColumn.DataPropertyName = "FULLNAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fULLNAMEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fULLNAMEDataGridViewTextBoxColumn.HeaderText = "FULLNAME";
            this.fULLNAMEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fULLNAMEDataGridViewTextBoxColumn.Name = "fULLNAMEDataGridViewTextBoxColumn";
            this.fULLNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gENDERDataGridViewTextBoxColumn
            // 
            this.gENDERDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gENDERDataGridViewTextBoxColumn.DataPropertyName = "GENDER";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gENDERDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.gENDERDataGridViewTextBoxColumn.HeaderText = "GENDER";
            this.gENDERDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.gENDERDataGridViewTextBoxColumn.Name = "gENDERDataGridViewTextBoxColumn";
            this.gENDERDataGridViewTextBoxColumn.ReadOnly = true;
            this.gENDERDataGridViewTextBoxColumn.Width = 102;
            // 
            // dOBDataGridViewTextBoxColumn
            // 
            this.dOBDataGridViewTextBoxColumn.DataPropertyName = "DOB";
            this.dOBDataGridViewTextBoxColumn.HeaderText = "DOB";
            this.dOBDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dOBDataGridViewTextBoxColumn.Name = "dOBDataGridViewTextBoxColumn";
            this.dOBDataGridViewTextBoxColumn.ReadOnly = true;
            this.dOBDataGridViewTextBoxColumn.Visible = false;
            this.dOBDataGridViewTextBoxColumn.Width = 125;
            // 
            // aGEDataGridViewTextBoxColumn
            // 
            this.aGEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.aGEDataGridViewTextBoxColumn.DataPropertyName = "AGE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.aGEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.aGEDataGridViewTextBoxColumn.HeaderText = "AGE";
            this.aGEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aGEDataGridViewTextBoxColumn.Name = "aGEDataGridViewTextBoxColumn";
            this.aGEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aGEDataGridViewTextBoxColumn.Width = 72;
            // 
            // pHONEDataGridViewTextBoxColumn
            // 
            this.pHONEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pHONEDataGridViewTextBoxColumn.DataPropertyName = "PHONE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pHONEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.pHONEDataGridViewTextBoxColumn.HeaderText = "PHONE";
            this.pHONEDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pHONEDataGridViewTextBoxColumn.Name = "pHONEDataGridViewTextBoxColumn";
            this.pHONEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDDRESSDataGridViewTextBoxColumn
            // 
            this.aDDRESSDataGridViewTextBoxColumn.DataPropertyName = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.HeaderText = "ADDRESS";
            this.aDDRESSDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aDDRESSDataGridViewTextBoxColumn.Name = "aDDRESSDataGridViewTextBoxColumn";
            this.aDDRESSDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDDRESSDataGridViewTextBoxColumn.Visible = false;
            this.aDDRESSDataGridViewTextBoxColumn.Width = 125;
            // 
            // eMAILDataGridViewTextBoxColumn
            // 
            this.eMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.eMAILDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eMAILDataGridViewTextBoxColumn.Name = "eMAILDataGridViewTextBoxColumn";
            this.eMAILDataGridViewTextBoxColumn.ReadOnly = true;
            this.eMAILDataGridViewTextBoxColumn.Visible = false;
            this.eMAILDataGridViewTextBoxColumn.Width = 125;
            // 
            // iMAGEDataGridViewImageColumn
            // 
            this.iMAGEDataGridViewImageColumn.DataPropertyName = "IMAGE";
            this.iMAGEDataGridViewImageColumn.HeaderText = "IMAGE";
            this.iMAGEDataGridViewImageColumn.MinimumWidth = 6;
            this.iMAGEDataGridViewImageColumn.Name = "iMAGEDataGridViewImageColumn";
            this.iMAGEDataGridViewImageColumn.ReadOnly = true;
            this.iMAGEDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iMAGEDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iMAGEDataGridViewImageColumn.Visible = false;
            this.iMAGEDataGridViewImageColumn.Width = 125;
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
            // UC_Teacher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvTeacher);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Teacher";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1047, 571);
            this.Load += new System.EventHandler(this.UC_Teacher_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTeacherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        public Guna.UI2.WinForms.Guna2TextBox tbxSearch;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private SMSDataSet sMSDataSet;
        private SMSDataSetTableAdapters.SchoolYearTableAdapter schoolYearTableAdapter;
        private Bunifu.UI.WinForms.BunifuSnackbar sbOC;
        private Guna.UI2.WinForms.Guna2MessageDialog MSDialog;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvTeacher;
        private System.Windows.Forms.BindingSource tblTeacherBindingSource;
        private SMSDataSet sMSDataSet1;
        private SMSDataSetTableAdapters.tblTeacherTableAdapter tblTeacherTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fULLNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gENDERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aGEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pHONEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDDRESSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMAILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMAGEDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDel;
    }
}
