using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsStatesController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<EhsState> stateList = new List<EhsState>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsStates";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            stateList = JsonConvert.DeserializeObject<List<EhsState>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(stateList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsState buyObj)
        {
            EhsState buy = new EhsState();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(buyObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsStates/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsState stateObj = new EhsState();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsStates/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    stateObj = JsonConvert.DeserializeObject<EhsState>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(stateObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsState stateObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsStates");
            string data = JsonConvert.SerializeObject(stateObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + stateObj.StateId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsState stateObj = new EhsState();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsStates/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    stateObj = JsonConvert.DeserializeObject<EhsState>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(stateObj);
        }
        public async Task<IActionResult> Details(string id)
        {
            EhsState stateObj = new EhsState();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsStates/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    stateObj = JsonConvert.DeserializeObject<EhsState>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(stateObj);
        }
    }
}
