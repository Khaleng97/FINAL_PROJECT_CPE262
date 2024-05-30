using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FINAL_PROJECT_CPE262
{
    internal class ClassDB
    {
        private string AY;
        private string Quarter;
        private string QID;
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public string GetConnection()
        {
            string con = "Data Source=LAPTOP-6L2E5SDB\\SQLEXPRESS;Initial Catalog=SchoolManagementSystem;Integrated Security=True";
            return con;
        }

        public string GetQuarter()
        {
            cn = new SqlConnection();
            cn.ConnectionString = GetConnection();
            cn.Open();
            cm = new SqlCommand("SELECT *FROM Quarter WHERE STATUS LIKE 'OPEN'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                Quarter = dr["QUARTER"].ToString();
            }
            else
            {
                Quarter = "";
            }
            dr.Close();
            cn.Close();
            return Quarter;
        }

        public string GetQID()
        {
            cn = new SqlConnection();
            cn.ConnectionString = GetConnection();
            cn.Open();
            cm = new SqlCommand("SELECT *FROM Quarter WHERE STATUS LIKE 'OPEN'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                QID = dr["ID"].ToString();
            }
            else
            {
                QID = "";
            }
            dr.Close();
            cn.Close();
            return QID;
        }

        public string GetAY()
        {
            cn = new SqlConnection();
            cn.ConnectionString = GetConnection();
            cn.Open();
            cm = new SqlCommand("SELECT *FROM Quarter WHERE STATUS LIKE 'OPEN'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                AY = dr["YEAR_ID"].ToString();
            }
            else
            {
                AY = "";
            }
            dr.Close();
            cn.Close();
            return AY;
        }
    }
}
