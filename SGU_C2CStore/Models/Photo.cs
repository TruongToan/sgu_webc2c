using System.ComponentModel.DataAnnotations;

namespace SGU_C2CStore.Models
{
    public class Photo
    {
        public virtual int Id { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public virtual int ProductId { get; set; }

        public virtual string URL { get; set; }

        [Display(Name = "Sản phẩm")]
        public virtual Product Product { get; set; }
    }
}