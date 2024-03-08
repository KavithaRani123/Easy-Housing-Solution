using System;
using System.Collections.Generic;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EhsUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
