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
        public virtual Product Item { get; set; }

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

        public void CopyValues(Auction p)
        {
            if (p == null) return;
            this.Item.CopyValues(Item);
            this.BestBid = p.BestBid;
            this.StartTime = p.StartTime;
            this.EndTime = p.EndTime;
            this.BestBid = p.BestBid;
            this.AutionStatus = p.AutionStatus;
        }
    }
}