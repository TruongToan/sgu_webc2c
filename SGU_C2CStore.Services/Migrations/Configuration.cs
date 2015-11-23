using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SGU_C2CStore.Services.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<SGU_C2CStore.Services.DAL.SGUStoreServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SGU_C2CStore.Services.DAL.SGUStoreServiceContext context)
        {
            context.Users.Add(new ApplicationUser() { UserName = "Admin", Email = "admin@gmail.com" });
            context.SaveChanges();

            var Categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Phụ kiện" },
                new Category() { Id = 2, Name = "Điện thoại" },
                new Category() { Id = 3, Name = "Máy tính, laptop" },
                new Category() { Id = 4, Name = "Khác" }
            };
            Categories.ForEach(e => context.Categories.Add(e));
            context.SaveChanges();

            ApplicationUser u = context.Users.FirstOrDefault();
            var Products = new List<Product>()
            {
                new Product() {Name = "Product 1", Description = "A product 1", Price=10, CategoryId=1, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 2", Description = "A product 2", Price=11, CategoryId=1, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 3", Description = "A product 3", Price=12, CategoryId=2, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 4", Description = "A product 4", Price=13, CategoryId=1, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 5", Description = "A product 5", Price=14, CategoryId=1, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 6", Description = "A product 6", Price=15, CategoryId=4, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 7", Description = "A product 7", Price=16, CategoryId=3, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 8", Description = "A product 8", Price=17, CategoryId=3, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 9", Description = "A product 9", Price=18, CategoryId=1, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
                new Product() {Name = "Product 10", Description = "A product 10", Price=19, CategoryId=4, CreateTime = DateTime.Now, UpdateTime = DateTime.Now, OwnerId = u.Id},
            };
            Products.ForEach(e => context.Products.Add(e));
            context.SaveChanges();
        }
    }
}
