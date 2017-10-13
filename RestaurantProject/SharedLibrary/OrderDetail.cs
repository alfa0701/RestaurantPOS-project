using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
  public  class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public int Status { get; set; }
        public int PaymentId { get; set; }
    }


}
