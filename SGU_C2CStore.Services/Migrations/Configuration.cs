using SGU_C2CStore.Services.DAL;
using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SGU_C2CStore.Services.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<SGUStoreServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SGUStoreServiceContext context)
        {
            context.Users.Add(new User() { Id = "admin", UserName = "Admin", Email = "admin@gmail.com" });
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

            User u = context.Users.FirstOrDefault();
            Random r = new Random();
            var Products = new List<Product>()
            {
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 0", Description = "A product 0", PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 1", Description = "A product 1", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 2", Description = "A product 2", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 3", Description = "A product 3", Price = r.Next(10000), CategoryId=2, Owner = u},
                new Product() {Name = "Product 4", Description = "A product 4", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 5", Description = "A product 5", Price = r.Next(10000), CategoryId=1, Owner = u},
                new Product() {Name = "Product 6", Description = "A product 6", Price = r.Next(10000), CategoryId=4, Owner = u},
                new Product() {Name = "Product 7", Description = "A product 7", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 8", Description = "A product 8", Price = r.Next(10000), CategoryId=3, Owner = u},
                new Product() {Name = "Product 9", Description = "A product 9", Price = r.Next(10000), CategoryId=1, Owner = u}
            };
            Products.ForEach(e => context.Products.Add(e));
            context.SaveChanges();

            var Autions = new List<Auction>();
            for(int i = 1; i <= 20; i++)
            {
                int id = r.Next(20);
                Autions.Add(new Auction() {
                    Item = context.Products.Where(e => e.Id == id).FirstOrDefault(),
                    BestBid = 0,
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now
                });
            }
            Autions.ForEach(e => context.AutionProducts.Add(e));
            context.SaveChanges();
        }
    }
}
