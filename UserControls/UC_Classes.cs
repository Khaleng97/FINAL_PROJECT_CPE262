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
    public partial class UC_Classes : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();

        public UC_Classes()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            dgvACA.RowPostPaint += DgvACA_RowPostPaint;
            dgvClasses.RowPostPaint += DgvClasses_RowPostPaint;
        }

        private void DgvClasses_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                row.Cells["ColNum"].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void DgvACA_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                row.Cells["Column1"].Value = (e.RowIndex + 1).ToString();
            }
        }

        private void UC_Classes_Load(object sender, EventArgs e)
        {
            this.subjectsTableAdapter.Fill(this.sMSDataSet2.Subjects);

            LoadClass();
            LoadTeacher();
            LoadSection();
            btnSave.Enabled = false;
            btnAssign.Enabled = true;
            Clear();
        }

        public void LoadClass()
        {
            this.classesTableAdapter2.Fill(this.sMSDataSet2.Classes);
            this.assignClassAdviserTableAdapter1.Fill(this.sMSDataSet5.AssignClassAdviser);
        }

        private void LoadTeacher()
        {
            this.tblTeacherTableAdapter1.Fill(this.sMSDataSet5.tblTeacher);
        }

        private void LoadSection()
        {
            this.tblSectionTableAdapter1.Fill(this.sMSDataSet5.tblSection);
        }

        public void Clear()
        {
            cbxSec.SelectedIndex = -1;
            cbxSec.Text = "";
            cbxTea.SelectedIndex = -1;  
            cbxTea.Text = "";
        }

        private bool IsDuplicate(int secID, int teacherID, int ID)
        {
            ClassesTableAdapter ct = new ClassesTableAdapter();

            int count = (int)ct.CheckDuplicate(secID, teacherID);
            int count1 = (int)ct.CheckDuplicateSection(secID);
            int count2 = (int)ct.CheckDuplicateTeacher(teacherID);
            if (ID > 0)
            {
                count1--;
                count2--; 
            }
            if (count > 0 || count1 > 0 || count2 > 0)
                return true;
            else
                return false;
        }

        private void dgvACA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvACA.Columns[e.ColumnIndex].Name;

                if (colName == "colEdit")
                {
                    btnAssign.Enabled = false;
                    btnSave.Enabled = true;
                    cn.Open();
                    cm = new SqlCommand("SELECT * FROM Classes WHERE ID LIKE '" + dgvACA.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        lblID.Text = dgvACA.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cbxSec.SelectedValue = dr["Sec_ID"].ToString();
                        cbxTea.SelectedValue = dr["TEA_ID"].ToString();
                    }
                    dr.Close();
                }
                else if (colName == "ColDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM Classes WHERE ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvACA.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.ExecuteNonQuery();
                        cn.Close();

                        sbC.Show(this.FindForm(), "DELETED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadClass();
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            UC_Classes_Load(sender, e);
        }

        private void tbxSearch_TextChanged_1(object sender, EventArgs e)
        {
            assignClassAdviserBindingSource1.Filter = "GRADE LIKE '%" + tbxSearch.Text + "%' OR FULLNAME LIKE '%" + tbxSearch.Text + "%' OR SECTION LIKE '%" + tbxSearch.Text + "%'";
            LoadClass();
        }

        private void btnAssign_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClassesTableAdapter ct = new ClassesTableAdapter();
                if (cbxSec.SelectedIndex == -1)
                {
                    sbC.Show(this.FindForm(), "SELECT SECTION!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxSec.Focus();
                    return;
                }
                if (cbxTea.SelectedIndex == -1)
                {
                    sbC.Show(this.FindForm(), "SELECT TEACHER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxTea.Focus();
                    return;
                }
                int secID = (int)cbxSec.SelectedValue;
                int teacherID = (int)cbxTea.SelectedValue;

                if (IsDuplicate(secID, teacherID, 0))
                {
                    sbC.Show(this.FindForm(), "ASSIGNED ALREADY (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                int row = ct.InsertQuery((int)cbxSec.SelectedValue, (int)cbxTea.SelectedValue);
                if (row > 0)
                {
                    sbC.Show(this.FindForm(), "ASSIGNED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    LoadClass();
                }
                UC_Classes_Load(sender, e);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                int secID = (int)cbxSec.SelectedValue;
                int teacherID = (int)cbxTea.SelectedValue;
                int ID = int.Parse(lblID.Text);
                if (IsDuplicate(secID, teacherID, ID))
                {
                    sbC.Show(this.FindForm(), "ASSIGNED ALREADY (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (KryptonMessageBox.Show("UPDATE? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE Classes SET Sec_ID = @sid, TEA_ID = @tid  WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", lblID.Text);
                    cm.Parameters.AddWithValue("@sid", (int)cbxSec.SelectedValue);
                    cm.Parameters.AddWithValue("@tid", (int)cbxTea.SelectedValue);
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0)
                    {
                        sbC.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadClass();
                        btnSave.Enabled = false;
                        Clear();
                    }
                    cn.Close();
                }
                UC_Classes_Load(sender, e);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
    }
}
    

