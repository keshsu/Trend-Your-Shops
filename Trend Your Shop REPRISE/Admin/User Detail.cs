using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Trend_Your_Shop_REPRISE.Report.Login_User_Report;

namespace Trend_Your_Shop_REPRISE
{
    public partial class User_Detail : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public User_Detail()
        {
            InitializeComponent();
        }

        private void UserViewbtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");
            conn.Open();

            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from loginTable where [Username]='" + txtFullName.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "insert into loginTable ([Username],Password,Email,Contact,StartTime,EndTime) values ('" + txtFullName.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','" + txtcontactNo.Text + "','" + txtstarttime.Text + "','" + txtendtime.Text + "')";
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();

                MessageBox.Show("User Record Inserted Successfully!!");
                conn.Close();
            }
            else
            {
                MessageBox.Show("Username already exists!!");
            }
            Query1 = "Select * from loginTable";
        }

        private void User_Detail_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        string Query;

        public string Query1
        {
            get
            {
                return Query;
            }

            set
            {
                Query = value;
            }
        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            Login_User_Report prs = new Login_User_Report();
            prs.get_value(Query1.ToString());
            prs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
