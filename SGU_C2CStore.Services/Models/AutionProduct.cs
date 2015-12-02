using System.Collections.Generic;

namespace SGU_C2CStore.Services.Models
{
    public class AutionProduct : Product
    {
        public virtual int CurrentPrice { get; set; }
        public virtual AutionStatus AutionStatus { get; set; }

        public virtual List<ApplicationUser> Users { get; set; }
    }
}