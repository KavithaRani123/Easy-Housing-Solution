namespace EasyHousingSolutions_WebUI.Models
{
    public class EhsBuyer
    {
        public EhsBuyer()
        {
            EhsCarts = new HashSet<EhsCart>();
        }

        public int BuyerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNo { get; set; } = null!;
        public string EmailId { get; set; } = null!;

        public virtual ICollection<EhsCart> EhsCarts { get; set; }
    }
}
