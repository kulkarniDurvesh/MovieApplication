using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    
    public class Theatre : ITheatre
    {
        MovieDbContext _movieDbContext;

        public Theatre(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

   

        public string Delete(int theatreId)
        {
            string msg = "";
            var theatre = _movieDbContext.theatreModel.Find(theatreId);
            // _movieDbContext.movieModel.Remove(theatre);
            _movieDbContext.Entry(theatre).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            msg = "Deleted ";
            return msg;
        }

        public string Register(TheatreModel theatreModel)
        {
            string msg = "";
            _movieDbContext.theatreModel.Add(theatreModel);
            _movieDbContext.SaveChanges();
            msg = "Inserted";
            return msg;

        }

        public object SelectTheatre()
        {
           List<TheatreModel>theatreList = _movieDbContext.theatreModel.ToList();   
            return theatreList;
        }

        public string UpdateTheatre(TheatreModel theatreModel)
        {
            string msg = "";
            _movieDbContext.Entry(theatreModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "Theatre Updated";
            return msg;
        }


        public object GetTheatreById(int theatreId)
        {
            var foundTheatre = _movieDbContext.theatreModel.Find(theatreId);
            if (foundTheatre != null)
            {
                return foundTheatre;
            }
            else
            {
                return "Theatre not found";
            }
        }

    }
}
