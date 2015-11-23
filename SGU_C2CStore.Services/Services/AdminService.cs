using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGU_C2CStore.Services.Models;
using System.ServiceModel;
using SGU_C2CStore.Services.DAL;

[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
public class AdminService : IAdminService
{
    SGUStoreServiceContext Db = new SGUStoreServiceContext();

    /// <summary>
    /// Get service information
    /// </summary>
    /// <returns></returns>
    public string GetServiceInfo()
    {
        return "This is Admin Service";
    }

    /// <summary>
    /// Approval pending product
    /// </summary>
    /// <param name="Id">Product Id</param>
    /// <returns></returns>
    public void ApprovalProduct(int Id)
    {
        var product = Db.Products.FirstOrDefault(e => e.Id == Id);
        if (product != null && !product.IsApproval)
        {
            product.IsApproval = true;
            Db.SaveChanges();
        }
        throw new FaultException("Product not found");
    }

    /// <summary>
    /// Delete product by Id
    /// </summary>
    /// <param name="Id">Product Id</param>
    /// <returns></returns>
    public void DeleteProduct(int Id)
    {
        var product = Db.Products.FirstOrDefault(e => e.Id == Id);
        if (product != null && !product.IsApproval)
        {
            Db.Products.Remove(product);
            Db.SaveChanges();
        }
        throw new FaultException("Product not found");
    }

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns></returns>
    public List<Product> GetAllProducts()
    {
        return TranslateListEntityProduct(Db.Products.ToList());
    }

    /// <summary>
    /// Get all product which is not approval yet
    /// </summary>
    /// <returns></returns>
    public List<Product> GetPendingProducts()
    {
        return TranslateListEntityProduct(Db.Products.Where(e => e.IsApproval == false).ToList());
    }

    /// <summary>
    /// Make lazyload entity into real product object
    /// </summary>
    /// <param name="product">The lazyload entity product</param>
    /// <returns></returns>
    public Product TranslateEntityProduct(Product product)
    {
        if (product == null) return null;

        Product p = new Product();
        p.Id = product.Id;
        p.Name = product.Name;
        p.Description = product.Description;
        p.Category = product.Category;
        p.Price = product.Price;
        p.PhotoUrl = product.PhotoUrl;
        p.Comments = product.Comments;

        return p;
    }

    /// <summary>
    /// Make lazyload entities into real products object
    /// </summary>
    /// <param name="products">The list of lazyload entities product</param>
    /// <returns></returns>
    public List<Product> TranslateListEntityProduct(List<Product> products)
    {
        List<Product> result = new List<Product>();
        foreach (Product product in products)
        {
            result.Add(TranslateEntityProduct(product));
        }
        return result;
    }
}