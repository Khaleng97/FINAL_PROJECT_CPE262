using FINAL_PROJECT_CPE262.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_CPE262
{
    public partial class AdminForm : Form
    {
        public int TID { get; set; }
        public int SID { get; set; }
        public int PID { get; set; }
        public AdminForm(int TID, int SID, int PID)
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
        private async void btnAYQ_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAYQ);
            UC_AYQuarter ua = new UC_AYQuarter();
            await addControls(ua);
        }

        private async void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Dashboard ud = new UC_Dashboard();
            await addControls(ud);
        }

        private void moveSidePanel(Control btn)
        {
            pnlClicked.Top = btn.Top;
            pnlClicked.Height = btn.Height;
        }

        private async void btnTeacher_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnTeacher);
            UC_Teacher ut = new UC_Teacher(TID, SID, PID);
            await addControls(ut);
        }

        private void btnSchInfo_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSchInfo);
            using (SchoolInfo si = new SchoolInfo())
            {
                si.ShowDialog();
                this.OnLoad(e);
            }
        }

        private async void btnSubject_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSubject);
            UC_Subjects us = new UC_Subjects();
            await addControls(us);
        }

        private async void btnSection_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSection);
            UC_Section use = new UC_Section();
            await addControls(use);
        }

        private async void btnClass_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnClass);
            UC_Classes c = new UC_Classes();
            await addControls(c);
        }

        private async void btnArchive_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnArchive);
            UC_Archive arc = new UC_Archive();
            await addControls(arc);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            btnHome_Click(sender, e);
        }
    }
}
