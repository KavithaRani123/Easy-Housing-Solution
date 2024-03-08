using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHousingSolutions_WebUI.Models
{
    public class LoginGet
    {
        public string? UserName { get; set; }
        public DateTime ValidUpTo { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
