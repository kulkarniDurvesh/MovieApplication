using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieService
    {
        IMovie _imovie;

        public MovieService(IMovie imovie)
        {
            _imovie = imovie;   
        }

        public string Register(MovieModel movieModel)
        { 
            return _imovie.Register(movieModel);    
        
        }

        public object SelectMovies()
        {
            return _imovie.SelectMovies();
        }

        public string UpdateMovie(MovieModel movie)
        {
             _imovie.UpdateMovie(movie);
            return "updated successfully";
        }

        public string DeleteMovie(int movieId)
        {
            _imovie.Delete(movieId);
            return "deleted successfully";
        }

        public object GetMovieById(int movieId)
        {
          return  _imovie.GetMovieById(movieId);
        }



    }
}
