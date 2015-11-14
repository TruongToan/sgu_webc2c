namespace SGU_C2CStore.Service.Models
{
    public class OrderDetail
    {
        public virtual int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual int Count { get; set; }
        public virtual Order Order { get; set; }
    }
}