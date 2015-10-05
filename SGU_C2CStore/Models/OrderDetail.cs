using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class OrderDetail
    {
        [Display(Name = "Mã số")]
        public virtual int OrderDetailId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public virtual int ProductId { get; set; }

        [Display(Name = "Sản phẩm")]
        public virtual Product Product { get; set; }

        [Display(Name = "Số lượng")]
        public virtual int Count { get; set; }

        public virtual Order Order { get; set; }
    }
}