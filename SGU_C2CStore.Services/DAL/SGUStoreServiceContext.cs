
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
            this.Configuration.ProxyCreationEnabled = false;
        }

        public static SGUStoreServiceContext Create()
        {
            return new SGUStoreServiceContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Auction>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<AuctionComment>().HasKey(e => e.Id);
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().HasKey(e => e.Id);
            modelBuilder.Entity<OrderDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<Bid>().HasKey(e => e.Id);

            modelBuilder.Entity<Product>().HasRequired(e => e.Owner).WithMany(e => e.OwnProducts).HasForeignKey(e => e.OwnerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>().HasRequired(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
            modelBuilder.Entity<Auction>().HasRequired(e => e.Item);
            modelBuilder.Entity<AuctionComment>().HasRequired(e => e.CommentUser);
            modelBuilder.Entity<Bid>().HasRequired(e => e.User).WithMany(e => e.Bids).HasForeignKey(e => e.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Auction>().HasMany(e => e.Bids);
            modelBuilder.Entity<Auction>().HasMany(e => e.AuctionComments);
            modelBuilder.Entity<Order>().HasRequired(e => e.Buyer);
            modelBuilder.Entity<OrderDetail>().HasRequired(e => e.Product).WithOptional();
            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Auction> AutionProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionComment> AuctionComments { get; set; }
    }
}
