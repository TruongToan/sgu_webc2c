using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [DataMember]
        public virtual DateTime OrderTime { get; set; }

        public virtual string BuyerId { get; set; }

        [DataMember]
        public virtual User Buyer { get; set; }

        public void CopyValues(Order order)
        {
            this.Id = order.Id;
            this.OrderTime = order.OrderTime;
            this.Buyer.CopyValues(order.Buyer);
            foreach (OrderDetail detail in order.OrderDetails)
            {
                OrderDetail newDetail = new OrderDetail();
                newDetail.CoupyValues(detail);
                this.OrderDetails.Add(newDetail);
            }
        }
    }
}