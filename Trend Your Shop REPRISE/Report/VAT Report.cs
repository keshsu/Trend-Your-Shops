using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trend_Your_Shop_REPRISE
{
    public partial class VAT_Report : Form
    {
        public VAT_Report()
        {
            InitializeComponent();
        }

        private void VATClosebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VATDetailsbtn_Click(object sender, EventArgs e)
        {
            (new VAT_Report_Viewer()).ShowDialog();
        }
    }
}
