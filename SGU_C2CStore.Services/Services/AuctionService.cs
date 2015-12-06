using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGU_C2CStore.Services.Models;
using SGU_C2CStore.Services.DAL;
using System.Collections;

namespace SGU_C2CStore.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AuctionService : IAuctionService
    {
        SGUStoreServiceContext db = new SGUStoreServiceContext();

        public void AddNewAuction(string userEmail, Auction item)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            item.AutionStatus = AuctionStatus.New;
            item.Owner = owner;
            item.IsApproval = false;
            item.StartTime = DateTime.Now;
            item.EndTime = DateTime.Now;
            item.AutionStatus = AuctionStatus.New;
            db.AutionProducts.Add(item);
            db.SaveChanges();
        }

        public bool Bid(string userEmail, int price, int autionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == autionId).FirstOrDefault();
            var user = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (user == null) throw new FaultException("User not found");
            if (p != null && p.AutionStatus == AuctionStatus.Opened && price > p.BestBid)
            {

                Bid bid = new Bid();
                bid.Auction = db.AutionProducts.Where(e => e.Id == autionId).FirstOrDefault();
                bid.Price = price;
                bid.Time = DateTime.Now;
                bid.Auction = p;
                bid.User = user;
                db.Bids.Add(bid);
                p.BestBid = bid.Price;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void CancelAuction(string userEmail, int auctionId)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            p.AutionStatus = AuctionStatus.Cancelled;
        }

        public void ContactToOwner(string userEmail, int auctionId, string message)
        {
            throw new NotImplementedException();
        }

        public void ContactToWinner(string userEmail, int auctionId, string message)
        {
            throw new NotImplementedException();
        }

        public List<Auction> GetAllAutions()
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner").ToList());
        }
        public List<Auction> GetAutionsByStatus(AuctionStatus status)
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner").Where(e =>e.AutionStatus == status).ToList());
        }

        public int GetBestBid(int auctionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            return p.BestBid;
        }

        public List<Bid> GetBidsOfAuction(string userEmail, int auctionId)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            return db.Bids.Where(e => e.Id == auctionId && p.Owner.Email == userEmail).ToList();
        }

        public List<Auction> GetMyAuctions(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner").Where(e => e.Owner.Email == userEmail).ToList());
        }

        public List<Auction> GetMyAuctionsWithStatus(string userEmail, AuctionStatus status)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner").Where(e => e.AutionStatus == status).ToList());
        }

        public List<Bid> GetMyBidHistory(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return db.Bids.Where(e => e.User.Email == userEmail).ToList();
        }

        public List<Bid> GetMyBidHistoryByItem(int auctionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            return db.Bids.Where(e => e.AuctionId == auctionId).ToList();
        }

        public List<Auction> GetMyWonAuctionsHistory(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var result = new List<Auction>();
            var groups = db.Bids.GroupBy(e => e.AuctionId).ToList();
            foreach(var g in groups)
            {
                var p = db.AutionProducts.Where(e => e.Id == g.Key).FirstOrDefault();
                var won = g.Where(e => e.Price == p.BestBid && e.User.Email == userEmail).FirstOrDefault() != null;
                if (won)
                {
                    result.Add(p);
                }
            }
            return TranslateListEntityAuctionProduct(result);
        }

        public List<Auction> GetOpenAuctions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts
                .Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened)
                .OrderBy(e => e.StartTime).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetOpenAuctionsByUser(string userEmail, int idx, int size)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(
                db.AutionProducts
                .Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened && e.Owner.Email == userEmail)
                .OrderBy(e => e.StartTime).Skip(idx).Take(size).ToList());
        }

        public User GetWinner(int auctionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            var wonBid = db.Bids.Where(e => e.AuctionId == p.Id && e.Price == p.BestBid).FirstOrDefault();
            User user = new User();
            user.CopyValues(db.Users.Where(e => e.Id == wonBid.User.Id).FirstOrDefault());
            return user;
        }

        public void StartAuction(string userEmail, int auctionId, DateTime startTime, DateTime endTime)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            if (p.AutionStatus == AuctionStatus.Pending && startTime <= endTime)
            {
                p.StartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day);
                p.EndTime = new DateTime(endTime.Year, endTime.Month, endTime.Day).AddDays(1).AddSeconds(-1);
                p.AutionStatus = AuctionStatus.Opened;
                db.SaveChanges();
            }
        }

        public void StopAuction(string userEmail, int auctionId)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            if (p.AutionStatus == AuctionStatus.Pending)
                throw new FaultException("Product have not approval yet!");
            p.AutionStatus = AuctionStatus.Closed;
        }

        public Auction TranslateEntityAuctionProduct(Auction auction)
        {
            if (auction == null) return null;

            Auction newItem = new Auction();
            newItem.Id = auction.Id;
            newItem.Owner = auction.Owner;
            newItem.Name = auction.Name;
            newItem.Price = auction.Price;
            newItem.AuctionComments = auction.AuctionComments;
            newItem.IsApproval = auction.IsApproval;
            newItem.PhotoUrl = auction.PhotoUrl;
            newItem.Category = auction.Category;
            newItem.StartTime = auction.StartTime;
            newItem.EndTime = auction.EndTime;
            newItem.AutionStatus = auction.AutionStatus;
            newItem.BestBid = auction.BestBid;
            newItem.Description = auction.Description;
            newItem.Bids = new List<Bid>();
            List<Bid> tmp = auction.Bids.OrderByDescending(e => e.Price).ToList();
            foreach (Bid bid in tmp)
            {
                var newBid = db.Bids.Include("User").Where(e => e.Id == bid.Id).FirstOrDefault();
                newItem.Bids.Add(newBid);
            }
            newItem.AuctionComments = new List<AuctionComment>();
            List<AuctionComment> tmpCmt = auction.AuctionComments.OrderByDescending(e => e.Time).ToList();
            foreach (AuctionComment cmt in tmpCmt)
            {
                var newCmt = db.AuctionComments.Include("CommentUser").Where(e => e.Id == cmt.Id).FirstOrDefault();
                newItem.AuctionComments.Add(newCmt);
            }
            return newItem;
        }

        public List<Auction> TranslateListEntityAuctionProduct(List<Auction> auctions)
        {
            List<Auction> result = new List<Auction>();
            for(var i = 0; i < auctions.Count; i++)
            {
                result.Add(TranslateEntityAuctionProduct(auctions.ElementAt(i)));
            }
            return result;
        }

        public string GetServiceInfo()
        {
            return "Auction Service";
        }

        public List<Auction> GetOpenAuctionsByCategory(string categoryName, int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened && (e.Category.Name.Contains(categoryName) || categoryName == null || "".Equals(categoryName)))
                .OrderByDescending(e => e.StartTime).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetTopBidAuctions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened)
                .OrderByDescending(e => e.Bids.Count()).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetTopPriceAuctions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened)
                .OrderByDescending(e => e.BestBid).Skip(idx).Take(size).ToList());
        }

        public Auction GetAuction(int Id)
        {
            return TranslateEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.Id == Id).FirstOrDefault());
        }

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public void Comment(string userEmail, int autionId, string Content)
        {
            var user = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            var auction = db.AutionProducts.Where(e => e.Id == autionId).FirstOrDefault();
            if (user == null) throw new FaultException("User not found");
            db.AuctionComments.Add(new AuctionComment() { Content = Content, CommentUser = user, Auction = auction, Time = DateTime.Now });
            db.SaveChanges();
        }

        public List<Auction> GetTopPriceAuctionsByCategory(string categoryName, int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened && (e.Category.Name.Contains(categoryName) || categoryName == null || "".Equals(categoryName)))
                .OrderByDescending(e => e.BestBid).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetTopBidAuctionsByCategory(string categoryName, int idx, int size)
        {
            return TranslateListEntityAuctionProduct(
                db.AutionProducts.Include("Bids").Include("AuctionComments").Include("Category").Include("Owner")
                .Where(e => e.AutionStatus == AuctionStatus.Opened && (e.Category.Name.Contains(categoryName) || categoryName == null || "".Equals(categoryName)))
                .OrderByDescending(e => e.Bids.Count()).Skip(idx).Take(size).ToList());
        }
    }
}
