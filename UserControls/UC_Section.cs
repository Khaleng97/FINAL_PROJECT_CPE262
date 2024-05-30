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
    public partial class UC_Section : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();

        public UC_Section()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            dgvSection.RowPostPaint += DgvSection_RowPostPaint;
        }

        private void DgvSection_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            int rowIndex = e.RowIndex + 1;
            row.Cells["Column1"].Value = rowIndex.ToString();
        }

        public void LoadRecords()
        {
            this.tblSectionTableAdapter.Fill(this.sMSDataSet2.tblSection);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UC_Section_Load(sender, e);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            tblTeacherBindingSource.Filter = "CONVERT(TID, 'System.String') LIKE '%" + tbxSearch.Text + "%' OR FULLNAME LIKE '%" + tbxSearch.Text + "%'";
            LoadRecords();
        }

        private void UC_Section_Load(object sender, EventArgs e)
        {
            LoadRecords();
            btnSave.Enabled = false;
            btnAd.Enabled = true;
            Clear();
        }

        public void Clear()
        {
            cbxGrade.SelectedIndex = -1;
            cbxGrade.Text = "";
            tbxSection.Text = "";
        }
        private void dgvSection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvSection.Columns[e.ColumnIndex].Name;

                if (colName == "colEdit")
                {
                    btnAd.Enabled = false;
                    btnSave.Enabled = true;
                    cn.Open();
                    cm = new SqlCommand("SELECT * FROM tblSection WHERE Sec_ID LIKE '" + dgvSection.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        lblID.Text = dgvSection.Rows[e.RowIndex].Cells[1].Value.ToString();
                        cbxGrade.Text = dr["GRADE"].ToString();
                        tbxSection.Text = dr["SECTION"].ToString();
                    }
                    dr.Close();
                }
                else if (colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("UPDATE tblStudent SET Sec_ID = NULL WHERE Sec_ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvSection.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.ExecuteNonQuery();

                        cm = new SqlCommand("DELETE FROM tblSection WHERE Sec_ID = @id", cn);
                        cm.Parameters.AddWithValue("@id", dgvSection.Rows[e.RowIndex].Cells[1].Value.ToString());
                        cm.ExecuteNonQuery();
                        cn.Close();

                        sbSec.Show(this.FindForm(), "SECTION HAS BEEN SUCCESSFULLY DELETED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadRecords();
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

        private void btnAd_Click(object sender, EventArgs e)
        {
            try
            {
                tblSectionTableAdapter sd = new tblSectionTableAdapter();
                if (cbxGrade.SelectedIndex == -1)
                {
                    sbSec.Show(this.FindForm(), "SELECT GRADE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxGrade.Focus();
                    return;
                }
                if (tbxSection.Text == null)
                {
                    sbSec.Show(this.FindForm(), "ENTER SECTION NAME!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    tbxSection.Focus();
                    return;
                }
                string grade = cbxGrade.Text;
                string name = tbxSection.Text;

                if (IsDuplicate(grade, name))
                {
                    sbSec.Show(this.FindForm(), "SECTION ALREADY EXIST!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                int row = sd.InsertQuery(grade, name);
                if (row > 0)
                {
                    sbSec.Show(this.FindForm(), "ASSIGNED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    LoadRecords();
                    Clear();
                }
                UC_Section_Load(sender, e);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private bool IsDuplicate(string grade, string section)
        {
            tblSectionTableAdapter sd = new tblSectionTableAdapter();
            if (sd.CheckDuplicate(grade, section) > 0 || sd.CheckDuplicateSection(section) > 0)
                return true;
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string grade = cbxGrade.Text;
                string name = tbxSection.Text;

                if (IsDuplicate(grade, name))
                {
                    sbSec.Show(this.FindForm(), "SECTION ALREADY EXIST!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (KryptonMessageBox.Show("UPDATE? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblSection SET GRADE = @grade, SECTION = @section  WHERE Sec_ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", lblID.Text);
                    cm.Parameters.AddWithValue("@sid", cbxGrade.Text);
                    cm.Parameters.AddWithValue("@tid", tbxSection.Text);
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0)
                    {
                        sbSec.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadRecords();
                        btnSave.Enabled = false;
                        Clear();
                    }
                    cn.Close();
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
    }
}
