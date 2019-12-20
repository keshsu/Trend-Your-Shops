using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trend_Your_Shop_REPRISE.Admin
{
    public partial class passwordChange : UserControl
    {
        public passwordChange()
        {
            InitializeComponent();
        }

        private static passwordChange _instance;

        public static passwordChange Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new passwordChange();
                return _instance;
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {

        }
    }
}
