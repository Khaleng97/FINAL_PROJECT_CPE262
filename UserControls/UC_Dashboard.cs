using ComponentFactory.Krypton.Toolkit;
using FINAL_PROJECT_CPE262.SMSDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_PROJECT_CPE262.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                tblStudentTableAdapter stud = new tblStudentTableAdapter();
                tblTeacherTableAdapter tea = new tblTeacherTableAdapter();
                ClassesTableAdapter classes = new ClassesTableAdapter();
                lblStud.Text = (stud.CountStudent().Value).ToString();
                lblTeacher.Text = (tea.CountTeacher().Value).ToString();
                lblClasses.Text = (classes.CountClass().Value).ToString();

                int male = stud.CountMale().Value;
                int female = stud.CountFemale().Value;
                StudentChart.Series["Student"].Points.Clear();

                StudentChart.Series["Student"].Points.AddXY("MALE STUDENTS", male);
                StudentChart.Series["Student"].Points.AddXY("FEMALE STUDENTS", female);
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SCHOOL MANAGEMENT SYSTEM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }
    }
}
