using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime;

        public MovieShowTimeService(IMovieShowTime movieShowTime)
        {
            _movieShowTime = movieShowTime;
        }

        public string InsertMovieShowTime(MovieSTime movieShowTime)
        { 
            return _movieShowTime.InsertMovieShowTime(movieShowTime);
        }

        public List<MovieSTime> ShowMovieTimeList()
        {
            return _movieShowTime.ShowMovieShowTime();
        }

    }
}
