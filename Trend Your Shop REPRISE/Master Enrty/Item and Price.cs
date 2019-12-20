using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Item_and_Price : Form
    {
        //SqlConnection Address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public Item_and_Price()
        {
            InitializeComponent();
        }


        private void Item_and_Price_Load(object sender, EventArgs e)
        {
            //Analyzing the connection state
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            display_Productdetails();
            display_GroupDetails();

            display();


        }


        public void display_GroupDetails()
        {
            //displaying the corresponding product details like group name from the datatable Group_Details
            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select * from Group_Detail";
            cmd4.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd4);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                itmPrcGropNm.Items.Add(dr1["Category"].ToString());
            }
        }

        private void itmPrcGropNm_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd4 = conn.CreateCommand();
            cmd4.CommandType = CommandType.Text;
            cmd4.CommandText = "select [Sub Category] from Group_Detail where [Category]='" + itmPrcGropNm.Text + "'";
            cmd4.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd4);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                itmPrcSubGropNm.Items.Add(dr1["Sub Category"].ToString());
            }
        }
        
        public void display_Productdetails()
        {
            //displaying the corresponding product details like product namefrom the datatable ProductDetails
            prodnmcomboBox.Items.Clear();
            produncomboBox.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from ProductDetails ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //viewing the abstracted data in the corresponding textboxes
                prodnmcomboBox.Items.Add(dr1["product_name"].ToString());

            }
        }

        private void prodnmcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displaying the corresponding product details as per product name from the datatable ProductDetails
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from ProductDetails where product_name = '" + prodnmcomboBox.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                //showing the corresponding data in related fields
                itmPrcGropNm.Text = dr1["Category"].ToString();
                itmPrcSubGropNm.Text = dr1["Sub Category"].ToString();
                txtiteprcRateper.Text = dr1["Product_Price"].ToString();
                comboBox1.Text = dr1["Selling_Price"].ToString();
                produncomboBox.Text = dr1["Unit"].ToString();
                byte[] images = (byte[])(dr1["Product_image"]);
                if (images == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(images);
                    pictureBox1.Image = Image.FromStream(ms);
                }

            }
            
        }


        public void display()
        {
            //displaying the inserted or manipulated data in a datagrid
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Item_Details";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds2 = new SqlDataAdapter(cmd2);
            ds2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            //displaying the image 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 100;
            }
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[5];
            image.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dataGridView1.AllowUserToAddRows = false;
        }


        //variabe to get the string of the imagelocation
        string imagelocation;

        private void button1_Click(object sender, EventArgs e)
        {
            //opening a dialog that shows the picture items
            OpenFileDialog dfd = new OpenFileDialog();
            dfd.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
            dfd.Title = "Select Product Picture";
            if (dfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imagelocation = dfd.FileName.ToString();
                //displaying the image in a picture box 
                pictureBox1.ImageLocation = imagelocation;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            //abstracting the corresponding values
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Item_Details where id =" + id + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {

                //passing the value of Item details datagrid to the corresponding textbox
                itmPrcGropNm.Text = dr2["Group"].ToString();
                itmPrcSubGropNm.Text = dr2["Sub Group"].ToString();
                prodnmcomboBox.Text = dr2["Product_name"].ToString();
                byte[] images = (byte[])(dr2["Product_image"]);
                if (images == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(images);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                itmPrcModNm.Text = dr2["Model Name"].ToString();
                produncomboBox.Text = dr2["Units"].ToString();
                txtiteprcRateper.Text = dr2["Rate"].ToString();
                comboBox1.Text = dr2["Selling_Rate"].ToString();
                txtiteprcVatper.Text = dr2["VAT"].ToString();
                itmPrcDetail.Text = dr2["Detail"].ToString();
            }
        }

        private void ItemPrcSavBtn_Click(object sender, EventArgs e)
        {
            //asking the user to confirm the operation 
            if (MessageBox.Show("Do you want to Save this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //converting the image in a binary code 
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] images = ms.ToArray();

                //Checking the Duplicate entry
                int count = 0;

                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT * from Item_Details where Product_name = '" + prodnmcomboBox.Text + "'and [Model Name] = '" + itmPrcModNm.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
                ds1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                count = Convert.ToInt32(dt1.Rows.Count.ToString());
                if (count == 0)
                {
                    //checking tif the textbox is empty or not
                    if (itmPrcModNm.Text == "")
                    {
                        MessageBox.Show("Empty Model Name!!");
                    }
                    else if (txtiteprcRateper.Text == "")
                    {
                        MessageBox.Show("Empty Rate Field!!");
                    }
                    else
                    {
                        //Inserting the Corresponding values in Item_Details database
                        SqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "insert into Item_Details values ('" + DateTime.Today + "','" + itmPrcGropNm.Text + "','" + itmPrcSubGropNm.Text + "','" + prodnmcomboBox.Text + "',@images,'" + itmPrcModNm.Text + "','" + produncomboBox.Text + "','" + txtiteprcRateper.Text + "','" + comboBox1.Text + "','" + txtiteprcVatper.Text + "','" + itmPrcDetail.Text + "')";
                        cmd2.Parameters.Add(new SqlParameter("@images", images));
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }
                }

                else
                {
                    MessageBox.Show(" Record Already exists..");
                }


                ////////////////////
                //Checking the Duplicate entry in Group Details
                ////////////////////


                try
                {
                    //Inserting the Corresponding values in Group Detail database            
                    string jm = @"(select count(*) from Group_Details where Category='" + itmPrcGropNm.Text + "'and [Sub Category]='" + itmPrcSubGropNm.Text + "')";

                    SqlCommand cmd3 = new SqlCommand("insert into Group_Detail values ('" + itmPrcGropNm.Text + "','" + itmPrcSubGropNm.Text + "')", conn);
                    SqlCommand cmda = new SqlCommand(jm, conn);
                    int count2 = (int)cmda.ExecuteScalar();
                    if (count2 > 0)
                    {
                        MessageBox.Show("Group Details already exists");
                    }
                    else
                    {
                        cmd3.ExecuteNonQuery();
                        //MessageBox.Show("Group Record Added Successfully");
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }


                ////////////////////
                //Checking the Duplicate entry in a product Details
                ////////////////////


                try
                {
                    //Inserting the Corresponding values in ProductDetail database            
                    string jj = @"(select count(*) from ProductDetails where product_name='" + prodnmcomboBox.Text + "'and Category='" + itmPrcGropNm.Text + "' and [Sub Category]= '"+itmPrcSubGropNm.Text+"')";

                    SqlCommand cmd4 = new SqlCommand("insert into ProductDetails values ('" + itmPrcGropNm.Text + "','" + itmPrcSubGropNm.Text + "','" + prodnmcomboBox.Text + "','" + txtiteprcRateper.Text + "','" + comboBox1.Text + "','" + produncomboBox.Text + "', @images)", conn);
                    cmd4.Parameters.Add(new SqlParameter("@images", images));
                    SqlCommand cmdb = new SqlCommand(jj, conn);
                    int count2 = (int)cmdb.ExecuteScalar();
                    if (count2 > 0)
                    {
                        MessageBox.Show("Product Details already exists");
                    }
                    else
                    {
                        cmd4.ExecuteNonQuery();
                        //MessageBox.Show("Product Details Added Successfully..");
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }



                ////////////////////
                //Checking the Duplicate entry in a VAT Details
                ////////////////////


                try
                {
                    //Inserting the Corresponding values in VAT_Detail database            
                    string jjp = @"(select count(*) from VAT_Details where product_name='" + prodnmcomboBox.Text + "'and Model_name='" + itmPrcModNm.Text + "' and [Group Name]='" + itmPrcGropNm.Text + "'and [Sub Group Name]='" + itmPrcSubGropNm.Text + "' and VAT = '" + txtiteprcVatper.Text + "')";

                    SqlCommand cmd5 = new SqlCommand("insert into VAT_Details (product_name,Model_name,[Group Name], [Sub Group Name], VAT) values ('" + prodnmcomboBox.Text + "','" + itmPrcModNm.Text + "','" + itmPrcGropNm.Text + "','" + itmPrcSubGropNm.Text + "','" + txtiteprcVatper.Text + "')", conn);
                    SqlCommand cmdc = new SqlCommand(jjp, conn);
                    int count3 = (int)cmdc.ExecuteScalar();
                    if (count3 > 0)
                    {
                        MessageBox.Show("VAT details is already exists");
                    }
                    else
                    {
                        cmd5.ExecuteNonQuery();
                        //MessageBox.Show("Product Details Added Successfully..");
                    }

                }
                catch (Exception)
                {
                    //MessageBox.Show(ex.Message);
                }


                //making the textboxes empty
                itmPrcGropNm.Text = ""; itmPrcSubGropNm.Text = ""; prodnmcomboBox.Text = ""; itmPrcModNm.Text = "";
                produncomboBox.Text = ""; txtiteprcRateper.Text = ""; txtiteprcVatper.Text = ""; itmPrcDetail.Text = "";

                display();
                MessageBox.Show("Record added successfully..");
            }
        }

        
        //Modifying records 
        private void ItemPrcModBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("warning", "Please select the Image again");

            //converting the image in a byte code 
            byte[] images = null;
            FileStream stream = new FileStream(imagelocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            
            if (MessageBox.Show("Are You Sure to Moify this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                //Modifying the selected record  of Item Details
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update Item_Details set [Group]= '" + itmPrcGropNm.Text + "',[Sub Group]='" + itmPrcSubGropNm.Text + "',Product_name = '" + prodnmcomboBox.Text + "' Product_image = @images, [Model Name] = '" + itmPrcModNm.Text + "',Units = '" + produncomboBox.Text + "', Rate = '" + txtiteprcRateper.Text + "', selling_rate = '" + comboBox1.Text + "', VAT = '" + txtiteprcVatper.Text + "', Detail='" + itmPrcDetail.Text + "' where id = '" + id + "'";
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                //Modifying the selected record of Group Details 
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "update Group_Detail set Category = '" + itmPrcGropNm.Text + "',[Sub Category]='" + itmPrcSubGropNm.Text + "' where Category= '" + itmPrcGropNm.Text + "'and [Sub Category]='" + itmPrcSubGropNm.Text + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();

                //Modifying the selected record  of VAT Details
                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = "update VAT_Details set product_name ='" + prodnmcomboBox.Text + "', Model_name = '" + itmPrcModNm.Text + "', [Group Name]= '" + itmPrcGropNm.Text + "',[Sub Group Name]='" + itmPrcSubGropNm.Text + "',VAT = '" + txtiteprcVatper.Text + "' where product_name ='" + prodnmcomboBox.Text + "' and  Model_name = '" + itmPrcModNm.Text + "' and [Group Name]= '" + itmPrcGropNm.Text + "' and [Sub Group Name]='" + itmPrcSubGropNm.Text + "'and VAT = '" + txtiteprcVatper.Text + "'";
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();

                //Modifying the selected record  of ProductDetails
                SqlCommand cmd4 = conn.CreateCommand();
                cmd4.CommandText = "update ProductDetails set category = '" + itmPrcGropNm.Text + "',[Sub Category] = '" + itmPrcSubGropNm.Text + "', product_name ='" + prodnmcomboBox.Text + "', product_image = @images, Product_price = '" + txtiteprcRateper.Text + "', Selling_price = '" + comboBox1.Text + "',  Unit = '" + produncomboBox.Text + "' where product_name='" + prodnmcomboBox.Text + "'and Category='" + itmPrcGropNm.Text + "' and [Sub Category]= '" + itmPrcSubGropNm.Text + "'";
                cmd4.Parameters.Add(new SqlParameter("@images", images));
                cmd4.CommandType = CommandType.Text;
                cmd4.ExecuteNonQuery();

                //making the texetboxes empty
                itmPrcGropNm.Text = ""; itmPrcSubGropNm.Text = ""; prodnmcomboBox.Text = ""; itmPrcModNm.Text = "";
                produncomboBox.Text = ""; txtiteprcRateper.Text = ""; txtiteprcVatper.Text = ""; itmPrcDetail.Text = "";
                comboBox1.Text = "";


                display();

                MessageBox.Show("Data Updated Successfully");
            }

        }

        private void ItemPrcDelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Remove this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int idd = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                //Deleting the selected row 
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from Item_Details where id = '" + idd + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                display();

                MessageBox.Show("Data Deleted Successfully");
            }
        }


        private void txtitmFindit_TextChanged(object sender, EventArgs e)
        {
            //Searching the fields in a datagrid view
            if (comboBox3.Text == "Category")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT *from Item_Details where [Group] like '" + txtitmFindit.Text + "%' ",conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox3.Text == "Model Name")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT *from Item_Details where [Model Name] like '" + txtitmFindit.Text + "%' ", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
             else if (comboBox3.Text == "Rate")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT *from Item_Details where Rate like '" + txtitmFindit.Text + "%' ", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else if (comboBox3.Text == "VAT")
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT *from Item_Details where VAT like '" + txtitmFindit.Text + "%' ", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //making the texetboxes empty
            itmPrcGropNm.Text = ""; itmPrcSubGropNm.Text = ""; prodnmcomboBox.Text = ""; itmPrcModNm.Text = "";
            produncomboBox.Text = ""; txtiteprcRateper.Text = ""; txtiteprcVatper.Text = ""; itmPrcDetail.Text = "";
            comboBox1.Text = ""; pictureBox1.Image = null;
        }

        private void ClsBtn_Click(object sender, EventArgs e)
        {
            //clode the current form
            this.Close();
        }

    }
}