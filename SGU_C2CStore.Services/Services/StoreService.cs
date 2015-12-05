using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SGU_C2CStore.Services.Models;
using SGU_C2CStore.Services.DAL;
using System;

namespace SGU_C2CStore.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class StoreService : IStoreService
    {
        SGUStoreServiceContext Db = new SGUStoreServiceContext();

        #region Service Information
        
        /// <summary>
        /// Get service information
        /// </summary>
        /// <returns>Service Information</returns>
        public string GetServiceInfo()
        {
            return "This is Product Service of SGU Store";
        }

        #endregion

        #region Product Get Services

        /// <summary>
        /// Get first 100 products in stock
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product> GetAllProducts()
        {
            return TranslateListEntityProduct(Db.Products.Take(100).ToList());
        }

        /// <summary>
        /// Get first <paramref name="count"/> product
        /// </summary>
        /// <param name="count">Number of product to take</param>
        /// <returns></returns>
        public List<Product> GetAllProductsLimit(int count)
        {
            return TranslateListEntityProduct(Db.Products.Take(count).ToList());
        }

        /// <summary>
        /// Get <paramref name="count"/> products from <paramref name="index"/>/>
        /// </summary>
        /// <param name="index">From</param>
        /// <param name="count">Number of product</param>
        /// <returns></returns>
        public List<Product> GetProductsFromIndex(int index, int count)
        {
            return TranslateListEntityProduct(Db.Products.OrderByDescending(e => e.CreateTime).Skip(index).Take(count).ToList());
        }

        /// <summary>
        /// Get products by name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Product> GetProductsByName(string Name)
        {
            return TranslateListEntityProduct(Db.Products.Where(e => e.Name.Contains(Name)).ToList());
        }

        /// <summary>
        /// Get products by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product GetProductsById(int Id)
        {
            return TranslateEntityProduct(Db.Products.Where(e => e.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// Get products by price
        /// </summary>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        public List<Product> GetProductsByPrice(int From, int To)
        {
            return TranslateListEntityProduct(Db.Products.Where(e => e.Price >= From && e.Price < To).ToList());
        }

        /// <summary>
        /// Get product by category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public List<Product> GetProductsByCategory(int CategoryId)
        {
            return TranslateListEntityProduct(Db.Products.Where(e => e.CategoryId == CategoryId).ToList());
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
            p.Owner = product.Owner;

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

        /// <summary>
        /// Get all products of user
        /// </summary>
        /// <param name="UserId">User Id</param>
        /// <returns></returns>
        public List<Product> GetUserProducts(string UserId)
        {
            return TranslateListEntityProduct(Db.Products.Where(e => e.Owner.Id.Equals(UserId)).ToList());
        }

        /// <summary>
        /// Get top-price products
        /// </summary>
        /// <param name="limit">Limit items</param>
        /// <returns></returns>
        public List<Product> GetTopPriceProducts(int limit)
        {
            return TranslateListEntityProduct(Db.Products.OrderByDescending(e => e.Price).Take(limit).ToList());
        }

        public void UpdateProduct(Product product)
        {
            Product p = Db.Products.FirstOrDefault(e => e.Id == product.Id);
            if (p != null)
            {
                p.CopyValues(product);
                Db.SaveChanges();
            }
            throw new FaultException("Product not found");
        }

        public void DeleteProduct(int Id)
        {
            Product p = Db.Products.FirstOrDefault(e => e.Id == Id);
            if (p != null)
            {
                Db.Products.Remove(p);
                Db.SaveChanges();
            }
            throw new FaultException("Product not found");
        }

        /// <summary>
        /// Comment product
        /// </summary>
        /// <param name="comment">Comment</param>
        public void Comment(Comment comment)
        {
            Db.Comments.Add(comment);
            Db.SaveChanges();
        }

        /// <summary>
        /// Post product to store to sell
        /// </summary>
        /// <param name="product">Your product</param>
        public void PostProduct(Product product)
        {
            Db.Products.Add(product);
            Db.SaveChanges();
        }

        #endregion

        #region Product Post Services



        #endregion
    }
}
