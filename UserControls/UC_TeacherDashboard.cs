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
    public partial class UC_TeacherDashboard : UserControl
    {
        public int TID { get; set; }
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB db = new ClassDB();
        public string ClassID;
        public UC_TeacherDashboard(int TID)
        {
            InitializeComponent();
            this.TID = TID;
            cn = new SqlConnection(db.GetConnection());
        }

        public string GetAdvisoryClass()
        {
            try
            {
                string name = "";
                cn.Open();
                cm = new SqlCommand("SELECT Class_Name FROM Classes WHERE TEA_ID = @classID", cn);
                cm.Parameters.AddWithValue("@classID", TID);
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

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                tblStudentTableAdapter stud = new tblStudentTableAdapter();
                tblTeacherTableAdapter tea = new tblTeacherTableAdapter();
                ClassesTableAdapter classes = new ClassesTableAdapter();
                SubjectDetailsTableAdapter sd = new SubjectDetailsTableAdapter();
                lblStud.Text = (sd.CountSubHandled(TID).Value).ToString();
                lblClasses.Text = GetAdvisoryClass();
                FillDataGridView();
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private DataTable GetSubjectsHandledData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT DISTINCT Subjects.NAME, Classes.Class_Name FROM SubjectDetails INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID WHERE SubjectDetails.TEA_ID = @tid ORDER BY [NAME] ASC";

            using (SqlConnection cn = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cm.Parameters.AddWithValue("@tid", TID);

                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cm);
                        cn.Open();
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return dataTable;
        }

        private void FillDataGridView()
        {
            try
            {
                DataTable dataTable = GetSubjectsHandledData();

                if (dataTable != null)
                {
                    dgvSubHandled.DataSource = dataTable;

                    dgvSubHandled.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    dgvSubHandled.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        
    }
}
