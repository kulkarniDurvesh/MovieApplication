using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using MovieApp.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    
        public async Task<IActionResult> ShowAllUsers()
        {
            //Fetch API,AxiosApi,HttpClient
            //Http Verbs: GET,POST,DELETE..
            //Http Req/response
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/ShowUserDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
                    }
                }
            }

           return View();   
        }

        [HttpGet]
        public IActionResult AddUser()
        { 
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel userModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Register";

                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Registered Successfully!!!";
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

        public async Task<IActionResult> EditUser(int userId)
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/GetUserById?userId="+userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            ViewBag.status = "";

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");

                string endPoint = _configuration["WebApiURL"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated Successfully!!!";
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


        public async Task<IActionResult> Delete(int userId)
        {

            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "User/GetUserById?userId=" + userId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }
                }
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UserModel userModel)
        {
            ViewBag.status = "";

            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebApiURL"] + "User/DeleteUser?userId="+userModel.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Deleted Successfully!!!";
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


        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("SelectMovies", "Movie");
                    }
                    
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();
        }


    }
}
