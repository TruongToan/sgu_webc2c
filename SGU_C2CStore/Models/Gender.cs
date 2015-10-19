using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public enum Gender
    {
        [Display(Name = "Nam")]
        Man,
        [Display(Name = "Nữ")]
        Woman,
        [Display(Name = "Khác")]
        Other
    }
}