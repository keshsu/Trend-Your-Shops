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

namespace Trend_Your_Shop_REPRISE.Report
{
    public partial class Item_And_Rate_Report : Form
    {

        string j;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");
        
        public void get_value(string i)
        {
            j = i;
        }

        public Item_And_Rate_Report()
        {
            InitializeComponent();
        }

        private void Item_And_Rate_Report_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            //Data set Name 
            Item_Rate_Dataset ds = new Item_Rate_Dataset();

            //Executing the Query
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);
            da.Fill(dt);

            //Crystal report Name
            ItemDetailsReport myreport = new ItemDetailsReport();
            myreport.SetDataSource(ds);
            crystalReportViewer1.ReportSource = myreport;
        }
    }
}
