using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class AuctionProduct : Product
    {
        [DataMember]
        public virtual int CurrentPrice { get; set; }

        [DataMember]
        public virtual AutionStatus AutionStatus { get; set; }
        
        public virtual ICollection<User> Users { get; set; }

        public void CopyValues(AuctionProduct p)
        {
            base.CopyValues(p);
            this.CurrentPrice = p.CurrentPrice;
            this.AutionStatus = p.AutionStatus;
            foreach (User u in p.Users)
            {
                User newUser = new User();
                newUser.CopyValues(u);
                this.Users.Add(newUser);
            }
        }
    }
}