using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SGU_C2CStore.Services.Models;

namespace SGU_C2CStore.Services
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AuctionService : IAuctionService
    {
        public void AddNewAution(string UserEmail, AuctionProduct item)
        {
            throw new NotImplementedException();
        }

        public bool Bid(Bid bid)
        {
            throw new NotImplementedException();
        }

        public void CancelAuction(string UserEmail, int AuctionId)
        {
            throw new NotImplementedException();
        }

        public void ContactToOwner(string UserEmail, int AuctionId, string Message)
        {
            throw new NotImplementedException();
        }

        public void ContactToWinner(string UserEmail, int AuctionId, string Message)
        {
            throw new NotImplementedException();
        }

        public int GetBestBid(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<Bid> GetBidsOfAuction(string UserEmail, int AutionId)
        {
            throw new NotImplementedException();
        }

        public List<AuctionProduct> GetMyAuctions(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public List<AuctionProduct> GetMyAuctionsWithStatus(string UserEmail, AuctionStatus status)
        {
            throw new NotImplementedException();
        }

        public List<Bid> GetMyBidHistory(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public List<Bid> GetMyBidHistoryByItem(string ItemId)
        {
            throw new NotImplementedException();
        }

        public List<AuctionProduct> GetMyWonAuctionsHistory(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public List<AuctionProduct> GetOpenAuctions()
        {
            throw new NotImplementedException();
        }

        public List<AuctionProduct> GetOpenAuctionsByUser(string UserEmail)
        {
            throw new NotImplementedException();
        }

        public User GetWinner(int AuctionId)
        {
            throw new NotImplementedException();
        }

        public void StartAuction(string UserEmail, int AuctionId, DateTime StartTime, DateTime EndTime)
        {
            throw new NotImplementedException();
        }

        public void StopAuction(string UserEmail, int AuctionId)
        {
            throw new NotImplementedException();
        }
    }
}
