using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System.Linq;
//Linq:Objects
namespace MovieApp.Data.Repositiories
{
    public class User : IUser
    {
        MovieDbContext _movieDbContext;

        public User(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }
        public string DeleteUser(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "";
            _movieDbContext.userModel.Remove(user);
            //_movieDbContext.Entry(user).State = EntityState.Deleted;
            _movieDbContext.SaveChanges();
            return "Deleted";
        }

        public UserModel Login(UserModel userModel)
        {
            //Linq   var result=from table in collectionObjectxmlTable select table
            //select * from userModel where email=userModel.email and password = userModel.password

            UserModel userData = null;
            var user = _movieDbContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;
            

        }

        public string Register(UserModel userModel)
        {
            string msg = "";
            //insert into usermodel.id,userModel.fname
            _movieDbContext.userModel.Add(userModel);
            _movieDbContext.SaveChanges();//Execute sql statement
            msg = "Inserted";
            return msg;
        }

        public object GetUserById(int userId)
        {
            var foundUser = _movieDbContext.userModel.Find(userId);
            if (foundUser != null)
            {
                return foundUser;
            }
            else
            {
                return "User not found";
            }
        }

        public object ShowUserDetails()
        {

            List<UserModel> userList = _movieDbContext.userModel.ToList();
            return userList;
        }

        public string UpdateUser(UserModel userModel)
        {
            string msg = "";
            _movieDbContext.Entry(userModel).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
            msg = "UpdatedUser";
            return msg;
        }
    }
}
