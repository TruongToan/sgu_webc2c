using SGU_C2CStore.Services.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace SGU_C2CStore.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IStoreService : IBaseProductService
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

        [OperationContract]
        List<Product> GetUserProducts(string UserId);

        [OperationContract]
        List<Product> GetTopPriceProducts(int limit);

        [OperationContract]
        void UpdateProduct(Product product);

        [OperationContract]
        void DeleteProduct(int Id);

        [OperationContract]
        void Comment(Comment comment);
    }
}
