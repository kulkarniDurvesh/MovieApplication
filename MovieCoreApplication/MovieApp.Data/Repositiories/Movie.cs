using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class Movie : IMovie
    {
        MovieDbContext _movieDbContext;

        public Movie(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

     

        public string Delete(int movieId)
        {
            string msg = "";
            var movie = _movieDbContext.movieModel.Find(movieId);
            _movieDbContext.movieModel.Remove(movie);   
            _movieDbContext.SaveChanges();
            msg = "Deleted ";
            return msg;
        }

        public object GetMovieById(int movieId)
        {
            var foundMovie = _movieDbContext.movieModel.Find(movieId);
            if (foundMovie != null)
            {
                return foundMovie;
            }
            else
            {
                return "Movie not found";
            }
        }



        public string Register(MovieModel movieModel)
        {
            string msg = "";
            _movieDbContext.movieModel.Add(movieModel);
            _movieDbContext.SaveChanges();
            msg = "Inserted";
            return msg; 
        }

      

        public object SelectMovies()
        {
            List<MovieModel> movieList = _movieDbContext.movieModel.ToList();
            return movieList;   
        }

      

        public string UpdateMovie(MovieModel movieModel)
        {
            string msg = "";
            _movieDbContext.Entry(movieModel).State=EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "UpdatedMovies";
            return msg;

        }
    }
}
