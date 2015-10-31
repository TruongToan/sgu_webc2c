using SGUStoreService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGUStoreService.DAL
{
    public class SGUStoreServiceDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<SGUStoreServiceContext>
    {
        protected override void Seed(SGUStoreServiceContext context)
        {
            var Categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Phụ kiện" },
                new Category() { Id = 2, Name = "Điện thoại" },
                new Category() { Id = 3, Name = "Máy tính, laptop" },
                new Category() { Id = 4, Name = "Khác" }
            };
            Categories.ForEach(e => context.Categories.Add(e));
            context.SaveChanges();
        }
    }
}