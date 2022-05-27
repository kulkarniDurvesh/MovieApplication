using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class TheatreController : Controller
    {
        IConfiguration _configuration;

        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        public async Task<IActionResult> ShowTheatre()
        {
            using (HttpClient client = new HttpClient()) 
            {

                string endPoint = _configuration["WebApiURl"] + "Theatre/SelectTheatre";

                using (var response = await client.GetAsync(endPoint))
                {
                    if ( response.StatusCode== System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                        return View(theatreModel);

                    }

                }

            }

                return View();
        }

        [HttpGet]
        public IActionResult AddPlay()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlay(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Theatre/Register";

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Registered Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Credentials";
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> EditTheatre(int theatreId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/GetTheatreById?theatreId="+theatreId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<TheatreModel>(result);
                        return View(theatreModel);

                    }
                }

            }
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditTheatre(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(theatreModel), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endPoint,content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Registered Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Credentials";
                    }
                }

            }

            return View();
        }

        


        [HttpPost]
        public async Task<IActionResult> Delete(TheatreModel theatreModel)
        {
            ViewBag.status = "";

            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Theatre/DeleteTheatre?theatreId=" + theatreModel.ThreatreId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowTheatre", "Theatre");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }

                }
            }

            return View();
        }



    }
}
