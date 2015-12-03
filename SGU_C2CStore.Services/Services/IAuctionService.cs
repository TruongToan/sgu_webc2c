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
    public interface IAuctionService
    {
        /* Own auctions */
        [OperationContract]
        void AddNewAution(string UserEmail, AuctionProduct item);
        [OperationContract]
        void StartAuction(string UserEmail, int AuctionId, DateTime StartTime, DateTime EndTime);
        [OperationContract]
        void StopAuction(string UserEmail, int AuctionId);
        [OperationContract]
        void CancelAuction(string UserEmail, int AuctionId);
        [OperationContract]
        User GetWinner(int AuctionId);
        [OperationContract]
        List<AuctionProduct> GetMyAuctions(string UserEmail);
        [OperationContract]
        List<Bid> GetBidsOfAuction(string UserEmail, int AutionId);
        [OperationContract]
        List<AuctionProduct> GetMyAuctionsWithStatus(string UserEmail, AuctionStatus status);

        /* Contact */
        [OperationContract]
        void ContactToWinner(string UserEmail, int AuctionId, string Message);
        [OperationContract]
        void ContactToOwner(string UserEmail, int AuctionId, string Message);

        /* Other users auctions */
        [OperationContract]
        bool Bid(Bid bid);
        [OperationContract]
        int GetBestBid(int itemId);
        [OperationContract]
        List<AuctionProduct> GetOpenAuctions();
        [OperationContract]
        List<AuctionProduct> GetOpenAuctionsByUser(string UserEmail);
        [OperationContract]
        List<AuctionProduct> GetMyWonAuctionsHistory(string UserEmail);
        [OperationContract]
        List<Bid> GetMyBidHistory(string UserEmail);
        [OperationContract]
        List<Bid> GetMyBidHistoryByItem(string ItemId);
    }
}
