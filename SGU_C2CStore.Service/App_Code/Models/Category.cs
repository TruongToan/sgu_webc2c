using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Service.Models
{
    [DataContract]
    public class Category
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}