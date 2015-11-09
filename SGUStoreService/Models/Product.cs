using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGUStoreService.Models
{
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

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}