using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Data.Repositiories;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("SelectMovies")]
        public IActionResult SelectMovies()
        {
            return Ok(_movieService.SelectMovies());

        }
        [HttpPost("Register")]
        public IActionResult Register(MovieModel movieModel)
        {
            return Ok(_movieService.Register(movieModel));

        }

        [HttpPut("UpdateMovies")]
        public IActionResult UpdateMovies([FromBody] MovieModel movieModel)
        {
            _movieService.UpdateMovie(movieModel);
                return Ok("Updated Successfully");
        }



        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId) 
        {
            _movieService.DeleteMovie(movieId);
            return Ok("Movie deleted successfully");
        }
        

    }
}
