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
    public partial class UC_TeacherProfile : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int STID { get; set; }
        public int PID { get; set; }

        public UC_TeacherProfile(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            this.STID = SID;
            this.PID = PID;
            cn = new SqlConnection(db.GetConnection());
            LoadProfile();
        }
       
        public void LoadProfile()
        {
            try
            {
                tbxTID.Enabled = false;
                tbxName.Enabled = false;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM tblTeacher WHERE ID = @TID", cn);
                cm.Parameters.AddWithValue("@TID", TID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblID.Text = TID.ToString();
                    tbxTID.Text = "TEACHER'S ID:     " + dr["TID"].ToString();
                    tbxName.Text = "Name:     " + dr["FULLNAME"].ToString();
                    lblLName.Text = dr["LNAME"].ToString();
                    lblFName.Text = dr["FNAME"].ToString();
                    lblMName.Text = dr["MNAME"].ToString();
                    lblGender.Text = dr["GENDER"].ToString();
                    if (DateTime.TryParse(dr["DOB"].ToString(), out DateTime startDate))
                    {
                        lblDOB.Text = startDate.ToShortDateString();
                    }
                    lblAge.Text = dr["AGE"].ToString();
                    lblPhone.Text = dr["PHONE"].ToString();
                    lblAds.Text = dr["ADDRESS"].ToString();
                    lblEmail.Text = dr["EMAIL"].ToString();

                    object imageDataObj = dr["IMAGE"];
                    if (imageDataObj == null)
                    {
                        pbxImage.Image = null;
                    }
                    if (imageDataObj != DBNull.Value)
                    {
                        byte[] imageData = (byte[])imageDataObj;
                        if (imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbxImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pbxImage.Image = null;
                        }
                    }
                    else
                    {
                        pbxImage.Image = null;
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        public void UC_Profile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                UC_Teacher uct = new UC_Teacher(TID, STID, PID);
                AddTeacher frm = new AddTeacher(uct, TID, STID, PID);
                frm.ProfileUpdated += Frm_ProfileUpdated;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM tblTeacher WHERE ID = @TID", cn);
                cm.Parameters.AddWithValue("@TID", TID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    frm.lblTID.Text = TID.ToString();
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
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Frm_ProfileUpdated(object sender, EventArgs e)
        {
            LoadProfile();;
        }

        public string GetPass(int TID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT Password FROM tblUser WHERE TID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", TID);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(dr.GetOrdinal("Password")))
                                {
                                    string pass = dr["Password"].ToString();
                                    return pass;
                                }
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private bool UpdatePassword(string oldPassword, string newPassword, string currentPass)
        {
            string confirmNewPassword = tbxCNewPass.Text.Trim();
            try
            {
                if (oldPassword != currentPass)
                {
                    MessageBox.Show("Old password is incorrect.");
                    return false;
                }

                if (newPassword != confirmNewPassword)
                {
                    MessageBox.Show("New password and confirmed new password do not match.");
                    return false;
                }

                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("UPDATE tblUser SET Password = @pass WHERE TID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@pass", newPassword);
                        cm.Parameters.AddWithValue("@id", TID);

                        int row = cm.ExecuteNonQuery();

                        return row > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                return false;
            }
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPassword = tbxPassword.Text.Trim();
                string newPassword = tbxNewPass.Text.Trim();
                string confirmNewPassword = tbxCNewPass.Text.Trim();
                string currentPass = GetPass(TID);

                if (UpdatePassword(oldPassword, newPassword, currentPass))
                {
                    sbOC.Show(this.FindForm(), "PASSWORD UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    tbxPassword.Clear();
                    tbxNewPass.Clear();
                    tbxCNewPass.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to update password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
    }
}
