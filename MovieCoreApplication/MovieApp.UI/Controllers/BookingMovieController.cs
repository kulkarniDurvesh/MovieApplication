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
        public async Task<IActionResult> AddBookingItem(int movieId)
        {
            List<TheatreModel> thetreModel = null;
            List<BookingModel> bookinglModel = null;
            MovieModel movieModel = null;
            List<MovieSTime> list = null;
            ViewBag.movieId = movieId; 

            // Get All Thetre List
     /*       using (HttpClient client = new HttpClient())
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
            }*/
            List<UserModel> userModel = null;
            //Get All User List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/ShowUserDetails";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        userModel = JsonConvert.DeserializeObject<List<UserModel>>(data);
                        List<SelectListItem> selectListItemsUsers = new List<SelectListItem>();
                        foreach (var item in userModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.FirstName;
                            selectListItem.Value = item.UserId.ToString();
                            selectListItemsUsers.Add(selectListItem);
                            ViewBag.userShowList = selectListItemsUsers;
                        }
                    }
                }


            }

            //get all show time
            List<BookingModel> bookingModel = null;
            //Get All User List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Booking/ShowBookingList";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        bookingModel = JsonConvert.DeserializeObject<List<BookingModel>>(data);
                        List<SelectListItem> selectListItemsBooking = new List<SelectListItem>();
                        foreach (var item in bookingModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.ShowTime;
                            selectListItem.Value = item.BookingId.ToString();
                            selectListItemsBooking.Add(selectListItem);
                            ViewBag.bookingShowList = selectListItemsBooking;
                        }
                    }
                }
            }

            //Get All Movie List
          
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movies/GetMovieById?MovieId="+movieId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<MovieModel>(data);
                        List<SelectListItem> MovieList = new List<SelectListItem>();
                        
                       
                            SelectListItem movie = new SelectListItem();
                            movie.Text = movieModel.MovieName;
                            movie.Value = movieModel.MovieId.ToString();
                            MovieList.Add(movie);
                            ViewBag.movieShowList = MovieList;
                       
                       


                        
                    }
                }


                // --------
                string endPoint2 = _configuration["WebApiURL"] + "Theatre/SelectTheatre";

                using (var response = await client.GetAsync(endPoint2))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        thetreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(data);
                        bookinglModel = JsonConvert.DeserializeObject<List<BookingModel>>(data);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in bookingModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            
                            var theatre = thetreModel.Where( obj=>obj.ThreatreId == item.TheatreId).ToList()[0];
                            selectListItem.Text = theatre.ThreatreName;
                            selectListItem.Value = theatre.ThreatreId.ToString();
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.theatreShowList = selectListItemsTheatre;
                        }
                    }
                }
                // --------







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

        [HttpGet]
        public async Task<IActionResult> EditBookingDetails(int bookingId)
        {

            List<BookingModel> bookingModel = null;
            //Get All User List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Booking/ShowBookingList";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        bookingModel = JsonConvert.DeserializeObject<List<BookingModel>>(data);
                        List<SelectListItem> selectListItemsBooking = new List<SelectListItem>();
                        foreach (var item in bookingModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.ShowTime;
                            selectListItem.Value = item.BookingId.ToString();
                            selectListItemsBooking.Add(selectListItem);
                            ViewBag.bookingShowList = selectListItemsBooking;
                        }
                    }
                }
            }



            List<MovieModel> movieModel = null;

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

            List<UserModel> userModel = null;
            //Get All User List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/ShowUserDetails";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        userModel = JsonConvert.DeserializeObject<List<UserModel>>(data);
                        List<SelectListItem> selectListItemsUsers = new List<SelectListItem>();
                        foreach (var item in userModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.FirstName;
                            selectListItem.Value = item.UserId.ToString();
                            selectListItemsUsers.Add(selectListItem);
                            ViewBag.userShowList = selectListItemsUsers;
                        }
                    }
                }
            }



            List<TheatreModel> theatreModel = null;
            // Get All Thetre List
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(data);
                        
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in theatreModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.ThreatreId.ToString();
                            selectListItem.Value = item.ThreatreName;
                         
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.theatreShowList = selectListItemsTheatre;
                        }
                    }
                }
            }

            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Booking/GetBookingById?bookingId=" + bookingId;
                using (var response = await client.GetAsync(endPoint))
                {

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookingModelfinal = JsonConvert.DeserializeObject<BookingModel>(result);
                        return View(bookingModelfinal);

                    }


                }

            }


           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditBookingDetails(BookingModel bookingModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookingModel), System.Text.Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Booking/UpdateBookingDetails";

                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated Successfully";
                        return RedirectToAction("showAllBookingList", "BookingMovie");
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
