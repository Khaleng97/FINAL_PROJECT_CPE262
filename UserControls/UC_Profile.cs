using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
    public partial class UC_Profile : UserControl
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int STID { get; set; }
        public int PID { get; set; }

        public UC_Profile(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            this.STID = SID;
            this.PID = PID;
            cn = new SqlConnection(db.GetConnection());
            LoadProfile();
            LoadGuardian();
        }
        
        public void LoadGuardian()
        {
            try
            {
                tbxPName.Enabled = false;
                tbxPType.Enabled = false;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM LegalGuardian WHERE ID = @ID", cn);
                cm.Parameters.AddWithValue("@ID", PID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblPID.Text = PID.ToString();
                    tbxPName.Text = "Name:     " + dr["FULL"].ToString();
                    tbxPType.Text = "Guardian Type:     " + dr["TYPE"].ToString();
                    lblGType.Text = dr["TYPE"].ToString();
                    lblPLName.Text = dr["LASTN"].ToString();
                    lblPFName.Text = dr["FIRSTN"].ToString();
                    lblPMName.Text = dr["MIDDLEN"].ToString();
                    lblPGender.Text = dr["GENDER"].ToString();
                    lblPPhone.Text = dr["PHONE"].ToString();
                    lblPAds.Text = dr["ADDRESS"].ToString();
                    lblPEmail.Text = dr["EMAIL"].ToString();

                    object imageDataObj = dr["IMAGE"];
                    if (imageDataObj == null)
                    {
                        pbxPImage.Image = null;
                    }
                    if (imageDataObj != DBNull.Value)
                    {
                        byte[] imageData = (byte[])imageDataObj;
                        if (imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbxPImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pbxPImage.Image = null;
                        }
                    }
                    else
                    {
                        pbxPImage.Image = null;
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }
        public void LoadProfile()
        {
            try
            {
                tbxLRN.Enabled = false;
                tbxName.Enabled = false;
                tbxClass.Enabled = false;
                cn.Open();
                cm = new SqlCommand("SELECT S.*, C.Class_Name FROM tblStudent S INNER JOIN Classes C ON S.CLASS_ID = C.ID WHERE S.ID = @StudentID", cn);
                cm.Parameters.AddWithValue("@StudentID", STID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    lblID.Text = STID.ToString();
                    tbxLRN.Text = "LRN:     " + dr["LRN"].ToString();
                    tbxName.Text = "Name:     " + dr["FULLNAME"].ToString();
                    tbxClass.Text = "Class:     " + dr["Class_Name"].ToString();
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
            LoadGuardian();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                UC_AdvisoryClass ac = new UC_AdvisoryClass(TID,STID, PID);
                AddStudent frm = new AddStudent(ac, TID, STID, PID);
                frm.ProfileUpdated += Frm_ProfileUpdated;
                cn.Open();
                cm = new SqlCommand("SELECT S.*, C.Class_Name FROM tblStudent S INNER JOIN Classes C ON S.CLASS_ID = C.ID WHERE S.ID = @StudentID", cn);
                cm.Parameters.AddWithValue("@StudentID", STID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    frm.lblSID.Text = STID.ToString();
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
                frm.tbxLRN.Enabled = false;
                frm.cbxSGender.Enabled = false;
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.cbxSGender.Enabled = false;
                frm.dpSDOB.Enabled = false;
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
            LoadProfile();
            LoadGuardian();
        }

        private void btnEditP_Click(object sender, EventArgs e)
        {
            try
            {
                UC_Profile ac = new UC_Profile(TID, STID, PID);
                AddParent frm = new AddParent(ac, STID, PID);
                frm.ProfileUpdated += Frm_ProfileUpdated;
                cn.Open();
                cm = new SqlCommand("SELECT * FROM LegalGuardian WHERE ID = @ID", cn);
                cm.Parameters.AddWithValue("@ID", PID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                        frm.lblPID.Text = PID.ToString();
                        frm.cbxGType.Text = dr["TYPE"].ToString();
                        frm.tbxLName.Text = dr["LASTN"].ToString();
                        frm.tbxFName.Text = dr["FIRSTN"].ToString();
                        frm.tbxMName.Text = dr["MIDDLEN"].ToString();
                        frm.cbxGender.Text = dr["GENDER"].ToString();
                        frm.tbxPhone.Text = dr["PHONE"].ToString();
                        frm.tbxAds.Text = dr["ADDRESS"].ToString();
                        frm.tbxEmail.Text = dr["EMAIL"].ToString();
                    object imageDataObj = dr["IMAGE"];
                    if (imageDataObj == null)
                    {
                        pbxPImage.Image = null;
                    }
                    if (imageDataObj != DBNull.Value)
                    {
                        byte[] imageData = (byte[])imageDataObj;
                        if (imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pbxPImage.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pbxPImage.Image = null;
                        }
                    }
                    else
                    {
                        pbxPImage.Image = null;
                    }                   
                }
                dr.Close();
                cn.Close();
                frm.btnSave.Enabled = true;
                frm.ShowDialog();           
            }
            catch (Exception)
            {
                dr?.Close();
                cn?.Close();
            }
        }

        public string GetPass(int SID)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT Password FROM tblUser WHERE SID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", SID);
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
                    using (SqlCommand cm = new SqlCommand("UPDATE tblUser SET Password = @pass WHERE SID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@pass", newPassword);
                        cm.Parameters.AddWithValue("@id", STID);
                        
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
                string currentPass = GetPass(STID);

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
