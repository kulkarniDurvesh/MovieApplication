using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface ITheatre
    {
        string Register(TheatreModel theatreModel);

        string Update(TheatreModel theatreModel);
        string Delete();
        object SelectTheatre();

    }
}
