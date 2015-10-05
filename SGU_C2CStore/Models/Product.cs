using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Product
    {
        [Display(Name = "Mã sản phẩm")]
        public virtual int ProductId { get; set; }

        [Display(Name = "Mã loại")]
        public virtual int CategoryId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public virtual string Name { get; set; }

        [Display(Name = "Loại")]
        public virtual Category Category { get; set; }

        [Display(Name = "Giá bán")]
        public virtual int Price { get; set; }

        [Display(Name = "Mô tả")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        [Display(Name = "Danh mục ảnh")]
        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}