using SGU_C2CStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGU_C2CStore.Services
{
    [ServiceContract]
    public interface IAuctionService : IBaseAuctionService
    {
        [OperationContract]
        string GetServiceInfo();
        /* Own auctions */
        [OperationContract]
        void AddNewAuction(string userEmail, Auction item);
        [OperationContract]
        void StartAuction(string userEmail, int auctionId, DateTime startTime, DateTime endTime);
        [OperationContract]
        void StopAuction(string userEmail, int auctionId);
        [OperationContract]
        void CancelAuction(string userEmail, int auctionId);
        [OperationContract]
        User GetWinner(int auctionId);
        [OperationContract]
        List<Auction> GetMyAuctions(string userEmail);
        [OperationContract]
        List<Bid> GetBidsOfAuction(string userEmail, int auctionId);
        [OperationContract]
        List<Auction> GetMyAuctionsWithStatus(string userEmail, AuctionStatus status);

        /* Contact */
        [OperationContract]
        void ContactToWinner(string userEmail, int auctionId, string message);
        [OperationContract]
        void ContactToOwner(string userEmail, int auctionId, string message);

        /* Other users auctions */
        [OperationContract]
        List<Auction> GetAllAutions(int idx, int size);
        [OperationContract]
        bool Bid(Bid bid);
        [OperationContract]
        int GetBestBid(int auctionId);
        [OperationContract]
        Auction GetAuction(int Id);
        [OperationContract]
        List<Auction> GetOpenAuctions(int idx, int size);
        [OperationContract]
        List<Auction> GetTopPriceAuctions(int idx, int size);
        [OperationContract]
        List<Auction> GetTopBidAuctions(int idx, int size);
        [OperationContract]
        List<Auction> GetOpenAuctionsByCategory(string categoryName, int idx, int size);
        [OperationContract]
        List<Auction> GetOpenAuctionsByUser(string userEmail, int idx, int size);
        [OperationContract]
        List<Auction> GetMyWonAuctionsHistory(string userEmail);
        [OperationContract]
        List<Bid> GetMyBidHistory(string userEmail);
        [OperationContract]
        List<Bid> GetMyBidHistoryByItem(int auctionId);

        [OperationContract]
        List<Category> GetAllCategories();
    }
}
