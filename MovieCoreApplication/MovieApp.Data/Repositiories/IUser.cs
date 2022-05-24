using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IUser
    {
        string Register(UserModel userModel);
        object Login();

        string Update();
        string Delete();
        object SelectUsers();
    }
}
