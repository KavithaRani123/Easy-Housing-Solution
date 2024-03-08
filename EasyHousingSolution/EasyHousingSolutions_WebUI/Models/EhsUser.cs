using System;
using System.Collections.Generic;

namespace EasyHousingSolutions_WebUI.Models
{
    public partial class EhsUser
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserType { get; set; }
    }
}
