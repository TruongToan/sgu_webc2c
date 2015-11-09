using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SGUStoreService.Models;
using SGUStoreService.DAL;

namespace SGUStoreService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in both code and config file together.
    public class ProductService : IProductService
    {

        public List<Product> GetAllProduct()
        {
            using (SGUStoreServiceContext Db = new SGUStoreServiceContext())
            {
                return Db.Products.Take(100).ToList();
            }
        }

        public List<Product> GetProductByName(string Name)
        {
            using (SGUStoreServiceContext Db = new SGUStoreServiceContext())
            {
                return Db.Products.Where(e => e.Name.Contains(Name)).ToList();
            }
        }

        public List<Product> GetProductByPrice(int From, int To)
        {
            using (SGUStoreServiceContext Db = new SGUStoreServiceContext())
            {
                return Db.Products.Where(e => e.Price >= From && e.Price < To).ToList();
            }
        }

        public List<Product> GetProductByCategory(int CategoryId)
        {
            using (SGUStoreServiceContext Db = new SGUStoreServiceContext())
            {
                return Db.Products.Where(e => e.CategoryId == CategoryId).ToList();
            }
        }
    }
}
