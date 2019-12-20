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
using System.IO;

namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    public partial class Stock_Details : UserControl
    {

        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        private static Stock_Details _instance;

        public static Stock_Details Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stock_Details();
                return _instance;
            }
        }

        public Stock_Details()
        {
            InitializeComponent();
        }


        private void Close_Click(object sender, EventArgs e)
        {
            disp();
        }

        public void display()
        {
            DasStkView.RowHeadersVisible = false;
            DasStkView.AllowUserToAddRows = false;

            //displaying the inserted or manipulated data in a datagrid
            SqlCommand cmd6 = conn.CreateCommand();
            cmd6.CommandType = CommandType.Text;
            cmd6.CommandText = "Select * from Stock_Entry";
            cmd6.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd6);
            ds1.Fill(dt1);
            DasStkView.DataSource = dt1;
        }

        public void disp()
        {
            DasStkView.RowHeadersVisible = false;

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.Focus();
                errorProvider1.SetError(comboBox1, "Please Enter Product Name");
            }
            else
            {
                errorProvider1.SetError(comboBox1, null);
                //txtVenTelNo.Focus();
            
                //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails
                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
                cmd7.CommandText = "Select * from Stock_Entry where Product_name = '" + comboBox1.Text + "'";
                cmd7.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter ds2 = new SqlDataAdapter(cmd7);
                ds2.Fill(dt2);
                DasStkView.DataSource = dt2;

            }

            DasStkView.AllowUserToAddRows = false;
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

        private void Stock_Details_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            display();        

            fill_product_name();

            AutoComplete_Text1();
        }

        private void UpdtBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure to Modify this data", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int id = Convert.ToInt32(DasStkView.SelectedCells[0].Value.ToString());


                //Inserting the values in Stock_Entry database 
                SqlCommand cmd16 = conn.CreateCommand();
                cmd16.CommandText = "update Stock_Entry set Quantity = Quantity + '" + QtyNm.Text + "', [Model Name] = '" + ModNm.Text + "'where Product_name = '" + ProdNm.Text + "'";
                cmd16.CommandType = CommandType.Text;
                cmd16.ExecuteNonQuery();


                MessageBox.Show("Record Modified successfully..");

                display();
            }
        }

        private void DasStkView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DasStkView.SelectedCells[0].Value.ToString());

            //abstracting the corresponding values
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Stock_Entry where id =" + id + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {

                //passing the value of Item details datagrid to the corresponding textbox
                ProdNm.Text = dr2["Product_name"].ToString();
                ModNm.Text = dr2["Model Name"].ToString();
                QtyNm.Text = dr2["Quantity"].ToString();
            }
        }
    }
}
