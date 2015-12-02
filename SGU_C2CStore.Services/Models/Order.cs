using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Services.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual DateTime OrderTime { get; set; }
        public virtual DateTime ShipTime { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string BuyerId { get; set; }
        public virtual ApplicationUser Buyer { get; set; }
    }
}