using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IMovieShowTime
    {
        string InsertMovieShowTime(MovieSTime movieShowTime);

        List<MovieSTime> ShowMovieShowTime();
    }
}
