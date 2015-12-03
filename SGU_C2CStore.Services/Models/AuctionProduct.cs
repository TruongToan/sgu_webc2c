using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class AuctionProduct : Product
    {
        [DataMember]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        public virtual DateTime EndTime { get; set; }

        [DataMember]
        public virtual int BestBid { get; set; }

        [DataMember]
        public virtual AuctionStatus AutionStatus { get; set; }

        public void CopyValues(AuctionProduct p)
        {
            base.CopyValues(p);
            this.BestBid = p.BestBid;
            this.StartTime = p.StartTime;
            this.EndTime = p.EndTime;
            this.BestBid = p.BestBid;
            this.AutionStatus = p.AutionStatus;
        }
    }
}