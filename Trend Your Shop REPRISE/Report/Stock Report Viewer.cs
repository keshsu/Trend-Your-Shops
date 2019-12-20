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
    public partial class Stock_Report_Viewer : Form
    {
        string j;

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public void get_value(string i)
        {
            j = i;
        }

        public Stock_Report_Viewer()
        {
            InitializeComponent();
        }

        private void Stock_Report_Viewer_Load(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();


            //DataSet Name
            StockDetailDataset ds = new StockDetailDataset();

            //Executing the Query
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = j;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);
            da.Fill(dt);

            //Crstal report Name Where you want to show your Purchase Details
            Stock_Report_List myreport = new Stock_Report_List();
            myreport.SetDataSource(ds);
            crystalReportViewer1.ReportSource = myreport;

        }
    }
}
