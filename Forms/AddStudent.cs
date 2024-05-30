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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Reflection;

namespace FINAL_PROJECT_CPE262
{
    public partial class AddStudent : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        string title = "SCHOOL MANAGEMENT SYSTEM";
        UC_AdvisoryClass ac;
        private byte[] selectedImageBytes;
        private byte[] imageBytes;

        private int _classId;
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID { get; set; }
        public int ClassId
        {
            get { return _classId; }
            set
            {
                _classId = value;
                if (cbxSClasses.Items.Count > 0)
                {
                    cbxSClasses.SelectedValue = _classId;
                }
            }
        }
        public AddStudent(UC_AdvisoryClass ac, int TID, int SID, int PID)
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            
            imageBytes = new byte[0];
            selectedImageBytes = new byte[0];
            this.ac = ac;
            this.TID = TID;
            this.SID = SID;
            this.PID = PID;

            closeTimer = new Timer();
            closeTimer.Interval = 1500;
            closeTimer.Tick += CloseTimer_Tick;
            LoadAddSClass();
        }

        public void LoadAddSClass()
        {
            this.classesTableAdapter.Fill(this.sMSDataSet.Classes);
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
            tbxLRN.Clear();
            tbxLRN.Text = null;
            cbxSClasses.SelectedIndex = -1;
            cbxSClasses.Text = "";
            tbxSLname.Clear();
            tbxSFname.Clear();
            tbxSMname.Clear();
            lblSAge.Text = "";
            dpSDOB.Value = DateTime.Today;
            tbxSPhone.Clear();
            cbxSGender.SelectedIndex = -1;
            pbxSImage.Image = null;
            tbxSEmail.Clear();
            tbxSEmail.Text = "";
            tbxSAds.Clear();
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
                    pbxSImage.Image = Image.FromFile(openFileD.FileName);
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Error: " +ex.Message);
            }                       
        }

        private bool IsDuplicateLRN(string LRN, int ID)
        {
            tblStudentTableAdapter sd = new tblStudentTableAdapter();
            int count = (int)sd.CheckDuplicateLRN(LRN);
            if (ID > 0)
            {
                count--;
            }
            if (count > 0)
                return true;
            else
                return false;
        }

        private bool IsDuplicateName(string lname, string fname, int ID)
        {
            tblStudentTableAdapter sd = new tblStudentTableAdapter();
            int count = (int)sd.CheckDuplicateName(lname, fname);
            if (ID > 0)
            {
                count--;
            }
            if (count > 0)
                return true;
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbxLRN.Text) || !IsValidTID(tbxLRN.Text.Trim()))
                {
                    if(string.IsNullOrWhiteSpace(tbxLRN.Text))
                    {
                        sbT.Show(this.FindForm(), "LRN IS REQUIRED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    else if(!IsValidTID(tbxLRN.Text.Trim()))
                    {
                        sbT.Show(this.FindForm(), "ENTER VALID LRN!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    tbxLRN.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbxSLname.Text))
                {
                    sbT.Show(this.FindForm(), "LAST NAME is required!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    tbxSLname.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbxSFname.Text))
                {
                    sbT.Show(this.FindForm(), "FIRST NAME is required!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    tbxSFname.Focus();
                    return;
                }

                string LRN = tbxLRN.Text;
                string lname = tbxSLname.Text;
                string fname = tbxSFname.Text;

                if (IsDuplicateLRN(LRN, 0))
                {
                    sbT.Show(this.FindForm(), "LRN ALREADY EXIST (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (IsDuplicateName(lname, fname, 0))
                {
                    sbT.Show(this.FindForm(), "STUDENT ALREADY EXIST (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tbxSEmail.Text) || !IsValidEmail(tbxSEmail.Text.Trim()))
                {
                    if(string.IsNullOrWhiteSpace(tbxSEmail.Text))
                    {
                        sbT.Show(this.FindForm(), "EMAIL IS REQUIRED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }
                    else if(!IsValidEmail(tbxSEmail.Text.Trim()))
                    {
                        sbT.Show(this.FindForm(), "ENTER VALID EMAIL!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    }  
                    tbxSEmail.Focus();
                    return;
                }
                if (dpSDOB.Value.Date == DateTime.Today)
                {
                    sbT.Show(this.FindForm(), "SELECT DATE OF BIRTH!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    dpSDOB.Focus();
                    return;
                }
                if (cbxSClasses.SelectedValue == null || cbxSClasses.SelectedIndex == -1)
                {
                    sbT.Show(this.FindForm(), "SELECT CLASS!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxSClass.Focus();
                    return;
                }
                if (!string.IsNullOrWhiteSpace(tbxSPhone.Text) && !IsValidPhoneNumber(tbxSPhone.Text.Trim()))
                {
                    sbT.Show(this.FindForm(), "ENTER VALID PHONE NUMBER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    dpSDOB.Focus();
                    return;
                }
                if (cbxSGender.SelectedIndex == -1 || cbxSGender.SelectedIndex == -1)
                {
                    sbT.Show(this.FindForm(), "SELECT GENDER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxSGender.Focus();
                    return;
                }
                

                if (KryptonMessageBox.Show("SAVE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string status = "ACTIVE";
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblStudent (LRN, CLASS_ID, LNAME, FNAME, MNAME, GENDER, DOB, AGE, PHONE, ADDRESS, EMAIL, IMAGE, STATUS) VALUES (@lrn, @classID, @lname, @fname, @mname, @gender, @dob, @age, @phone, @address, @email, @image, @status)", cn);
                    cm.Parameters.AddWithValue("@lrn", string.IsNullOrEmpty(tbxLRN.Text) ? (object)DBNull.Value : tbxLRN.Text);
                    cm.Parameters.AddWithValue("@classID", (int)cbxSClasses.SelectedValue);
                    cm.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(tbxSLname.Text) ? (object)DBNull.Value : tbxSLname.Text);
                    cm.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(tbxSFname.Text) ? (object)DBNull.Value : tbxSFname.Text);
                    cm.Parameters.AddWithValue("@mname", string.IsNullOrEmpty(tbxSMname.Text) ? (object)DBNull.Value : tbxSMname.Text);
                    cm.Parameters.AddWithValue("@gender", string.IsNullOrEmpty(cbxSGender.Text) ? (object)DBNull.Value : cbxSGender.Text);
                    cm.Parameters.AddWithValue("@dob", string.IsNullOrEmpty(dpSDOB.Value.Date.ToShortDateString()) ? (object)DBNull.Value : dpSDOB.Value.Date.ToShortDateString());
                    cm.Parameters.AddWithValue("@age", string.IsNullOrEmpty(lblSAge.Text) ? (object)DBNull.Value : lblSAge.Text);
                    cm.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(tbxSPhone.Text) ? (object)DBNull.Value : tbxSPhone.Text);
                    cm.Parameters.AddWithValue("@address", string.IsNullOrEmpty(tbxSAds.Text) ? (object)DBNull.Value : tbxSAds.Text);
                    cm.Parameters.AddWithValue("@email", string.IsNullOrEmpty(tbxSEmail.Text) ? (object)DBNull.Value : tbxSEmail.Text);
                     cm.Parameters.AddWithValue("@image", selectedImageBytes);
                    cm.Parameters.AddWithValue("@status", status);
                    string email = tbxSEmail.Text;
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0) 
                    {
                        sbT.Show(this.FindForm(), "ADDED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        LoadAddSClass();
                        ac.LoadRecords();
                    }
                    cn.Close();
                    Clear();
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
            lblSAge.Text = Years(dpSDOB.Value.Date, DateTime.Now.Date).ToString();
        }

        public void AddStudent_Load(object sender, EventArgs e)
        {
            lblValEm.Visible = false;
            lblValNum.Visible = false;
            lblValLRN.Visible = false;
        }
        public event EventHandler ProfileUpdated;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UC_Profile p = new UC_Profile(TID, SID, PID);
                ParentForm pf = new ParentForm(TID, SID, PID);

                string LRN = tbxLRN.Text;
                string lname = tbxSLname.Text;
                string fname = tbxSFname.Text;
                int ID = int.Parse(lblSID.Text);

                if (IsDuplicateLRN(LRN, ID))
                {
                    sbT.Show(this.FindForm(), "LRN ALREADY EXISTS (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (IsDuplicateName(lname, fname, ID))
                {
                    sbT.Show(this.FindForm(), "STUDENT ALREADY EXISTS (DUPLICATION)!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (KryptonMessageBox.Show("UPDATE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE tblStudent SET LRN = @lrn, CLASS_ID = @classID, LNAME = @lname, FNAME = @fname, MNAME = @mname, GENDER = @gender, DOB = @dob, AGE = @age, PHONE = @phone, ADDRESS = @address, EMAIL = @email, IMAGE = @image, STATUS = @status WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", ID); 
                    cm.Parameters.AddWithValue("@lrn", string.IsNullOrEmpty(tbxLRN.Text) ? (object)DBNull.Value : tbxLRN.Text);
                    cm.Parameters.AddWithValue("@classID", (int)cbxSClasses.SelectedValue);
                    cm.Parameters.AddWithValue("@lname", string.IsNullOrEmpty(tbxSLname.Text) ? (object)DBNull.Value : tbxSLname.Text);
                    cm.Parameters.AddWithValue("@fname", string.IsNullOrEmpty(tbxSFname.Text) ? (object)DBNull.Value : tbxSFname.Text);
                    cm.Parameters.AddWithValue("@mname", string.IsNullOrEmpty(tbxSMname.Text) ? (object)DBNull.Value : tbxSMname.Text);
                    cm.Parameters.AddWithValue("@gender", string.IsNullOrEmpty(cbxSGender.Text) ? (object)DBNull.Value : cbxSGender.Text);
                    cm.Parameters.AddWithValue("@dob", dpSDOB.Value.Date);
                    cm.Parameters.AddWithValue("@age", string.IsNullOrEmpty(lblSAge.Text) ? (object)DBNull.Value : lblSAge.Text);
                    cm.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(tbxSPhone.Text) ? (object)DBNull.Value : tbxSPhone.Text);
                    cm.Parameters.AddWithValue("@address", string.IsNullOrEmpty(tbxSAds.Text) ? (object)DBNull.Value : tbxSAds.Text);
                    cm.Parameters.AddWithValue("@email", string.IsNullOrEmpty(tbxSEmail.Text) ? (object)DBNull.Value : tbxSEmail.Text);
                    cm.Parameters.AddWithValue("@image", selectedImageBytes);
                    cm.Parameters.AddWithValue("@status", lblStatus.Text);
                    int Trows = cm.ExecuteNonQuery();

                    if (Trows > 0)
                    {
                        ProfileUpdated?.Invoke(this, EventArgs.Empty);
                        sbT.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        Clear();
                        ac.LoadRecords();
                        pf.btnProfile_Click(sender, e);
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
            return !string.IsNullOrEmpty(tid) && tid.Length == 12 && tid.All(char.IsDigit);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+63|0)\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void tbxTPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = tbxSPhone.Text.Trim();
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

        private void tbxLRN_TextChanged(object sender, EventArgs e)
        {
            string lrn = tbxLRN.Text.Trim();
            if (string.IsNullOrEmpty(lrn))
            {
                lblValLRN.Visible = false;
            }
            else if (!IsValidTID(lrn))
            {
                lblValLRN.Visible = true;
            }
            else
            {
                lblValLRN.Visible = false;
            }
        }

        private void cbxSClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSClasses.SelectedValue != null)
            {
                lblClassID.Text = cbxSClasses.SelectedValue.ToString();
            }
            else
            {
                lblClassID.Text = "";
            }
            
        }
    }
}
