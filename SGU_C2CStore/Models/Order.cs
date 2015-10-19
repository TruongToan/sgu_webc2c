using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class Order
    {
        [Display(Name = "Mã hóa đơn")]
        public virtual int Id { get; set; }
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [Display(Name = "Thời gian mua")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime OrderTime { get; set; }

        [Display(Name = "Thời gian giao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime ShipTime { get; set; }

        [Display(Name = "Địa chỉ giao")]
        public virtual string ShipAddress { get; set; }

        [Display(Name = "Người mua")]
        public virtual string UserId { get; set; }

        [Display(Name = "Người mua")]
        public virtual ApplicationUser User { get; set; }
    }
}