using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class AdminHomeController : Controller
    {
       


       // [Authorize]
        public IActionResult Index()
        {
            //UserDTO user = userManager.GetUserAsync(HttpContext.User).Result;

            ViewBag.Message = $"Welcome {  HttpContext.Session.GetString("UserName")}!";
           
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
       
    }
}
