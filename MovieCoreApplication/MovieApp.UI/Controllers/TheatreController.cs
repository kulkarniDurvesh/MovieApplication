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

        public async Task<IActionResult> SelectTheatreAsync()
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




    }
}
