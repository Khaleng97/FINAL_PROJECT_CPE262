using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_StudentDashboard : UserControl
    {
        public int SID { get; set; }
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public string ClassID;
        public UC_StudentDashboard(int SID)
        {
            InitializeComponent();
            this.SID = SID;
            cn = new SqlConnection(db.GetConnection());
        }

        public string GetClassName()
        {
            try
            {
                int classID = int.Parse(GetClassID());
                string name = "";
                cn.Open();
                cm = new SqlCommand("SELECT Class_Name FROM Classes WHERE ID = @classID", cn);
                cm.Parameters.AddWithValue("@classID", classID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    name = dr["Class_Name"].ToString();
                }
                else
                {
                    name = "";
                }
                dr.Close();
                cn.Close();
                return name;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }
        public string GetClassID()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT CLASS_ID FROM tblStudent WHERE ID = @id", cn);
                cm.Parameters.AddWithValue("@id", SID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    ClassID = dr["CLASS_ID"].ToString();
                }
                else
                {
                    ClassID = "";
                }
                dr.Close();
                cn.Close();
                return ClassID;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        public string GetAdviser()
        {
            try
            {
                int classID = int.Parse(GetClassID());
                string name = "";
                cn.Open();
                cm = new SqlCommand("SELECT Classes.TEA_ID, Classes.ID, tblTeacher.FULLNAME FROM Classes INNER JOIN tblTeacher ON Classes.TEA_ID = tblTeacher.ID WHERE Classes.ID = @classID", cn);
                cm.Parameters.AddWithValue("@classID", classID);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    name = dr["FULLNAME"].ToString();
                }
                else
                {
                    name = "";
                }
                dr.Close();
                cn.Close();
                return name;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                int classID = int.Parse(GetClassID());
                tblStudentTableAdapter stud = new tblStudentTableAdapter();
                tblTeacherTableAdapter tea = new tblTeacherTableAdapter();
                ClassesTableAdapter classes = new ClassesTableAdapter();
                SubjectDetailsTableAdapter sd = new SubjectDetailsTableAdapter();
                lblStud.Text = (sd.CountStudSubjects(classID).Value).ToString();


                LoadStudAttChart();
                LoadStudScoreChart();
                lblTeacher.Text = GetAdviser();
                lblClasses.Text = GetClassName();

            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        public void LoadStudScoreChart()
        {
            try
            {
                ScoreDetailsTableAdapter s = new ScoreDetailsTableAdapter();

                string pass = s.CountStudScore(SID, "PASSED").ToString();
                string fail = s.CountStudScore(SID, "FAILED").ToString();

                ScoreChart.Series["Score"].Points.Clear();
                int P = 0;
                int F = 0;

                if (!int.TryParse(pass, out P))
                {
                    P = 0; 
                }

                if (!int.TryParse(fail, out F))
                {
                    F = 0; 
                }
                ScoreChart.Series["Score"].Points.AddXY("Passed", P);
                ScoreChart.Series["Score"].Points.AddXY("Failed", F);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadStudAttChart()
        {
            try
            {
                AttendanceTableAdapter att = new AttendanceTableAdapter();

                string pres = att.CountStudStat(SID, "Present").ToString();
                string ab = att.CountStudStat(SID, "Absent").ToString();
                string la = att.CountStudStat(SID, "Late").ToString();
                string ex = att.CountStudStat(SID, "Excused").ToString();
                AttendanceChart.Series["Attendance"].Points.Clear();
                int P = 0;
                int L = 0;
                int A = 0;
                int E = 0;

                if (!int.TryParse(pres, out P))
                {
                   P = 0; 
                }

                if (!int.TryParse(ab, out A))
                {
                    A = 0; 
                }

                if (!int.TryParse(la, out L))
                {
                    L = 0; 
                }

                if (!int.TryParse(ex, out E))
                {
                    E = 0; 
                }
                AttendanceChart.Series["Attendance"].Points.AddXY("Present", P);
                AttendanceChart.Series["Attendance"].Points.AddXY("Absent", A);
                AttendanceChart.Series["Attendance"].Points.AddXY("Late", L);
                AttendanceChart.Series["Attendance"].Points.AddXY("Excused", E);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
