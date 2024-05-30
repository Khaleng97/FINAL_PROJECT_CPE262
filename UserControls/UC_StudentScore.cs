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
    public partial class UC_StudentScore : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int SID {  get; set; }
        public string ClassID;

        public UC_StudentScore(int TID, int SID)
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            this.TID = TID;
            this.SID = SID;
            lblQuarter.Text = db.GetQuarter();
            lblQID.Text = db.GetQID();
            lblYear.Text = db.GetAY();
            FillRepSubCBX();
        }

        public string GetClassID()
        {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = db.GetConnection();
                cn.Open();
                cm = new SqlCommand("SELECT CLASS_ID FROM tblStudent WHERE ID = @id", cn);
                cm.Parameters.AddWithValue("@id", SID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    ClassID = dr["CLASS_ID"].ToString();
                }
                else
                {
                    ClassID = "";
                }
                dr.Close();
                cn.Close();
                return ClassID;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        public void FillRepSubCBX()
        {
            string query = @"SELECT SubjectDetails.ID, SubjectDetails.SUB_ID, SubjectDetails.TEA_ID, SubjectDetails.CLASS_ID, Subjects.NAME FROM SubjectDetails INNER JOIN
                  Subjects ON SubjectDetails.SUB_ID = Subjects.ID WHERE CLASS_ID = @classID";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@classID", GetClassID());
                    SqlDataAdapter adapter = new SqlDataAdapter(cm);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        cn.Open();
                        adapter.Fill(dataTable);
                        cbxRepSub.DataSource = dataTable;
                        cbxRepSub.DisplayMember = "NAME";
                        cbxRepSub.ValueMember = "SUB_ID";
                        cbxRepSub.SelectedIndex = -1;
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
            FillDataGridView();
            LoadStudChart();
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
                if (cbxRepSub.SelectedValue != null)
                {
                    if (int.TryParse(cbxRepSub.SelectedValue.ToString(), out int subID))
                    {
                        DataTable dataTable = GetScoreData(SID, subID);

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

        private void metroTabPage4_Enter(object sender, EventArgs e)
        {
            FillDataGridView();
            LoadStudChart();
        }
    }
}
