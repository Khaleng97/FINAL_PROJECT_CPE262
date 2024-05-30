using FINAL_PROJECT_CPE262.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_CPE262
{
    public partial class AddParent : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        UC_Profile pf;
        private byte[] selectedImageBytes;
        public int SID { get; set; }
        public int PID { get; set; }
        public AddParent(UC_Profile pfl, int SID, int PID)
        {
            InitializeComponent();
            this.pf = pfl;
            this.SID = SID;
            this.PID = PID;
            cn = new SqlConnection(db.GetConnection());
            selectedImageBytes = new byte[0];
            lblPID.Text = PID.ToString();
            lblSID.Text = SID.ToString();

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

        private void btnSchBrowse_Click(object sender, EventArgs e)
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
                    pbxLogo.Image = Image.FromFile(openFileD.FileName);
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        public event EventHandler ProfileUpdated;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ParentForm pf = new ParentForm(0, SID, PID);
                if (int.Parse(lblPID.Text) > 0) 
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE LegalGuardian SET [TYPE] = @TYPE, [LASTN] = @LASTN, [FIRSTN] = @FIRSTN, [MIDDLEN] = @MIDDLEN, [GENDER] = @GENDER, [PHONE] = @PHONE, [EMAIL] = @EMAIL, [ADDRESS] = @ADDRESS, [IMAGE] = @IMAGEEE WHERE ID = @pid", cn);
                    cm.Parameters.AddWithValue("@pid", lblPID.Text);
                    cm.Parameters.AddWithValue("@TYPE", cbxGType.Text);
                    cm.Parameters.AddWithValue("@LASTN", tbxLName.Text);
                    cm.Parameters.AddWithValue("@FIRSTN", tbxFName.Text);
                    cm.Parameters.AddWithValue("@MIDDLEN", tbxMName.Text);
                    cm.Parameters.AddWithValue("@GENDER", cbxGender.Text);
                    cm.Parameters.AddWithValue("@PHONE", tbxPhone.Text);
                    cm.Parameters.AddWithValue("@EMAIL", tbxEmail.Text);
                    cm.Parameters.AddWithValue("@ADDRESS", tbxAds.Text);
                    cm.Parameters.AddWithValue("@IMAGEEE", selectedImageBytes);

                    int row = cm.ExecuteNonQuery();
                    if (row > 0)
                    {
                        ProfileUpdated?.Invoke(this, EventArgs.Empty);
                        sbSI.Show(this.FindForm(), "SAVED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        closeTimer.Start();
                        pf.btnProfile_Click(sender, e);
                    }
                }
                else
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO LegalGuardian ([TYPE], [LASTN], [FIRSTN], [MIDDLEN], [GENDER], [PHONE], [EMAIL], [ADDRESS], [IMAGE]) VALUES (@TYPE, @LASTN, @FIRSTN, @MIDDLEN, @GENDER, @PHONE, @EMAIL, @ADDRESS, @IMAGEE); SELECT SCOPE_IDENTITY();", cn);
                    cm.Parameters.AddWithValue("@TYPE", cbxGType.Text);
                    cm.Parameters.AddWithValue("@LASTN", tbxLName.Text);
                    cm.Parameters.AddWithValue("@FIRSTN", tbxFName.Text);
                    cm.Parameters.AddWithValue("@MIDDLEN", tbxMName.Text);
                    cm.Parameters.AddWithValue("@GENDER", cbxGender.Text);
                    cm.Parameters.AddWithValue("@PHONE", tbxPhone.Text);
                    cm.Parameters.AddWithValue("@EMAIL", tbxEmail.Text);
                    cm.Parameters.AddWithValue("@ADDRESS", tbxAds.Text);
                    cm.Parameters.AddWithValue("@IMAGEE", selectedImageBytes);
                    object result = cm.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Failed to retrieve the new LegalGuardian ID.");
                    }

                    int newLGId = Convert.ToInt32(result);

                    cm = new SqlCommand("UPDATE tblStudent SET LG_ID1 = @LG_ID WHERE ID = @id", cn);
                    cm.Parameters.AddWithValue("@id", int.Parse(lblSID.Text));
                    cm.Parameters.AddWithValue("@LG_ID", newLGId);
                    int row1 = cm.ExecuteNonQuery();

                    if (newLGId > 0 && row1 > 0)
                    {
                        sbSI.Show(this.FindForm(), "SAVED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
