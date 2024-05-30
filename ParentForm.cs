using FINAL_PROJECT_CPE262.UserControls;
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

namespace FINAL_PROJECT_CPE262
{
    public partial class ParentForm : Form
    {
        public int TID { get; set; }  
        public int SID { get; set; }
        public int PID { get; set; }
        ClassDB db = new ClassDB(); 
        public ParentForm(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            this.SID = SID;
            this.PID = PID;
            timerTime.Start();

            UC_AYQuarter ua = new UC_AYQuarter();
            UC_Teacher ut = new UC_Teacher(TID, SID, PID);
            AddTeacher at = new AddTeacher(ut, TID, SID, PID);
            ua.LoadQuarter();
            ua.LoadYear();
        }
        public int GetLGID()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT LG_ID1 FROM tblStudent WHERE ID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", SID);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (dr["LG_ID1"] != DBNull.Value && int.TryParse(dr["LG_ID1"].ToString(), out int LG_ID))
                                {
                                    return LG_ID;
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
        public string GetUserStud()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT FULLNAME FROM tblStudent WHERE ID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", SID);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(dr.GetOrdinal("FULLNAME")))
                                {
                                    string pass = dr["FULLNAME"].ToString();
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

        public string GetUserPar()
        {
            try
            {
                int LG_ID = GetLGID();
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT [FULL] FROM LegalGuardian WHERE ID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", LG_ID);
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(dr.GetOrdinal("[FULL]")))
                                {
                                    string pass = dr["[FULL]"].ToString();
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
        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblDate.Text = dt.ToString("MMMM dd, yyyy");
            lblTime.Text = dt.ToString("hh:mm:ss");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
            SignIn f = new SignIn();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        private async Task addControls(UserControl uc)
        {
            pnlControls.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlControls.Controls.Add(uc);
            uc.BringToFront();

            await Task.Delay(100);
        }

        private async void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_StudentDashboard ud = new UC_StudentDashboard(SID);
            await addControls(ud);
        }

        private void moveSidePanel(Control btn)
        {
            pnlClicked.Top = btn.Top;
            pnlClicked.Height = btn.Height;
        }

        private async void btnTeacher_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAttendance);
            UC_StudentAttendance ut = new UC_StudentAttendance(TID, SID);
            await addControls(ut);
        }

        private void btnSchInfo_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSchInfo);
            using (SchoolInfo si = new SchoolInfo())
            {
                si.tbxSchID.Enabled = false;
                si.tbxSchName.Enabled = false;
                si.tbxSchEmail.Enabled = false;
                si.tbxSchFace.Enabled = false;
                si.tbxSchPhone.Enabled = false;
                si.tbxSchAds.Enabled = false;
                si.btnSave.Enabled = false;
                si.btnSchBrowse.Enabled = false;
                si.ShowDialog();
                this.OnLoad(e);
            }
        }

        public async void btnProfile_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnProfile);
            UC_Profile c = new UC_Profile(TID, SID, PID);
            await addControls(c);
        }

        private async void btnScore_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnScore);
            UC_StudentScore us = new UC_StudentScore(0, SID);
           await addControls(us);
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            string User = GetUserPar() +" / " + GetUserStud();
            lblUser.Text = User;

            btnHome_Click(sender, e);
        }
    }
}
