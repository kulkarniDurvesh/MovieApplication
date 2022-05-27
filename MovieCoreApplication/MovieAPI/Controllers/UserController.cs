using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("ShowUserDetails")]
        public IActionResult ShowUserDetails()
        {
            return Ok(_userService.ShowUserDetails());

        }
        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));

        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserModel userModel)
        {
            _userService.UpdateUser(userModel);
            return Ok("Updated Successfully");
        }



        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            _userService.DeleteUser(userId);
            return Ok("User deleted successfully");
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int userId)
        {
            return Ok(_userService.GetUserById(userId));
        }


    }
}
