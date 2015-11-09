namespace SGUStoreService.Models
{
    public class AutionByPriceProduct : AutionProduct
    {
        public virtual int MinPrice { get; set; }
        public virtual int ExpectedPrice { get; set; }
    }
}