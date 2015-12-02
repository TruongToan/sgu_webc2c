using System;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class AuctionByTimeProduct : AuctionProduct
    {
        [DataMember]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        public virtual DateTime EndTime { get; set; }

        public void CopyValues(AuctionByTimeProduct p)
        {
            base.CopyValues(p);
            this.StartTime = p.StartTime;
            this.EndTime = p.EndTime;
        }
    }
}