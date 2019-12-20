using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    public partial class View_Stock : UserControl
    {

        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");


        public View_Stock()
        {
            InitializeComponent();
        }

        private static View_Stock _instance;

        public static View_Stock Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new View_Stock();
                return _instance;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            disp();
        }

        public void disp()
        {
            ClientsDataGridView.RowHeadersVisible = false;
            if (comboBox1.Text == "")
            {
                SqlCommand cmd4 = conn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "Select * from Stock_Entry";
                cmd4.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ds1 = new SqlDataAdapter(cmd4);
                ds1.Fill(dt1);
                ClientsDataGridView.DataSource = dt1;
            }
            else
            {
                //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails
                SqlCommand cmd5 = conn.CreateCommand();
                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "Select * from Stock_Entry where Product_name = '" + comboBox1.Text + "'";
                cmd5.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter ds2 = new SqlDataAdapter(cmd5);
                ds2.Fill(dt2);
                ClientsDataGridView.DataSource = dt2;
            }


            ClientsDataGridView.AllowUserToAddRows = false;
        }

        public void fill_product_name()
        {
            //displaying the corresponding product details like product name and units from the datatable ProductDetails
            comboBox1.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Stock_Entry";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //viewing the abstracted data  product name in the corresponding textboxes
                comboBox1.Items.Add(dr1["Product_name"].ToString());
            }
        }

        void AutoComplete_Text1()
        {
            //
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

            comboBox1.AutoCompleteCustomSource = coll1;
            //conn.Close();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBox1.Text == "Product Name")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.White;
            }
        }

        private void View_Stock_Load(object sender, EventArgs e)
        {
            if (conn.State  == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            fill_product_name();
            AutoComplete_Text1();
        }
    }
}
