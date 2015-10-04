using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionProduct : Product
    {
        public virtual int CurrentPrice { get; set; }
        public virtual AutionStatus AutionStatus { get; set; }
    }
}