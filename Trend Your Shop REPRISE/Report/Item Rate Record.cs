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
    public partial class Item_Rate_Record : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        String Query;

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

        public Item_Rate_Record()
        {
            InitializeComponent();
        }

        private void Item_Rate_Record_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for the certain date period of time
        
            int i = 0;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Item_Details where Date >= '" + dateTimePicker1.Value + "' and Date <= '" + dateTimePicker2.Value + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;


            foreach (DataRow dr in dt.Rows)
            {

                i = i + Convert.ToInt32(dr["Net Amount"].ToString());
            }
            Query1 = "select * from Item_Details where Date >= '" + dateTimePicker1.Value + "' and Date <= '" + dateTimePicker2.Value + "'";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Item_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            Query1 = "select * from Purchase_Details";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Item_And_Rate_Report prs = new Item_And_Rate_Report();
            prs.get_value(Query1.ToString());
            prs.Show();
        }
    }
}
