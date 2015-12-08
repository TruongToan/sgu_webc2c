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
            var users = new List<User>()
            {
                new User() { Id = 1, UserName = "admin", Email = "admin@gmail.com", PhoneNumber = "01234657980" },
                new User() { Id = 2, UserName = "linh", Email = "linh@gmail.com", PhoneNumber = "01234657980" },
                new User() { Id = 3, UserName = "toan", Email = "toan@gmail.com", PhoneNumber = "01234657980" },
                new User() { Id = 4, UserName = "linhhuynh", Email = "linhhuynh@gmail.com", PhoneNumber = "01234657980" },
                new User() { Id = 5, UserName = "truongtoan", Email = "truongtoan@gmail.com", PhoneNumber = "01234657980" },

            };
            users.ForEach(e => context.Users.Add(e));

            context.SaveChanges();

            var Categories = new List<Category>()
            {
                new Category() { Id = 3, Name = "Phụ kiện" },
                new Category() { Id = 2, Name = "Điện thoại" },
                new Category() { Id = 1, Name = "Máy tính, laptop" },
                new Category() { Id = 4, Name = "Khác" }
            };
            Categories.ForEach(e => context.Categories.Add(e));
            context.SaveChanges();

            User u1 = context.Users.FirstOrDefault(i => i.Id == 1);
            User u2 = context.Users.FirstOrDefault(i => i.Id == 2);
            User u3 = context.Users.FirstOrDefault(i => i.Id == 3);
            User u4 = context.Users.FirstOrDefault(i => i.Id == 4);
            User u5 = context.Users.FirstOrDefault(i => i.Id == 5);
            Random r = new Random();
            var Auctions = new List<Auction>()
            {
                new Auction() {Name = "Samsung Galaxy A8", Description = "Samsung Galaxy A8 - A800VE",
                    PhotoUrl = "https://cdn1.tgdd.vn/Products/Images/42/73993/samsung-galaxy-a8-a800ve-trang-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u1,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Lenovo A7000 Plus", Description = "Lenovo A7000 Plus",
                    PhotoUrl = "https://cdn2.tgdd.vn/Products/Images/42/73318/lenovo-a7000-plus-den-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Galaxy Note 5", Description = "Samsung Galaxy Note 5",
                    PhotoUrl = "https://cdn1.tgdd.vn/Products/Images/42/72373/samsung-galaxy-note-5-vangdong-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u3,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.New,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "iPhone 6s 16GB", Description = "iPhone 6s 16GB",
                    PhotoUrl = "https://cdn2.tgdd.vn/Products/Images/42/71306/iphone-6s-hong-1-org-6.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u4,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Cancelled,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "HTC One A9", Description = "HTC One A9",
                    PhotoUrl = "https://cdn2.tgdd.vn/Products/Images/42/73268/htc-one-a9-bac-2-org-2.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u5,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Closed,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "SGalaxy S6 Edge Plus", Description = "Samsung Galaxy S6 Edge Plus",
                    PhotoUrl = "https://cdn3.tgdd.vn/Products/Images/42/72530/samsung-galaxy-s6-edge-plus-vang-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u1,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Pending,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "LG G4 Leather", Description = "LG G4 Leather",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/42/71448/lg-g4-nau-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =2, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "HP Stream 13", Description = "HP Stream 13 N2840/2GB/32GB/Win8.1",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/72316/hp-stream-13-timhong-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u3,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Dell Inspiron 3458", Description = "Dell Inspiron 3458 i3 4005U/4G/500G/Win8.1",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/72484/Slider/dell-inspiron-3458-i3-4005u-4g-500g-win81-slider01.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u4,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Asus E402MA", Description = "Asus E402MA N2840/2GB/500GB/Win10",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/73443/Slider/asus-e402ma-n2840-2gb-500gb-win10-slider01.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u5,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Acer ES1 431", Description = "Acer ES1 431 N3050/4GB/500GB/Win10",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/73875/Slider/acer-es1-431-n3700-4gb-500gb-win10-slider02.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u1,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Lenovo Yoga 500", Description = "Lenovo Yoga 500 14IBD i3 5020U/4GB/500GB/Touch/Win10",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/73440/Slider/lenovo-yoga-500-i3-4030u-4g-500g-win81-slider00.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "HP Pavilion 14", Description = "HP Pavilion 14 ab133TU i5 5200U/4GB/500GB/Win10",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/73543/Slider/hp-pavilion-14-ab019tu-m4y37pa-slider01.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u3,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Dell XPS 13", Description = "Dell XPS 13 i5 5200U/4GB/128GB/Win10Home",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/44/73224/Slider/dell-xps-13-slider-02a.jpg",
                    Price = r.Next(10000),
                    CategoryId =1, Owner = u4,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Ốp lưng Xperia M4", Description = "Ốp lưng Xperia M4 nhựa phủ sơn XMobile",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/60/72428/op-lung-xperia-m4-nhua-phu-son-xmobile-tgdd-1-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u5,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Pin sạc XR02", Description = "Pin sạc dự phòng 6000 mAh X mobile XR02",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/57/70917/pin-sac-du-phong-6000-mah-x-mobile-xr02-trang-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u1,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "USB X mobile", Description = "Cáp micro USB X mobile",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/58/69921/cap-x-mobile-micro-usb-mautrang-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "iWalk iPhone 5/6", Description = "Cáp cao cấp iWalk iPhone 5 / 6",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/58/61258/cap-cao-cap-iwalk-iphone-5-trang-org-1.jpg",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "USB Apacer AH328", Description = "USB Apacer AH328 8GB 2.0",
                    PhotoUrl = "https://cdn4.tgdd.vn/Products/Images/75/61271/usb-apacer-ah328-8gb-20-org-2.jpg",
                    Price = r.Next(10000),
                    CategoryId =3, Owner = u2,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "ElfYourself", Description = "ElfYourself - Ghép mặt vào Video vũ điệu giáng sinh",
                    PhotoUrl = "https://cdn.tgdd.vn/Products/Images/1784/74043/elfyourselfbyofficedepot-org-scr3.jpg",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u3,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "Zing TV", Description = "Zing TV",
                    PhotoUrl = "https://cdn.tgdd.vn/Products/Images/1784/69814/zingtv-org-scr1.png",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u3,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now},
                new Auction() {Name = "ElfYourself 2", Description = "ElfYourself - Ghép mặt vào Video vũ điệu giáng sinh",
                    PhotoUrl = "https://cdn.tgdd.vn/Products/Images/1784/69814/zingtv-org-scr1.png",
                    Price = r.Next(10000),
                    CategoryId =4, Owner = u5,
                    BestBid = r.Next(10000),
                    AutionStatus = AuctionStatus.Opened,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now}
            };
            Auctions.ForEach(e => context.AutionProducts.Add(e));
            context.SaveChanges();
        }
    }
}
