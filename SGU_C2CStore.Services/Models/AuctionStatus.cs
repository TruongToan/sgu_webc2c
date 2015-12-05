using System.Runtime.Serialization;

namespace SGU_C2CStore.Services.Models
{
    [DataContract]
    public enum AuctionStatus
    {
        [EnumMember]
        New,
        [EnumMember]
        Pending,
        [EnumMember]
        Opened,
        [EnumMember]
        Closed,
        [EnumMember]
        Cancelled
    }
}