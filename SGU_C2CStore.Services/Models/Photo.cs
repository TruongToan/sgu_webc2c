namespace SGU_C2CStore.Services.Models
{
    public class Photo
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual string URL { get; set; }
        public virtual Product Product { get; set; }
    }
}