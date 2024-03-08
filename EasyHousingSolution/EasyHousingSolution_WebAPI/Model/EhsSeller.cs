using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsSeller
    {
        public EhsSeller()
        {
            EhsProperties = new HashSet<EhsProperty>();
        }

        public int SellerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string EmailId { get; set; }

        public virtual EhsCity City { get; set; }
        public virtual EhsState State { get; set; }
        public virtual ICollection<EhsProperty> EhsProperties { get; set; }
    }
}
