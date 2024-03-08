using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsUsersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<EhsUser> userList = new List<EhsUser>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsUsers/";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            userList = JsonConvert.DeserializeObject<List<EhsUser>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(userList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsUser userObj)
        {
            EhsUser user = new EhsUser();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsUsers/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsUser userObj = new EhsUser();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsUsers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    userObj = JsonConvert.DeserializeObject<EhsUser>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(userObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsUser userObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsUsers/");
            string data = JsonConvert.SerializeObject(userObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + userObj.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsUser userObj = new EhsUser();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsUsers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userObj = JsonConvert.DeserializeObject<EhsUser>(apiResponse);
                }
            }
            return View(userObj);
        }
    }
}
