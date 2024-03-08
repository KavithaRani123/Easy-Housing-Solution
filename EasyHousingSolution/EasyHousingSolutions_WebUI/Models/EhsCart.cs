namespace EasyHousingSolutions_WebUI.Models
{
    public class EhsCart
    {
        public int CartId { get; set; }
        public int BuyerId { get; set; }
        public int PropertyId { get; set; }

        public virtual EhsBuyer Buyer { get; set; } = null!;
        public virtual EhsProperty Property { get; set; } = null!;
    }
}
