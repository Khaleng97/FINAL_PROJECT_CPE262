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

namespace FINAL_PROJECT_CPE262
{
    public partial class AddScore : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        ClassDB db = new ClassDB();
        string title = "SCHOOL MANAGEMENT SYSTEM";
        UC_Score us;
        public int TID { get; set; }    
        private DateTime lastValidDate;
        public AddScore(UC_Score us, int TID)
        {
            InitializeComponent();
            cn = new SqlConnection(db.GetConnection());
            this.us = us;
            this.TID = TID;
            lblACTQID.Text = db.GetQID();
            closeTimer = new Timer();
            closeTimer.Interval = 1500;
            closeTimer.Tick += CloseTimer_Tick;
            LoadClassSubject();            
        }

        public void LoadClassSubject()
        {
            this.classSubjectTableAdapter.Fill(this.sMSDataSet.ClassSubject);

            try
            {
                cm = new SqlCommand("SELECT SubjectDetails.*, Subjects.NAME, Classes.Class_Name FROM SubjectDetails INNER JOIN Subjects ON SubjectDetails.SUB_ID = Subjects.ID INNER JOIN Classes ON SubjectDetails.CLASS_ID = Classes.ID", cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataView dv = new DataView(dt);
                dv.RowFilter = "TEA_ID = '" + TID.ToString() + "'";

                var distinctSubjects = dv.ToTable(true, "SUB_ID", "NAME").AsEnumerable()
                                         .Select(row => new
                                         {
                                             ID = row["SUB_ID"],
                                             Name = row["NAME"]
                                         }).Distinct().ToList();

                Dictionary<string, int> subjectIdMap = distinctSubjects.ToDictionary(x => x.Name.ToString(), x => Convert.ToInt32(x.ID));
                cbxSub.DataSource = null;
                cbxSub.Items.Clear();
                cbxSub.ValueMember = "ID";
                cbxSub.DisplayMember = "Name";
                cbxSub.DataSource = distinctSubjects;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            this.classSubjectTableAdapter1.Fill(this.sMSDataSet.ClassSubject);
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
            cbxType.SelectedIndex = -1;
            cbxType.Text = "";
            cbxClass.SelectedIndex = -1;
            cbxClass.Text = "";
            cbxSub.SelectedIndex = -1;
            cbxSub.Text = "";
            tbxName.Clear();
            tbxFullScore.Clear();
            dpDATE.Value = DateTime.Today;
            cbxMAPEHType.SelectedIndex = -1;
            cbxMAPEHType.Text = "";
        }
        private bool IsDuplicateQE(string Type, int ID)
        {
            ScoreTableAdapter sd = new ScoreTableAdapter();
            int count = (int)sd.CheckDuplicateQE(Type, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, int.Parse(lblACTQID.Text));
            if (ID > 0)
            {
                count--;
            }
            if (count > 0)
                return true;
            else
                return false;
        }

        private bool IsDuplicateScoreName(string Name, int ID)
        {
            ScoreTableAdapter sd = new ScoreTableAdapter();
            int count = (int)sd.CheckDuplicateScoreName(Name, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, int.Parse(lblACTQID.Text));
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
                if (cbxType.SelectedIndex == -1)
                {
                    sbT.Show(this.FindForm(), "SELECT SCORE TYPE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    cbxType.Focus();
                    return;
                }
                if (cbxSub.SelectedValue == null || cbxSub.SelectedIndex == -1 || cbxClass.SelectedValue == null || cbxClass.SelectedIndex == -1)
                {
                    if(cbxSub.SelectedValue == null || cbxSub.SelectedIndex == -1)
                    {
                        sbT.Show(this.FindForm(), "SELECT SUBJECT!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        cbxSub.Focus();
                    }
                    else if(cbxClass.SelectedValue == null || cbxClass.SelectedIndex == -1)
                    {
                        sbT.Show(this.FindForm(), "SELECT CLASS!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        cbxClass.Focus();
                    }
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(tbxName.Text) || string.IsNullOrWhiteSpace(tbxFullScore.Text))
                {
                    if(string.IsNullOrWhiteSpace(tbxName.Text))
                    {
                        sbT.Show(this.FindForm(), "SCORE NAME IS REQUIRED AS INDICATOR!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        tbxName.Focus();
                    }
                    else if(string.IsNullOrWhiteSpace(tbxFullScore.Text))
                    {
                        sbT.Show(this.FindForm(), "HIGHEST POSSIBLE SCORE IS REQUIRED!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        tbxFullScore.Focus();
                    }
                    return;
                }

                if(cbxMAPEHType.Enabled == true)
                {
                    if (cbxMAPEHType.SelectedIndex == -1)
                    {
                        sbT.Show(this.FindForm(), "SELECT MAPEH TYPE!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                        cbxMAPEHType.Focus();
                        return;
                    }
                }

                if (IsDuplicateScoreName(tbxName.Text, 0))
                {
                    sbT.Show(this.FindForm(), "SCORE NAME ALREADY EXIST! CREATE NEW NAME", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (IsDuplicateQE(cbxType.Text, 0))
                {
                    sbT.Show(this.FindForm(), "ONE QUARTERLY EXAM ONLY FOR EACH QUARTER!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (KryptonMessageBox.Show("SAVE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ScoreTableAdapter st = new ScoreTableAdapter();
                    int row = st.InsertQuery(cbxType.Text, tbxName.Text, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, int.Parse(lblACTQID.Text), cbxMAPEHType.Text, dpDATE.Value, int.Parse(tbxFullScore.Text));
                    if(row > 0 )
                    {
                        sbT.Show(this.FindForm(), "ADDED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                        
                    }
                    Clear();
                    us.btnLoadScore_Click(this, new EventArgs());
                    closeTimer.Start();
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
      
        private void AddStudent_Load(object sender, EventArgs e)
        {
            cbxMAPEHType.Enabled = false;
            if (cbxSub.SelectedValue != null)
            {
                classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "' AND SUB_ID = '" + cbxSub.SelectedValue.ToString() + "'";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {            
                if(IsDuplicateScoreName(tbxName.Text, int.Parse(lblID.Text)))
                {
                    sbT.Show(this.FindForm(), "SCORE NAME ALREADY EXIST! CREATE NEW NAME", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }

                if (IsDuplicateQE(cbxType.Text, int.Parse(lblID.Text)))
                {
                    sbT.Show(this.FindForm(), "SCORE NAME ALREADY EXIST! CREATE NEW NAME", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning);
                    return;
                }
                if (KryptonMessageBox.Show("UPDATE RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ScoreTableAdapter st = new ScoreTableAdapter();
                    int row = st.UpdateQuery(cbxType.Text, tbxName.Text, (int)cbxSub.SelectedValue, (int)cbxClass.SelectedValue, int.Parse(lblACTQID.Text), cbxMAPEHType.Text, dpDATE.Value, int.Parse(tbxFullScore.Text), int.Parse(lblID.Text));
                    if (row > 0)
                    {
                        sbT.Show(this.FindForm(), "UPDATED SUCCESSFULLY!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);

                    }
                    us.btnLoadScore_Click(this, new EventArgs());                  
                    closeTimer.Start();
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

        private void tbxFullScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void cbxSub_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cbxSub.SelectedValue != null)
            {
                if (int.TryParse(cbxSub.SelectedValue.ToString(), out int selectedValue))
                {
                    if (selectedValue == 8)
                    {
                        cbxMAPEHType.Enabled = true;
                    }
                    else
                    {
                        cbxMAPEHType.Enabled = false;
                    }
                    classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "' AND SUB_ID = '" + selectedValue.ToString() + "'";
                }
                else
                {
                    MessageBox.Show("Invalid selected value.");
                }
            }
            else
            {
                cbxMAPEHType.Enabled = false;
                classSubjectBindingSource1.Filter = "TEA_ID = '" + TID.ToString() + "'"; 
            }
        }

        private void dpDATE_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dpDATE.Value;

            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Weekends are not allowed. Please select a weekday.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dpDATE.Value = lastValidDate;
            }
            else
            {
                lastValidDate = selectedDate;
            }
        }
    }
}
