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

namespace Trend_Your_Shop_REPRISE.Admin
{
    public partial class Add_Company : UserControl
    {
        public Add_Company()
        {
            InitializeComponent();
        }

        private static Add_Company _instance;

        public static Add_Company Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Add_Company();
                return _instance;
            }
        }

        private void Add_Company_Load(object sender, EventArgs e)
        {

        }
        string imageFolder = Application.StartupPath + "\\images\\";

        private void Pur_Add_Info_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "insert into Company_Detail(TIN_No,Telephone,Fax,[Mobile 1],[Mobile 2],Name,Address,[Full Address],[E-mail],Website,WalpaperLogo,Watermark) values ('" + pan_no_txt.Text + "','" + txtTelephone.Text + "','" + txtFax.Text + "','" + txtmobile1.Text + "','" + txtmobile2.Text + "','" + cmpName.Text + "','" + cmpAddress.Text + "','" + cmpFullAddress.Text + "','" + cmp_email.Text + "','" + cmp_Website.Text + "','" + cmp_walpaper.Text + "','" + cmp_watermark.Text + "')";
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            File.Copy(logoDialog.FileName, imageFolder + logoDialog.SafeFileName, true);
            File.Copy(watermarkDialog.FileName, imageFolder + watermarkDialog.SafeFileName, true);
        }

        private void btnWalpaper_Click(object sender, EventArgs e)
        {
            // upload
            logoDialog.ShowDialog();
            if (!string.IsNullOrEmpty(logoDialog.FileName))
            {
                cmp_walpaper.Text = logoDialog.SafeFileName;
            }

        }

        private void btnWatermark_Click(object sender, EventArgs e)
        {
            watermarkDialog.ShowDialog();
            if (!string.IsNullOrEmpty(watermarkDialog.FileName))
            {
                cmp_watermark.Text = watermarkDialog.SafeFileName;
            }

        }

        private void Pur_Modify_Info_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update Company_Detail set Telephone = '" + txtTelephone.Text + "',Fax = '" + txtFax.Text + "',[Mobile 1] = '" + txtmobile1.Text + "',[Mobile 2]= '" + txtmobile2.Text + "',Name = '" + cmpName.Text + "',Address = '" + cmpAddress.Text + "',[Full Address] = '" + cmpFullAddress.Text + "',[E-mail] = '" + cmp_email.Text + "',Website = '" + cmp_Website.Text + "',WalpaperLogo = '" + cmp_walpaper.Text + "',Watermark = '" + cmp_watermark.Text + "' where TIN_No = '" + pan_no_txt.Text + "'";
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            File.Copy(logoDialog.FileName, imageFolder + logoDialog.SafeFileName);
            File.Copy(watermarkDialog.FileName, imageFolder + watermarkDialog.SafeFileName);
        }

        private void pan_no_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(pan_no_txt.Text)) return;

            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MR6JCUA\\MSSQLSERVERDEV;Initial Catalog=TrendYourShops;Persist Security Info=True;User ID=sa;Password=test");

            SqlCommand cmd = new SqlCommand("Select TIN_No,Telephone,Fax,[Mobile 1],[Mobile 2],Name,Address,[Full Address],[E-mail],Website,WalpaperLogo,Watermark from Company_Detail");
            cmd.CommandType = CommandType.Text;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    txtTelephone.Text = reader["Telephone"].ToString();
                    txtFax.Text = reader["Fax"].ToString();
                    txtmobile1.Text = reader["[Mobile 1]"].ToString();
                    txtmobile2.Text = reader["[Mobile 2]"].ToString();
                    cmpName.Text = reader["Name"].ToString();
                    cmpAddress.Text = reader["Address"].ToString();
                    cmpFullAddress.Text = reader["[Full Address]"].ToString();
                    cmp_email.Text = reader["[E-mail]"].ToString();
                    cmp_Website.Text = reader["Website"].ToString();
                    cmp_walpaper.Text = reader["WalpaperLogo"].ToString();
                    cmp_watermark.Text = reader["Watermark"].ToString();
                }
            }
        }
    }
}
