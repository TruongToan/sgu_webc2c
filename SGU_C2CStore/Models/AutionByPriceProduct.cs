using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionByPriceProduct : AutionProduct
    {
        public virtual int MinPrice { get; set; }
        public virtual int ExpectedPrice { get; set; }
    }
}