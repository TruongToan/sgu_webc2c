using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class Product
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

        public virtual string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        [DataMember]
        public virtual DateTime UpdateTime { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


        public void CopyValues(Product p)
        {
            Name = p.Name;
            Category = p.Category;
            Price = p.Price;
            Description = p.Description;
            IsApproval = p.IsApproval;
            Owner = p.Owner;
            PhotoUrl = p.PhotoUrl;
        }
    }
}