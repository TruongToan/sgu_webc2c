using SGUStoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SGUStoreService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProduct();
        [OperationContract]
        List<Product> GetProductByCategory(int CategoryId);
        [OperationContract]
        List<Product> GetProductByName(string Name);
        [OperationContract]
        List<Product> GetProductByPrice(int From, int To);
    }
}
