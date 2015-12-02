using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class AuctionByPriceProduct : AuctionProduct
    {
        [DataMember]
        public virtual int StartPrice { get; set; }

        [DataMember]
        public virtual int WinPrice { get; set; }

        public void CopyValues(AuctionByPriceProduct p)
        {
            base.CopyValues(p);
            this.StartPrice = p.StartPrice;
            this.WinPrice = p.WinPrice;
        }
    }
}