﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Service.Models
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

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public void CopyValues(Product p)
        {
            Name = p.Name;
            CategoryId = p.CategoryId;
            Price = p.Price;
            Description = p.Description;
            IsApproval = p.IsApproval;
            UserId = p.UserId;
            PhotoUrl = p.PhotoUrl;
        }
    }
}