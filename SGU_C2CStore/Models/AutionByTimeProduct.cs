using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class AutionByTimeProduct : AutionProduct
    {
        [Display(Name = "Thời gian bắt đầu")]
        public virtual DateTime StartTime { get; set; }

        [Display(Name = "Thời gian kết thúc")]
        public virtual DateTime EndTime { get; set; }
    }
}