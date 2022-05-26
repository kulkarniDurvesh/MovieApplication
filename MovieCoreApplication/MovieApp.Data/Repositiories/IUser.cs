using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositiories
{
    public interface IUser
    {
        string Register(UserModel userModel);
        UserModel Login(UserModel userModel);

        string UpdateUser(UserModel userModel);
        string DeleteUser(int userId);
        object ShowUserDetails();
        object GetUserById(int userId);
    }
}
