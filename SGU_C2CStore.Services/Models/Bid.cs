using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class Bid
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual int AuctionId { get; set; }

        [DataMember]
        public virtual Auction Auction { get; set; }

        [DataMember]
        public virtual string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public virtual int Price { get; set; }

        [DataMember]
        public virtual DateTime Time { get; set; }

        public void CopyValues(Bid bid)
        {
            if (bid == null) return;
            this.Id = bid.Id;
            this.Auction.CopyValues(bid.Auction);
            this.Price = bid.Price;
            this.User.CopyValues(bid.User);
        }
    }
}