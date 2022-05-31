using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Business.Services;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{

    public class DisplayMovieTimeController : Controller
    {
        IConfiguration _configuration;

        public DisplayMovieTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/ShowMovieTimeList";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTime = JsonConvert.DeserializeObject<List<MovieSTime>>(result);
                        return View(movieShowTime);

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


        public async Task<IActionResult> InsertMovieShowTime()
        {
            
            List<MovieModel> moviedata = null;
            List<SelectListItem> movieList = new List<SelectListItem>();

            SelectListItem item1 = new SelectListItem();
                

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movies/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                         moviedata = JsonConvert.DeserializeObject<List<MovieModel>>(result);

                    }
                }
            }

            item1.Text = "Select";
            item1.Value = "0";
            movieList.Add(item1);
            foreach (var movie in moviedata)
            {
                item1= new SelectListItem();
                item1.Text = movie.MovieName;
                item1.Value = movie.MovieId.ToString();
                movieList.Add(item1);
            }

            ViewBag.movieShowList = movieList;
            /*TempData["movieShowList"] = movieList;*/

            List<TheatreModel> theatredata = null;
            List<SelectListItem> theatrelist = new List<SelectListItem>();

            SelectListItem item2 = new SelectListItem();


            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theatredata = JsonConvert.DeserializeObject<List<TheatreModel>>(result);

                    }
                }
            }

            item2.Text = "Select";
            item2.Value = "0";
            theatrelist.Add(item2);
            foreach (var theatre in theatredata)
            {
                item2 = new SelectListItem();   
                item2.Text = theatre.ThreatreName;
                item2.Value = theatre.ThreatreId.ToString();
                theatrelist.Add(item2);
            }

            ViewBag.theatreShowList = theatrelist;
           /* TempData["theatreShowList"] = theatrelist;*/

            return View();
        
        }






        [HttpPost]
        public async Task<IActionResult> InsertMovieShowTime(MovieSTime movieShowTime)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTime), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/InsertMovieTimeList";
                using (var response = await client.PostAsync(endPoint, content))
                { 
                    if(response.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted";
                        return RedirectToAction("Index", "DisplayMovieTime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Failed";
                    }
                    

                }
            }


                return View();
        }

    }
}
