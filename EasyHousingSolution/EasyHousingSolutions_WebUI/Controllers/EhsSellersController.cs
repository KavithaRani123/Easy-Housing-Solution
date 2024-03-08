using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsSellersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<EhsSeller> selList = new List<EhsSeller>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsSellers/";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            selList = JsonConvert.DeserializeObject<List<EhsSeller>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(selList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsSeller selObj)
        {
            EhsSeller sel = new EhsSeller();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(selObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsSellers/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsSeller selObj = new EhsSeller();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsSellers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    selObj = JsonConvert.DeserializeObject<EhsSeller>(apiResponse);
               }
            }
            return View(selObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsSeller selObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsSellers/");
            string data = JsonConvert.SerializeObject(selObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + selObj.SellerId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsSeller selObj = new EhsSeller();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsSellers/" + id))
                {                   
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    selObj = JsonConvert.DeserializeObject<EhsSeller>(apiResponse);
                }
            }
            return View(selObj);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, EhsSeller selObj)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44398/api/EhsSellers/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
