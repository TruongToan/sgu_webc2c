using System;
using System.Collections.Generic;

namespace SGUStoreService.Models
{
    public class User
    {
        public virtual string Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Username { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> Product { get; set; }
    }
}