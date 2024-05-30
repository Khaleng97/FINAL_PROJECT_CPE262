using FINAL_PROJECT_CPE262.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FINAL_PROJECT_CPE262
{
    public partial class SignIn : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public int TEA_ID;
        public int STUD_ID;
        public int PAR_ID;
        public SignIn()
        {
            InitializeComponent();
            cn = new SqlConnection();
            cn.ConnectionString = db.GetConnection();
            closeTimer = new Timer();
            closeTimer.Interval = 1000;
            closeTimer.Tick += CloseTimer_Tick;
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Hide();
        }
        private void SignIn_Load(object sender, EventArgs e)
        {
            tbxPass.PasswordChar = '●';
            btnHidePass.Hide();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            tbxPass.PasswordChar = '\0';
            btnShowPass.Hide();
            btnHidePass.Show();
        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            tbxPass.PasswordChar = '●';
            btnHidePass.Hide();
            btnShowPass.Show();
        }

        public int GetSID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT SID FROM tblUser WHERE Username = @username AND Password = @pass AND UserType = @userType", cn))
                    {
                        cm.Parameters.AddWithValue("@username", tbxUsername.Text);
                        cm.Parameters.AddWithValue("@pass", tbxPass.Text);
                        cm.Parameters.AddWithValue("@userType", cbxUsertype.Text);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["SID"] != DBNull.Value && int.TryParse(dr["SID"].ToString(), out int ID))
                                {
                                    return ID;
                                }
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int GetPID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT LG_ID1 FROM tblStudent WHERE ID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", GetSID());
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["LG_ID1"] != DBNull.Value && int.TryParse(dr["LG_ID1"].ToString(), out int ID))
                                {
                                    return ID;
                                }
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int GetTID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT TID FROM tblUser WHERE Username = @username AND Password = @pass AND UserType = @userType", cn))
                    {
                        cm.Parameters.AddWithValue("@username", tbxUsername.Text);
                        cm.Parameters.AddWithValue("@pass", tbxPass.Text);
                        cm.Parameters.AddWithValue("@userType", cbxUsertype.Text);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                int ID = int.Parse(dr["TID"].ToString());
                                return ID;
                            }
                        }
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(tbxUsername.Text))
             {
                sbLogin.Show(this.FindForm(), "Enter username!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                return;
             }
             else if(string.IsNullOrEmpty(tbxPass.Text))
             {
                sbLogin.Show(this.FindForm(), "Enter password!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                return;
             }
            cn.Open();
            cm = new SqlCommand("SELECT * FROM tblUser WHERE Username = @username AND Password = @pass AND UserType = @userType", cn);
            cm.Parameters.AddWithValue("@username", tbxUsername.Text);
            cm.Parameters.AddWithValue("@pass", tbxPass.Text);
            cm.Parameters.AddWithValue("@userType", cbxUsertype.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                string password = dr["Password"].ToString();
                string username = dr["Username"].ToString();
                string status = dr["STATUS"].ToString();
                if(cbxUsertype.Text == "Parent")
                {
                    if(status != "ACTIVE")
                    {
                        sbLogin.Show(this.FindForm(), "ACCOUNT IS NOT ACTIVE OR DISABLED!!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                        tbxPass.Clear();
                        cn.Close();
                        return;
                    }
                }
                if(password != tbxPass.Text)
                {
                    sbLogin.Show(this.FindForm(), "Incorrect Password!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    tbxPass.Clear();
                    cn.Close();
                    return;
                }
                else if(username != tbxUsername.Text)
                {
                    sbLogin.Show(this.FindForm(), "Incorrect Username!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                    tbxPass.Clear();
                    cn.Close();
                    return;
                }

                sbLogin.Show(this.FindForm(), "Login successfully!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                closeTimer.Start();

                if(cbxUsertype.Text == "Teacher")
                {
                    int teacherID = GetTID(); 
                    TEA_ID = teacherID;
                    UC_Score us = new UC_Score(teacherID);
                    AddScore ads = new AddScore(us, teacherID);
                    UC_Attendance ut = new UC_Attendance(teacherID);
                    UC_AdvisoryClass ac = new UC_AdvisoryClass(teacherID, 0, 0);
                    UC_Profile ucp = new UC_Profile(teacherID, 0, 0);
                    TeacherForm f = new TeacherForm(teacherID, STUD_ID, PAR_ID);
                    f.FormClosed += (s, args) => this.Close();
                    f.Show();
                }
                else if(cbxUsertype.Text == "Parent")
                {
                    int studentID = GetSID();
                    int parentID = GetPID();
                    STUD_ID = studentID;
                    PAR_ID = parentID;
                    
                    UC_Profile up = new UC_Profile(0, studentID, parentID);
                    AddParent ap = new AddParent(up, studentID, parentID);

                    ParentForm f = new ParentForm(0, studentID, parentID);
                    f.FormClosed += (s, args) => this.Close();
                    f.Show();
                }
                else if(cbxUsertype.Text == "Admin")
                {
                    AdminForm f = new AdminForm(0, 0, 0);
                    f.FormClosed += (s, args) => this.Close();
                    f.Show();
                }
            }
            else
            {
                sbLogin.Show(this.FindForm(), "INCORRECT USERNAME OR PASSWORD!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
            dr.Close();
            cn.Close();
        }
    }
}
