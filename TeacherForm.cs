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
    public partial class TeacherForm : Form
    {
        ClassDB db = new ClassDB();
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID { get; set; }
        public TeacherForm(int TID, int SID, int PID)
        {
            InitializeComponent();
            this.TID = TID;
            this.SID = SID;
            this.PID = PID;
            timerTime.Start();

            UC_AYQuarter ua = new UC_AYQuarter();
            UC_Subjects us = new UC_Subjects();
            UC_Section use = new UC_Section();
            UC_Teacher ut = new UC_Teacher(TID, SID, PID);
            UC_Classes c = new UC_Classes();
            AddTeacher at = new AddTeacher(ut, TID, SID, PID);
            SchoolInfo si = new SchoolInfo();
            ua.LoadQuarter();
            ua.LoadYear();            
        }

        public string GetUser()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(db.GetConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT FULLNAME FROM tblTeacher WHERE ID = @id", cn))
                    {
                        cm.Parameters.AddWithValue("@id", TID);
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
            UC_TeacherDashboard ud = new UC_TeacherDashboard(TID);
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
            UC_Attendance ut = new UC_Attendance(TID);
            ut.AttTabControl.SelectedIndex = 0;
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

        private async void btnClass_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAdClass);
            UC_AdvisoryClass c = new UC_AdvisoryClass(TID, SID, PID);
            await addControls(c);
        }

        private async void btnScore_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnScore);
            UC_Score us = new UC_Score(TID);
            us.ScoreTabControl.SelectedIndex = 0;
            await addControls(us);
        }

        public async void btnProfile_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnProfile);
            UC_TeacherProfile us = new UC_TeacherProfile(TID, SID, PID);
            await addControls(us);
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = GetUser();
            btnHome_Click(sender, e);
        }
    }
}
