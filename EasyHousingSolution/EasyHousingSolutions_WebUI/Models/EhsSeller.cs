using System;
using System.Collections.Generic;

namespace EasyHousingSolutions_WebUI.Models
{
    public partial class EhsSeller
    {
        public EhsSeller()
        {
            EhsProperties = new HashSet<EhsProperty>();
        }

        public int SellerId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNo { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string EmailId { get; set; } = null!;

        public virtual EhsCity City { get; set; } = null!;
        public virtual EhsState State { get; set; } = null!;
        public virtual ICollection<EhsProperty> EhsProperties { get; set; }
    }
}
