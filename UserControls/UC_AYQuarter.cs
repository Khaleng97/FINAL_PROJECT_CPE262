using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_AYQuarter : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public UC_AYQuarter()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            dpFROM.ValueChanged += UpdateAcademicYearText;
            dpTO.ValueChanged += UpdateAcademicYearText;
            UpdateAcademicYearText(null, EventArgs.Empty);
        }

        public void LoadYear()
        {
            try
            {
                dgvYear.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM SchoolYear", cn);
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    i++;
                    dgvYear.Rows.Add(i, dr["ID"].ToString(), dr["AY"].ToString(), DateTime.Parse(dr["START"].ToString()).ToShortDateString(), DateTime.Parse(dr["END"].ToString()).ToShortDateString());
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }

        public void LoadQuarter()
        {
            try
            {
                dgvQuarter.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("SELECT Q.*, SY.AY FROM Quarter Q INNER JOIN SchoolYear SY ON Q.YEAR_ID = SY.ID", cn);
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    i++;
                    string startDateString = dr["START"].ToString();
                    string endDateString = dr["END"].ToString();
                    DateTime startDate, endDate;

                    if (!string.IsNullOrEmpty(startDateString) && DateTime.TryParse(startDateString, out startDate) &&
                        !string.IsNullOrEmpty(endDateString) && DateTime.TryParse(endDateString, out endDate))
                    {
                        dgvQuarter.Rows.Add(i, dr["ID"].ToString(), dr["YEAR_ID"].ToString(), dr["AY"].ToString(), dr["QUARTER"].ToString(), startDate.ToShortDateString(), endDate.ToShortDateString(), dr["STATUS"].ToString());
                    }
                    else
                    {
                        dgvQuarter.Rows.Add(i, dr["ID"].ToString(), dr["YEAR_ID"].ToString(), dr["AY"].ToString(), dr["QUARTER"].ToString(), "", "", dr["STATUS"].ToString());
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Clear()
        {
            lblID.Text = "";
            lblYear.Text = "";
            dpFROM.Value = DateTime.Today;
            dpTO.Value = DateTime.Today;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
        }

        private void UC_AYQuarter_Load(object sender, EventArgs e)
        {
            LoadQuarter();
            LoadYear();
            btnUpdateQ.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
        }

        private void UpdateAcademicYearText(object sender, EventArgs e)
        {
            int startYear = dpFROM.Value.Year;
            int endYear = dpTO.Value.Year;
            lblYear.Text = $"{startYear}-{endYear}";
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            dgvYear.Rows.Clear();
            int i = 0;
            cn.Open();
            cm = new SqlCommand("SELECT * FROM SchoolYear WHERE AY LIKE '%" +tbxSearch.Text + "%'", cn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dgvYear.Rows.Add(i, dr["ID"].ToString(), dr["AY"].ToString(), DateTime.Parse(dr["START"].ToString()).ToShortDateString(), DateTime.Parse(dr["END"].ToString()).ToShortDateString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpFROM.Value.Date == DateTime.Today && dpTO.Value.Date == DateTime.Today)
                {
                    sbOC.Show(this.FindForm(), "SELECT STARTING OR ENDING DATE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if ((dpTO.Value.Year - dpFROM.Value.Year) < 1)
                {
                    sbOC.Show(this.FindForm(), "ENDING DATE should be at least 1 year apart from the STARTING DATE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                SchoolYearTableAdapter ad = new SchoolYearTableAdapter();
                int rowsAffected = ad.InsertQuery(lblYear.Text, dpFROM.Value.ToShortDateString(), dpTO.Value.ToShortDateString());

                if (rowsAffected > 0) 
                {
                    sbOC.Show(this.FindForm(), "SCHOOL YEAR ADDED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    Clear();
                    btnSave.Enabled = false;
                    int yearID = GetInsertedSchoolYearID(); 

                    if (yearID > 0)
                    {
                        for (int quarter = 1; quarter <= 4; quarter++)
                        {
                            InsertQuarter(yearID, quarter);
                        }
                    }
                    else
                    {
                        MSDialog.Show("Error", "Failed to retrieve school year ID.");
                    }
                    LoadQuarter();
                    LoadYear();
                }
                else
                {
                    MSDialog.Show("Error", "Failed to add school year.");
                }
            }catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private int GetInsertedSchoolYearID()
        {
            int yearID = 0;
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT IDENT_CURRENT('SchoolYear') AS LastInsertedID", cn);

                object result = cm.ExecuteScalar();
                if (result != null)
                {
                    yearID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving inserted school year ID: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return yearID;
        }

        private void InsertQuarter(int yearID, int quarter)
        {
            string status = "CLOSE";
            try
            {
                QuarterTableAdapter q = new QuarterTableAdapter();
                q.InsertQuery(yearID, quarter, null, null, status);
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvYear_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvYear.Columns[e.ColumnIndex].Name;
                if (colName == "colEdit")
                {
                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    cn.Open();
                    cm = new SqlCommand("SELECT * FROM SchoolYear WHERE ID LIKE '" + dgvYear.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        lblID.Text = dgvYear.Rows[e.RowIndex].Cells[1].Value.ToString();
                        lblYear.Text = dr["AY"].ToString();
                        dpFROM.Value = DateTime.Parse(dr["START"].ToString());
                        dpTO.Value = DateTime.Parse(dr["END"].ToString());
                    }
                    dr.Close();
                    cn.Close();
                }

                if (colName == "colDel")
                {
                    if (KryptonMessageBox.Show("DO YOU REALLY WANT TO DELETE THIS?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        cn.Open();
                        cm = new SqlCommand("DELETE FROM Quarter WHERE YEAR_ID LIKE '" + dgvYear.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();


                        cm = new SqlCommand("DELETE FROM SchoolYear WHERE ID LIKE '" + dgvYear.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        sbOC.Show(this.FindForm(), "RECORD HAS BEEN SUCCESSFULLY DELETED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadYear();
                        LoadQuarter();
                    }
                }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dgvQuarter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dgvQuarter.Columns[e.ColumnIndex].Name;
                if (colName == "colUpdate")
                {
                    btnUpdateQ.Enabled = true;
                    btnSave.Enabled = false;
                    cn.Open();
                    cm = new SqlCommand("SELECT Q.*, SY.START AS SY_START, SY.[END] AS SY_END FROM Quarter Q INNER JOIN SchoolYear SY ON Q.YEAR_ID = SY.ID WHERE Q.ID = @quarterId", cn);
                    cm.Parameters.AddWithValue("@quarterId", dgvQuarter.Rows[e.RowIndex].Cells[1].Value.ToString());
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        DateTime safeDate = DateTime.Today;

                        if (DateTime.TryParse(dr["SY_START"].ToString(), out DateTime schoolYearStart) &&
                            DateTime.TryParse(dr["SY_END"].ToString(), out DateTime schoolYearEnd))
                        {
                            safeDate = schoolYearStart;

                            dpSTART.MinDate = safeDate.AddYears(-10);
                            dpSTART.MaxDate = safeDate.AddYears(10);
                            dpEND.MinDate = safeDate.AddYears(-10);
                            dpEND.MaxDate = safeDate.AddYears(10);

                            dpSTART.Value = safeDate;
                            dpEND.Value = safeDate;

                            dpSTART.MinDate = schoolYearStart;
                            dpSTART.MaxDate = schoolYearEnd;
                            dpEND.MinDate = schoolYearStart;
                            dpEND.MaxDate = schoolYearEnd;
                        }

                        lblIDQ.Text = dgvQuarter.Rows[e.RowIndex].Cells[1].Value.ToString();
                        lblYID.Text = dr["YEAR_ID"].ToString();

                        if (DateTime.TryParse(dr["START"].ToString(), out DateTime startDate))
                        {
                            if (startDate >= dpSTART.MinDate && startDate <= dpSTART.MaxDate)
                            {
                                dpSTART.Value = startDate;
                            }
                            else
                            {
                                dpSTART.Value = dpSTART.MinDate;
                            }
                        }
                        else
                        {
                            dpSTART.Value = dpSTART.MinDate;
                        }

                        if (DateTime.TryParse(dr["END"].ToString(), out DateTime endDate))
                        {
                            if (endDate >= dpEND.MinDate && endDate <= dpEND.MaxDate)
                            {
                                dpEND.Value = endDate;
                            }
                            else
                            {
                                dpEND.Value = dpSTART.MinDate;
                            }
                        }
                        else
                        {
                            dpEND.Value = dpSTART.MinDate;
                        }
                    }
                    dr.Close();
                    cn.Close();                   
                }
                if (colName == "colOpen")
                {
                    dgvQuarter.Rows[e.RowIndex].Cells[6].ReadOnly = true;
                    if (KryptonMessageBox.Show("OPEN QUARTER" + dgvQuarter.Rows[e.RowIndex].Cells[3].Value.ToString() + "?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("UPDATE Quarter SET STATUS = 'CLOSE'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("UPDATE Quarter SET STATUS = 'OPEN' WHERE ID LIKE'" + dgvQuarter.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        sbOC.Show(this.FindForm(), "OPENED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadQuarter();
                    }
                }                
            }
            catch(Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpSTART.Value.Date == dpEND.Value.Date || (dpEND.Value.Year - dpSTART.Value.Year) * 12 + dpEND.Value.Month - dpSTART.Value.Month > 3 ||
                (dpEND.Value.Year - dpSTART.Value.Year) * 12 + dpEND.Value.Month - dpSTART.Value.Month < 1)
                {
                    sbOC.Show(this.FindForm(), "SELECT VALID STARTING OR ENDING DATE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("UPDATE QUARTER SET START = @start, [END] = @end WHERE ID LIKE'" + lblIDQ.Text + "'", cn);
                cm.Parameters.AddWithValue("@start", dpSTART.Value.ToShortDateString());
                cm.Parameters.AddWithValue("@end", dpEND.Value.ToShortDateString());
                cm.ExecuteNonQuery();
                cn.Close();
                sbOC.Show(this.FindForm(), "QUARTER UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                Clear();
                LoadQuarter();
                btnUpdateQ.Enabled = false; 
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dpFROM.Value.Date == DateTime.Today && dpTO.Value.Date == DateTime.Today)
                {
                    sbOC.Show(this.FindForm(), "SELECT STARTING OR ENDING DATE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if ((dpTO.Value.Year - dpFROM.Value.Year) < 1)
                {
                    sbOC.Show(this.FindForm(), "ENDING YEAR should be at least 1 year apart from the STARTING YEAR!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }
                cn.Open();
                cm = new SqlCommand("UPDATE SchoolYear SET AY = @ay, START = @start, [END] = @end WHERE ID LIKE'" + lblID.Text + "'", cn);
                cm.Parameters.AddWithValue("@ay", lblYear.Text);
                cm.Parameters.AddWithValue("@start", dpFROM.Value.ToShortDateString());
                cm.Parameters.AddWithValue("@end", dpTO.Value.ToShortDateString());
                cm.ExecuteNonQuery();
                cn.Close();
                sbOC.Show(this.FindForm(), "SCHOOL YEAR UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                btnUpdate.Enabled = false;
                Clear();
                LoadYear();
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
