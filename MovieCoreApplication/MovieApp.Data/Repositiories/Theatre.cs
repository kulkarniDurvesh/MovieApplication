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

        public string Delete()
        {
            throw new NotImplementedException();
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

        public string Update(TheatreModel theatreModel)
        {
            throw new NotImplementedException();
        }
    }
}
