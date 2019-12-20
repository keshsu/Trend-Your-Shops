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
using Trend_Your_Shop_REPRISE.Report.Purchase_Report;
using Trend_Your_Shop_REPRISE.Report;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Purchase_Report : Form
    {

        String j;

        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");


        public void get_value(string i)
        {
            j = i;
        }

        public Purchase_Report()
        {
            InitializeComponent();
        }

        private void Purchase_Report_Load(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            //DataSet Name
            Purchase_report_Dataset ds = new Purchase_report_Dataset();

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
            PurchaseReport myreport = new PurchaseReport();
            myreport.SetDataSource(ds);
            crystalReportViewer1.ReportSource = myreport;


        }
    }
}
