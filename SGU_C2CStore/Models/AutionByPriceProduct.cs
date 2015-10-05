using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionByPriceProduct : AutionProduct
    {
        [Display(Name = "Giá khởi điểm")]
        public virtual int MinPrice { get; set; }

        [Display(Name = "Giá mong đợi")]
        public virtual int ExpectedPrice { get; set; }
    }
}