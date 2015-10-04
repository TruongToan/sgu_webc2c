using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual DateTime OrderTime { get; set; }
        public virtual DateTime ShipTime { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}