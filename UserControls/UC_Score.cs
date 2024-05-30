using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_Score : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public UC_Score(int TID)
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            this.TID = TID;
            dgvScore.RowPostPaint += DgvAttendance_RowPostPaint;
            dgvScore.EditingControlShowing += DgvAttendance_EditingControlShowing;
            lblQuarter.Text = db.GetQuarter();
            lblQID.Text = db.GetQID();
            lblYear.Text = db.GetAY();
            LoadClassSubject();
            cbxSub.SelectedIndex = -1;
            cbxClass.SelectedIndex = -1;
        }

        public void LoadScoreCBX()
        {
            try
            {
                this.scoreTableAdapter1.Fill(this.sMSDataSet5.Score);
                cbxSTM.DataSource = this.sMSDataSet5.Score;

                DataView scoreDataView = new DataView(this.sMSDataSet5.Score);

                if (cbxClass.SelectedValue != null && cbxSub.SelectedValue != null)
                {
                    int classId = (int)cbxClass.SelectedValue;
                    int subId = (int)cbxSub.SelectedValue;
                    scoreDataView.RowFilter = $"CLASS_ID = {classId} AND SUB_ID = {subId}";
                }
                else
                {
                    cbxSTM.DataSource = null;
                }

                cbxSTM.DataSource = scoreDataView;
                cbxSTM.DisplayMember = "Score_Name";
                cbxSTM.ValueMember = "ID";
                cbxSTM.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        private void DgvAttendance_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvScore.CurrentCell.ColumnIndex == dgvScore.Columns["sTATUSDataGridViewTextBoxColumn"].Index)
            {
                DataGridViewComboBoxEditingControl comboBoxControl = e.Control as DataGridViewComboBoxEditingControl;
                if (comboBoxControl != null && comboBoxControl.EditingControlDataGridView.CurrentCell is DataGridViewComboBoxCell comboBoxCell)
                {
                    if (comboBoxCell.Value != null && comboBoxCell.Value.ToString() == "Excused")
                    {
                        e.Control.Enabled = true;
                    }
                    else
                    {
                        e.Control.Enabled = false;
                    }
                }
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
            try
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
                cbxSSub.DataSource = null;
                cbxSSub.Items.Clear();

                cbxSub.ValueMember = "ID";
                cbxSub.DisplayMember = "Name";
                cbxSSub.ValueMember = "ID";
                cbxSSub.DisplayMember = "Name";

                cbxSub.DataSource = distinctSubjects;
                cbxSSub.DataSource = distinctSubjects;

                this.classSubjectTableAdapter1.Fill(this.sMSDataSet2.ClassSubject);
            }
            catch(Exception ex) 
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
        public void LoadScores()
        {
            try
            {
                AddScore frm = new AddScore(this, TID);
                this.scoreTableAdapter.Fill(this.sMSDataSet5.Score);
                if (cbxSSub.SelectedValue != null && cbxSClass.SelectedValue != null)
                {
                    scoreBindingSource.Filter = "SUB_ID = '" + cbxSSub.SelectedValue.ToString() + "' AND CLASS_ID = '" + cbxSClass.SelectedValue.ToString() + "'  AND Q_ID = '" + frm.lblACTQID.Text + "'";
                }
                else
                {
                    scoreBindingSource.Filter = "1 = 0"; 
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void dgvScore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvScore.Columns[e.ColumnIndex].Name;

                if (colName == "colEdit")
                {
                    AddScore frm = new AddScore(this, TID);
                    frm.btnSave.Enabled = false;
                    frm.btnUpdate.Enabled = true;
                    cn.Open();
                     cm = new SqlCommand("SELECT * FROM Score WHERE ID LIKE '" + dgvScore.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        frm.lblID.Text = dgvScore.Rows[e.RowIndex].Cells[1].Value.ToString();
                        frm.cbxType.Text = dr["Type"].ToString();
                        frm.tbxName.Text = dr["Score_Name"].ToString();
                        frm.lblSubID.Text = dr["SUB_ID"].ToString();
                        frm.cbxClass.SelectedValue = int.Parse(dr["Class_ID"].ToString());
                        frm.lblQID.Text = dr["Q_ID"].ToString();
                        frm.cbxMAPEHType.Text = dr["MAPEH_Type"].ToString();
                        if (DateTime.TryParse(dr["DATE"].ToString(), out DateTime startDate))
                        {
                            frm.dpDATE.Value = startDate;
                        }
                        else
                        {
                            frm.dpDATE.Value = DateTime.Today;
                        }
                        frm.tbxFullScore.Text = dr["FULL_SCORE"].ToString();
                    }
                    dr.Close();                 
                    cm = new SqlCommand("SELECT SubjectDetails.*, Subjects.NAME, Classes.Class_Name FROM SubjectDetails INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataView dv = new DataView(dt);
                    dv.RowFilter = "TEA_ID = '" + TID.ToString() + "'";

                    var distinctSubjects = dv.ToTable(true, "SUB_ID", "NAME").AsEnumerable()
                                             .Select(row => new
                                             {
                                                 ID = row["SUB_ID"],
                                                 Name = row["NAME"]
                                             }).Distinct().ToList();

                    Dictionary<string, int> subjectIdMap = distinctSubjects.ToDictionary(x => x.Name.ToString(), x => Convert.ToInt32(x.ID));

                    frm.cbxSub.DataSource = null;
                    frm.cbxSub.Items.Clear();
                    frm.cbxSub.ValueMember = "ID";
                    frm.cbxSub.DisplayMember = "Name";
                    frm.cbxSub.DataSource = distinctSubjects;
                    frm.cbxSub.SelectedValue = Convert.ToInt32(frm.lblSubID.Text);

                    frm.ShowDialog();                    
                }
                else if (colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM Score WHERE ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvScore.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int row = cm.ExecuteNonQuery();
                        if (row > 0)
                        {
                            sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY DELETED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        }
                        cn.Close();                       
                        btnLoadScore_Click(sender, e);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cn.Close();
            }
        }

        public void btnLoadScore_Click(object sender, EventArgs e)
        {
            LoadScores();
        }

        private void cbxSSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSSub.SelectedValue != null)
            {
                int selected = (int)cbxSSub.SelectedValue;
                classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "' AND SUB_ID = '" + selected.ToString() + "'";
            }
        }

        private void cbxSub_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadFullScore();
            if (cbxSub.SelectedValue != null)
            {
                int selected = (int)cbxSub.SelectedValue;
                classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "' AND SUB_ID = '" + selected.ToString() + "'";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddScore us = new AddScore(this, TID))
            {
                us.btnSave.Enabled = true;
                us.btnUpdate.Enabled = false;
                us.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void UC_Score_Load(object sender, EventArgs e)
        {
            lblHPS.Text = "";
            LoadClassSubject();
        }

        private void cbxClass_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadScoreCBX();
            LoadFullScore();
        }

        private void cbxSTM_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadFullScore();           
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                if (cbxSTM.SelectedValue == null)
                {
                    sbOC.Show(this.FindForm(), "SELECT SCORE TO MARK!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxSTM.Focus();
                    return;
                }
                ScoreDetailsTableAdapter ada = new ScoreDetailsTableAdapter();
                DataTable dt = ada.GetDataByScoreID((int)cbxSTM.SelectedValue, status);

                tblStudentTableAdapter std = new tblStudentTableAdapter();
                DataTable dt_Students = std.GetDataByClassID((int)cbxClass.SelectedValue, status);

                foreach(DataRow row in dt_Students.Rows)
                {
                    int studentId = (int)row[0];
                    string studentStatus = row[15].ToString();

                    bool recordExists = RecordExists(ada, (int)cbxSTM.SelectedValue, studentId, status);

                    if (!recordExists)
                    {
                        ada.InsertQuery((int)cbxSTM.SelectedValue, studentId, row[3].ToString(), null, "", studentStatus);
                    }
                }
                DataTable dt_new = ada.GetDataByScoreID((int)cbxSTM.SelectedValue, status);
                dgvScoreDetails.DataSource = dt_new;
                UpdateRemarksCounts(ada);
                LoadChart();               
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private bool RecordExists(ScoreDetailsTableAdapter ada, int scoreID, int studID, string status)
        {
            return (int)ada.CheckRecordExists(scoreID, studID, status) > 0;
        }
        
        public void LoadFullScore()
        {
            try
            {
                if (cbxSub.SelectedValue != null && cbxClass.SelectedValue != null && cbxSTM.SelectedValue != null)
                {
                    cn = new SqlConnection(db.GetConnection());
                    cn.Open();
                    cm = new SqlCommand("SELECT FULL_SCORE FROM Score WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", int.Parse(cbxSTM.SelectedValue.ToString()));
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        lblHPS.Text = dr["FULL_SCORE"].ToString();
                    }
                    dr.Close();
                    cn.Close();
                }
                else
                {
                    lblHPS.Text = "";
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            try
            {
                string status = "ACTIVE";
                ScoreDetailsTableAdapter ada = new ScoreDetailsTableAdapter();
                bool updateSuccessful = false;

                foreach (DataGridViewRow row in dgvScoreDetails.Rows)
                {
                    if (row.Cells["nAMEDataGridViewTextBoxColumn"].Value != null)
                    {
                        if (row.Cells["marksDataGridViewTextBoxColumn"].Value != null && int.TryParse(row.Cells["marksDataGridViewTextBoxColumn"].Value.ToString(), out int marks))
                        {
                            int affect = ada.UpdateQuery(marks, row.Cells["nAMEDataGridViewTextBoxColumn"].Value.ToString(), (int)cbxSTM.SelectedValue);

                            if (affect > 0)
                            {
                                updateSuccessful = true;
                            }
                        }
                    }
                }

                if (updateSuccessful)
                {
                    sbOC.Show(this.FindForm(), "SCORES SAVED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                }

                DataTable dt_new = ada.GetDataByScoreID((int)cbxSTM.SelectedValue, status);
                dgvScoreDetails.DataSource = dt_new;
                UpdateRemarksCounts(ada);
                LoadChart();
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateRemarksCounts(ScoreDetailsTableAdapter ada)
        {
            string status = "ACTIVE";
            int P = (int)ada.CountRemarks((int)cbxSTM.SelectedValue, "PASSED",  status);
            int F = (int)ada.CountRemarks((int)cbxSTM.SelectedValue, "FAILED", status);


            lblPass.Text = P.ToString();
            lblFail.Text = F.ToString();
        }
        private void dgvScoreDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvScoreDetails.Columns[e.ColumnIndex].Name == "marksDataGridViewTextBoxColumn")
                    {
                        
                         int marks = Convert.ToInt32(dgvScoreDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                         int fullScore = int.Parse(lblHPS.Text);
                         if (marks > fullScore || marks < 0)
                         {
                             dgvScoreDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                             sbOC.Show(this.FindForm(), "ENTERED MARKS EXCEED THE FULL SCORE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                         }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void LoadChart()
        {
            SChart.Series["ScoreChart"].Points.Clear();

            SChart.Series["ScoreChart"].Points.AddXY("PASSED", int.Parse(lblPass.Text));
            SChart.Series["ScoreChart"].Points.AddXY("FAILED", int.Parse(lblFail.Text));
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

        private DataTable GetScoreData(int sid, int subID)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT Score.Type, Score.Score_Name, ScoreDetails.Marks, ScoreDetails.Remarks FROM ScoreDetails INNER JOIN Score ON ScoreDetails.Score_ID = Score.ID WHERE SID = @sid AND Score.SUB_ID = @subID ORDER BY Score.Type";

            int passedCount = 0;
            int failedCount = 0;

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

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string remark = row["Remarks"].ToString();
                            if (remark.Equals("PASSED", StringComparison.OrdinalIgnoreCase))
                            {
                                passedCount++;
                            }
                            else if (remark.Equals("FAILED", StringComparison.OrdinalIgnoreCase))
                            {
                                failedCount++;
                            }
                        }
                        lblSPass.Text = passedCount.ToString();
                        lblSFail.Text = failedCount.ToString();
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
                        DataTable dataTable = GetScoreData(sid, subID);

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
            }
            catch(Exception ex) 
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void LoadStudChart()
        {
            try
            {
                StudScoreChart.Series["ScoreChart"].Points.Clear();
                int pass = 0;
                int fail = 0;

                if (!int.TryParse(lblSPass.Text, out pass))
                {
                    pass = 0; 
                }

                if (!int.TryParse(lblSFail.Text, out fail))
                {
                    fail = 0; 
                }
                var passedPoint = new DataPoint();
                passedPoint.SetValueXY("PASSED", pass);
                passedPoint.Label = ""; 
                passedPoint.IsValueShownAsLabel = false; 

                var failedPoint = new DataPoint();
                failedPoint.SetValueXY("FAILED", fail);
                failedPoint.Label = "";
                failedPoint.IsValueShownAsLabel = false; 

                StudScoreChart.Series["ScoreChart"].Points.Add(passedPoint);
                StudScoreChart.Series["ScoreChart"].Points.Add(failedPoint);

                foreach (var point in StudScoreChart.Series["ScoreChart"].Points)
                {
                    point.Label = "";
                    point.IsValueShownAsLabel = false;
                }

                StudScoreChart.Series["ScoreChart"].IsValueShownAsLabel = false;
                StudScoreChart.Series["ScoreChart"].Label = "";
                StudScoreChart.Series["ScoreChart"].LabelToolTip = "";
                StudScoreChart.Series["ScoreChart"].ToolTip = "";
            }
            catch (Exception ex) 
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        private void cbxRepStud_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDataGridView();
            LoadStudChart();
        }

        private void metroTabPage4_Enter(object sender, EventArgs e)
        {
            FillDataGridView();
            LoadStudChart();
        }
    }
}
