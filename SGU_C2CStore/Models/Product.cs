using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
        public virtual int Price { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<string> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}