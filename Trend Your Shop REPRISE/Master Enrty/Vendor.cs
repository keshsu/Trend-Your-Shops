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
    public partial class Vendor : UserControl
    {
        public Vendor()
        {
            InitializeComponent();
        }

        //Sql connection address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        private static Vendor _instance;

        public static Vendor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Vendor();
                return _instance;
            }
        }

        private void Loaddata()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Vendor_Details ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void Vendor_Load(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            Loaddata();
            //emailValidation();
            AutoComplete_Text();
        }

        private void SvVendorBtn_Click(object sender, EventArgs e)
        {
            if (txtVenName.Text == "" && txtVenPanNo.Text == "" && txtVenCntPers.Text == "")
            {
                MessageBox.Show("Empty vendor Information");
            }
            else
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Vendor_Details([PAN NO],Telephone,[Mobile 1],[Vendor Name],[E-mail],Website,[Contact Person],Street,City,State,District,[PIN Code],[Bank 1],[Ac No 1],Details) values ('" + txtVenPanNo.Text + "','" + txtVenTelNo.Text + "','" + txtVenMobNo1.Text + "','" + txtVenName.Text + "','" + txtVenEmail.Text + "','" + txtVenWEB.Text + "','" + txtVenCntPers.Text + "','" + txtVenStreet.Text + "','" + txtVenCity.Text + "','" + txtVenState.Text + "','" + txtVendistrict.Text + "','" + txtVenPincode.Text + "','" + txtVenBankName1.Text + "','" + txtVenBankAc1.Text + "','" + txtVenDetails.Text + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

            //making the textboxes empty after you save the data
            txtVenBankAc1.Text = ""; txtVenBankName1.Text = "";
            txtVenCity.Text = ""; txtVenCntPers.Text = ""; txtVenDetails.Text = ""; txtVendistrict.Text = "";
            txtVenEmail.Text = ""; txtVenMobNo1.Text = ""; txtVenName.Text = "";
            txtVenPanNo.Text = ""; txtVenPincode.Text = ""; txtVenState.Text = ""; txtVenStreet.Text = ""; txtVenTelNo.Text = "";
            txtVenWEB.Text = "";


            Loaddata();
        }

        private void MdVendorBtn_Click(object sender, EventArgs e)
        {

            //Modification of the vendor details
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update Vendor_Details set Telephone = '" + txtVenTelNo.Text + "', [Mobile 1] = '" + txtVenMobNo1.Text + "', [Vendor Name] = '" + txtVenName.Text + "', [E-mail] = '" + txtVenEmail.Text + "', Website = '" + txtVenWEB.Text + "', [Contact Person] = '" + txtVenCntPers.Text + "', Street = '" + txtVenStreet.Text + "', City = '" + txtVenCity.Text + "', State = '" + txtVenState.Text + "', District = '" + txtVendistrict.Text + "', [PIN Code] = '" + txtVenPincode.Text + "', [Bank 1] = '" + txtVenBankName1.Text + "', [Ac No 1] = '" + txtVenBankAc1.Text + "',  Details ='" + txtVenDetails.Text + "' where [PAN NO] = '" + txtVenPanNo.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            //making the textboxes empty after the modification
            txtVenBankAc1.Text = ""; txtVenBankName1.Text = "";
            txtVenCity.Text = ""; txtVenCntPers.Text = ""; txtVenDetails.Text = ""; txtVendistrict.Text = "";
            txtVenEmail.Text = ""; txtVenMobNo1.Text = ""; txtVenName.Text = "";
            txtVenPanNo.Text = ""; txtVenPincode.Text = ""; txtVenState.Text = ""; txtVenStreet.Text = ""; txtVenTelNo.Text = "";
            txtVenWEB.Text = "";


            Loaddata();
        }

        private void DelVendorBtn_Click(object sender, EventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(dataGridView2.SelectedCells[0].Value.ToString());


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Delete from Vendor_Details where id = " + id + "";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            //making the textboxes empty after the delete operation
            txtVenBankAc1.Text = ""; txtVenBankName1.Text = "";
            txtVenCity.Text = ""; txtVenCntPers.Text = ""; txtVenDetails.Text = ""; txtVendistrict.Text = "";
            txtVenEmail.Text = ""; txtVenMobNo1.Text = ""; txtVenName.Text = "";
            txtVenPanNo.Text = ""; txtVenPincode.Text = ""; txtVenState.Text = ""; txtVenStreet.Text = ""; txtVenTelNo.Text = "";
            txtVenWEB.Text = "";


            Loaddata();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column
            int i = Convert.ToInt32(dataGridView2.SelectedCells[0].Value.ToString());


            //showing the data in the textbox from the datagrid view
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Vendor_Details where id =" + i + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {
                //abstraction in a click
                txtVenPanNo.Text = dr2["PAN NO"].ToString();
                txtVenTelNo.Text = dr2["Telephone"].ToString();
                txtVenMobNo1.Text = dr2["Mobile 1"].ToString();
                txtVenName.Text = dr2["Vendor Name"].ToString();
                txtVenEmail.Text = dr2["E-mail"].ToString();
                txtVenWEB.Text = dr2["Website"].ToString();
                txtVenCntPers.Text = dr2["Contact Person"].ToString();
                txtVenStreet.Text = dr2["Street"].ToString();
                txtVenCity.Text = dr2["City"].ToString();   //////////////
                txtVenState.Text = dr2["State"].ToString();
                txtVendistrict.Text = dr2["District"].ToString();
                txtVenPincode.Text = dr2["PIN Code"].ToString();
                txtVenBankName1.Text = dr2["Bank 1"].ToString();
                txtVenBankAc1.Text = dr2["Ac No 1"].ToString();
                txtVenDetails.Text = dr2["Details"].ToString();
            }
        }

        private void Clearall_Click(object sender, EventArgs e)
        {
            //making the textboxes empty after the delete operation
            txtVenBankAc1.Text = ""; txtVenBankName1.Text = "";
            txtVenCity.Text = ""; txtVenCntPers.Text = ""; txtVenDetails.Text = ""; txtVendistrict.Text = "";
            txtVenEmail.ForeColor = Color.LightGray;
            txtVenEmail.Text = "Something@example.com"; txtVenMobNo1.Text = ""; txtVenName.Text = "";
            txtVenPanNo.Text = ""; txtVenPincode.Text = ""; txtVenState.Text = ""; txtVenStreet.Text = ""; txtVenTelNo.Text = "";
            txtVenWEB.ForeColor = Color.LightGray;
            txtVenWEB.Text = "www.Something.com";
        }

        private void txtVenTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtVenMobNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtVenPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtVenPanNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVenPanNo.Text))
            {
                txtVenPanNo.Focus();
                errorProvider1.SetError(txtVenPanNo, "Please Enter pan no");
            }
            else
            {
                errorProvider1.SetError(txtVenPanNo, null);
                //txtVenTelNo.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //conn.Open();
            SqlCommand cmd14 = conn.CreateCommand();
            cmd14.CommandType = CommandType.Text;
            cmd14.CommandText = "select * from vendor_details where [Vendor Name]= '" + textBox1.Text + "'";
            cmd14.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd14);
            ds14.Fill(dt14);
            dataGridView2.DataSource = dt14;
        }

        void AutoComplete_Text()
        {
            //
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll1 = new AutoCompleteStringCollection();

            //conn.Open();
            SqlCommand cmd14 = conn.CreateCommand();
            cmd14.CommandType = CommandType.Text;
            cmd14.CommandText = "select * from Vendor_Details ";
            cmd14.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd14);
            ds14.Fill(dt14);
            foreach (DataRow dr14 in dt14.Rows)
            {
                string nams1 = dr14["Vendor Name"].ToString(); //taking all database venname colun values and adding them as an item
                coll1.Add(nams1);

            }

            textBox1.AutoCompleteCustomSource = coll1;

            //conn.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Vendor_Details ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ds = new SqlDataAdapter(cmd);
                ds.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            else
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Vendor_Details where [Vendor Name] = '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ds = new SqlDataAdapter(cmd);
                ds.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }


        private void txtVenEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtVenEmail.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txtVenEmail.Text))
                {
                    MessageBox.Show("invalid Email Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVenEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }


        private void txtVenEmail_Enter(object sender, EventArgs e)
        {
            if (txtVenEmail.Text == "Something@gmail.com")
            {
                txtVenEmail.Text = "";
                txtVenEmail.ForeColor = Color.Black;
            }
        }

        private void txtVenWEB_Enter(object sender, EventArgs e)
        {
            if (txtVenWEB.Text == "www.Something.com")
            {
                txtVenWEB.Text = "";
                txtVenWEB.ForeColor = Color.Black;
            }
        }


        private void txtVenEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtVenWEB_Click(object sender, EventArgs e)
        {

        }

        private void txtVenEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtVenEmail.Text == "Something@gmail.com")
            {
                txtVenEmail.Text = "";
                txtVenEmail.ForeColor = Color.Black;
            }
        }

        private void txtVenWEB_TextChanged(object sender, EventArgs e)
        {
            if (txtVenWEB.Text == "www.Something.com")
            {
                txtVenWEB.Text = "";
                txtVenWEB.ForeColor = Color.Black;
            }
        }

        private void txtVenBankName1_TextChanged(object sender, EventArgs e)
        {
            if (txtVenBankName1.Text == "Something.Pvt.ltd")
            {
                txtVenBankName1.Text = "";
                txtVenBankName1.ForeColor = Color.Black;
            }
        }

        private void txtVenBankName1_Enter(object sender, EventArgs e)
        {
            if (txtVenWEB.Text == "Something.Pvt.ltd")
            {
                txtVenWEB.Text = "";
                txtVenWEB.ForeColor = Color.Black;
            }
        }
    }
}
