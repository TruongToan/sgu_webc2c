namespace SGU_C2CStore.Service.Models
{
    public class AutionProduct : Product
    {
        public virtual int CurrentPrice { get; set; }
        public virtual AutionStatus AutionStatus { get; set; }
    }
}