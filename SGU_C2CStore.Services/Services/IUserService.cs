using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SGU_C2CStore.Services
{
    [ServiceContract(Namespace = "SGU_C2CStore.Services.Identity")]
    public interface IUserService
    {
        [OperationContract]
        List<User> GetAllUser();
    }
}