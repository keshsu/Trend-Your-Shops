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
    public partial class Stock_Report : Form
    {
        string Query;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");


        public Stock_Report()
        {
            InitializeComponent();
        }

        public void fill_product_name()
        {
            //displaying the corresponding product details like product name and units from the datatable ProductDetails
            combProductname.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Stock_Entry";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                combProductname.Items.Add(dr1["Product_name"].ToString());
            }
        }
        void AutoComplete_Text1()
        {
            //
            combProductname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combProductname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll1 = new AutoCompleteStringCollection();

            //conn.Open();
            SqlCommand cmd14 = conn.CreateCommand();
            cmd14.CommandType = CommandType.Text;
            cmd14.CommandText = "select * from Stock_Entry ";
            cmd14.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd14);
            ds14.Fill(dt14);
            foreach (DataRow dr14 in dt14.Rows)
            {
                string nams1 = dr14["Product_name"].ToString(); //taking all database venname colun values and adding them as an item
                coll1.Add(nams1);
            }

            combProductname.AutoCompleteCustomSource = coll1;


            //conn.Close();
        }

        private void Stock_Report_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            fill_product_name();
            AutoComplete_Text1();
        }

        private void StockRepBtn_Click(object sender, EventArgs e)
        {
            StockprintBtn.Enabled = true;
            int i = 0;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stock_Entry where Product_name ='" + combProductname.Text + "'and Date >= '" + dateTimePicker1.Value + "' and Date <= '" + dateTimePicker2.Value + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {

                i = i + Convert.ToInt32(dr["Quantity"].ToString());
            }

            Query = "select * from Stock_Entry where Product_name ='" + combProductname.Text + "'and Date >= '" + dateTimePicker1.Value + "' and Date <= '" + dateTimePicker2.Value + "'";
            label4.Text = i.ToString();
        }

        private void StockAllRepBtn_Click(object sender, EventArgs e)
        {
            StockprintBtn.Enabled = true;
            int i = 0;

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stock_Entry";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {

                i = i + Convert.ToInt32(dr["Quantity"].ToString());
            }

            label4.Text = i.ToString();

            Query = "select * from Stock_Entry";
        }

        private void StockprintBtn_Click(object sender, EventArgs e)
        {
            Stock_Report_Viewer sa = new Stock_Report_Viewer();
            sa.get_value(Query.ToString());
            sa.Show();
        }

        private void combProductname_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *from Stock_entry where Product_name like '" + combProductname.Text + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_name like '{0}%'", combProductname.Text);
        }
    }
}
