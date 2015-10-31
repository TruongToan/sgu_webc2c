namespace SGUStoreService.Data.Models
{
    public class AutionProduct : Product
    {
        public virtual int CurrentPrice { get; set; }
        public virtual AutionStatus AutionStatus { get; set; }
    }
}