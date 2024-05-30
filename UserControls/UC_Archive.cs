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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_Archive : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        int classID = 0;
        public UC_Archive()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            dgvStudent.RowPostPaint += DgvTeacher_RowPostPaint;
            LoadClass();
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
            tblStudentBindingSource.Filter = "STATUS = 'INACTIVE' AND CLASS_ID = '" + classID.ToString() + "'";
        }

        public void LoadClass()
        {
            classesTableAdapter.Fill(this.sMSDataSet2.Classes);
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

                if (colName == "colRestore")
                {
                    if (KryptonMessageBox.Show("DO YOU WANT TO RESTORE THIS?", "RESTORE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string status = "ACTIVE";
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
                            sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY RESTORED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        }
                        LoadRecords();
                    }
                }
                if (colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS RECORD?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM Attendance WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM ScoreDetails WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count1 = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM tblUser WHERE SID LIKE @SID", cn);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count2 = cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM tblStudent WHERE ID = @SID", cn);
                        cm.Parameters.AddWithValue("@SID", dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString());
                        int count3 = cm.ExecuteNonQuery();
                        cn.Close();

                        if (count > 0 && count1 > 0  && count2 > 0 && count3 > 0)
                        {
                            sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY ARCHIVED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        }
                        LoadRecords();
                    }
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxClass_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxClass.SelectedValue != null)
                {
                    classID = (int)cbxClass.SelectedValue;
                }
                LoadRecords();
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
