using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public async Task<IActionResult> SelectMovies()
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Movies/SelectMovies";
                using (var response = await client.GetAsync(endPoint)) 
                {

                    if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        return View(movieModel);
                    
                    }
                
                
                }
            
            }
                return View();
        }


        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Movies/Register";

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
