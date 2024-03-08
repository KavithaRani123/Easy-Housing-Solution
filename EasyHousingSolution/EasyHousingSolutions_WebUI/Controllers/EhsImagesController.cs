using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{
    public class EhsImagesController : Controller
    {
        public async Task<ActionResult> Index()
        {   
            List<EhsImage> imgList = new List<EhsImage>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsImages";

            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            imgList = JsonConvert.DeserializeObject<List<EhsImage>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(imgList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsImage imgObj)
        {
            EhsImage img = new EhsImage();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(imgObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsImages/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsImage imgObj = new EhsImage();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsImages/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    imgObj = JsonConvert.DeserializeObject<EhsImage>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(imgObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsImage imgObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsImages");
            string data = JsonConvert.SerializeObject(imgObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + imgObj.ImageId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
        public async Task<IActionResult> Delete(int id)
        {
            EhsImage imgObj = new EhsImage();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsImages/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    imgObj = JsonConvert.DeserializeObject<EhsImage>(apiResponse);
                }
            }
            return View(imgObj);
        }
        public async Task<IActionResult> Details(string id)
        {
            EhsImage imgObj = new EhsImage();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsImages/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    imgObj = JsonConvert.DeserializeObject<EhsImage>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(imgObj);
        }
    }
}
