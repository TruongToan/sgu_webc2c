using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGUStoreService.Data.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}