using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Trend_Your_Shop_REPRISE.Admin;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        Point org = new Point(2, 361);
        Size ors = new Size(87, 40);

        string msg;

        public Login()
        {
            InitializeComponent();
        }

       
        private void Login_Load(object sender, EventArgs e)
        { 
            if (conn.State== ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            txtpassword.UseSystemPasswordChar = true;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            //Exiting the whole program
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void AdminLoginBtn_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "admin")
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Admin_Table where Admin_name='" + txtusername.Text + "' and Admin_Password= '" + txtpassword.Text + "'";
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        msg = "Admin";
                        this.Hide();
                        (new Main_Menu(msg)).ShowDialog();
                        this.Close();
                        //Form1 frm = new Form1();
                        //frm.ShowDialog();
                    }
                    else { MessageBox.Show("invalid username or password"); }

                }
            }
            else
            {
                string user = txtusername.Text.Trim();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from loginTable where [Username]='" + txtusername.Text + "' and [Password]= '" + txtpassword.Text + "' AND ('" + DateTime.Now.ToShortTimeString() + "' BETWEEN [StartTime] AND [EndTime])";
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        conn.Open();
                        SqlCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandText = "Insert into Attendence_System values('" + txtusername.Text + "','" + DateTime.Now + "','" + DateTime.Today + "')";
                        cmd1.CommandType = CommandType.Text;
                        cmd1.ExecuteNonQuery();
                        ///////////
                        msg = txtusername.Text;
                        this.Hide();
                        (new Main_Menu(msg)).ShowDialog();
                        this.Close();
                        //Form1 frm = new Form1();
                        //frm.ShowDialog();
                    }
                    else { MessageBox.Show("invalid Username or password"); }
                }
            }
        }
    }
}
