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
using System.Diagnostics;

namespace Trend_Your_Shop_REPRISE.Master_Enrty
{

    public partial class Purchase_Details : UserControl
    {

        private static Purchase_Details _instance;

        public static Purchase_Details Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Purchase_Details();
                return _instance;
            }
        }

        public Purchase_Details()
        {
            InitializeComponent();
        }

        //SqlConnection Address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        DataTable dt = new DataTable();
        
        private void Purchase_Details_Load(object sender, EventArgs e)
        {
            //Analyzing the Connection state
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();


            display();


            fill_Ven_name();
            AutoComplete_Text();

            fill_Product_name();
            AutoComplete_Text1();

            //disp();
            //dispp();

            dt.Columns.Add("S.N.");
            dt.Columns.Add("Bill_Date");
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Rate/Unit.");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("VAT/Unit.");
            dt.Columns.Add("Disc/Unit.");
            dt.Columns.Add("Total Amount");


            DataGridViewForAll.ColumnHeadersVisible = true;
            DataGridViewForAll.RowHeadersVisible = false;
            DataGridViewForAll.AllowUserToAddRows = false;
            DataGridViewForAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        }

        public void display()
        {
            //displaying the inserted or manipulated data in a datagrid
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Purchase_Details";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            ds.Fill(dt);
            DataGridViewForAll.DataSource = dt;
            //displaying the image 
            foreach (DataGridViewRow row in DataGridViewForAll.Rows)
            {
                row.Height = 50;
            }
            DataGridViewImageColumn imag = new DataGridViewImageColumn();
            imag = (DataGridViewImageColumn)DataGridViewForAll.Columns[12];
            imag.ImageLayout = DataGridViewImageCellLayout.Zoom;

            DataGridViewForAll.AllowUserToAddRows = false;

        }

        public void disp()
        {
            DataGridViewForAll.RowHeadersVisible = false;
            DataGridViewForAll.AllowUserToAddRows = false;
            DataGridViewForAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails
            SqlCommand cmd5 = conn.CreateCommand();
            cmd5.CommandType = CommandType.Text;
            cmd5.CommandText = "Select [Vendor Name],[PAN NO],[Telephone],[Contact Person], concat(Street,'-',City,'-',District,'-',State) as FullAddress from Vendor_Details where [Vendor Name] = '" + comVendordet.Text + "'";
            cmd5.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds2 = new SqlDataAdapter(cmd5);
            ds2.Fill(dt2);
            DataGridViewForAll.DataSource = dt2;
            

            foreach (DataGridViewRow row in DataGridViewForAll.Rows)
            {
                row.Height = 50;
            }

            DataGridViewForAll.AllowUserToAddRows = false;
        }

        public void dispp()
        {
            DataGridViewForAll.RowHeadersVisible = false;
            DataGridViewForAll.AllowUserToAddRows = false;
            DataGridViewForAll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //displaying the corresponding vendor details within Vendor name from the datatable VendorDetails

            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "Select concat([Group],'-',[Sub Group],'-',Product_name,'-',[Model Name]) as Particulars,Rate as Purchase_Rate,Selling_Rate,VAT,Details from Item_Details where Product_name = '" + combProductname.Text + "'";
            cmd4.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd4);
            ds1.Fill(dt1);
            DataGridViewForAll.DataSource = dt1;

            foreach (DataGridViewRow row in DataGridViewForAll.Rows)
            {
                row.Height = 50;
            }

            DataGridViewForAll.AllowUserToAddRows = false;
        }

        private void Calculate()
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
                txtPERAmt.Text = (NomAmt).ToString();
                txtTotalVATAmt.Text = NomAmt2.ToString();
                txtTotalDiscAmt.Text = NomAmt4.ToString();
                txtTotalAmt.Text = NomAmt5.ToString();
            }
        }

        private void txtSalratePERQty_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtPERQty_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtPERVat_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtPERDisc_Leave(object sender, EventArgs e)
        {
            Calculate();
        }

        //Detailing the data information of Vendors
        public void fill_Ven_name()
        {
            //displaying the corresponding Vendor Name from datatable Vendor_Details
            comVendordet.Items.Clear();
            //conn.Open();
            SqlCommand cmd11 = conn.CreateCommand();
            cmd11.CommandType = CommandType.Text;
            cmd11.CommandText = "select * from Vendor_Details"; // where [Vendor Name] = '" + comVendordet.Text + "'
            cmd11.ExecuteNonQuery();
            DataTable dt11 = new DataTable();
            SqlDataAdapter ds11 = new SqlDataAdapter(cmd11);
            ds11.Fill(dt11);
            foreach (DataRow dr11 in dt11.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                comVendordet.Items.Add(dr11["Vendor Name"].ToString());
            }

            //conn.Close();
        }

        //Vendor name suggestion when we type the text
        void AutoComplete_Text()
        {
            //Selecting the mode, source and collecting then in along as string 
            comVendordet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comVendordet.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            //conn.Open();
            SqlCommand cmd12 = conn.CreateCommand();
            cmd12.CommandType = CommandType.Text;
            cmd12.CommandText = "select * from Vendor_Details ";
            cmd12.ExecuteNonQuery();
            DataTable dt12 = new DataTable();
            SqlDataAdapter ds12 = new SqlDataAdapter(cmd12);
            ds12.Fill(dt12);
            foreach (DataRow dr12 in dt12.Rows)
            {
                string nams = dr12["Vendor Name"].ToString(); //taking all database venname colun values and adding them as an item
                coll.Add(nams);
            }

            comVendordet.AutoCompleteCustomSource = coll;

            vendetviewbtn.Enabled = true;
            //conn.Close();
        }

        private void vendetviewbtn_Click(object sender, EventArgs e)
        {
            vendetviewbtn.Text = "Hide Details";
            disp();
        }

        private void vendetviewbtn_Leave(object sender, EventArgs e)
        {
            vendetviewbtn.Text = "View Details";
            DataGridViewForAll.Columns.Clear();
            display();
        }


        public void fill_Product_name()
        {
            //displaying the corresponding Vendor Name from datatable Vendor_Details
            combProductname.Items.Clear();
            //conn.Open();
            SqlCommand cmd13 = conn.CreateCommand();
            cmd13.CommandType = CommandType.Text;
            cmd13.CommandText = "select * from Item_Details"; // where [Vendor Name] = '" + comVendordet.Text + "'
            cmd13.ExecuteNonQuery();
            DataTable dt13 = new DataTable();
            SqlDataAdapter ds13 = new SqlDataAdapter(cmd13);
            ds13.Fill(dt13);
            foreach (DataRow dr13 in dt13.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                combProductname.Items.Add(dr13["Product_name"].ToString());
            }


            //conn.Close();
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
            //displaying the corresponding product details like product name and units from the datatable ProductDetails
            SqlCommand cmd15 = conn.CreateCommand();
            cmd15.CommandType = CommandType.Text;
            cmd15.CommandText = "select * from Item_Details where [Product_name] = '" + combProductname.Text + "' ";
            cmd15.ExecuteNonQuery();
            DataTable dt15 = new DataTable();
            SqlDataAdapter ds15 = new SqlDataAdapter(cmd15);
            ds15.Fill(dt15);
            foreach (DataRow dr15 in dt15.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                txtModNm.Text = dr15["Model Name"].ToString();
                txtSalratePERQty.Text = dr15["Selling_Rate"].ToString();
                txtPERVat.Text = dr15["VAT"].ToString();
            }
        }


        private void Itmdetviewbtn_Click(object sender, EventArgs e)
        {
            Itmdetviewbtn.Text = "Hide Details";
            dispp();
        }


        private void Itmdetviewbtn_Leave(object sender, EventArgs e)
        {
            Itmdetviewbtn.Text = "Show Details";
            DataGridViewForAll.Columns.Clear();
            display();
        }

        string picpath;

        private void BillPictureClick_Click(object sender, EventArgs e)
        {
            // Bill picture saving
            OpenFileDialog dlg = new OpenFileDialog(); //opening the dialogue box
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*"; //filtering the dialog box
            dlg.Title = "Select Bill Picture.";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picpath = dlg.FileName.ToString(); //selecting the path of the image 
                billPiclocation.Text = picpath;
                pictureBox1.ImageLocation = picpath;
            }
        }

        private void PurstockSavBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Save this data", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //converting the image in a byte code 
                byte[] images = null;
                FileStream stream = new FileStream(picpath, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);

                //varialble to check duplicacy
                int check = 0;


                SqlCommand cmd7 = conn.CreateCommand();
                cmd7.CommandType = CommandType.Text;
                cmd7.CommandText = "SELECT * from Stock_Entry where [Product_name] = '" + combProductname.Text + "'";
                cmd7.ExecuteNonQuery();
                DataTable dt12 = new DataTable();
                SqlDataAdapter ds12 = new SqlDataAdapter(cmd7);
                ds12.Fill(dt12);
                check = Convert.ToInt32(dt12.Rows.Count.ToString());
                if (check == 0)
                {
                    //variable to find if there is a duplicate entry or not
                    int a = 0;
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "SELECT * from Purchase_Details where [Vendor Name] = '" + comVendordet.Text + "' and [Product_name] = '" + combProductname.Text + "'";
                    cmd1.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
                    ds1.Fill(dt1);
                    DataGridViewForAll.DataSource = dt1;
                    a = Convert.ToInt32(dt1.Rows.Count.ToString());
                    if (a == 0)
                    {
                        if (billPiclocation.Text == "Bill Picture Location" && billPiclocation.Text == "")
                        {
                            MessageBox.Show("Please Select Bill Picture!!!");
                        }
                        else
                        {
                            //Inserting the values in Purchase_Details database 
                            SqlCommand cmd2 = conn.CreateCommand();
                            cmd2.CommandText = "insert into Purchase_Details values ('" + comVendordet.Text + "','" + combProductname.Text + "','"+txtModNm.Text+"','" + txtPERQty.Text + "','" + txtSalratePERQty.Text + "','" + Purtext.Text + "' ,'" + txtPERVat.Text + "','" + txtPERDisc.Text + "' ,'" + txtTotalAmt.Text + "','" + txtVenBill.Text + "','" + billPiclocation.Text + "',@images ,'" + DateTime.Today + " ','" + comboBoxPurTyp.Text + "','" + txtcash.Text + "','" + txtBank.Text + "','" + txtCredit.Text + "')";
                            cmd2.Parameters.Add(new SqlParameter("@images", images));
                            cmd2.CommandType = CommandType.Text;
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Record added successfully..");

                            //([Vendor Name],Product_name,Quantity,Purchase_Rate,Selling_Rate,VAT,Discount,[Net Amount],[Bill No],Bill_Image,Bill_img,Bill_Date,Purchase_Type,CASH,CHEQUE,CREDIT)

                            //Inserting the values in Stock_Entry database 
                            SqlCommand cmd13 = conn.CreateCommand();
                            cmd13.CommandText = "insert into Stock_Entry (Date,Product_name,[Model Name],Quantity) values ('"+DateTime.Today+"','" + combProductname.Text + "','" + txtModNm.Text + "','" + txtPERQty.Text + "')";
                            cmd13.CommandType = CommandType.Text;
                            cmd13.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Purchase Record already exixts..");
                    }
                    //}
                }

                else
                {
                    int am = 0;
                    SqlCommand cmd14 = conn.CreateCommand();
                    cmd14.CommandType = CommandType.Text;
                    cmd14.CommandText = "SELECT * from Purchase_Details where [Vendor Name] = '" + comVendordet.Text + "' and [Product_name] = '" + combProductname.Text + "'";
                    cmd14.ExecuteNonQuery();
                    DataTable dt14 = new DataTable();
                    SqlDataAdapter ds14 = new SqlDataAdapter(cmd14);
                    ds14.Fill(dt14);
                    DataGridViewForAll.DataSource = dt14;
                    am = Convert.ToInt32(dt14.Rows.Count.ToString());
                    if (am == 0)
                    {
                        if (billPiclocation.Text == "Bill Picture Location" && billPiclocation.Text == "")
                        {
                            MessageBox.Show("Please Select Bill Picture!!!");
                        }
                        else
                        {
                            //Inserting the values in Purchase_Details database 
                            SqlCommand cmd15 = conn.CreateCommand();
                            cmd15.CommandText = "insert into Purchase_Details ([Vendor Name],Product_name,[Model Name],Quantity,Purchase_Rate,Selling_Rate,VAT,Discount,[Net Amount],[Bill No],Bill_Image,Bill_img,Bill_Date,Purchase_Type,CASH,CHEQUE,CREDIT) values ('" + comVendordet.Text + "','" + combProductname.Text + "','" + txtModNm.Text + "','" + txtPERQty.Text + "','" + txtSalratePERQty.Text + "','" + Purtext.Text + "' ,'" + txtPERVat.Text + "','" + txtPERDisc.Text + "' ,'" + txtTotalAmt.Text + "','" + txtVenBill.Text + "','" + billPiclocation.Text + "', @images,'" + DateTime.Today + " ','" + comboBoxPurTyp.Text + "','" + txtcash.Text + "','" + txtBank.Text + "','" + txtCredit.Text + "')";
                            cmd15.Parameters.Add(new SqlParameter("@images", images));
                            cmd15.CommandType = CommandType.Text;
                            cmd15.ExecuteNonQuery();
                            MessageBox.Show("Record added successfully..");

                            //Inserting the values in Stock_Entry database 
                            SqlCommand cmd16 = conn.CreateCommand();
                            cmd16.CommandText = "update Stock_Entry set Quantity = Quantity + '" + txtPERQty.Text + "' where Product_name = '" + combProductname.Text + "'";
                            cmd16.CommandType = CommandType.Text;
                            cmd16.ExecuteNonQuery();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Purchase Record already exixts..");
                    }
                    // }
                }


                display();
            }
            
            // DataGridViewForAll.Rows.Clear();
        }

        private void PurstockModfBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete this data", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int id = Convert.ToInt32(DataGridViewForAll.SelectedCells[0].Value.ToString());

                //Modifying the selected record 
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from Purchase_Details where id = " + id + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            PurstockModfBtn.Enabled = false;
        }


        private void DataGridViewForAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(DataGridViewForAll.SelectedCells[0].Value.ToString());

            //abstracting the corresponding values
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Purchase_Details where id =" + id + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {

                //passing the value of Item details datagrid to the corresponding textbox
                comVendordet.Text = dr2["Vendor Name"].ToString();
                combProductname.Text = dr2["Product_name"].ToString();
                txtModNm.Text = dr2["Model Name"].ToString();
                txtPERQty.Text = dr2["Quantity"].ToString();
                Purtext.Text = dr2["Selling_Rate"].ToString();
                txtSalratePERQty.Text = dr2["Purchase_Rate"].ToString();
                txtPERVat.Text = dr2["VAT"].ToString();
                txtPERDisc.Text = dr2["Discount"].ToString();
                txtPERAmt.Text = dr2["Net Amount"].ToString();
                txtVenBill.Text = dr2["Bill No"].ToString();
                billPiclocation.Text = dr2["Bill_Image"].ToString();

                //converting the byte image to view in picture box
                byte[] images = (byte[])(dr2["Bill_img"]);
                if (images == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(images);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                comboBoxPurTyp.Text = dr2["Purchase_Type"].ToString();

            }
            PurstockModfBtn.Enabled = true;
        }

        private void AddVenBtn_Click(object sender, EventArgs e)
        {
            //Calling the win form name Vendors_forms
            (new Vendors_form()).ShowDialog();
        }

        private void AddProductDet_Click(object sender, EventArgs e)
        {
            //calling the win form name Item_And_price
            (new Item_and_Price()).ShowDialog();
        }

        private void comVendordet_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comVendordet.Text))
            {
                comVendordet.Focus();
                errorProvider1.SetError(comVendordet, "Please Enter pan no");
            }
            else
            {
                errorProvider1.SetError(comVendordet, null);
                //txtVenTelNo.Focus();
            }

            int am = 0;
            //Checking the selected record whenn we leave the vendor ComboBox Fiels=dds
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Vendor_Details where [Vendor Name] = '" + comVendordet.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd);
            ds14.Fill(dt14);
            am = Convert.ToInt32(dt14.Rows.Count.ToString());
            if (am == 0)
            {

                if (MessageBox.Show("No Vendor Found..", " Do You Want to Add new Vendor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new Vendors_form()).ShowDialog();
                }
            }
            else
            { 
            }
        }

        private void combProductname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combProductname.Text))
            {
                combProductname.Focus();
                errorProvider1.SetError(combProductname, "Please Enter pan no");
            }
            else
            {
                errorProvider1.SetError(combProductname, null);
                //txtVenTelNo.Focus();
            }
            int amp = 0;
            //Checking the selected record whenn we leave the vendor ComboBox Fiels=dds
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * from Item_Details where Product_Name = '" + combProductname.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DataTable dt14 = new DataTable();
            SqlDataAdapter ds14 = new SqlDataAdapter(cmd);
            ds14.Fill(dt14);
            amp = Convert.ToInt32(dt14.Rows.Count.ToString());
            if (amp == 0)
            {
                if (MessageBox.Show("No Product Found..", " Do You Want to Add new Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new Item_and_Price()).ShowDialog();
                }
            }
            else
            {
               
            }
        }

        private void txtPERQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtSalratePERQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPERVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtPERDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtVenBill_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void comboBoxPurTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPurTyp.Text == "CASH")
            {
                label3.Visible = true;
                txtcash.Visible = true;
            }
            else if (comboBoxPurTyp.Text == "CHEQUE")
            {
                label4.Visible = true;
                txtBank.Visible = true;
            }
            else if (comboBoxPurTyp.Text == "CREDIT")
            {
                label5.Visible = true;
                txtCredit.Visible = true;
            }
            else if (comboBoxPurTyp.Text == "CASH & CHEQUE")
            {
                label3.Visible = true;
                txtcash.Visible = true;
                label4.Visible = true;
                txtBank.Visible = true;
            }
            else if (comboBoxPurTyp.Text == "CASH & CREDIT")
            {
                label3.Visible = true;
                txtcash.Visible = true;
                label5.Visible = true;
                txtCredit.Visible = true;
            }
            else if (comboBoxPurTyp.Text == "CHEQUE & CREDIT")
            {
                label5.Visible = true;
                txtCredit.Visible = true;
                label4.Visible = true;
                txtBank.Visible = true;
            }
            else
            {
                label3.Visible = true;
                txtcash.Visible = true;
                label4.Visible = true;
                txtBank.Visible = true;
                label5.Visible = true;
                txtCredit.Visible = true;
            }
        }

        private void billPiclocation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(billPiclocation.Text))
            {
                billPiclocation.Focus();
                errorProvider1.SetError(billPiclocation, "Please Select Bill Picture");
            }
            else if(billPiclocation.Text == "Bill Picure Location")
            {
                billPiclocation.Focus();
                errorProvider1.SetError(billPiclocation, "Please Select Bill Picture");
            }
            else
            {
                errorProvider1.SetError(billPiclocation, null);
                //txtVenTelNo.Focus();
            }
        }
    }
}

//private void PurstockDelBtn_Click(object sender, EventArgs e)
//{
//    if (MessageBox.Show("Do you want to Remove this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//    {
//        //creating the variable in (int) that is for the comparision of the database Id column
//        int id = Convert.ToInt32(DataGridViewForAll.SelectedCells[0].Value.ToString());

//        //Deleting the selected record 
//        SqlCommand cmd = conn.CreateCommand();
//        cmd.CommandText = "Delete from Purchase_Details where [Vendor Name] = '" + comVendordet.Text + "'and Product_name = '" + combProductname.Text + "'";
//        cmd.CommandType = CommandType.Text;
//        cmd.ExecuteNonQuery();

//        //Clearing all the substances of the textboxs
//        comVendordet.Text = ""; combProductname.Text = ""; txtPERQty.Text = ""; txtTotalDiscAmt.Text = "";
//        txtTotalVATAmt.Text = ""; billPiclocation.Text = "";
//        txtTotalAmt.Text = ""; txtPERDisc.Text = ""; txtPERVat.Text = ""; txtVenBill.Text = ""; comboBoxPurTyp.Text = "";
//        txtSalratePERQty.Text = ""; pictureBox1.Image = null;


//        display();
//    }

//    else
//    {
//        MessageBox.Show("Not Deleted", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//}
