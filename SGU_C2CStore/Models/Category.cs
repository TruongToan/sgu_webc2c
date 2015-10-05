using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Category
    {
        [Display(Name = "Mã số")]
        public virtual int CategoryId { get; set; }

        [Display(Name = "Tên loại")]
        public virtual string Name { get; set; }

        [Display(Name = "Mô tả")]
        public virtual string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}