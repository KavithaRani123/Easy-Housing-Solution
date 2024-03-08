using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsCart
    {
        public int CartId { get; set; }
        public int BuyerId { get; set; }
        public int PropertyId { get; set; }

        public virtual EhsBuyer Buyer { get; set; }
        public virtual EhsProperty Property { get; set; }
    }
}
