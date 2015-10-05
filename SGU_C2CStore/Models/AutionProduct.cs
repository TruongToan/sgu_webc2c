using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionProduct : Product
    {
        [Display(Name = "Giá hiện tại")]
        public virtual int CurrentPrice { get; set; }

        [Display(Name = "Trạng thái")]
        public virtual AutionStatus AutionStatus { get; set; }
    }
}