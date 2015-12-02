using System;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public virtual User CommentUser { get; set; }

        [DataMember]
        public virtual string Content { get; set; }

        [DataMember]
        public virtual DateTime Time { get; set; }

        public void CopyValues(Comment comment)
        {
            this.Id = comment.Id;
            this.Product.CopyValues(comment.Product);
            this.CommentUser.CopyValues(comment.CommentUser);
            this.Content = comment.Content;
            this.Time = comment.Time;
        }
    }
}