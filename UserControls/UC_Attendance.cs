using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_Attendance : UserControl
    {
        SqlConnection cn;
        ClassDB db = new ClassDB();        
        public int TID { get; set; }
        private DateTime lastValidDate;
        public UC_Attendance(int TID)
        {
              
            InitializeComponent();
            this.TID = TID;
            cn = new SqlConnection(db.GetConnection());
            dgvAttendance.RowPostPaint += DgvAttendance_RowPostPaint;
            dgvAttendance.CellValueChanged += DgvAttendance_CellValueChanged;
            dgvAttendance.CurrentCellDirtyStateChanged += DgvAttendance_CurrentCellDirtyStateChanged;
            dgvAttendance.EditingControlShowing += DgvAttendance_EditingControlShowing;
            lblQuarter.Text = db.GetQuarter();
            lblQID.Text = db.GetQID();
            lblYear.Text = db.GetAY();
            dgvStudRep.DataSource = attendanceBindingSource1;
            FillAttSubCBX();
            FillRepSubCBX();
        }

        private void DgvStudRep_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["Column1"].Value = rowIndex.ToString();
        }

        private void DgvAttendance_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAttendance.IsCurrentCellDirty)
            {
                dgvAttendance.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DgvAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAttendance.Columns["sTATUSDataGridViewTextBoxColumn"].Index)
            {
                DataGridViewComboBoxCell comboBoxCell = dgvAttendance.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (comboBoxCell != null)
                {
                    string selectedValue = comboBoxCell.Value?.ToString();
                    if (selectedValue == "Excused")
                    {
                        dgvAttendance.Rows[e.RowIndex].Cells["rEASONDataGridViewTextBoxColumn"].ReadOnly = false;
                    }
                    else
                    {
                        dgvAttendance.Rows[e.RowIndex].Cells["rEASONDataGridViewTextBoxColumn"].ReadOnly = true;
                        dgvAttendance.Rows[e.RowIndex].Cells["rEASONDataGridViewTextBoxColumn"].Value = null; // Clear the value if not excused
                    }
                }
            }
        }

        public void FillAttSubCBX()
        {
            string query = @"
        SELECT DISTINCT Subjects.NAME, Subjects.ID, SubjectDetails.TEA_ID 
        FROM SubjectDetails 
        INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID 
        INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID 
        WHERE SubjectDetails.TEA_ID = @TID";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@TID", TID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxAttSub.DataSource = dataTable;
                        cbxAttSub.DisplayMember = "NAME";
                        cbxAttSub.ValueMember = "ID";
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void FillRepSubCBX()
        {
            string query = @"
        SELECT DISTINCT Subjects.NAME, Subjects.ID, SubjectDetails.TEA_ID 
        FROM SubjectDetails 
        INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID 
        INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID 
        WHERE SubjectDetails.TEA_ID = @TID";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@TID", TID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxRepSub.DataSource = dataTable;
                        cbxRepSub.DisplayMember = "NAME";
                        cbxRepSub.ValueMember = "ID";
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public void FillRepClassCBX()
        {
            if (cbxRepSub.SelectedValue == null)
            {
                sbOC.Show(this.FindForm(), "Please select a subject first.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                return;
            }

            string query = @"
        SELECT Classes.Class_Name, SubjectDetails.CLASS_ID, SubjectDetails.TEA_ID 
        FROM SubjectDetails 
        INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID 
        INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID 
        WHERE SubjectDetails.SUB_ID = @SubID AND SubjectDetails.TEA_ID = @TID";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    int selectedSubID;
                    if (cbxRepSub.SelectedValue is DataRowView rowView)
                    {
                        selectedSubID = Convert.ToInt32(rowView["ID"]);
                    }
                    else
                    {
                        selectedSubID = Convert.ToInt32(cbxRepSub.SelectedValue);
                    }
                    cm.Parameters.AddWithValue("@SubID", selectedSubID);
                    cm.Parameters.AddWithValue("@TID", TID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxRepClass.DataSource = dataTable;
                        cbxRepClass.DisplayMember = "Class_Name";
                        cbxRepClass.ValueMember = "CLASS_ID";
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void UpdateReasonColumnReadOnlyState()
        {
            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                DataGridViewComboBoxCell statusCell = row.Cells["sTATUSDataGridViewTextBoxColumn"] as DataGridViewComboBoxCell;
                if (statusCell != null)
                {
                    string selectedValue = statusCell.Value?.ToString();
                    if (selectedValue == "Excused")
                    {
                        row.Cells["rEASONDataGridViewTextBoxColumn"].ReadOnly = false;
                    }
                    else
                    {
                        row.Cells["rEASONDataGridViewTextBoxColumn"].ReadOnly = true;
                        row.Cells["rEASONDataGridViewTextBoxColumn"].Value = null;
                    }
                }
            }
        }
        public void FillRepStudCBX()
        {
            string status = "ACTIVE";
            if (cbxRepClass.SelectedValue == null)
            {
                sbOC.Show(this.FindForm(), "Please select a class first.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                return;
            }

            string query = @"SELECT ID, FULLNAME FROM tblStudent WHERE CLASS_ID = @classID and STATUS = @stat";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    int selectedclassID;
                    if (cbxRepClass.SelectedValue is DataRowView rowView)
                    {
                        selectedclassID = Convert.ToInt32(rowView["CLASS_ID"]);
                    }
                    else
                    {
                        selectedclassID = Convert.ToInt32(cbxRepClass.SelectedValue);
                    }
                    cm.Parameters.AddWithValue("@classID", selectedclassID);
                    cm.Parameters.AddWithValue("@stat", status);

                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxRepStud.DataSource = dataTable;
                        cbxRepStud.DisplayMember = "FULLNAME";
                        cbxRepStud.ValueMember = "ID";
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        public void FillAttClassCBX()
        {
            if (cbxAttSub.SelectedValue == null)
            {
                sbOC.Show(this.FindForm(), "Please select a subject first.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                return;
            }

            string query = @"
        SELECT Classes.Class_Name, SubjectDetails.CLASS_ID, SubjectDetails.TEA_ID 
        FROM SubjectDetails 
        INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID 
        INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID 
        WHERE SubjectDetails.SUB_ID = @SubID AND SubjectDetails.TEA_ID = @TID";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    int selectedSubID;
                    if (cbxAttSub.SelectedValue is DataRowView rowView)
                    {
                        selectedSubID = Convert.ToInt32(rowView["ID"]);
                    }
                    else
                    {
                        selectedSubID = Convert.ToInt32(cbxAttSub.SelectedValue);
                    } 
                    cm.Parameters.AddWithValue("@SubID", selectedSubID);
                    cm.Parameters.AddWithValue("@TID", TID);

                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxAttClass.DataSource = dataTable;
                        cbxAttClass.DisplayMember = "Class_Name";
                        cbxAttClass.ValueMember = "CLASS_ID";
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void DgvAttendance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvAttendance.CurrentCell.ColumnIndex == dgvAttendance.Columns["rEASONDataGridViewTextBoxColumn"].Index)
            {
                e.Control.Enabled = !dgvAttendance.CurrentCell.ReadOnly;
            }
        }

        private void DgvAttendance_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["Column1"].Value = rowIndex.ToString();
        }

        public void LoadClassSubject()
        {
            this.classSubjectTableAdapter.Fill(this.sMSDataSet2.ClassSubject);
            classSubjectBindingSource.Filter = "TEA_ID = '" + TID.ToString() + "'";

            var distinctSubjects = (from DataRowView rowView in classSubjectBindingSource
                                    select new
                                    {
                                        ID = rowView["SUB_ID"],
                                        Name = rowView["NAME"]
                                    }).Distinct().ToList();

            Dictionary<string, int> subjectIdMap = distinctSubjects.ToDictionary(x => x.Name.ToString(), x => Convert.ToInt32(x.ID));

            cbxSub.DataSource = null;
            cbxSub.Items.Clear();
            cbxSub.ValueMember = "ID";
            cbxSub.DisplayMember = "Name";
            cbxSub.DataSource = distinctSubjects;

            this.classSubjectTableAdapter1.Fill(this.sMSDataSet2.ClassSubject);
        }

        private void UC_Teacher_Load(object sender, EventArgs e)
        {
            LoadClassSubject();
        }
        private DataTable dt_new;
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                if (cbxSub.SelectedValue == null || cbxClass.SelectedValue == null)
                {
                    if (cbxSub.SelectedValue == null)
                    {
                        sbOC.Show(this.FindForm(), "SELECT SUBJECT!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    else if (cbxClass.SelectedValue == null)
                    {
                        sbOC.Show(this.FindForm(), "SELECT CLASS!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    return;
                }
                AttendanceTableAdapter ada = new AttendanceTableAdapter();
                DataTable dt = ada.GetDataBy11((int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value, status);

                tblStudentTableAdapter std = new tblStudentTableAdapter();
                DataTable dt_Students = std.GetDataByClassID((int)cbxClass.SelectedValue, status);

                foreach (DataRow row in dt_Students.Rows)
                {
                    int studentId = (int)row[0];
                    string studentStatus = row[15].ToString();


                    if (!RecordExists(ada, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value, studentId, studentStatus))
                    {
                        ada.InsertQuery((int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value, studentId, row[3].ToString(), int.Parse(lblQID.Text), "", "", row[15].ToString());
                    }
                }
                dt_new = ada.GetDataBy11((int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value, status);
                dgvAttendance.DataSource = dt_new;
                UpdateReasonColumnReadOnlyState();           
                UpdateStatusCounts(ada);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void UpdateStatusCounts(AttendanceTableAdapter ada)
        {
            string status = "ACTIVE";
            int P = (int)ada.CountStatus(dpDate.Value, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, "Present", status);
            int A = (int)ada.CountStatus(dpDate.Value, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, "Absent", status);
            int L = (int)ada.CountStatus(dpDate.Value, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, "Late", status);
            int E = (int)ada.CountStatus(dpDate.Value, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, "Excused", status);

            lblPresent.Text = P.ToString();
            lblAbsent.Text = A.ToString();
            lblLate.Text = L.ToString();
            lblExcused.Text = E.ToString();
        }

        private bool RecordExists(AttendanceTableAdapter ada, int subjectId, int classId, DateTime date, int studentId, string studstat)
        {
            int dt = (int)ada.CheckRecordExists(subjectId, classId, date, studentId, studstat);
            if(dt > 0)
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                AttendanceTableAdapter ada = new AttendanceTableAdapter();
                bool updateSuccessful = false;
                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.Cells[6].Value != null)
                    {

                        int affect = ada.UpdateQuery(row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[6].Value.ToString(), (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value);
                        if (affect > 0 && !updateSuccessful)
                        {
                            updateSuccessful = true;
                        }
                    }
                }
                if (updateSuccessful)
                {
                    sbOC.Show(this.FindForm(), "ATTENDANCE SAVED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                }

                DataTable dt_new = ada.GetDataBy11((int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, dpDate.Value, status);
                dgvAttendance.DataSource = dt_new;
                UpdateReasonColumnReadOnlyState();
                UpdateStatusCounts(ada);
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxSub_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxSub.SelectedValue != null)
            {
                int selected = (int)cbxSub.SelectedValue;
                classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "' AND SUB_ID = '" + selected.ToString() + "'";
            }
        }

        private void dpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = dpDate.Value;

                if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    sbOC.Show(this.FindForm(), "WEEKENDS NOT ALLOWED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    dpDate.Value = lastValidDate;
                }
                else
                {
                    lastValidDate = selectedDate;
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void cbxAttSub_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbxAttSub.SelectedValue != null)
                {
                    if(cbxAttSub.SelectedIndex != -1)
                    {
                        FillAttClassCBX();
                    }
                    else
                    {
                        cbxAttClass.DataSource = null;
                    }
                }
            }catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                tblStudentTableAdapter std = new tblStudentTableAdapter();
                DataTable dt_Students = std.GetDataByClassID((int)cbxAttClass.SelectedValue, status);

                AttendanceTableAdapter ada = new AttendanceTableAdapter();

                int P = 0;
                int A = 0;
                int L = 0;
                int E = 0;

                listViewReport.Items.Clear();
                foreach (DataRow row in dt_Students.Rows)
                {
                    string studentName = row["FULLNAME"].ToString();

                    P = GetMonthlyReportCount(ada, dpAttDate.Value.Month, studentName, "Present", status);
                    A = GetMonthlyReportCount(ada, dpAttDate.Value.Month, studentName, "Absent", status);
                    L = GetMonthlyReportCount(ada, dpAttDate.Value.Month, studentName, "Late", status);
                    E = GetMonthlyReportCount(ada, dpAttDate.Value.Month, studentName, "Excused", status);

                    ListViewItem litem = new ListViewItem();
                    litem.Text = row["FULLNAME"].ToString();
                    litem.SubItems.Add(P.ToString());
                    litem.SubItems.Add(A.ToString());
                    litem.SubItems.Add(L.ToString());
                    litem.SubItems.Add(E.ToString());
                    
                    listViewReport.Items.Add(litem);
                }              
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private int GetMonthlyReportCount(AttendanceTableAdapter ada, int month, string name, string status, string studstat)
        {
            var dt = ada.GetDataByMonthlyReport(month, name, status, studstat);
            if (dt.Rows.Count > 0 && dt.Rows[0]["StatusCount"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["StatusCount"]);
            }
            return 0;
        }

        private int GetWeeklyReportCount(AttendanceTableAdapter ada, DateTime date, string name , string status, string studstat)
        {
            var dt = ada.GetDataByWeekly(date, name, status, studstat);
            if (dt.Rows.Count > 0 && dt.Rows[0]["WStatusCount"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["WStatusCount"]);
            }
            return 0;
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                tblStudentTableAdapter std = new tblStudentTableAdapter();
                DataTable dt_Students = std.GetDataByClassID((int)cbxAttClass.SelectedValue, status);

                AttendanceTableAdapter ada = new AttendanceTableAdapter();

                int P = 0;
                int A = 0;
                int L = 0;
                int E = 0;
               
                listViewReport.Items.Clear();
                foreach (DataRow row in dt_Students.Rows)
                {
                    string studentName = row["FULLNAME"].ToString();

                    P = GetWeeklyReportCount(ada, dpAttDate.Value, studentName, "Present", status);
                    A = GetWeeklyReportCount(ada, dpAttDate.Value, studentName, "Absent", status);
                    L = GetWeeklyReportCount(ada, dpAttDate.Value, studentName, "Late", status);
                    E = GetWeeklyReportCount(ada, dpAttDate.Value, studentName, "Excused", status);

                    ListViewItem litem = new ListViewItem();
                    litem.Text = row["FULLNAME"].ToString();
                    litem.SubItems.Add(P.ToString());
                    litem.SubItems.Add(A.ToString());
                    litem.SubItems.Add(L.ToString());
                    litem.SubItems.Add(E.ToString());
                    
                    listViewReport.Items.Add(litem);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroTabPage1_Enter(object sender, EventArgs e)
        {
            UpdateReasonColumnReadOnlyState();
        }

        private void cbxRepSub_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxRepSub.SelectedValue != null)
                {
                    if (cbxRepSub.SelectedIndex != -1)
                    {
                        FillRepClassCBX();
                    }
                    else
                    {
                        cbxRepClass.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxRepClass_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxRepClass.SelectedValue != null)
                {
                    if (cbxRepClass.SelectedIndex != -1)
                    {
                        FillRepStudCBX();
                    }
                    else
                    {
                        cbxRepStud.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable GetAttendanceData(int sid, int subID)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT DATE, STATUS, REASON FROM Attendance WHERE SID = @sid AND SUBID = @subID ORDER BY DATE DESC";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@sid", sid);
                    cm.Parameters.AddWithValue("@subID", subID);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cm);
                        cn.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return dataTable;
        }

        private void FillDataGridView()
        {
            try
            {
                if (cbxRepSub.SelectedValue != null && cbxRepStud.SelectedValue != null)
                {
                    if (int.TryParse(cbxRepStud.SelectedValue.ToString(), out int sid) &&
                        int.TryParse(cbxRepSub.SelectedValue.ToString(), out int subID))
                    {
                        DataTable dataTable = GetAttendanceData(sid, subID);

                        if (dataTable != null)
                        {
                            dgvStudRep.DataSource = dataTable;
                            AddRowNumberColumn();
                            dgvStudRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                        else
                        {
                            dgvStudRep.DataSource = null;
                        }
                    }
                    else
                    {
                        dgvStudRep.DataSource = null;
                    }
                }
                else
                {
                    dgvStudRep.DataSource = null;
                }
            }catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void AddRowNumberColumn()
        {
            if (dgvStudRep.Columns["RowNumber"] == null)
            {
                DataGridViewTextBoxColumn rowNumberColumn = new DataGridViewTextBoxColumn
                {
                    Name = "RowNumber",
                    HeaderText = "#",
                    ReadOnly = true
                };

                dgvStudRep.Columns.Insert(0, rowNumberColumn);
            }

            foreach (DataGridViewRow row in dgvStudRep.Rows)
            {
                row.Cells["RowNumber"].Value = row.Index + 1;
            }
            dgvStudRep.Columns["RowNumber"].Width = 50;
            dgvStudRep.Columns["RowNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void cbxRepStud_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void tbxSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dt_new != null)
                {
                    DataView dv = dt_new.DefaultView;
                    dv.RowFilter = string.Format("NAME LIKE '%{0}%'", tbxSearch.Text); 
                    dgvAttendance.DataSource = dv;
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void metroTabPage3_Enter(object sender, EventArgs e)
        {
            FillDataGridView();
        }
    }
}
