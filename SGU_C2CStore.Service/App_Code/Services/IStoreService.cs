using SGU_C2CStore.Service.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SGU_C2CStore.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService
    {
        [OperationContract]
        string GetServiceInfo();

        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        List<Product> GetAllProductsLimit(int count);

        [OperationContract]
        List<Product> GetProductsFromIndex(int index, int count);

        [OperationContract]
        List<Product> GetProductsByCategory(int CategoryId);

        [OperationContract]
        List<Product> GetProductsByName(string Name);

        [OperationContract]
        Product GetProductsById(int Id);

        [OperationContract]
        List<Product> GetProductsByPrice(int From, int To);

        Product TranslateEntityProduct(Product product);

        List<Product> TranslateListEntityProduct(List<Product> products);
    }
}
