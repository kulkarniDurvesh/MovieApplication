using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }
        [HttpGet("SelectTheatre")]
        public IActionResult SelectTheatre()
        {
            return Ok(_theatreService.SelectTheatre());

        }
        [HttpPost("Register")]
        public IActionResult Register(TheatreModel theatreModel)
        {
            return Ok(_theatreService.Register(theatreModel));

        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int theatreId)
        {
            _theatreService.DeleteTheatre(theatreId);
            return Ok("Deleted Sucessfully");
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre([FromBody]TheatreModel theatreModel)
        {
            _theatreService.UpdateTheatre(theatreModel);
            return Ok("Updated Successfully");
        }

        [HttpGet("GetTheatreById")]
        public IActionResult GetTheatreById(int theatreId)
        {
            return Ok(_theatreService.GetTheatreById(theatreId));
        }

    }
}
