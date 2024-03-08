using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsBuyer
    {
        public EhsBuyer()
        {
            EhsCarts = new HashSet<EhsCart>();
        }

        public int BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }

        public virtual ICollection<EhsCart> EhsCarts { get; set; }
    }
}
