using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teacher.Business.Services;
using Teacher.Entity;

namespace Teacher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        TeacherService _teacherService;

        public TeacherController(TeacherService teacherService)
        {
            _teacherService = teacherService;   
        }


        [HttpGet("ShowAllTeacher")]
        public IActionResult ShowAllTeacher()
        {
            return Ok(_teacherService.ShowAllTeacher());
        }

        [HttpPost("Register")]
        public IActionResult Register(Master master)
        {
            return Ok(_teacherService.Register(master));
        }

    }
}
