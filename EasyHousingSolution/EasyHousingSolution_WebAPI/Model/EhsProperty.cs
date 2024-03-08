using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsProperty
    {
        public EhsProperty()
        {
            EhsCarts = new HashSet<EhsCart>();
            EhsImages = new HashSet<EhsImage>();
        }

        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyOption { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal PriceRange { get; set; }
        public decimal InitialDeposit { get; set; }
        public string LandMark { get; set; }
        public bool IsActive { get; set; }
        public int SellerId { get; set; }

        public virtual EhsSeller Seller { get; set; }
        public virtual ICollection<EhsCart> EhsCarts { get; set; }
        public virtual ICollection<EhsImage> EhsImages { get; set; }
    }
}
