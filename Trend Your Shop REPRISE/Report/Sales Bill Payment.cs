using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using Trend_Your_Shop_REPRISE.Report;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Daily_Bill_Payment : Form
    {
        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public Daily_Bill_Payment()
        {
            InitializeComponent();
        }

        string Query;
        private void Daily_Bill_Payment_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void DailyBillPaytClsBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sales_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;



            Query = "select * from sales_details";
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sales_Details where Date = '"+DateTime.Now+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            

            Query = "select * from Sales_details where Date = '" + DateTime.Now + "'";


        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            Sale_Bill_Report sc = new Sale_Bill_Report();
            sc.get_value(Query.ToString());
            sc.Show();
        }
    }
}
