using FINAL_PROJECT_CPE262.UserControls;
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

namespace FINAL_PROJECT_CPE262
{
    public partial class SchoolInfo : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        public SchoolInfo()
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSchBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(*.jpg, *.png, *.jpeg)|*.jpg| *.png| *.jpeg";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbxLogo.Image = Image.FromFile(ofd.FileName);
            }
        }

        byte[] ConvertImageToBytes(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void SchoolInfo_Load(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT * FROM SchoolInfo WHERE ID = '303165'", cn);
                SqlDataReader reader = cm.ExecuteReader();

                if (reader.Read())
                {
                    tbxSchID.Text = "303165";
                    tbxSchName.Text = reader["Name"].ToString();
                    tbxSchEmail.Text = reader["Email"].ToString();
                    tbxSchFace.Text = reader["Web"].ToString();
                    tbxSchPhone.Text = reader["Phone"].ToString();
                    tbxSchAds.Text = reader["Address"].ToString();

                    if (reader["Image"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["Image"];
                        MemoryStream ms = new MemoryStream(imageData);
                        pbxLogo.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        pbxLogo.Image = null;
                    }
                }
                reader.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("UPDATE SchoolInfo SET Name = @name, Email = @email, Web = @web, Phone = @phone, Address = @ads, Image = @image WHERE ID = '303165'", cn);
                cm.Parameters.AddWithValue("@name", tbxSchName.Text);
                cm.Parameters.AddWithValue("@email", tbxSchEmail.Text);
                cm.Parameters.AddWithValue("@web", tbxSchFace.Text);
                cm.Parameters.AddWithValue("@phone", tbxSchPhone.Text);
                cm.Parameters.AddWithValue("@ads", tbxSchAds.Text);
                if (pbxLogo.Image != null)
                {
                    byte[] imageData = ConvertImageToBytes(pbxLogo.Image);
                    cm.Parameters.AddWithValue("@image", imageData);
                }
                else
                {
                    cm.Parameters.AddWithValue("@image", DBNull.Value);
                }
                sbSI.Show(this.FindForm(), "SAVED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
