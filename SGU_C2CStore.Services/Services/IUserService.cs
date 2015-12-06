using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SGU_C2CStore.Services.Services
{
    public interface IUserService : IBaseUserService
    {
        [OperationContract]
         List<User> GetAllUser();
       
    }
}