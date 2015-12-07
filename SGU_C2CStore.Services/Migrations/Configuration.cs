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
            context.Users.Add(new User() { UserName = "Admin", Email = "admin@gmail.com" });
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
            var Auctions = new List<Auction>()
            {
                new Auction() {Name = "Auction 0", Description = "A Auction 0",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 1",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 2",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 3",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.Cancelled,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 5",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.Closed,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 6",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.Pending,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Auction 0", Description = "A Auction 7",
                    PhotoUrl = "https://allhiphop.files.wordpress.com/2015/01/screen-shot-2015-01-28-at-1-02-57-pm.png",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u,
                    BestBid = 0,
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
            };
            Auctions.ForEach(e => context.AutionProducts.Add(e));
            context.SaveChanges();
        }
    }
}
