using System;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class AuctionComment
    {
        [DataMember]
        public virtual int Id { get; set; }
        
        public virtual Auction Auction { get; set; }

        [DataMember]
        public virtual User CommentUser { get; set; }

        [DataMember]
        public virtual string Content { get; set; }

        [DataMember]
        public virtual DateTime Time { get; set; }
        
    }
}