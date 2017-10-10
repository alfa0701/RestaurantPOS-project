using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaierPOS
{
   public class Order
    {
        public int _orderId { get; set; }
        public int EmpId { get; set; }
        public int TableNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int GuestCount { get; set; }
    }
}
