using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public enum AutionStatus
    {
        [Display(Name = "Đang chờ xét duyệt")]
        Pending,
        [Display(Name = "Đã mở")]
        Opened,
        [Display(Name = "Đã đóng")]
        Closed 
    }
}