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
        public object ShowUserDetails()
        {
            return _iuser.ShowUserDetails();
        }


        public string UpdateUser(UserModel user)
        {
            _iuser.UpdateUser(user);
            return "updated successfully";
        }

        public string DeleteUser(int userId)
        {
            _iuser.DeleteUser(userId);
            return "deleted successfully";
        }

        public object GetUserById(int userId)
        {
            return _iuser.GetUserById(userId);
            
        }


    }
}
