using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGU_C2CStore.Services.Models;
using SGU_C2CStore.Services.DAL;

namespace SGU_C2CStore.Services
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AuctionService : IAuctionService
    {
        SGUStoreServiceContext db = new SGUStoreServiceContext();

        public void AddNewAuction(string userEmail, AuctionProduct item)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            item.Owner = owner;
            item.BestBid = item.Price;
            item.Category = db.Categories.FirstOrDefault();
            item.AutionStatus = AuctionStatus.New;
            db.AutionProducts.Add(item);
            db.SaveChanges();
        }

        public bool Bid(Bid bid)
        {
            var p = db.AutionProducts.Where(e => e.Id == bid.Item.Id).FirstOrDefault();
            if (p != null && bid.Price > p.BestBid)
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

        public List<AuctionProduct> GetMyAuctions(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return db.AutionProducts.Where(e => owner.Email == userEmail).ToList();
        }

        public List<AuctionProduct> GetMyAuctionsWithStatus(string userEmail, AuctionStatus status)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return db.AutionProducts.Where(e => e.AutionStatus == status).ToList();
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
            return db.Bids.Where(e => e.Item.Id == auctionId).ToList();
        }

        public List<AuctionProduct> GetMyWonAuctionsHistory(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            var result = new List<AuctionProduct>();
            var groups = db.Bids.GroupBy(e => e.Item.Id).ToList();
            foreach(var g in groups)
            {
                var p = db.AutionProducts.Where(e => e.Id == g.Key).FirstOrDefault();
                var won = g.Where(e => e.Price == p.BestBid && e.User.Email == userEmail).FirstOrDefault() != null;
                if (won)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public List<AuctionProduct> GetOpenAuctions()
        {
            return db.AutionProducts.Where(e => e.AutionStatus == AuctionStatus.Opened).ToList();
        }

        public List<AuctionProduct> GetOpenAuctionsByUser(string userEmail)
        {
            var owner = db.Users.Where(e => e.Email == userEmail).FirstOrDefault();
            if (owner == null)
                throw new FaultException("User not found!");
            return db.AutionProducts.Where(e => e.AutionStatus == AuctionStatus.Opened && e.Owner.Email == userEmail).ToList();
        }

        public User GetWinner(int auctionId)
        {
            var p = db.AutionProducts.Where(e => e.Id == auctionId).FirstOrDefault();
            if (p == null)
                throw new FaultException("Auction product not found!");
            var wonBid = db.Bids.Where(e => e.Item.Id == p.Id && e.Price == p.BestBid).FirstOrDefault();
            return db.Users.Where(e => e.Id == wonBid.User.Id).FirstOrDefault();
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
    }
}
