using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Service.Models
{
    [DataContract]
    public class Product
    {
        private int id;
        private string name;
        private int price;
        private string description;

        [DataMember]
        public int Id {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int CategoryId { get; set; }

        //[DataMember]
        public virtual Category Category { get; set; }

        [DataMember]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}