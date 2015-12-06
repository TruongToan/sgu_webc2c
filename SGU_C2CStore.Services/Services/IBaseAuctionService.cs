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
    public interface IBaseAuctionService
    {
        Auction TranslateEntityAuctionProduct(Auction auction);
        List<Auction> TranslateListEntityAuctionProduct(List<Auction> auctions);
        
    }
}
