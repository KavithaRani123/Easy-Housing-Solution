using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsCity
    {
        public EhsCity()
        {
            EhsSellers = new HashSet<EhsSeller>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual EhsState State { get; set; }
        public virtual ICollection<EhsSeller> EhsSellers { get; set; }
    }
}
