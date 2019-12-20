using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trend_Your_Shop_REPRISE
{
    class OrderDetails
    {
        public int orderId { get; set; }
        public string ProductName { get; set; }
        public int quantity { get; set; }
        public int waranttee { get; set; }
        public decimal rate { get; set; }
        public decimal vat { get; set; }
        public decimal discount { get; set; }
        public decimal Nettotal
        {
            get
            {
                return quantity * rate - quantity * rate * discount + quantity * vat * rate;
            }
            set
            {

            }
        }
        public string Billtype { get; set; }
    }
}
