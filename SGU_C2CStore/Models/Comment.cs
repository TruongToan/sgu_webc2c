using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Comment
    {
        public virtual int CommentId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual string Content { get; set; }
    }
}