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
    public partial class UC_Subjects : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public UC_Subjects()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            dgvSubjects.RowPostPaint += DgvSubjects_RowPostPaint;
            dgvSubTea.RowPostPaint += DgvSubTea_RowPostPaint;
        }

        private void DgvSubTea_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["ColNum"].Value = rowIndex.ToString();
        }

        private void DgvSubjects_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["Column1"].Value = rowIndex.ToString();
        }

        private void UC_Subjects_Load(object sender, EventArgs e)
        {
            LoadSubjects();
            LoadSubTeacher();  
            LoadTeacher();
            LoadClasses();
            btnSave.Enabled = false;
            btnAssign.Enabled = true;
            Clear();
        }

        private void LoadTeacher()
        {
            cbxTea.Text = "";
            cbxSub.SelectedIndex = -1;
            this.tblTeacherTableAdapter.Fill(this.sMSDataSet1.tblTeacher);
        }
        private void LoadSubjects()
        {
            this.subjectsTableAdapter.Fill(this.sMSDataSet1.Subjects);
        }

        private void LoadSubTeacher()
        {
            this.assignSubjectsTableAdapter1.Fill(this.sMSDataSet3.AssignSubjects);
        }

        private void LoadClasses()
        {
            this.classesTableAdapter.Fill(this.sMSDataSet3.Classes);
        }

        public void Clear()
        {
            cbxSub.SelectedIndex = -1;
            cbxSub.Text = "";
            cbxTea.SelectedIndex = -1;  
            cbxTea.Text = "";
        }
        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                SubjectDetailsTableAdapter sd = new SubjectDetailsTableAdapter();
                if (cbxClass.SelectedIndex == -1)
                {
                    sbS.Show(this.FindForm(), "SELECT CLASS!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxTea.Focus();
                    return;
                }
                if (cbxSub.SelectedIndex == -1)
                {
                    sbS.Show(this.FindForm(), "SELECT SUBJECT!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxSub.Focus();
                    return;
                }
                if (cbxTea.SelectedIndex == -1)
                {
                    sbS.Show(this.FindForm(), "SELECT TEACHER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxTea.Focus();
                    return;
                }

                int subID = (int)cbxSub.SelectedValue;
                int teacherID = (int)cbxTea.SelectedValue;
                int classID = (int)cbxClass.SelectedValue;

                if (IsDuplicate(subID, teacherID, classID, 0))
                {
                    sbS.Show(this.FindForm(), "ASSIGNED ALREADY (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }
                int row = sd.InsertQuery((int)cbxSub.SelectedValue, (int)cbxTea.SelectedValue, (int)cbxClass.SelectedValue);

                if (row > 0)
                {
                    sbS.Show(this.FindForm(), "ASSIGNED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    LoadSubTeacher();
                }
                UC_Subjects_Load(sender, e);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private bool IsDuplicate(int subID, int teacherID, int classID, int SD_ID)
        {
            try
            {
                SubjectDetailsTableAdapter sd = new SubjectDetailsTableAdapter();
                int count = (int)sd.CheckDuplicate(subID, teacherID, classID);
                int count1 = (int)sd.CheckDuplicateSubject(subID, classID);
                if (SD_ID > 0)
                {
                    count1--; 
                }
                if (count > 0 || count1 > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
        }

        private void dgvSubTea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvSubTea.Columns[e.ColumnIndex].Name;

                if (colName == "colEdit")
                {
                    btnAssign.Enabled = false;
                    btnSave.Enabled = true;
                    cn.Open();
                    cm = new SqlCommand("SELECT * FROM SubjectDetails WHERE ID LIKE '" + dgvSubTea.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        lblID.Text = dgvSubTea.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cbxSub.SelectedValue = dr["SUB_ID"].ToString();
                        cbxTea.SelectedValue = dr["TEA_ID"].ToString();
                        cbxClass.SelectedValue = dr["CLASS_ID"].ToString();
                    }
                    dr.Close();
                }
                else if(colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM SubjectDetails WHERE ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvSubTea.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.ExecuteNonQuery();
                        cn.Close();

                        sbS.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY DELETED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadSubTeacher();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int subID = (int)cbxSub.SelectedValue;
                int teacherID = (int)cbxTea.SelectedValue;
                int classID = (int)cbxClass.SelectedValue;
                int SD_ID = int.Parse(lblID.Text);

                if (IsDuplicate(subID, teacherID, classID, SD_ID))
                {
                    sbS.Show(this.FindForm(), "ASSIGNED ALREADY (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (KryptonMessageBox.Show("UPDATE? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE SubjectDetails SET SUB_ID = @sid, TEA_ID = @tid  WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", lblID.Text);
                    cm.Parameters.AddWithValue("@sid", (int)cbxSub.SelectedValue);
                    cm.Parameters.AddWithValue("@tid", (int)cbxTea.SelectedValue);
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0)
                    {
                        sbS.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadSubTeacher();
                        btnSave.Enabled = false;
                        Clear();
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UC_Subjects_Load(sender, e);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            assignSubjectsBindingSource1.Filter = "NAME LIKE '%" + tbxSearch.Text + "%' OR FULLNAME LIKE '%" + tbxSearch.Text + "%'";
            LoadSubTeacher();
        }

        private void cbxClass_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxClass.SelectedValue != null)
                {
                    assignSubjectsBindingSource1.Filter = $"CLASS_ID = '{cbxClass.SelectedValue}'";
                }
                else
                {
                    assignSubjectsBindingSource1.Filter = null;
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
    }
}
    

