using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsState
    {
        public EhsState()
        {
            EhsCities = new HashSet<EhsCity>();
            EhsSellers = new HashSet<EhsSeller>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<EhsCity> EhsCities { get; set; }
        public virtual ICollection<EhsSeller> EhsSellers { get; set; }
    }
}
