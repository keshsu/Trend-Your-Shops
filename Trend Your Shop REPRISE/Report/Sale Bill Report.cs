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
using Trend_Your_Shop_REPRISE.Report;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Sale_Bill_Report : Form
    {
        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");


        string j;
        //int tot = 0;


        public Sale_Bill_Report()
        {
            InitializeComponent();
        }


        public void get_value(String i)
        {
            j = i;
        }

        private void Sale_Bill_Report_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            SalesReportViewer sal = new SalesReportViewer();
            ///to do 
            crystalReportViewer1.ReportSource = sal;
        }
    }
}
