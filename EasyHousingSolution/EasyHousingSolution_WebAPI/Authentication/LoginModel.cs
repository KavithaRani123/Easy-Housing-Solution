using System.ComponentModel.DataAnnotations;

namespace EasyHousingSolution_WebAPI.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        //public bool Seller{ get; set; }

        //public bool 

    }
}
