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

namespace Trend_Your_Shop_REPRISE
{
    public partial class Purchase_Records : Form
    {

        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public Purchase_Records()
        {
            InitializeComponent();
        }

        private void Purchase_Records_Load(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        private void SrchBtn_Click(object sender, EventArgs e)
        {
            int i = 0;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Purchase_Details where Bill_Date >= '" +dateTimePicker1.Value + "' and Bill_Date <= '" +dateTimePicker2.Value+ "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;


            foreach (DataRow dr in dt.Rows)
            {

                i = i + Convert.ToInt32(dr["Net Amount"].ToString());
            }
            Query1 = "select * from Purchase_Details where Bill_Date >= '" + dateTimePicker1.Value + "' and Bill_Date <= '" + dateTimePicker2.Value + "'";
        
           }


        private void AllDta_Click(object sender, EventArgs e)
        {
            Decimal i = 0;
            Decimal j = 0;
            Decimal k = 0;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Purchase_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;
            

            foreach (DataRow dr in dt.Rows)
            {
                i = i + Convert.ToDecimal(dr["Net Amount"].ToString());
                j = j + Convert.ToDecimal(Convert.ToInt32(dr["VAT"].ToString()) * Convert.ToInt32(dr["Quantity"].ToString()) * Convert.ToInt32(dr["Purchase_Rate"].ToString()) / 100);
                k = k + Convert.ToDecimal(Convert.ToInt32(dr["Discount"].ToString()) * Convert.ToInt32(dr["Quantity"].ToString()) * Convert.ToInt32(dr["Purchase_Rate"].ToString()) / 100);
            }

            label5.Text = i.ToString();
            label6.Text = k.ToString();
            label8.Text = j.ToString();

            Query1 = "select * from Purchase_Details";
        }

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

        private void print_Click(object sender, EventArgs e)
        {
            Purchase_Report prs = new Purchase_Report();
            prs.get_value(Query1.ToString());
            prs.ShowDialog();
        }
    }
}
