using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieApp.Entity;
using MovieApp.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration _iconfiguration;

        public HomeController( IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            
        }
    
        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _iconfiguration["WebApiURL"] + "Movies/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result).ToList();
                        return View(movieModel);
                    }
                }
            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
