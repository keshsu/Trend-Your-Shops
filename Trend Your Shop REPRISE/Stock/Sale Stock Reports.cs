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
using Trend_Your_Shop_REPRISE.Master_Enrty;

namespace Trend_Your_Shop_REPRISE
{
    public partial class Sale_Stock_Reports : Form
    {
        //initializing the connection to sql server
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

        public Sale_Stock_Reports()
        {
            InitializeComponent();
        }

        private void Sale_Stock_Reports_Load(object sender, EventArgs e)
        {
            //checking the connection state is open or not
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            slidepanel.Location = new Point(3, 67);
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Clients.Instance))
            {
                panel3.Controls.Add(Clients.Instance);
                Clients.Instance.Dock = DockStyle.Fill;
                Clients.Instance.BringToFront();
            }
            else
            {
                Clients.Instance.BringToFront();
            }
            slidepanel.Location = new Point(80, 67);
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Client_View.Instance))
            {
                panel3.Controls.Add(Client_View.Instance);
                Client_View.Instance.Dock = DockStyle.Fill;
                Client_View.Instance.BringToFront();
            }
            else
            {
                Client_View.Instance.BringToFront();
            }
            slidepanel.Location = new Point(157, 67);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Stock_Details.Instance))
            {
                panel3.Controls.Add(Stock_Details.Instance);
                Stock_Details.Instance.Dock = DockStyle.Fill;
                Stock_Details.Instance.BringToFront();
            }
            else
            {
                Stock_Details.Instance.BringToFront();
            }
            slidepanel.Location = new Point(234, 67);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(View_Stock.Instance))
            {
                panel3.Controls.Add(View_Stock.Instance);
                View_Stock.Instance.Dock = DockStyle.Fill;
                View_Stock.Instance.BringToFront();
            }
            else
            {
                View_Stock.Instance.BringToFront();
            }
            slidepanel.Location = new Point(311, 67);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Sales_Details.Instance))
            {
                panel3.Controls.Add(Sales_Details.Instance);
                Sales_Details.Instance.Dock = DockStyle.Fill;
                Sales_Details.Instance.BringToFront();
            }
            else
            {
                Sales_Details.Instance.BringToFront();
            }
            slidepanel.Location = new Point(388, 67);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            (new Sale_Bill_Report()).ShowDialog();
            slidepanel.Location = new Point(465, 67);
        }

        private void X_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

