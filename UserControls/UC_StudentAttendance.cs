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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_StudentAttendance : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();        
        public int TID { get; set; }
        public int SID { get; set; }
        public string ClassID;
        public UC_StudentAttendance(int TID, int SID)
        {             
            InitializeComponent();
            this.TID = TID;
            this.SID = SID;
            cn = new SqlConnection(db.GetConnection());
            lblQuarter.Text = db.GetQuarter();
            lblQID.Text = db.GetQID();
            lblYear.Text = db.GetAY();
            dgvStudRep.DataSource = attendanceBindingSource;
            this.attendanceTableAdapter.Fill(this.sMSDataSet3.Attendance);
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
            catch(Exception ex)
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

        private void UC_Teacher_Load(object sender, EventArgs e)
        {
            this.attendanceTableAdapter.Fill(this.sMSDataSet3.Attendance);
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

        private void SelectRowByDate(DateTime date)
        {
            try
            {
                bool rowFound = false;
                foreach (DataGridViewRow row in dgvStudRep.Rows)
                {
                    if (row.Cells["DATE"].Value != null && DateTime.Parse(row.Cells["DATE"].Value.ToString()).Date == date.Date)
                    {
                        dgvStudRep.ClearSelection();
                        row.Selected = true;
                        dgvStudRep.FirstDisplayedScrollingRowIndex = row.Index;
                        rowFound = true;
                        break;
                    }
                }
                if (!rowFound)
                {
                    sbOC.Show(this.FindForm(), "NO ATTENDANCE RECORD FOR THAT DATE", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    return;
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void FillDataGridView()
        {
            try
            {
                if (cbxRepSub.SelectedValue != null)
                {
                    int subID = Convert.ToInt32(cbxRepSub.SelectedValue);
                    DataTable dataTable = GetAttendanceData(SID, subID);

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
            catch (Exception ex)
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

        private void cbxRepSub_SelectedValueChanged(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void dpAttDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dpAttDate.Value;
            SelectRowByDate(selectedDate);
        }
    }
}
