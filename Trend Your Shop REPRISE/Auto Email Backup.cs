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

namespace Trend_Your_Shop_REPRISE
{
    public partial class Auto_Email_Backup : Form
    {
        public Auto_Email_Backup()
        {
            InitializeComponent();
        }

        private void backUpBtn_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            string dd = d.Day + "-" + d.Month;
            //+dbname+ "_" +dd IS BACKUP FILE NAME
            string servername = textBox3.Text;
            string dbname = "TrendYourShops";

            string qqq = @"Data Source=" + servername + ";Integrated Security=True; Initial Catalog=" + dbname + "";
            SqlConnection con = new SqlConnection(qqq);
            con.Open();

            string str = "USE" + dbname + ";";
            string str1 = "BACKUP DATABASE" + dbname + "TO DISK = 'E:\\Database\\" + dbname + "_" + dd + ".Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'FULL Backup of " + dbname + "';";
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlCommand cmd2 = new SqlCommand(str1, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Successfully Completed BackUp.You can Find this file (DB Name.Bak) in your disk E:\\Database\\");
        }
    }
}
