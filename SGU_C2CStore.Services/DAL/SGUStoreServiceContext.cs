
using Microsoft.AspNet.Identity.EntityFramework;
using SGU_C2CStore.Services.Models;
using System.Data.Entity;

namespace SGU_C2CStore.Services.DAL
{
    public class SGUStoreServiceContext : DbContext
    {
        public SGUStoreServiceContext() : base("name=SGU_C2CStoreContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static SGUStoreServiceContext Create()
        {
            return new SGUStoreServiceContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<AuctionProduct>().HasKey(e => e.Id).ToTable("AutionProduct");
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Comment>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().HasKey(e => e.Id);
            modelBuilder.Entity<OrderDetail>().HasKey(e => e.Id);

            modelBuilder.Entity<Product>().HasRequired(e => e.Owner);
            modelBuilder.Entity<Product>().HasRequired(e => e.Category);
            modelBuilder.Entity<Product>().HasMany(e => e.Comments);
            modelBuilder.Entity<Comment>().HasRequired(e => e.CommentUser);
            modelBuilder.Entity<User>().HasMany(e => e.BidItems).WithMany(e => e.Users).Map(
                e =>
                {
                    e.MapLeftKey("ProductId");
                    e.MapRightKey("UserId");
                    e.ToTable("AuctionBid");
                }

            );
            modelBuilder.Entity<Order>().HasRequired(e => e.Buyer);
            modelBuilder.Entity<OrderDetail>().HasRequired(e => e.Product);
            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AuctionProduct> AutionProducts { get; set; }
        public DbSet<AuctionByPriceProduct> AuctionByPriceProducts { get; set; }
        public DbSet<AuctionByTimeProduct> AuctionByTimeProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
