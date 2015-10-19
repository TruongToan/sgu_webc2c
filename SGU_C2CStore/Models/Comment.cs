using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Comment
    {
        [Display(Name = "Tên loại")]
        public virtual int Id { get; set; }

        [Display(Name = "Sản phẩm")]
        public virtual int ProductId { get; set; }

        [Display(Name = "Sản phẩm")]
        public virtual Product Product { get; set; }

        [Display(Name = "Người bình luận")]
        public virtual string CommentUserId { get; set; }

        [Display(Name = "Người bình luận")]
        public virtual ApplicationUser CommentUser { get; set; }

        [Display(Name = "Nội dung")]
        public virtual string Content { get; set; }

        [Display(Name = "Thời gian")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime Time { get; set; }
    }
}