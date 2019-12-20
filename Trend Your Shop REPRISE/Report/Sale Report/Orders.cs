using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trend_Your_Shop_REPRISE.Report.Sale_Report
{
    public class Orders
    {
        public int orderId { get; set; }
        public int userid{ get; set; }
        public string customer{ get; set; }
        public string customer_address{ get; set; }
        public string telephone{ get; set; }
        public DateTime order_date{ get; set; }
    }
}
