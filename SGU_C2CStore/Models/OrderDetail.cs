using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class OrderDetail
    {
        public virtual int OrderDetailId { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Count { get; set; }
        public virtual Order Order { get; set; }
    }
}