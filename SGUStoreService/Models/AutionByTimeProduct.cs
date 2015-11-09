using System;

namespace SGUStoreService.Models
{
    public class AutionByTimeProduct : AutionProduct
    {
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}