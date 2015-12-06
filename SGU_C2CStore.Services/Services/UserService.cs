using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGU_C2CStore.Services.Models;
using SGU_C2CStore.Services.DAL;
using System.ServiceModel;

namespace SGU_C2CStore.Services.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService : IUserService
    {
        SGUStoreServiceContext db = new SGUStoreServiceContext();
        public List<User> GetAllUser()
        {

            return TranslateListEntityUser(db.Users.ToList());

        }

        public User TranslateEntityUser(User user)
        {
            throw new NotImplementedException();
        }


        public List<User> TranslateListEntityUser(List<User> users)
        {
            throw new NotImplementedException();
        }
    }
}