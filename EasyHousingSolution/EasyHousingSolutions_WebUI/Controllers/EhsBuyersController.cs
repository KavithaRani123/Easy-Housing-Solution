using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsBuyersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<EhsBuyer> buyList = new List<EhsBuyer>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsBuyers/";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            buyList = JsonConvert.DeserializeObject<List<EhsBuyer>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(buyList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsBuyer buyObj)
        {
            EhsBuyer buy = new EhsBuyer();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(buyObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsBuyers/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        // GET: UsersController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            EhsBuyer buyObj = new EhsBuyer();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsBuyers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    buyObj = JsonConvert.DeserializeObject<EhsBuyer>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(buyObj);
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsBuyer buyObj = new EhsBuyer();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsBuyers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    buyObj = JsonConvert.DeserializeObject<EhsBuyer>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(buyObj);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsBuyer buyObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsBuyers/");
            string data = JsonConvert.SerializeObject(buyObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + buyObj.BuyerId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsBuyer buyObj = new EhsBuyer();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsBuyers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    buyObj = JsonConvert.DeserializeObject<EhsBuyer>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(buyObj);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, EhsBuyer buyObj)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44398/api/EhsBuyers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
