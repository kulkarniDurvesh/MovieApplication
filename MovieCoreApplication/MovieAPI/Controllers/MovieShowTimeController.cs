using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowTimeController : ControllerBase
    {
        MovieShowTimeService _MovieShowTimeService { get; set; }

        public MovieShowTimeController(MovieShowTimeService movieShowTimeService)
        {
            _MovieShowTimeService = movieShowTimeService;
        }

        [HttpGet("ShowMovieTimeList")]
        public IActionResult ShowMovieTimeList()
        {
            return Ok(_MovieShowTimeService.ShowMovieTimeList());
        }

        [HttpPost("InsertMovieTimeList")]
        public IActionResult InsertMovieTimeList(MovieSTime movieShowTime)
        {
            return Ok(_MovieShowTimeService.InsertMovieShowTime(movieShowTime));
        }




    }
}
