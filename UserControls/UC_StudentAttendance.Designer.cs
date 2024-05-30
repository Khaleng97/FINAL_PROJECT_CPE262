namespace FINAL_PROJECT_CPE262.UserControls
{
    partial class UC_StudentAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_StudentAttendance));
            this.classSubjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet2 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.classSubjectBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.classesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbOC = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.MSDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet3 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.tblTeacherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet1 = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sMSDataSet = new FINAL_PROJECT_CPE262.SMSDataSet();
            this.schoolYearTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.SchoolYearTableAdapter();
            this.tblTeacherTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.tblTeacherTableAdapter();
            this.classesTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.ClassesTableAdapter();
            this.classSubjectTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.ClassSubjectTableAdapter();
            this.classSubjectTableAdapter1 = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.ClassSubjectTableAdapter();
            this.lblQuarter = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblYear = new Bunifu.UI.WinForms.BunifuLabel();
            this.lblQID = new Bunifu.UI.WinForms.BunifuLabel();
            this.attendanceTableAdapter = new FINAL_PROJECT_CPE262.SMSDataSetTableAdapters.AttendanceTableAdapter();
            this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTRIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEASONDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUBIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dATEDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qTRIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEASONDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.dgvStudRep = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.dpAttDate = new System.Windows.Forms.DateTimePicker();
            this.bunifuLabel12 = new Bunifu.UI.WinForms.BunifuLabel();
            this.cbxRepSub = new Guna.UI2.WinForms.Guna2ComboBox();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTeacherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudRep)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // classSubjectBindingSource
            // 
            this.classSubjectBindingSource.DataMember = "ClassSubject";
            this.classSubjectBindingSource.DataSource = this.sMSDataSet2;
            // 
            // sMSDataSet2
            // 
            this.sMSDataSet2.DataSetName = "SMSDataSet";
            this.sMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classSubjectBindingSource1
            // 
            this.classSubjectBindingSource1.DataMember = "ClassSubject";
            this.classSubjectBindingSource1.DataSource = this.sMSDataSet2;
            // 
            // classesBindingSource
            // 
            this.classesBindingSource.DataMember = "Classes";
            this.classesBindingSource.DataSource = this.sMSDataSet2;
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
            this.sbOC.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.sbOC.ErrorOptions.BorderColor = System.Drawing.Color.White;
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
            this.sbOC.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.sbOC.SuccessOptions.BorderColor = System.Drawing.Color.White;
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
            this.sbOC.WarningOptions.BackColor = System.Drawing.Color.White;
            this.sbOC.WarningOptions.BorderColor = System.Drawing.Color.White;
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
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "Attendance";
            this.attendanceBindingSource.DataSource = this.sMSDataSet3;
            // 
            // sMSDataSet3
            // 
            this.sMSDataSet3.DataSetName = "SMSDataSet";
            this.sMSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // classesTableAdapter
            // 
            this.classesTableAdapter.ClearBeforeFill = true;
            // 
            // classSubjectTableAdapter
            // 
            this.classSubjectTableAdapter.ClearBeforeFill = true;
            // 
            // classSubjectTableAdapter1
            // 
            this.classSubjectTableAdapter1.ClearBeforeFill = true;
            // 
            // lblQuarter
            // 
            this.lblQuarter.AllowParentOverrides = false;
            this.lblQuarter.AutoEllipsis = false;
            this.lblQuarter.AutoSize = false;
            this.lblQuarter.CursorType = null;
            this.lblQuarter.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuarter.ForeColor = System.Drawing.Color.Transparent;
            this.lblQuarter.Location = new System.Drawing.Point(451, 70);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQuarter.Size = new System.Drawing.Size(63, 24);
            this.lblQuarter.TabIndex = 84;
            this.lblQuarter.Text = "?";
            this.lblQuarter.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblQuarter.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblYear
            // 
            this.lblYear.AllowParentOverrides = false;
            this.lblYear.AutoEllipsis = false;
            this.lblYear.AutoSize = false;
            this.lblYear.CursorType = null;
            this.lblYear.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.Transparent;
            this.lblYear.Location = new System.Drawing.Point(520, 69);
            this.lblYear.Name = "lblYear";
            this.lblYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblYear.Size = new System.Drawing.Size(63, 24);
            this.lblYear.TabIndex = 85;
            this.lblYear.Text = "?";
            this.lblYear.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblYear.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lblQID
            // 
            this.lblQID.AllowParentOverrides = false;
            this.lblQID.AutoEllipsis = false;
            this.lblQID.AutoSize = false;
            this.lblQID.CursorType = null;
            this.lblQID.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQID.ForeColor = System.Drawing.Color.Transparent;
            this.lblQID.Location = new System.Drawing.Point(589, 69);
            this.lblQID.Name = "lblQID";
            this.lblQID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblQID.Size = new System.Drawing.Size(63, 24);
            this.lblQID.TabIndex = 86;
            this.lblQID.Text = "?";
            this.lblQID.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblQID.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn1
            // 
            this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
            this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // sUBIDDataGridViewTextBoxColumn1
            // 
            this.sUBIDDataGridViewTextBoxColumn1.DataPropertyName = "SUBID";
            this.sUBIDDataGridViewTextBoxColumn1.HeaderText = "SUBID";
            this.sUBIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.sUBIDDataGridViewTextBoxColumn1.Name = "sUBIDDataGridViewTextBoxColumn1";
            this.sUBIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // classIDDataGridViewTextBoxColumn1
            // 
            this.classIDDataGridViewTextBoxColumn1.DataPropertyName = "Class_ID";
            this.classIDDataGridViewTextBoxColumn1.HeaderText = "Class_ID";
            this.classIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.classIDDataGridViewTextBoxColumn1.Name = "classIDDataGridViewTextBoxColumn1";
            this.classIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dATEDataGridViewTextBoxColumn1
            // 
            this.dATEDataGridViewTextBoxColumn1.DataPropertyName = "DATE";
            this.dATEDataGridViewTextBoxColumn1.HeaderText = "DATE";
            this.dATEDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dATEDataGridViewTextBoxColumn1.Name = "dATEDataGridViewTextBoxColumn1";
            this.dATEDataGridViewTextBoxColumn1.Width = 125;
            // 
            // sIDDataGridViewTextBoxColumn1
            // 
            this.sIDDataGridViewTextBoxColumn1.DataPropertyName = "SID";
            this.sIDDataGridViewTextBoxColumn1.HeaderText = "SID";
            this.sIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.sIDDataGridViewTextBoxColumn1.Name = "sIDDataGridViewTextBoxColumn1";
            this.sIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // nAMEDataGridViewTextBoxColumn1
            // 
            this.nAMEDataGridViewTextBoxColumn1.DataPropertyName = "NAME";
            this.nAMEDataGridViewTextBoxColumn1.HeaderText = "NAME";
            this.nAMEDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.nAMEDataGridViewTextBoxColumn1.Name = "nAMEDataGridViewTextBoxColumn1";
            this.nAMEDataGridViewTextBoxColumn1.Width = 125;
            // 
            // qTRIDDataGridViewTextBoxColumn1
            // 
            this.qTRIDDataGridViewTextBoxColumn1.DataPropertyName = "QTR_ID";
            this.qTRIDDataGridViewTextBoxColumn1.HeaderText = "QTR_ID";
            this.qTRIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.qTRIDDataGridViewTextBoxColumn1.Name = "qTRIDDataGridViewTextBoxColumn1";
            this.qTRIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // sTATUSDataGridViewTextBoxColumn1
            // 
            this.sTATUSDataGridViewTextBoxColumn1.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn1.HeaderText = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.sTATUSDataGridViewTextBoxColumn1.Name = "sTATUSDataGridViewTextBoxColumn1";
            this.sTATUSDataGridViewTextBoxColumn1.Width = 125;
            // 
            // rEASONDataGridViewTextBoxColumn1
            // 
            this.rEASONDataGridViewTextBoxColumn1.DataPropertyName = "REASON";
            this.rEASONDataGridViewTextBoxColumn1.HeaderText = "REASON";
            this.rEASONDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.rEASONDataGridViewTextBoxColumn1.Name = "rEASONDataGridViewTextBoxColumn1";
            this.rEASONDataGridViewTextBoxColumn1.Width = 125;
            // 
            // iDDataGridViewTextBoxColumn2
            // 
            this.iDDataGridViewTextBoxColumn2.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn2.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn2.Name = "iDDataGridViewTextBoxColumn2";
            this.iDDataGridViewTextBoxColumn2.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // sUBIDDataGridViewTextBoxColumn2
            // 
            this.sUBIDDataGridViewTextBoxColumn2.DataPropertyName = "SUBID";
            this.sUBIDDataGridViewTextBoxColumn2.HeaderText = "SUBID";
            this.sUBIDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.sUBIDDataGridViewTextBoxColumn2.Name = "sUBIDDataGridViewTextBoxColumn2";
            this.sUBIDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // classIDDataGridViewTextBoxColumn2
            // 
            this.classIDDataGridViewTextBoxColumn2.DataPropertyName = "Class_ID";
            this.classIDDataGridViewTextBoxColumn2.HeaderText = "Class_ID";
            this.classIDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.classIDDataGridViewTextBoxColumn2.Name = "classIDDataGridViewTextBoxColumn2";
            this.classIDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // dATEDataGridViewTextBoxColumn2
            // 
            this.dATEDataGridViewTextBoxColumn2.DataPropertyName = "DATE";
            this.dATEDataGridViewTextBoxColumn2.HeaderText = "DATE";
            this.dATEDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dATEDataGridViewTextBoxColumn2.Name = "dATEDataGridViewTextBoxColumn2";
            this.dATEDataGridViewTextBoxColumn2.Width = 125;
            // 
            // sIDDataGridViewTextBoxColumn2
            // 
            this.sIDDataGridViewTextBoxColumn2.DataPropertyName = "SID";
            this.sIDDataGridViewTextBoxColumn2.HeaderText = "SID";
            this.sIDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.sIDDataGridViewTextBoxColumn2.Name = "sIDDataGridViewTextBoxColumn2";
            this.sIDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // nAMEDataGridViewTextBoxColumn2
            // 
            this.nAMEDataGridViewTextBoxColumn2.DataPropertyName = "NAME";
            this.nAMEDataGridViewTextBoxColumn2.HeaderText = "NAME";
            this.nAMEDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.nAMEDataGridViewTextBoxColumn2.Name = "nAMEDataGridViewTextBoxColumn2";
            this.nAMEDataGridViewTextBoxColumn2.Width = 125;
            // 
            // qTRIDDataGridViewTextBoxColumn2
            // 
            this.qTRIDDataGridViewTextBoxColumn2.DataPropertyName = "QTR_ID";
            this.qTRIDDataGridViewTextBoxColumn2.HeaderText = "QTR_ID";
            this.qTRIDDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.qTRIDDataGridViewTextBoxColumn2.Name = "qTRIDDataGridViewTextBoxColumn2";
            this.qTRIDDataGridViewTextBoxColumn2.Width = 125;
            // 
            // sTATUSDataGridViewTextBoxColumn2
            // 
            this.sTATUSDataGridViewTextBoxColumn2.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn2.HeaderText = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.sTATUSDataGridViewTextBoxColumn2.Name = "sTATUSDataGridViewTextBoxColumn2";
            this.sTATUSDataGridViewTextBoxColumn2.Width = 125;
            // 
            // rEASONDataGridViewTextBoxColumn2
            // 
            this.rEASONDataGridViewTextBoxColumn2.DataPropertyName = "REASON";
            this.rEASONDataGridViewTextBoxColumn2.HeaderText = "REASON";
            this.rEASONDataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.rEASONDataGridViewTextBoxColumn2.Name = "rEASONDataGridViewTextBoxColumn2";
            this.rEASONDataGridViewTextBoxColumn2.Width = 125;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(10, 10);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1027, 551);
            this.metroTabControl1.TabIndex = 87;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.dgvStudRep);
            this.metroTabPage3.Controls.Add(this.panel3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1019, 508);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Student Report";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // dgvStudRep
            // 
            this.dgvStudRep.AllowUserToAddRows = false;
            this.dgvStudRep.AllowUserToDeleteRows = false;
            this.dgvStudRep.AllowUserToResizeColumns = false;
            this.dgvStudRep.AllowUserToResizeRows = false;
            this.dgvStudRep.ColumnHeadersHeight = 30;
            this.dgvStudRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudRep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber});
            this.dgvStudRep.Location = new System.Drawing.Point(114, 99);
            this.dgvStudRep.MultiSelect = false;
            this.dgvStudRep.Name = "dgvStudRep";
            this.dgvStudRep.ReadOnly = true;
            this.dgvStudRep.RowHeadersVisible = false;
            this.dgvStudRep.RowHeadersWidth = 51;
            this.dgvStudRep.RowTemplate.Height = 24;
            this.dgvStudRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudRep.Size = new System.Drawing.Size(790, 387);
            this.dgvStudRep.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvStudRep.StateCommon.Background.Color2 = System.Drawing.Color.White;
            this.dgvStudRep.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvStudRep.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.DodgerBlue;
            this.dgvStudRep.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvStudRep.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStudRep.StateNormal.Background.Color1 = System.Drawing.Color.White;
            this.dgvStudRep.StateNormal.Background.Color2 = System.Drawing.Color.White;
            this.dgvStudRep.StateSelected.DataCell.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(191)))), ((int)(((byte)(238)))));
            this.dgvStudRep.StateSelected.DataCell.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(191)))), ((int)(((byte)(238)))));
            this.dgvStudRep.StateSelected.DataCell.Content.Color1 = System.Drawing.Color.Black;
            this.dgvStudRep.StateSelected.DataCell.Content.Color2 = System.Drawing.Color.Black;
            this.dgvStudRep.TabIndex = 91;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.bunifuLabel5);
            this.panel3.Controls.Add(this.dpAttDate);
            this.panel3.Controls.Add(this.bunifuLabel12);
            this.panel3.Controls.Add(this.cbxRepSub);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1019, 50);
            this.panel3.TabIndex = 90;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AllowParentOverrides = false;
            this.bunifuLabel5.AutoEllipsis = false;
            this.bunifuLabel5.AutoSize = false;
            this.bunifuLabel5.CursorType = null;
            this.bunifuLabel5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel5.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel5.Location = new System.Drawing.Point(753, 15);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(63, 24);
            this.bunifuLabel5.TabIndex = 86;
            this.bunifuLabel5.Text = "DATE:";
            this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // dpAttDate
            // 
            this.dpAttDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpAttDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAttDate.Location = new System.Drawing.Point(822, 12);
            this.dpAttDate.MaxDate = new System.DateTime(2024, 11, 22, 0, 0, 0, 0);
            this.dpAttDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dpAttDate.Name = "dpAttDate";
            this.dpAttDate.Size = new System.Drawing.Size(185, 26);
            this.dpAttDate.TabIndex = 85;
            this.dpAttDate.Value = new System.DateTime(2024, 5, 13, 0, 0, 0, 0);
            this.dpAttDate.ValueChanged += new System.EventHandler(this.dpAttDate_ValueChanged);
            // 
            // bunifuLabel12
            // 
            this.bunifuLabel12.AllowParentOverrides = false;
            this.bunifuLabel12.AutoEllipsis = false;
            this.bunifuLabel12.AutoSize = false;
            this.bunifuLabel12.CursorType = null;
            this.bunifuLabel12.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel12.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel12.Location = new System.Drawing.Point(19, 16);
            this.bunifuLabel12.Name = "bunifuLabel12";
            this.bunifuLabel12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel12.Size = new System.Drawing.Size(77, 24);
            this.bunifuLabel12.TabIndex = 83;
            this.bunifuLabel12.Text = "SUBJECT:";
            this.bunifuLabel12.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel12.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cbxRepSub
            // 
            this.cbxRepSub.BackColor = System.Drawing.Color.Transparent;
            this.cbxRepSub.BorderRadius = 15;
            this.cbxRepSub.DataSource = this.classSubjectBindingSource;
            this.cbxRepSub.DisplayMember = "NAME";
            this.cbxRepSub.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxRepSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRepSub.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxRepSub.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxRepSub.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cbxRepSub.ForeColor = System.Drawing.Color.DimGray;
            this.cbxRepSub.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxRepSub.ItemHeight = 30;
            this.cbxRepSub.ItemsAppearance.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRepSub.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.cbxRepSub.Location = new System.Drawing.Point(102, 8);
            this.cbxRepSub.Name = "cbxRepSub";
            this.cbxRepSub.Size = new System.Drawing.Size(232, 36);
            this.cbxRepSub.TabIndex = 82;
            this.cbxRepSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cbxRepSub.ValueMember = "SUB_ID";
            this.cbxRepSub.SelectedValueChanged += new System.EventHandler(this.cbxRepSub_SelectedValueChanged);
            // 
            // RowNumber
            // 
            this.RowNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RowNumber.HeaderText = "#";
            this.RowNumber.MinimumWidth = 6;
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 51;
            // 
            // UC_StudentAttendance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.lblQID);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblQuarter);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_StudentAttendance";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1047, 571);
            this.Load += new System.EventHandler(this.UC_Teacher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTeacherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sMSDataSet)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudRep)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private SMSDataSet sMSDataSet;
        private SMSDataSetTableAdapters.SchoolYearTableAdapter schoolYearTableAdapter;
        private Bunifu.UI.WinForms.BunifuSnackbar sbOC;
        private Guna.UI2.WinForms.Guna2MessageDialog MSDialog;
        private System.Windows.Forms.BindingSource tblTeacherBindingSource;
        private SMSDataSet sMSDataSet1;
        private SMSDataSetTableAdapters.tblTeacherTableAdapter tblTeacherTableAdapter;
        private SMSDataSet sMSDataSet2;
        private System.Windows.Forms.BindingSource classesBindingSource;
        private SMSDataSetTableAdapters.ClassesTableAdapter classesTableAdapter;
        private System.Windows.Forms.BindingSource classSubjectBindingSource;
        private SMSDataSetTableAdapters.ClassSubjectTableAdapter classSubjectTableAdapter;
        private System.Windows.Forms.BindingSource classSubjectBindingSource1;
        private SMSDataSetTableAdapters.ClassSubjectTableAdapter classSubjectTableAdapter1;
        private Bunifu.UI.WinForms.BunifuLabel lblQuarter;
        private Bunifu.UI.WinForms.BunifuLabel lblYear;
        private Bunifu.UI.WinForms.BunifuLabel lblQID;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private SMSDataSet sMSDataSet3;
        private SMSDataSetTableAdapters.AttendanceTableAdapter attendanceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTRIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEASONDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUBIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn classIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATEDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTRIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEASONDataGridViewTextBoxColumn2;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel12;
        public Guna.UI2.WinForms.Guna2ComboBox cbxRepSub;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvStudRep;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel5;
        public System.Windows.Forms.DateTimePicker dpAttDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
    }
}
