using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IMovie
    {
        string Register(MovieModel movieModel);
       

        string UpdateMovie(MovieModel movieModel);
        string Delete(int movieId);
        object SelectMovies();
        MovieModel GetMovieById(int movieId);
    }
}
