using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public enum AuctionStatus
    {
        Pending,
        Opened,
        Closed 
    }
}