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
            db.AutionProducts.Add(item);
            db.SaveChanges();
        }

        public bool Bid(Bid bid)
        {
            var p = db.AutionProducts.Where(e => e.Id == bid.AuctionId).FirstOrDefault();
            if (p != null && p.AutionStatus == AuctionStatus.Opened && bid.Price > p.BestBid)
            {
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

        public List<Auction> GetAllAutions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").ToList());
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
            return TranslateListEntityBid(db.Bids.Where(e => e.Id == auctionId && p.Item.Owner.Email == userEmail).ToList());
        }

        public List<Auction> GetMyAuctions(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => owner.Email == userEmail).ToList());
        }

        public List<Auction> GetMyAuctionsWithStatus(string userEmail, AuctionStatus status)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.AutionStatus == status).ToList());
        }

        public List<Bid> GetMyBidHistory(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityBid(db.Bids.Where(e => e.User.Email == userEmail).ToList());
        }

        public List<Bid> GetMyBidHistoryByItem(int auctionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            return TranslateListEntityBid(db.Bids.Where(e => e.AuctionId == auctionId).ToList());
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
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.AutionStatus == AuctionStatus.Opened).OrderBy(e => e.StartTime).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetOpenAuctionsByUser(string userEmail, int idx, int size)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Where(e => e.AutionStatus == AuctionStatus.Opened && e.Item.Owner.Email == userEmail).OrderBy(e => e.StartTime).Skip(idx).Take(size).ToList());
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
            if (p.AutionStatus == AuctionStatus.Pending)
                throw new FaultException("Product have not approval yet!");
            p.StartTime = startTime;
            p.EndTime = startTime;
            p.AutionStatus = AuctionStatus.Opened;
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
            newItem.Item = db.Products.Include("Category").Include("Owner").Where(e => auction.Item.Id == e.Id).FirstOrDefault();   
            newItem.StartTime = auction.StartTime;
            newItem.EndTime = auction.EndTime;
            newItem.AutionStatus = auction.AutionStatus;
            newItem.BestBid = auction.BestBid;
            newItem.Bids = new List<Bid>();
            foreach (Bid bid in auction.Bids)
            {
                var newBid = db.Bids.Include("User").Where(e => e.Id == bid.Id).FirstOrDefault();
                newItem.Bids.Add(newBid);
            }
            return newItem;
        }

        public List<Auction> TranslateListEntityAuctionProduct(List<Auction> auctions)
        {
            List<Auction> result = new List<Auction>();
            foreach (Auction auction in auctions)
            {
                result.Add(TranslateEntityAuctionProduct(auction));
            }
            return result;
        }

        public Bid TranslateEntityBid(Bid bid)
        {
            if (bid == null) return null;

            Bid newItem = new Bid();
            newItem.CopyValues(bid);
            return newItem;
        }

        public List<Bid> TranslateListEntityBid(List<Bid> bids)
        {
            List<Bid> result = new List<Bid>();
            foreach (Bid bid in bids)
            {
                result.Add(TranslateEntityBid(bid));
            }
            return result;
        }

        public string GetServiceInfo()
        {
            return "Auction Service";
        }

        public List<Auction> GetOpenAuctionsByCategory(string categoryName, int idx, int size)
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.AutionStatus == AuctionStatus.Opened && (e.Item.Category.Name.Contains(categoryName) || categoryName == null || "".Equals(categoryName))).OrderByDescending(e => e.StartTime).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetTopPriceAuctions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.AutionStatus == AuctionStatus.Opened).OrderByDescending(e => e.BestBid).Skip(idx).Take(size).ToList());
        }

        public List<Auction> GetTopBidAuctions(int idx, int size)
        {
            return TranslateListEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.AutionStatus == AuctionStatus.Opened).OrderByDescending(e => e.Bids.Count()).Skip(idx).Take(size).ToList());
        }

        public Auction GetAuction(int Id)
        {
            return TranslateEntityAuctionProduct(db.AutionProducts.Include("Item").Include("Bids").Where(e => e.Id == Id).FirstOrDefault());
        }

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }
    }
}
