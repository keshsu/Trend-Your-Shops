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
    public partial class Unit_Details : UserControl
    {
        public Unit_Details()
        {
            InitializeComponent();
        }

        //Connection string to connect database
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        private static Unit_Details _instance;

        public static Unit_Details Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Unit_Details();
                return _instance;
            }
        }

        private void Unit_Details_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            du();
        }

        public void du()
        {
            //data abstraction in a datagridview 
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from UnitDetails ";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(cmd1);
            ds.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void AddUnitBtn_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from UnitDetails where Unit= '" + textBox1.Text + "'";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ds1 = new SqlDataAdapter(cmd1);
            ds1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            count = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (count == 0)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into UnitDetails values('" + textBox1.Text + "')";
                cmd.ExecuteNonQuery();
                du();
            }
            else
            {
                MessageBox.Show("The Unit already exists..");
            }
        }

        private void deleteunitBtn_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "delete from UnitDetails where id = " + id + "";

            cmd2.ExecuteNonQuery();
            du();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please Enter Unit");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }
    }
}
