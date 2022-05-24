using MovieApp.Data.Repositiories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class TheatreService
    {
        ITheatre _itheatre;

        public TheatreService(ITheatre itheatre)
        {
            _itheatre = itheatre;   
        }

        public string Register(TheatreModel theatreModel)
        {
            return _itheatre.Register(theatreModel);

        }

        public object SelectTheatre()
        {
            return _itheatre.SelectTheatre();
        }

        public object UpdateMovie(TheatreModel theatre)
        {
            return _itheatre.Update(theatre);
        }



    }
}
