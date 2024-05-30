using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_AdvisoryClass : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID {  get; set; }
        int classHandled = 0;
        public UC_AdvisoryClass(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            cn = new SqlConnection(db.GetConnection());
            dgvStudent.RowPostPaint += DgvTeacher_RowPostPaint;
            classHandled = GetClassID(TID);
            this.SID = SID;
            this.PID = PID;
        }

        public int GetClassID(int TID)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT ID FROM Classes WHERE TEA_ID = @tid", cn);
                cm.Parameters.AddWithValue("@tid", TID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    return int.Parse(dr["ID"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
        private void DgvTeacher_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["Column1"].Value = rowIndex.ToString();
        }

        public void LoadRecords()
        {
            this.tblStudentTableAdapter.Fill(this.sMSDataSet2.tblStudent);
            tblStudentBindingSource.Filter = "STATUS = 'ACTIVE' and CLASS_ID = '" + classHandled.ToString() + "'";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using(AddStudent at = new AddStudent(this, TID, SID, PID))
            {
                at.cbxSClasses.Enabled = false;
                at.btnSave.Enabled = true;
                at.btnUpdate.Enabled = false;
                at.ClassId = GetClassID(TID);
                at.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            tblStudentBindingSource.Filter = "CONVERT(LRN, 'System.String') LIKE '%" + tbxSearch.Text + "%' OR FULLNAME LIKE '%" + tbxSearch.Text + "%'";
            LoadRecords();
        }

        private void UC_Teacher_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvStudent.Columns[e.ColumnIndex].Name;

                if (colName == "colEdit")
                {
                    AddStudent frm = new AddStudent(this, TID, SID, PID);
                    cn.Open();
                    cm = new SqlCommand("SELECT S.*, C.Class_Name FROM tblStudent S INNER JOIN Classes C ON S.CLASS_ID = C.ID WHERE S.ID = @StudentID", cn);
                    cm.Parameters.AddWithValue("@StudentID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        frm.lblSID.Text = dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                        frm.tbxLRN.Text = dr["LRN"].ToString();
                        frm.ClassId = int.Parse(dr["CLASS_ID"].ToString());
                        frm.tbxSLname.Text = dr["LNAME"].ToString();
                        frm.tbxSFname.Text = dr["FNAME"].ToString();
                        frm.tbxSMname.Text = dr["MNAME"].ToString();
                        frm.cbxSGender.Text = dr["GENDER"].ToString();
                        if (DateTime.TryParse(dr["DOB"].ToString(), out DateTime startDate))
                        {
                            frm.dpSDOB.Value = startDate;
                        }
                        else
                        {
                            frm.dpSDOB.Value = DateTime.Today;
                        }
                        frm.lblSAge.Text = dr["AGE"].ToString();
                        frm.tbxSPhone.Text = dr["PHONE"].ToString();
                        frm.tbxSAds.Text = dr["ADDRESS"].ToString();
                        frm.tbxSEmail.Text = dr["EMAIL"].ToString();

                        object imageDataObj = dr["IMAGE"];
                        if (imageDataObj == null)
                        {
                            frm.pbxSImage.Image = null;
                        }
                        if (imageDataObj != DBNull.Value)
                        {
                            byte[] imageData = (byte[])imageDataObj;
                            if (imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    frm.pbxSImage.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                frm.pbxSImage.Image = null;
                            }
                        }
                        else
                        {
                            frm.pbxSImage.Image = null;
                        }
                        frm.lblStatus.Text = dr["STATUS"].ToString();
                    }
                    dr.Close();
                    cn.Close();
                    frm.btnSave.Enabled = false;
                    frm.btnUpdate.Enabled = true;
                    frm.ShowDialog();
                }
                if (colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO ARCHIVE THIS RECORD?", "ARCHIVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string status = "INACTIVE";
                        cn.Open();
                        cm = new SqlCommand("UPDATE tblStudent SET STATUS = @status WHERE ID = @SID", cn);
                        cm.Parameters.AddWithValue("@status", status);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("UPDATE tblUser SET STATUS = @status WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@status", status);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count1 = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("UPDATE ScoreDetails SET STUD_STATUS = @status WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@status", status);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count2 = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("UPDATE Attendance SET STUD_STATUS = @status WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@status", status);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count3 = cm.ExecuteNonQuery();
                        cn.Close();

                        if (count > 0 && count1 > 0 && count2 > 0 && count3 > 0)
                        {
                            sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY ARCHIVED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        }

                        LoadRecords();
                    }
                }
            }catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
