using SGU_C2CStore.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

[ServiceContract]
public interface IAdminService : IBaseProductService
{
    [OperationContract]
    string GetServiceInfo();

    [OperationContract]
    List<Product> GetAllProducts();

    [OperationContract]
    List<Product> GetPendingProducts();

    [OperationContract]
    void ApprovalProduct(int Id);

    [OperationContract]
    void DeleteProduct(int Id);
}