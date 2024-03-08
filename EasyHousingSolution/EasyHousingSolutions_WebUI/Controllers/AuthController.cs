using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using EasyHousingSolutions_WebUI.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class AuthController : Controller
    {
        
        public  ActionResult ShowMe()
        {
            return View();
        }
        ///<summary>
        ///This is A View Logic Which Returns Login Page
        ///</summary>
        public IActionResult Login()
        {
            //Checking If User is Already Logged In
            //If Customer is Logged in, Go To Profile Page
            if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Role") == "NormalUser")
            {
                return RedirectToAction("Index", "EhsBuyers");
            }
            //If Admin is Logged in, Go To Admin Page
            else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Role") == "ADMIN")
            {
                return RedirectToAction("Index", "AdminHome");
            }
             else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Role") == "Seller")
            {
                return RedirectToAction("Index", "EhsSellers");
            }
            //Else Show Login Page
            else
            {
                return View();
            }
        }

        ///<summary>
        ///This is an Action Result Method <c>Login</c>.
        ///It Takes Login Model as Input From UI
        ///If LoggedIn, It Creates Role and CustomerId Sessions
        ///</summary>
        [HttpPost]
        public ActionResult Login(Login model)
        {
            //Checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {

                //Validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(model).Result;

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isValidUser != null)
                {
                    HttpContext.Session.SetString("UserName", isValidUser.UserName);
                   // HttpContext.Session.SetString("FullName", isValidUser.FullName);
                    //HttpContext.Session.SetString("Email", isValidUser.Email);
                    //HttpContext.Session.SetString("DOB", isValidUser.BirthDate.ToString());
                    HttpContext.Session.SetString("Role", isValidUser.Role);
                  


                    return HttpContext.Session.GetString("Role") == "NormalUser" ? RedirectToAction("Privacy", "Home") : RedirectToAction("Index", "AdminHome");

                }
                else
                {
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError(string.Empty, "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }

        ///<summary>
        ///This is an Async Method <c>IsValidUser</c>.
        ///It Takes Login Model as Input and Returns Object of Profile.
        ///This Method Makes API Request to Post Login Credentials and Get Customer Details.
        ///It Returns Null If Status Code of API Request is Not Successful.
        ///<param name="model">Login</param>
        ///</summary>
        public async Task<LoginGet> IsValidUser(Login model)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/");
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string tmp = JsonConvert.SerializeObject(model).ToString();
            var content = new StringContent(tmp, Encoding.UTF8, "application/json");
            HttpResponseMessage Res = await client.PostAsync("Authenticate/login", content);
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var apiResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list
                var resValue = JsonConvert.DeserializeObject<LoginGet>(apiResponse);
                HttpContext.Session.SetString("Token", resValue.Token);
                return resValue;
            }
            else
#pragma warning disable CS8603 // Possible null reference return.
                return null ;
#pragma warning restore CS8603 // Possible null reference return.
        }

        ///<summary>
        ///This is A View Logic Which Returns Signup Page
        ///</summary>
        public IActionResult Signup()
        {
            //Checking If User is Already Logged In
            //If Customer is Logged in, Go To Profile Page
            if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Role") == "NormalUser")
            {
                return RedirectToAction("Index", "Home");
            }
            //If Admin is Logged in, Go To Admin Page
            else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Role") == "AdminUser")
            {
                return RedirectToAction("Index", "AdminHome");
            }
            //Else Show Signup Page
            else
            {
                return View();
            }
        }

        ///<summary>
        ///This is an Action Result Method <c>Signup</c>.
        ///It Takes Signup Model as Input From UI
        ///If Created, It Shows Login Page
        ///</summary>
        [HttpPost]
        public IActionResult Signup(Signup model)
        {
           // model.Role = "CUSTOMER";          

            if (ModelState.IsValid)
            {

                //Validating the user, whether the user is valid or not.
                var hasValidData = HasValidData(model).Result;

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (hasValidData != null)
                {
                    return View("Login");
                }
                else
                {
                    //If User Already Exist in DB then error message is shown.
                    ModelState.AddModelError(string.Empty, "Email Already Present in Database !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }

        ///<summary>
        ///This is an Async Method <c>HadValidData</c>.
        ///It Takes Signup Model as Input and Returns Object of Profile.
        ///This Method Makes API Request to Post Signup Credentials and Get Customer Details.
        ///It Returns Null If Status Code of API Request is Not Successful.
        ///<param name="model">Signup</param>
        ///</summary>
        public async Task<string> HasValidData(Signup model)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/");
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string tmp = JsonConvert.SerializeObject(model).ToString();
            var content = new StringContent(tmp, Encoding.UTF8, "application/json");
            HttpResponseMessage Res = await client.PostAsync("Authenticate/register", content);
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var apiResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list
                //       string resp = JsonConvert.DeserializeObject<string>(apiResponse);
                string resp = "ok";
                return resp;
            }
            else
                return "un succesful";
        }

        ///<summary>
        ///This is Logout Logic
        ///It Clears All Value from Session
        ///</summary>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
           
            return View("Login");
        }

     
        
    }
}
