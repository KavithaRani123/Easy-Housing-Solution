using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsCartsController : Controller
    { 
         public async Task<ActionResult> ShowCart()
        {
            EhsProperty prop = TempData["propList"] as EhsProperty;
            List<EhsProperty> list = new List<EhsProperty>();
            list.Add(prop);
          //  ViewBag["propList"] = list;
            return View(list);

        }
    
        public async Task<ActionResult> Index()
        {
            List<EhsCart> cartList = new List<EhsCart>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsCarts/";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            cartList = JsonConvert.DeserializeObject<List<EhsCart>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(cartList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsCart cartObj)
        {
            EhsCart cart = new EhsCart();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cartObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsCarts/", content))
                {
 

                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsCart cartObj = new EhsCart();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsCarts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    cartObj = JsonConvert.DeserializeObject<EhsCart>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(cartObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsCart cartObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsCarts/");
            string data = JsonConvert.SerializeObject(cartObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + cartObj.CartId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsCart cartObj = new EhsCart();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsCarts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cartObj = JsonConvert.DeserializeObject<EhsCart>(apiResponse);
                }
            }
            return View(cartObj);
        }
    }
}
