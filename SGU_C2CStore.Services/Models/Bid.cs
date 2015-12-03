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
        public virtual AuctionProduct Item { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public virtual int Price { get; set; }

        public void CopyValues(Bid bid)
        {
            this.Id = bid.Id;
            this.Item.CopyValues(bid.Item);
            this.Price = bid.Price;
            this.User.CopyValues(bid.User);
        }
    }
}