using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    public partial class Sales_Details : UserControl
    {
        private static Sales_Details _instance;

        public static Sales_Details Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Sales_Details();
                return _instance;
            }
        }

        public Sales_Details()
        {
            InitializeComponent();
        }


        private void Sales_Details_Load(object sender, EventArgs e)
        {

            //checking the connection state is open or not
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            //calling display function
            display();
            //calling the customer detailed function 
            fill_Customer();
            AutoComplete_Text();
            //calling the product detailed function
            fill_product_name();
            AutoComplete_Text1();

            //clearing the datagrid temporary table
            dt.Clear();

            //creating a temporary columns that is going to displayed in the global declared datatable
            dt.Columns.Add("S.N.");
            dt.Columns.Add("Group");
            dt.Columns.Add("Sub Group");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Model Name");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Rate");
            dt.Columns.Add("VAT/Unit");
            dt.Columns.Add("Disc/Unit.");
            dt.Columns.Add("Sales_Type");
            dt.Columns.Add("Waranttee");
            dt.Columns.Add("Total Amount");
        }

        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        //creating a temporary table
        DataTable dt = new DataTable();

        float tot = 0;
        float vtot = 0;
        float dtot = 0;

        string Query;

        public void display()
        {
            //displaying the inserted or manipulated data in a datagrid
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Sales_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        public void multiply()
        {

            //Fuction that for the calculation of the sub total values
            int b;
            float a, c, d;

            float NomAmt1, NomAmt2, NomAmt3, NomAmt, NomAmt4, NomAmt5;

            bool isAValid = float.TryParse(txtPERQty.Text, out a);
            bool isBValid = int.TryParse(txtSalratePERQty.Text, out b);
            bool isCValid = float.TryParse(txtPERVat.Text, out c);
            bool isDValid = float.TryParse(txtPERDisc.Text, out d);
            if (isAValid && isCValid && isDValid)
            {
                NomAmt = a * b;
                NomAmt1 = b * c / 100;
                NomAmt2 = a * NomAmt1;
                NomAmt3 = b * d / 100;
                NomAmt4 = a * NomAmt3;
                NomAmt5 = NomAmt + NomAmt2 - NomAmt4;
                txtPERAmt.Text = (NomAmt5).ToString();
            }
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
                //viewing the abstracted data  product name in the corresponding textboxes
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
            cmd14.CommandText = "select * from Item_Details ";
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

            Itmdetviewbtn.Enabled = true;

            //conn.Close();
        }

        private void combProductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displaying the corresponding product details like related to the product name and units from the datatable Item Details
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Item_Details where Product_name = '" + combProductname.Text + "' ";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds2 = new SqlDataAdapter(cmd2);
            ds2.Fill(dt2);
            foreach (DataRow dr1 in dt2.Rows)
            {
                txtSalratePERQty.Text = dr1["Rate"].ToString();
                txtPERVat.Text = dr1["VAT"].ToString();
            }

            //displaying the corresponding product name Quantity from the datatable Stock Entry
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Stock_Entry where Product_name = '" + combProductname.Text + "' ";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr3 in dt3.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                txtPERQty.Text = dr3["Quantity"].ToString();
            }
        }


        //displaying the customer information
        public void fill_Customer()
        {
            //clearing the substances in customer name combobox
            txtSalrepCustomernm.Items.Clear();

            //displaying the Customer names in a combobox
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Order_User";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                txtSalrepCustomernm.Items.Add(dr1["Customer"].ToString());
            }
        }

        void AutoComplete_Text()
        {
            //
            txtSalrepCustomernm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSalrepCustomernm.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll1 = new AutoCompleteStringCollection();

            //conn.Open();
            SqlCommand cmd14 = conn.CreateCommand();
            cmd14.CommandType = CommandType.Text;
            cmd14.CommandText = "select * from Order_User ";
            cmd14.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd14);
            ds14.Fill(dt14);
            foreach (DataRow dr14 in dt14.Rows)
            {
                string nams1 = dr14["Customer"].ToString(); //taking all database venname colun values and adding them as an item
                coll1.Add(nams1);
            }

            txtSalrepCustomernm.AutoCompleteCustomSource = coll1;

            Cusdetviewbtn.Enabled = true;

            //conn.Close();
        }


        private void DeleteColumns()
        {
            //Removing the selected cells
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridView1.CurrentCell.RowIndex.ToString()));

                //this loop is making a new calculation after any row is deleted 
                foreach (DataRow dr in dt.Rows)
                {
                    //calculating the new amounts
                    tot = tot + Convert.ToInt32(dr["Total Amount"].ToString());
                    vtot = vtot + Convert.ToInt32(dr["VAT/Unit"].ToString()) * Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["Rate"]) / 100;
                    dtot = dtot + Convert.ToInt32(dr["Disc/Unit."].ToString()) * Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["Rate"]) / 100;
                    //displaying them in below fields
                    txtTotalVATAmt.Text = Convert.ToString(vtot);
                    txtTotalDiscAmt.Text = Convert.ToString(dtot);
                    txtTotalAmt.Text = Convert.ToString(tot);
                }
            }
            catch
            {

            }

            //making save button disable when there is no datarow in a datagridview
            if (dataGridView1.Rows.Count == 1)
            {
                SalrepSaveNUpdateBtn.Enabled = false;
            }
        }


        //Adding the multiple Data items that are going to be sold
        private void SalrepAddBtn_Click(object sender, EventArgs e)
        {
            //when we add a new data now we can sell them by enabling the save button
            SalrepSaveNUpdateBtn.Enabled = true;

            //creating the variable to check if the stock is available or not
            int stock = 0;

            //getting the stock information in a database we created as stock_Entry
            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "Select * from Stock_Entry where Product_name = '" + combProductname.Text + "'";
            cmd4.ExecuteNonQuery();
            DataTable dt4 = new DataTable();
            SqlDataAdapter ds4 = new SqlDataAdapter(cmd4);
            ds4.Fill(dt4);

            foreach (DataRow dr4 in dt4.Rows)
            {
                //abstracting data quantity from the database and Initializing the value of remaining quantity  as variable "stock"
                stock = Convert.ToInt32(dr4["Quantity"].ToString());
            }

            //checking if the value of stock is greater than the user input quantity to be sold 
            if (Convert.ToInt32(txtPERQty.Text) > stock)
            {
                //if true showing the messagebox
                MessageBox.Show("This value of Quantity is not available..");
            }

            else
            {
                //Inserting the values in the globally declared or created datatable 

                //creating a Row 
                DataRow dr = dt.NewRow();
                //making a variable to count the no of rows
                int count = 1;

                //making the columns that contains the corresponding data values
                dr["S.N."] = count;
                dr["Product Name"] = combProductname.Text;
                dr["Quantity"] = txtPERQty.Text;
                dr["Rate"] = txtSalratePERQty.Text;
                dr["VAT/Unit"] = txtPERVat.Text;
                dr["Disc/Unit."] = txtPERDisc.Text;
                dr["Total Amount"] = txtPERAmt.Text;

                //Adding them as a row
                dt.Rows.Add(dr);
                //Showing them in a datagridview
                dataGridView1.DataSource = dt;
                //increasing the count of row
                count = count + 1;

                //calcluating the amount we added in a datatable 
                tot = tot + Convert.ToInt32(dr["Total Amount"].ToString());
                vtot = vtot + Convert.ToInt32(dr["VAT/Unit"].ToString()) * Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["Rate"]) / 100;
                dtot = dtot + Convert.ToInt32(dr["Disc/Unit."].ToString()) * Convert.ToInt32(dr["Quantity"]) * Convert.ToInt32(dr["Rate"]) / 100;

                //showing them in their fields
                txtTotalVATAmt.Text = Convert.ToString(vtot);
                txtTotalDiscAmt.Text = Convert.ToString(dtot);
                txtTotalAmt.Text = Convert.ToString(tot);
            }



            //Clearing all the substances of the textboxs
            combProductname.Text = "";
            txtSalratePERQty.Text = "0"; txtPERQty.Text = "0";
            txtPERAmt.Text = "0"; txtPERVat.Text = "0"; txtPERDisc.Text = "0";

        }


        //deleting the selected column
        private void SalrepDelBtn_Click(object sender, EventArgs e)
        {
            DeleteColumns();
        }

        //creating the leave event to calculate the total of vat ,discount and the net total

        private void txtSalratePERQty_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalratePERQty.Text))
            {
                txtSalratePERQty.Focus();
                errorProvider1.SetError(txtSalratePERQty, "Customer Name Field is Empty");
            }
            else
            {
                errorProvider1.SetError(txtSalratePERQty, null);
                //txtVenTelNo.Focus();
            }
            multiply();
        }

        private void txtPERQty_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPERQty.Text))
            {
                txtPERQty.Focus();
                errorProvider1.SetError(txtPERQty, "Customer Name Field is Empty");
            }
            else
            {
                errorProvider1.SetError(txtPERQty, null);
                //txtVenTelNo.Focus();
            }
            multiply();
        }

        private void txtPERVat_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtPERVat.Text))
            //{
            //    txtPERVat.Focus();
            //    errorProvider1.SetError(txtPERVat, "Customer Name Field is Empty");
            //}
            //else
            //{
            //    errorProvider1.SetError(txtPERVat, null);
            //    //txtVenTelNo.Focus();
            //}
            multiply();
        }

        private void txtPERDisc_Leave(object sender, EventArgs e)
        {
            multiply();
        }


        //saving the corresponding sold data we inserted in the fields and Generating a bill
        private void SalrepSaveNUpdateBtn_Click(object sender, EventArgs e)
        {
            if (txtSalrepCustomernm.Text == "" && combProductname.Text == "" && txtSalratePERQty.Text == "" && txtPERQty.Text == "")
            {
                MessageBox.Show("Sales Details not Valid");
            }
            else
            {
                //asking before we save it
                if (MessageBox.Show("Do you want to Save this data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //creating a string variable to make the ID of a customer
                    string orderid = "";


                    //Selecting the ID field of the OrderUser where we set a id of customer
                    SqlCommand cmd8 = conn.CreateCommand();
                    cmd8.CommandType = CommandType.Text;
                    cmd8.CommandText = " select top 1 * from Order_User order by id desc";
                    cmd8.ExecuteNonQuery();
                    DataTable dt12 = new DataTable();
                    SqlDataAdapter ds12 = new SqlDataAdapter(cmd8);
                    ds12.Fill(dt12);
                    foreach (DataRow dr5 in dt12.Rows)
                    {
                        //getting the ID 
                        orderid = dr5["id"].ToString();
                    }

                    foreach (DataRow dr in dt.Rows)
                    {
                        //creating  a variable to check the Quantity and after we sold the item we have to decrease the Stock
                        int qty = 0;
                        //creating a variable to check the product name
                        string pname = "";

                        //inserting the values in Order_item table
                        SqlCommand cmd9 = conn.CreateCommand();
                        cmd9.CommandType = CommandType.Text;
                        cmd9.CommandText = "insert into Order_Item(Order_id,Order_Date,Product_name,Quantity,Waranttee,Rate,VAT,Discount,[Net Amount],Bill_type) values('" + orderid.ToString() + "','" + DateTime.Now + "','" + dr["Product Name"].ToString() + "','" + dr["Quantity"].ToString() + "','" + textWaranttee.Text + "','" + dr["Rate"].ToString() + "','" + dr["VAT/Unit"].ToString() + "','" + dr["Disc/Unit."].ToString() + "','" + dr["Total Amount"].ToString() + "','" + txtsaltype.Text + "')";
                        cmd9.ExecuteNonQuery();

                        //
                        //checking the Quantity and initializing the value as Qty
                        //
                        qty = Convert.ToInt32(dr["Quantity"].ToString());
                        //
                        //checking the Productname and initializing the value as pname
                        //
                        pname = dr["Product Name"].ToString();

                        //
                        // Stock Management 
                        //
                        SqlCommand cmd10 = conn.CreateCommand();
                        cmd10.CommandType = CommandType.Text;
                        cmd10.CommandText = "update Stock_Entry set Quantity = Quantity -" + qty + "  where Product_name = '" + dr["Product Name"].ToString() + "'";
                        cmd10.ExecuteNonQuery();


                        int b = 0;
                        SqlCommand cmd11 = conn.CreateCommand();
                        cmd11.CommandType = CommandType.Text;
                        cmd11.CommandText = "SELECT * from Sales_Details where Customer = '" + txtSalrepCustomernm.Text + "'and Product_name ='" + dr["Product Name"].ToString() + "' and Sales_Type='" + txtsaltype.Text + "'";
                        cmd11.ExecuteNonQuery();
                        DataTable dt11 = new DataTable();
                        SqlDataAdapter ds11 = new SqlDataAdapter(cmd11);
                        ds11.Fill(dt11);
                        dataGridView2.DataSource = dt11;
                        b = Convert.ToInt32(dt11.Rows.Count.ToString());
                        if (b == 0)
                        {

                            //
                            //Inserting the values in Purchase_Details database 
                            //
                            SqlCommand cmd15 = conn.CreateCommand();
                            cmd15.CommandText = "insert into Sales_Details values ('" + DateTime.Now + "','" + txtSalrepCustomernm.Text + "','" + dr["Product Name"].ToString() + "','" + dr["Quantity"].ToString() + "','" + dr["Rate"].ToString() + "','" + textWaranttee.Text + "','" + dr["VAT/Unit"].ToString() + "','" + dr["Disc/Unit."].ToString() + "','" + dr["Total Amount"].ToString() + "','" + txtsaltype.Text + "')";
                            cmd15.CommandType = CommandType.Text;
                            cmd15.ExecuteNonQuery();
                        }
                    }

                    Query = "Select * from Sales_Details where  Date ='"+DateTime.Now+"' ";



                    //Clearing all the substances of the textboxs
                    txtSalrepCustomernm.Text = ""; combProductname.Text = "";
                    txtPERQty.Text = ""; txtSalratePERQty.Text = "";
                    txtPERAmt.Text = ""; txtPERVat.Text = ""; txtPERDisc.Text = "";


                    MessageBox.Show("Record Added successfully..");

                    dt.Clear();
                    dataGridView2.DataSource = dt;

                    Sale_Bill_Report sb = new Sale_Bill_Report();
                    sb.get_value(Query.ToString());
                    sb.Show();

                }

                //
                //increasing the bill that is been genetared as the date
                //
                textBox19.Text = Convert.ToString(Convert.ToInt32(textBox19.Text)) + 1;

                display();
                //
                //disabling the save button after we insert/ Sell the data items
                //
                SalrepSaveNUpdateBtn.Enabled = false;
                //
                //viewing the result in a crystal report
                //
            }
        }


        private void SalrepDltBillBtn_Click(object sender, EventArgs e)
        {

            ////Asking User to comfirm before the deletion is done
            //if (MessageBox.Show("Do you want to Remove this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    //creating the variable in (int) that is for the comparision of the database Id column
            //    int id = Convert.ToInt32(dataGridView2.SelectedCells[0].Value.ToString());

            //    //Deleting the selected record 
            //    SqlCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = "Delete from Sales_Details where Customer = '" + txtSalrepCustomernm.Text + "'and Product_name = '" + combProductname.Text + "'";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();

            //    //Clearing all the substances of the textboxs


            //    display();
            //}

            //else
            //{
            //    //showing the message
            //    MessageBox.Show("Not Deleted", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(dataGridView2.SelectedCells[0].Value.ToString());

            //abstracting the corresponding values
            SqlCommand cmd31 = conn.CreateCommand();
            cmd31.CommandType = CommandType.Text;
            cmd31.CommandText = "select * from Sales_Details where [Bill No]=" + id + "";
            cmd31.ExecuteNonQuery();
            DataTable dt31 = new DataTable();
            SqlDataAdapter ds31 = new SqlDataAdapter(cmd31);
            ds31.Fill(dt31);
            foreach (DataRow dr21 in dt31.Rows)
            {

                //passing the value of Item details datagrid to the corresponding textbox
                txtSalrepCustomernm.Text = dr21["Customer"].ToString();
                combProductname.Text = dr21["Product_name"].ToString();
                txtPERQty.Text = dr21["Quantity"].ToString();
                txtSalratePERQty.Text = dr21["Rate"].ToString();
                txtPERVat.Text = dr21["VAT"].ToString();
                txtPERDisc.Text = dr21["Discount"].ToString();
                txtPERAmt.Text = dr21["Net Amount"].ToString();

            }
        }

        private void Cusdetviewbtn_Click(object sender, EventArgs e)
        {
            Cusdetviewbtn.Text = "Hide Details";
            disp();
        }

        private void Cusdetviewbtn_Leave(object sender, EventArgs e)
        {
            Cusdetviewbtn.Text = "Show Details";
            dataGridView1.Columns.Clear();
        }


        private void Itmdetviewbtn_Click(object sender, EventArgs e)
        {
            Itmdetviewbtn.Text = "Hide Details";
            dispp();
        }

        private void Itmdetviewbtn_Leave(object sender, EventArgs e)
        {
            Itmdetviewbtn.Text = "Show Details";
            dataGridView1.Columns.Clear();
        }

        public void disp()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails
            SqlCommand cmd5 = conn.CreateCommand();
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "Select * from Order_User Where Customer = '" + txtSalrepCustomernm.Text+ "'";
            cmd5.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds2 = new SqlDataAdapter(cmd5);
            ds2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        public void dispp()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails

            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "Select concat([Group],'-',[Sub Group],'-',Product_name,'-',[Model Name]) as Particulars,Selling_Rate,VAT from Item_Details where Product_name = '" + combProductname.Text + "'";
            cmd4.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd4);
            ds1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        private void txtSalratePERQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch) && ch!=8)
            {
                e.Handled = true;
            }
        }

        private void txtPERQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPERVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textWaranttee_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void AddCusbtn_MouseClick(object sender, MouseEventArgs e)
        {
            ////////////////////////

        }

        private void AddCusbtn_Click(object sender, EventArgs e)
        {

            //panel2.Visible = false;
        }

        private void txtSalrepCustomernm_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSalrepCustomernm.Text))
            {
                txtSalrepCustomernm.Focus();
                errorProvider1.SetError(txtSalrepCustomernm, "Customer Name Field is Empty");
            }
            else
            {
                errorProvider1.SetError(txtSalrepCustomernm, null);
                //txtVenTelNo.Focus();
            }
        }

        private void combProductname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combProductname.Text))
            {
                combProductname.Focus();
                errorProvider1.SetError(combProductname, "Customer Name Field is Empty");
            }
            else
            {
                errorProvider1.SetError(combProductname, null);
                //txtVenTelNo.Focus();
            }
        }

        private void SalrepSaveNUpdateBtn_Leave(object sender, EventArgs e)
        {
            bool SalrepSaveNUpdateBtnWasClicked = false;
            if (SalrepSaveNUpdateBtnWasClicked)
            {
                SalrepSaveNUpdateBtn.Focus();
                errorProvider1.SetError(SalrepSaveNUpdateBtn, "Customer Name Field is Empty");
            }
            else
            {
                errorProvider1.SetError(SalrepSaveNUpdateBtn, null);
                //txtVenTelNo.Focus();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
