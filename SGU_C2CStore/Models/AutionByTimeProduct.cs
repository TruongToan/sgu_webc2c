using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionByTimeProduct : AutionProduct
    {
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}