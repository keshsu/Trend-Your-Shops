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

namespace Trend_Your_Shop_REPRISE.Admin
{
    public partial class Main_Menu : Form
    {
        //assigning the string that shows the login is by user or the Admin 
        public Main_Menu(string ms)
        {
            InitializeComponent();

            if (ms.ToString() != "Admin")
            {
                User.Text = "You are Login as User :- " + ms.ToString();

                adminStripMenuItem2.Visible = false;
                advanceToolsToolStripMenuItem.Visible = false;

            }
            else
            {
                User.Text = "You are Login as " + ms.ToString();

                adminStripMenuItem2.Visible = true;
                masterToolStripMenuItem.Visible = false;
                stockToolStripMenuItem.Visible = false;
            }
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Home.Instance))
            {
                panel4.Controls.Add(Home.Instance);
                Home.Instance.Dock = DockStyle.Fill;
                Home.Instance.BringToFront();
            }
            else
            {
                Home.Instance.BringToFront();
            }

        }

        //Dashboard
        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Home.Instance))
            {
                panel4.Controls.Add(Home.Instance);
                Home.Instance.Dock = DockStyle.Fill;
                Home.Instance.BringToFront();
            }
            else
            {
                Home.Instance.BringToFront();
            }
        }

        //admin add company details Button
        private void companyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Add_Company.Instance))
            {
                panel4.Controls.Add(Add_Company.Instance);
                Add_Company.Instance.Dock = DockStyle.Fill;
                Add_Company.Instance.BringToFront();
            }
            else
            {
                Add_Company.Instance.BringToFront();
            }
        }

        //admin add user Button
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new User_Detail()).ShowDialog();
        }

        //admin password change Button
        private void passwordChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(passwordChange.Instance))
            {
                panel4.Controls.Add(passwordChange.Instance);
                passwordChange.Instance.Dock = DockStyle.Fill;
                passwordChange.Instance.BringToFront();
            }
            else
            {
                passwordChange.Instance.BringToFront();
            }
            //nothing here
        }

        //Exit the Form
        private void exittoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //master Entry manage product Button
        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Item_and_Prices.Instance))
            {
                panel4.Controls.Add(Item_and_Prices.Instance);
                Item_and_Prices.Instance.Dock = DockStyle.Fill;
                Item_and_Prices.Instance.BringToFront();
            }
            else
            {
                Item_and_Prices.Instance.BringToFront();
            }
        }

        //master Entry Receipt Button
        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Vendor.Instance))
            {
                panel4.Controls.Add(Vendor.Instance);
                Vendor.Instance.Dock = DockStyle.Fill;
                Vendor.Instance.BringToFront();
            }
            else
            {
                Vendor.Instance.BringToFront();
            }
        }

        //master Entry units Button
        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Unit_Details.Instance))
            {
                panel4.Controls.Add(Unit_Details.Instance);
                Unit_Details.Instance.Dock = DockStyle.Fill;
                Unit_Details.Instance.BringToFront();
            }
            else
            {
                Unit_Details.Instance.BringToFront();
            }
        }

        //master Entry vat Button
        private void vATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(VAT_Entries.Instance))
            {
                panel4.Controls.Add(VAT_Entries.Instance);
                VAT_Entries.Instance.Dock = DockStyle.Fill;
                VAT_Entries.Instance.BringToFront();
            }
            else
            {
                VAT_Entries.Instance.BringToFront();
            }
        }


        //master Entry category Button
        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Groups.Instance))
            {
                panel4.Controls.Add(Groups.Instance);
                Groups.Instance.Dock = DockStyle.Fill;
                Groups.Instance.BringToFront();
            }
            else
            {
                Groups.Instance.BringToFront();
            }
        }

        //master Entry Receipt Button
        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Complain cmpl = new Complain();
            cmpl.ShowDialog();
        }

        //Adjust Stock purchase button Click
        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Purchase_Details.Instance))
            {
                panel4.Controls.Add(Purchase_Details.Instance);
                Purchase_Details.Instance.Dock = DockStyle.Fill;
                Purchase_Details.Instance.BringToFront();
            }
            else
            {
                Purchase_Details.Instance.BringToFront();
            }
        }

        //Adjust Stock add stock button Click
        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!panel4.Controls.Contains(Stock_Details.Instance))
            {
                panel4.Controls.Add(Stock_Details.Instance);
                Stock_Details.Instance.Dock = DockStyle.Fill;
                Stock_Details.Instance.BringToFront();
            }
            else
            {
                Stock_Details.Instance.BringToFront();
            }
        }
        
        //Adjust Stock sale button Click
        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sale_Stock_Reports salstkent = new Sale_Stock_Reports();
            salstkent.ShowDialog();
        }

        //Adjust Stock advance Purchase button Click
        private void advancePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase_Stock_Entry pse = new Purchase_Stock_Entry();
            pse.ShowDialog();
        }

        //report generation daily bill report Button Click
        private void dailyBillReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily_Bill_Payment DBp = new Daily_Bill_Payment();
            DBp.ShowDialog();
        }

        //report generation item report Button Click
        private void itemRateListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Item_Rate_Record()).ShowDialog();
        }

        //report generation stock report Button Click
        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Report stkrep = new Stock_Report();
            stkrep.ShowDialog();
        }

        //report generation vat report Button Click
        private void vATReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VAT_Report vatr = new VAT_Report();
            vatr.ShowDialog();
        }

        //report generation customer report Button Click
        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remaining Part
        }

        //report generation Purchase report Button Click
        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Purchase_Records()).ShowDialog();
        }

        //advance tool send sms Button
        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remains
        }

        //advance tool auto email backup Button
        private void autoEmailBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Auto_Email_Backup()).Show();
        }

        //backup Button Click
        private void backuptoolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        //Logout Button Click
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "Update Attendence_System set Endtime = '" + DateTime.Now + "' where Endtime = '" + DateTime.Today + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();
            Login lgn = new Login();
            this.Hide();
            lgn.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
