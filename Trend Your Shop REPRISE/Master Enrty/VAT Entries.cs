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
    public partial class VAT_Entries : UserControl
    {
        public VAT_Entries()
        {
            InitializeComponent();
        }

        //Sql connection address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        private static VAT_Entries _instance;

        public static VAT_Entries Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VAT_Entries();
                return _instance;
            }
        }

        private void VAT_Entries_Load(object sender, EventArgs e)
        {
            //Analyzing if the connection state is open or close
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            Loaddata();
            Group_details();
        }

        public void Group_details()
        {
            //displaying the product names in a combobox
            cmbGrpNam.Items.Clear();
            cmbSubGrpNam.Items.Clear();
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Item_Details";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr1 in dt3.Rows)
            {
                txtVatProdNm.Items.Add(dr1["Product_name"].ToString());
            }
        }

        private void txtVatProdNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displaying the corresponding product details like model name Group name etc from the datatable ProductDetails
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Item_Details where Product_name = '" + txtVatProdNm.Text + "' ";
            cmd2.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd2);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                txtVatProdModNm.Text = dr1["Model Name"].ToString();
                cmbGrpNam.Text = dr1["Group"].ToString();
                cmbSubGrpNam.Text = dr1["Sub Group"].ToString();
                txtVatPerc.Text = dr1["VAT"].ToString();
            }
        }

        public void Loaddata()
        {
            // Showing the data in a datagrid view 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *from VAT_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.AllowUserToAddRows = false;
        }

        private void VATmodfyBtn_Click(object sender, EventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column

            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            //Modifying the selected Row 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Update VAT_Details set product_name = '" + txtVatProdNm.Text + "', Model_name = '" + txtVatProdModNm.Text + "', [Group Name]= '" + cmbGrpNam.Text + "', [Sub Group Name]= '" + cmbSubGrpNam.Text + "', VAT = '" + txtVatPerc.Text + "' , StartDate ='" + dtStatVat.Text + "' , EndDate = '" + dtEndVat.Text + "' where id= " + id + "";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            Loaddata();
        }

        private void VATDelBtn_Click(object sender, EventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column

            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            //Modifying the selected Row 
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "delete from VAT_Details where id= " + id + "";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            Loaddata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from VAT_Details where id =" + id + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {
                //passing the value of group name and sub group name to the corresponding textbox
                txtVatProdNm.Text = dr2["Product_name"].ToString();
                txtVatProdModNm.Text = dr2["Model_name"].ToString();
                cmbGrpNam.Text = dr2["Group Name"].ToString();
                cmbSubGrpNam.Text = dr2["Sub Group Name"].ToString();
                txtVatPerc.Text = dr2["VAT"].ToString();
                dtStatVat.Text = dr2["StartDate"].ToString();
                dtEndVat.Text = dr2["EndDate"].ToString();
            }
        }

    }
}
