using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class OrderDetail
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public virtual int Count { get; set; }

        [DataMember]
        public virtual Order Order { get; set; }

        public void CoupyValues(OrderDetail orderDetail)
        {
            this.Id = orderDetail.Id;
            this.Product.CopyValues(orderDetail.Product);
            this.Count = orderDetail.Count;
        }
    }
}