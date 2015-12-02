using System;

namespace SGU_C2CStore.Services.Models
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual string CommentUserId { get; set; }
        public virtual ApplicationUser CommentUser { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Time { get; set; }
    }
}