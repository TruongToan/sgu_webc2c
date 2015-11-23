using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SGU_C2CStore.Services
{
    [ServiceContract]
    public interface IBaseProductService
    {
        [OperationContract]
        Product TranslateEntityProduct(Product product);

        [OperationContract]
        List<Product> TranslateListEntityProduct(List<Product> products);
    }
}