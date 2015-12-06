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

        public virtual int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }

        [DataMember]
        public virtual string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public virtual int Price { get; set; }

        [DataMember]
        public virtual DateTime Time { get; set; }
    }
}