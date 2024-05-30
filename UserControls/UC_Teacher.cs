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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_Teacher : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID { get; set; }

        public UC_Teacher(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            this.SID = SID;
            this.PID = PID;
            cn = new SqlConnection(db.GetConnection());
            dgvTeacher.RowPostPaint += DgvTeacher_RowPostPaint;
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
            this.tblTeacherTableAdapter.Fill(this.sMSDataSet1.tblTeacher);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using(AddTeacher at = new AddTeacher(this, TID, SID, PID))
            {
                at.btnSave.Enabled = true;
                at.btnUpdate.Enabled = false;
                at.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            tblTeacherBindingSource.Filter = "CONVERT(TID, 'System.String') LIKE '%" + tbxSearch.Text + "%' OR FULLNAME LIKE '%" + tbxSearch.Text + "%'";
            LoadRecords();
        }

        private void UC_Teacher_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        public int GetClassID(SqlConnection cn, int TID)
        {
            try
            {
                cm = new SqlCommand("SELECT ID FROM Classes WHERE TEA_ID = @tid", cn);
                cm.Parameters.AddWithValue("@tid", TID);
                dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    return int.Parse(dr["ID"].ToString());
                }

                return 0;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
        }

        public int GetSubID(SqlConnection cn, int TID)
        {
            try
            {
                cm = new SqlCommand("SELECT ID FROM SubjectDetails WHERE TEA_ID = @tid", cn);
                cm.Parameters.AddWithValue("@tid", TID);
                dr = cm.ExecuteReader();

                if (dr.Read())
                {
                    return int.Parse(dr["ID"].ToString());
                }

                return 0;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            finally
            {
                if (dr != null && !dr.IsClosed)
                {
                    dr.Close();
                }
            }
        }

        private void dgvTeacher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvTeacher.Columns[e.ColumnIndex].Name;

            if (colName == "colEdit")
            {
                AddTeacher frm = new AddTeacher(this, TID, SID, PID);
                cn.Open();
                cm = new SqlCommand("SELECT * FROM tblTeacher WHERE ID LIKE '" + dgvTeacher.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    frm.lblTID.Text = dgvTeacher.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.tbxTID.Text = dr["TID"].ToString();
                    frm.tbxTLname.Text = dr["LNAME"].ToString();
                    frm.tbxTFname.Text = dr["FNAME"].ToString();
                    frm.tbxTMname.Text = dr["MNAME"].ToString();
                    frm.cbxGender.Text = dr["GENDER"].ToString();
                    if (DateTime.TryParse(dr["DOB"].ToString(), out DateTime startDate))
                    {
                        frm.dpDOB.Value = startDate;
                    }
                    else
                    {
                        frm.dpDOB.Value = DateTime.Today;
                    }
                    frm.lblAge.Text = dr["AGE"].ToString();
                    frm.tbxTPhone.Text = dr["PHONE"].ToString();
                    frm.tbxTAds.Text = dr["ADDRESS"].ToString();
                    frm.tbxTEmail.Text = dr["EMAIL"].ToString();

                    object imageDataObj = dr["IMAGE"];
                    if (imageDataObj != DBNull.Value)
                    {
                        byte[] imageData = (byte[])imageDataObj;
                        if (imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                frm.pbxImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            frm.pbxImage.Image = null;
                        }
                    }
                }
                dr.Close();
                cn.Close();
                frm.tbxTID.Enabled = false;
                frm.cbxGender.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.cbxGender.Enabled = false;
                frm.dpDOB.Enabled = false;
                frm.ShowDialog();
            }
            if (colName == "colDel")
            {
                try
                {
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;

                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    int classID = GetClassID(cn, (int)dgvTeacher.Rows[e.RowIndex].Cells[1].Value);
                    int subID = GetSubID(cn, (int)dgvTeacher.Rows[e.RowIndex].Cells[1].Value);
                    if (classID > 0)
                    {
                        sbOC.Show(this.FindForm(), "REASSIGN THE ADVISER OF THE CLASS HANDLED BY THIS TEACHER FIRST!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        return;
                    }
                    if (subID > 0)
                    {
                        sbOC.Show(this.FindForm(), "REASSIGN THE SUBJECTS HANDLED BY THIS TEACHER FIRST!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        return;
                    }

                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM tblUser WHERE TID = @TeacherID", cn);
                        cm.Parameters.AddWithValue("@TeacherID", dgvTeacher.Rows[e.RowIndex].Cells[1].Value.ToString());
                        count = cm.ExecuteNonQuery();


                        cm = new SqlCommand("DELETE FROM Classes WHERE TEA_ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvTeacher.Rows[e.RowIndex].Cells[1].Value.ToString());
                        count1 = cm.ExecuteNonQuery();

                        cm = new SqlCommand("DELETE FROM tblTeacher WHERE ID = @TeacherID", cn);
                        cm.Parameters.AddWithValue("@TeacherID", dgvTeacher.Rows[e.RowIndex].Cells[1].Value.ToString());
                        count2 = cm.ExecuteNonQuery();
                        
                    }
                    if (count > 0 && count1 > 0 && count2 > 0)
                    {
                        sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY DELETED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);

                    }
                    LoadRecords();
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                }
            }
        }
    }
}
