using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using FINAL_PROJECT_CPE262.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace FINAL_PROJECT_CPE262
{
    public partial class AddTeacher : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        string title = "SCHOOL MANAGEMENT SYSTEM";
        UC_Teacher ut;
        private byte[] selectedImageBytes;
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID { get; set; }
        public AddTeacher(UC_Teacher ut, int TID, int SID, int PID)
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            selectedImageBytes = new byte[0];
            this.ut = ut;
            this.TID = TID;
            this.PID = PID;
            this.SID = SID;

            closeTimer = new Timer();
            closeTimer.Interval = 1500;
            closeTimer.Tick += CloseTimer_Tick;
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Dispose();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            tbxTID.Clear();
            tbxTID.Text = null;
            tbxTLname.Clear();
            tbxTFname.Clear();
            tbxTMname.Clear();
            lblAge.Text = "";
            dpDOB.Value = DateTime.Today;
            tbxTPhone.Clear();
            cbxGender.SelectedIndex = -1;
            pbxImage.Image = null;
            tbxTEmail.Clear();
            tbxTAds.Clear();
        }

        private void btnTBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileD = new OpenFileDialog();
                string mypictures = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileD.Filter = "Image Files (*.jpg, *.jpeg, *.gif, *.png)|*.jpg;*.jpeg;*.gif;*.png";
                openFileD.FileName = "Image file name";
                openFileD.Title = "Choose an image...";
                openFileD.AddExtension = true;
                openFileD.FilterIndex = 0;
                openFileD.Multiselect = false;
                openFileD.ValidateNames = true;
                openFileD.InitialDirectory = mypictures;
                openFileD.RestoreDirectory = true;
                if (openFileD.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileD.FileName;
                    selectedImageBytes = File.ReadAllBytes(imagePath);
                    pbxImage.Image = Image.FromFile(openFileD.FileName);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Error: " +ex.Message);
            }                        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbxTID.Text) || !IsValidTID(tbxTID.Text.Trim()))
                {
                    if(string.IsNullOrWhiteSpace(tbxTID.Text))
                    {
                        sbT.Show(this.FindForm(), "TEACHER's ID IS REQUIRED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    else if(!IsValidTID(tbxTID.Text.Trim()))
                    {
                        sbT.Show(this.FindForm(), "ENTER VALID TEACHER's ID!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    tbxTID.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbxTLname.Text))
                {
                    sbT.Show(this.FindForm(), "LAST NAME is required!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    tbxTLname.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbxTFname.Text))
                {
                    sbT.Show(this.FindForm(), "FIRST NAME is required!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    tbxTFname.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbxTEmail.Text) || !IsValidEmail(tbxTEmail.Text.Trim()))
                {
                    if(string.IsNullOrWhiteSpace(tbxTEmail.Text))
                    {
                        sbT.Show(this.FindForm(), "EMAIL IS REQUIRED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    else if(!IsValidEmail(tbxTEmail.Text.Trim()))
                    {
                        sbT.Show(this.FindForm(), "ENTER VALID EMAIL!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }  
                    tbxTEmail.Focus();
                    return;
                }
                if (dpDOB.Value.Date == DateTime.Today)
                {
                    sbT.Show(this.FindForm(), "SELECT DATE OF BIRTH!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    dpDOB.Focus();
                    return;
                }
                if(!string.IsNullOrWhiteSpace(tbxTPhone.Text) && !IsValidPhoneNumber(tbxTPhone.Text.Trim()))
                {
                    sbT.Show(this.FindForm(), "ENTER VALID PHONE NUMBER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    dpDOB.Focus();
                    return;
                }
                if (cbxGender.SelectedIndex == -1 || cbxGender.SelectedIndex == -1)
                {
                    sbT.Show(this.FindForm(), "SELECT GENDER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxGender.Focus();
                    return;
                }

                if (KryptonMessageBox.Show("SAVE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblTeacher (TID, LNAME, FNAME, MNAME, GENDER, DOB, AGE, PHONE, ADDRESS, EMAIL, IMAGE) VALUES (@tid, @lname, @fname, @mname, @gender, @dob, @age, @phone, @address, @email, @image)", cn);
                    cm.Parameters.AddWithValue("@tid", string.IsNullOrEmpty(tbxTID.Text) ? (object)DBNull.Value : tbxTID.Text);
                    cm.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(tbxTLname.Text) ? (object)DBNull.Value : tbxTLname.Text);
                    cm.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(tbxTFname.Text) ? (object)DBNull.Value : tbxTFname.Text);
                    cm.Parameters.AddWithValue("@mname", string.IsNullOrEmpty(tbxTMname.Text) ? (object)DBNull.Value : tbxTMname.Text);
                    cm.Parameters.AddWithValue("@gender", string.IsNullOrEmpty(cbxGender.Text) ? (object)DBNull.Value : cbxGender.Text);
                    cm.Parameters.AddWithValue("@dob", string.IsNullOrEmpty(dpDOB.Value.Date.ToShortDateString()) ? (object)DBNull.Value : dpDOB.Value.Date.ToShortDateString());
                    cm.Parameters.AddWithValue("@age", string.IsNullOrEmpty(lblAge.Text) ? (object)DBNull.Value : lblAge.Text);
                    cm.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(tbxTPhone.Text) ? (object)DBNull.Value : tbxTPhone.Text);
                    cm.Parameters.AddWithValue("@address", string.IsNullOrEmpty(tbxTAds.Text) ? (object)DBNull.Value : tbxTAds.Text);
                    cm.Parameters.AddWithValue("@email", string.IsNullOrEmpty(tbxTEmail.Text) ? (object)DBNull.Value : tbxTEmail.Text);
                    cm.Parameters.AddWithValue("@image", selectedImageBytes);
                    string email = tbxTEmail.Text;
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0) 
                    {
                        sbT.Show(this.FindForm(), "ADDED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        Clear();
                        ut.LoadRecords();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cn.Close();
            }
        }
        

        private void cbxGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        int Years(DateTime start, DateTime end)
        {
            int years = end.Year - start.Year;
            if (end.Month < start.Month || (end.Month == start.Month && end.Day < start.Day))
            {
                years--;
            }
            return years;
        }

        private void dpDOB_ValueChanged(object sender, EventArgs e)
        {
            lblAge.Text = Years(dpDOB.Value.Date, DateTime.Now.Date).ToString();
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            lblValEm.Visible = false;
            lblValNum.Visible = false;
            lblValTID.Visible = false;
        }

        public event EventHandler ProfileUpdated;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TeacherForm tf = new TeacherForm(TID, SID, PID);
                if (KryptonMessageBox.Show("UPDATE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblTeacher SET TID = @tid, LNAME = @lname, FNAME = @fname, MNAME = @mname, GENDER = @gender, DOB = @dob, AGE = @age, PHONE = @phone, ADDRESS = @address, EMAIL = @email, IMAGE = @image WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", lblTID.Text);
                    cm.Parameters.AddWithValue("@tid", string.IsNullOrEmpty(tbxTID.Text) ? (object)DBNull.Value : tbxTID.Text);
                    cm.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(tbxTLname.Text) ? (object)DBNull.Value : tbxTLname.Text);
                    cm.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(tbxTFname.Text) ? (object)DBNull.Value : tbxTFname.Text);
                    cm.Parameters.AddWithValue("@mname", string.IsNullOrEmpty(tbxTMname.Text) ? (object)DBNull.Value : tbxTMname.Text);
                    cm.Parameters.AddWithValue("@gender", string.IsNullOrEmpty(cbxGender.Text) ? (object)DBNull.Value : cbxGender.Text);
                    cm.Parameters.AddWithValue("@dob", string.IsNullOrEmpty(dpDOB.Value.Date.ToShortDateString()) ? (object)DBNull.Value : dpDOB.Value.Date.ToShortDateString());
                    cm.Parameters.AddWithValue("@age", string.IsNullOrEmpty(lblAge.Text) ? (object)DBNull.Value : lblAge.Text);
                    cm.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(tbxTPhone.Text) ? (object)DBNull.Value : tbxTPhone.Text);
                    cm.Parameters.AddWithValue("@address", string.IsNullOrEmpty(tbxTAds.Text) ? (object)DBNull.Value : tbxTAds.Text);
                    cm.Parameters.AddWithValue("@email", string.IsNullOrEmpty(tbxTEmail.Text) ? (object)DBNull.Value : tbxTEmail.Text);
                    cm.Parameters.AddWithValue("@image", selectedImageBytes);
                    string email = tbxTEmail.Text;
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0)
                    {
                        ProfileUpdated?.Invoke(this, EventArgs.Empty);
                        sbT.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        Clear();
                        ut.LoadRecords();
                        tf.btnProfile_Click(sender, e);

                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Database error: " + sqlEx.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                cn.Close();
                KryptonMessageBox.Show(ex.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                cn.Close();
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private bool IsValidTID(string tid)
        {
            return !string.IsNullOrEmpty(tid) && tid.Length == 7 && tid.All(char.IsDigit);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+63|0)\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }


        private void tbxTEmail_TextChanged(object sender, EventArgs e)
        {
            string email = tbxTEmail.Text.Trim();
            if(string.IsNullOrEmpty(email))
            {
                lblValEm.Visible = false;
            }
            else if (!IsValidEmail(email))
            {
                lblValEm.Visible = true;
            }
            else
            {
                lblValEm.Visible = false;
            }
        }

        private void tbxTPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = tbxTPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                lblValNum.Visible = false;
            }
            else if (!IsValidPhoneNumber(phone))
            {
                lblValNum.Visible = true; 
            }
            else
            {
                lblValNum.Visible = false; 
            }
        }

        private void tbxTID_TextChanged(object sender, EventArgs e)
        {
            string tid = tbxTID.Text.Trim();
            if (string.IsNullOrEmpty(tid))
            {
                lblValTID.Visible = false;
            }
            else if (!IsValidTID(tid))
            {
                lblValTID.Visible = true;
            }
            else
            {
                lblValTID.Visible = false;
            }
        }
    }
}
