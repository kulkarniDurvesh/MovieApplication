using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Data.Repositiories;
using MovieApp.Entity;

namespace MovieApp.Business.Services
{
    public class UserService
    {
        IUser _iuser;
        public UserService(IUser user)
        {
            _iuser = user;
        }
        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }
        public object SelectUsers()
        {
            return _iuser.SelectUsers();
        }
    }
}
