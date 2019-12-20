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
    public partial class Clients : UserControl
    {
        //SqlConnection Address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");


        private static Clients _instance;

        public static Clients Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Clients();
                return _instance;
            }
        }

        public Clients()
        {
            InitializeComponent();
        }


        private void Clients_Load(object sender, EventArgs e)
        {
            //Analyzing the connection state
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        public void display()
        {
            //displaying the inserted or manipulated data in a datagrid
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Order_User";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter ds2 = new SqlDataAdapter(cmd2);
            ds2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            //displaying the image 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 50;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //creating the variable in (int) that is for the comparision of the database Id column
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            //abstracting the corresponding values
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from Order_User where id =" + id + "";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
            ds3.Fill(dt3);
            foreach (DataRow dr2 in dt3.Rows)
            {
                textBox1.Text = dr2["Customer"].ToString();
                textBox1.Text = dr2["Telephone"].ToString();
                textBox1.Text = dr2["Customer Address"].ToString();
                textBox1.Text = dr2["Company_name"].ToString();
            }

            button2.Visible = true;
            button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //asking the user to confirm the operation 
            if (MessageBox.Show("Do you want to Save this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int count = 0;
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Order_User where Customer = '"+textBox1.Text+"'";
                cmd.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ds1 = new SqlDataAdapter(cmd);
                ds1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                count = Convert.ToInt32(dt1.Rows.Count.ToString());
                if (count == 0)
                {
                    //checking tif the textbox is empty or not
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Empty Client Name!!");
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("Empty Client Address!!");
                    }
                    else
                    {
                        //Inserting the Corresponding values in Item_Details database
                        SqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "insert into Order_User values ('" + DateTime.Now + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                    }
                }

                else
                {
                    MessageBox.Show(" Record Already exists..");
                }
            }

            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //asking the user to confirm the operation 
            if (MessageBox.Show("Do you want to Save this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //creating the variable in (int) that is for the comparision of the database Id column
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                //Modifying the selected record of Group Details 
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "update Order_User set Customer = '" + textBox1.Text + "',Telephone='" + textBox2.Text + "' ,[Customer Address]= '" + textBox3.Text + "', Company_Name='" + textBox4.Text + "' where Customer = '" + textBox1.Text + "'and Telephone='" + textBox2.Text + "' and [Customer Address]= '" + textBox3.Text + "'";
                cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();
            }

            display();
            button3.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //asking the user to confirm the operation 
            if (MessageBox.Show("Do you want to Save this selected data", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int idd = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                //Deleting the selected row 
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from Order_User where id = '" + idd + "'";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                

                MessageBox.Show("Data Deleted Successfully");
                display();
            }

            button2.Visible = false;
            button3.Visible = false;
        }
    }
}
