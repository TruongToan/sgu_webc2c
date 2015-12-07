using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string UserName { get; set; }

        [DataMember]
        public virtual string Email { get; set; }

        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual string PhoneNumber { get; set; }

        public virtual ICollection<Auction> OwnAuctions { get; set; }
        
        public virtual ICollection<Bid> Bids { get; set; }

        public void CopyValues(User user)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Email = user.Email;
            this.Address = user.Address;
            this.PhoneNumber = user.PhoneNumber;
        }
    }
}