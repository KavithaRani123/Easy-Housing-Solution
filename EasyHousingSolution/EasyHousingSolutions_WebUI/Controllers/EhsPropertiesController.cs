using EasyHousingSolutions_WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EasyHousingSolutions_WebUI.Controllers
{

    public class EhsPropertiesController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            
            List<EhsProperty> propList = new List<EhsProperty>();
            HttpClient clientObj = new HttpClient();
            string url = "https://localhost:44398/api/EhsProperties";
            
            var response = clientObj.GetAsync(url);
            string apiResponse = await response.Result.Content.ReadAsStringAsync();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            propList = JsonConvert.DeserializeObject<List<EhsProperty>>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            return View(propList);
           
    

       
        //return View();
    
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EhsProperty propObj)
        {
            EhsProperty prop = new EhsProperty();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(propObj), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44398/api/EhsProperties/", content))
                {


                }

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            EhsProperty propObj = new EhsProperty();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsProperties/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    propObj = JsonConvert.DeserializeObject<EhsProperty>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(propObj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EhsProperty propObj)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44398/api/EhsProperties/");
            string data = JsonConvert.SerializeObject(propObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + propObj.PropertyId.ToString(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //Deleting from MVC
       
        public async Task<IActionResult> Details(string id)
        {
            EhsProperty propObj = new EhsProperty();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsProperties/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    propObj = JsonConvert.DeserializeObject<EhsProperty>(apiResponse);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
            }
            return View(propObj);
        }
        //[HttpPost]

        //public ActionResult search(int? PropertyId)
        //{
        //    //Lambda Linq to entity does not support Int32
        //    //var search = (from d in db.students where d.No == Convert.ToInt32(id) && d.Name == id select d).ToList();
        //    //var search = db.students.Where(d => d.No == Convert.ToInt32(id) && d.Name == id).ToList();
        //   var query = EasyHousingSolutions_WebUI.Models.EhsProperty.AsQueryable();
        //    if (PropertyId.HasValue)
        //    {
        //        int PropertyId = PropertyId.Value;
        //        query = query.Where(d => d.No == PropertyId);
        //    }
        //    //if (!string.IsNullOrEmpty(searchString))
        //    //    query = query.Where(d => d.Name.Contains(searchString));

        //    var search = query.ToList();
        //    return View("index", search);
        //}
        //public async Task<IActionResult> Search(int PropertyId)
        //{
        //    var Property = from m in EHSDBContext.Property
        //                 select m;

        //    if (!String.IsNullOrEmpty(int  PropertyId))
        //    {
        //        Property = Property.Where(s => s.Title!.Contains(int PropertyId));
        //    }

        //    return View(await Property.ToListAsync());
        //}

        public async Task<IActionResult> Delete(int id)
        {
            EhsProperty prodObj = new EhsProperty();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsProperties/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prodObj = JsonConvert.DeserializeObject<EhsProperty>(apiResponse);
                }
            }
            return View(prodObj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, EhsProperty pObj)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44398/api/EhsProperties/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }



        
        public async Task<ActionResult> AddToCart(int id)
            {
            EhsProperty propObj = new EhsProperty();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/api/EhsProperties/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    propObj = JsonConvert.DeserializeObject<EhsProperty>(apiResponse);

                }

            }
            TempData["propList"]= JsonConvert.SerializeObject(propObj);


            return RedirectToAction("ShowCart", "EhsCarts");
//                List<EhsCart> cartList = new List<EhsCart>();
//                HttpClient clientObj = new HttpClient();
//                string url = "https://localhost:44398/api/EhsCarts/";

//                var response = clientObj.GetAsync(url);
//                string apiResponse = await response.Result.Content.ReadAsStringAsync();

//#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
//                cartList = JsonConvert.DeserializeObject<List<EhsCart>>(apiResponse);
//#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
//                return View(cartList);
            }
        
        
    }
}
