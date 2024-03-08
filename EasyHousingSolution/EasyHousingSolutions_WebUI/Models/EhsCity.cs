using System;
using System.Collections.Generic;

namespace EasyHousingSolutions_WebUI.Models
{
    public partial class EhsCity
    {
        public EhsCity()
        {
            EhsSellers = new HashSet<EhsSeller>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int StateId { get; set; }

        public virtual EhsState State { get; set; } = null!;
        public virtual ICollection<EhsSeller> EhsSellers { get; set; }
    }
}
