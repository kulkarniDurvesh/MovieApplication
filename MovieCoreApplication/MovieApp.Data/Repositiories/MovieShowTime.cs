using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDbContext _movieDbContext;
        public MovieShowTime(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
    
        public string InsertMovieShowTime(MovieSTime movieShowTime)
        {
            _movieDbContext.movieShowTimes.Add(movieShowTime);
            _movieDbContext.SaveChanges();
            return "Inserted";
        }

        public List<MovieSTime> ShowMovieShowTime()
        {
            return _movieDbContext.movieShowTimes.ToList();
        }
    }
}
