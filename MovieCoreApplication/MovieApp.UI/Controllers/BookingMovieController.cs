using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class BookingMovieController : Controller
    {
        IConfiguration _configuration;

        public BookingMovieController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }



        public async Task<IActionResult> showAllBookingList()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Booking/ShowBookingList";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTime = JsonConvert.DeserializeObject<List<BookingModel>>(result);
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


        




        [HttpGet]
        public async Task<IActionResult> AddBookingItem()
        {
            List<TheatreModel> thetreModel = null;
            List<MovieModel> movieModel = null;
            List<MovieSTime> list = null;

            // Get All Thetre List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        thetreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(data);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in thetreModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.ThreatreName;
                            selectListItem.Value = item.ThreatreId.ToString();
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.theatreShowList = selectListItemsTheatre;
                        }
                    }
                }
            }

            //Get All Movie List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movies/SelectMovies";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.MovieName;
                            selectListItem.Value = item.MovieId.ToString();
                            selectListItemsMovies.Add(selectListItem);
                            ViewBag.movieShowList = selectListItemsMovies;
                        }

                    }
                }
            }

            //Get All MovieShow List
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieShowTime/ShowMovieTimeList";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<MovieSTime>>(data);
                    }
                }
            }

            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingItem(BookingModel bookingModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookingModel), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Booking/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted";
                        return RedirectToAction("showAllBookingList", "BookingMovie");
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
