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
    public partial class Groups : UserControl
    {
        public Groups()
        {
            InitializeComponent();
        }

        //Sql connection address
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        private static Groups _instance;

        public static Groups Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Groups();
                return _instance;
            }
        }

        private void Groups_Load(object sender, EventArgs e)
            {
                //Analyzing if the connection state is open or close
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();

                Groupsavbtn.Focus();

                Loaddata();
            }

            private void Loaddata()
            {

                // Showing the data in a datagrid view 
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT *from Group_Detail";
                cmd1.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter ds = new SqlDataAdapter(cmd1);
                ds.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;

            }

            private void Groupsavbtn_Click(object sender, EventArgs e)
            {
                //Checking the Duplicate entry
                int count = 0;
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT * from Group_Detail where Category = '" + txtgroupname.Text + "' and [Sub Category] ='" + txtsubgroupname.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
                ds1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                count = Convert.ToInt32(dt1.Rows.Count.ToString());
                if (count == 0)
                {
                    //checking tif the textbox is empty or not
                    if (txtgroupname.Text == "")
                    {
                        MessageBox.Show("Empty Group Name!!");
                    }
                    else if (txtsubgroupname.Text == "")
                    {
                        MessageBox.Show("Empty Sub Group Name!!");
                    }
                    else
                    {
                        //Inserting the Corresponding values in a database
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "insert into Group_Detail values('" + txtgroupname.Text + "','" + txtsubgroupname.Text + "')";
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        txtgroupname.Text = "";
                        txtsubgroupname.Text = "";

                        txtgroupname.Focus();
                        Loaddata();
                        MessageBox.Show("Record added successfully..");

                    }
                }
                else
                {
                    MessageBox.Show("Already exists..");
                }


            }

            private void Groupeditbtn_Click(object sender, EventArgs e)
            {
                //creating the variable in (int) that is for the comparision of the database Id column

                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                //Modifying the selected Row 
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Group_Detail set Category = '" + txtgroupname.Text + "',[Sub Category] = '" + txtsubgroupname.Text + "' where id = " + id + "";
                cmd.ExecuteNonQuery();

                txtgroupname.Focus();
                Loaddata();
            }

            private void Groupdeletbtn_Click(object sender, EventArgs e)
            {

                //deleting the selected Group details row
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Group_Detail where Category = '" + txtgroupname.Text + "'and [Sub Category] = '" + txtsubgroupname.Text + "'";
                cmd.ExecuteNonQuery();

                txtgroupname.Focus();
                Loaddata();
            }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                //creating the variable in (int) that is for the comparision of the database Id column
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd3 = conn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from Group_Detail where id =" + id + "";
                cmd3.ExecuteNonQuery();
                DataTable dt3 = new DataTable();
                SqlDataAdapter ds3 = new SqlDataAdapter(cmd3);
                ds3.Fill(dt3);
                foreach (DataRow dr2 in dt3.Rows)
                {
                    //string[] groupsss = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString().Split('~');

                    //passing the value of group name and sub group name to the corresponding textbox
                    txtgroupname.Text = dr2["Category"].ToString();
                    txtsubgroupname.Text = dr2["Sub Category"].ToString();
                }
                txtgroupname.Focus();
            }

            private void txtsearch_TextChanged(object sender, EventArgs e)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Group_Detail where [Sub Category] like '" + txtsearch.Text + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
    }

}