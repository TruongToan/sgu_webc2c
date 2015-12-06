using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class Auction
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        public virtual int CategoryId { get; set; }

        [DataMember]
        public virtual Category Category { get; set; }

        [DataMember]
        public virtual int Price { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string PhotoUrl { get; set; }

        [DataMember]
        public virtual bool IsApproval { get; set; }

        [DataMember]
        public virtual User Owner { get; set; }

        public virtual string OwnerId { get; set; }

        [DataMember]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        public virtual DateTime EndTime { get; set; }

        [DataMember]
        public virtual int BestBid { get; set; }

        [DataMember]
        public virtual AuctionStatus AutionStatus { get; set; }

        [DataMember]
        public virtual ICollection<Bid> Bids { get; set; }

        [DataMember]
        public virtual ICollection<AuctionComment> AuctionComments { get; set; }
    }
}