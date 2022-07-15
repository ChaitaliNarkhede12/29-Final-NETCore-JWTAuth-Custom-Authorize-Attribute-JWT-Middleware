using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servcies
{
    public class UserService : IUserService
    {
        public UserModel GetUserDetails(LoginModel loginModel)
        {
            if (loginModel != null && loginModel.UserName == "admin" && loginModel.Password == "abc")
            {
                UserModel user = new UserModel()
                {
                    UserId = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    Password = "abc"
                };

                return user;
            }
            return null;
        }

        public async Task<UserModel> GetUserDetailsById(Expression<Func<UserModel, bool>> predicate)
        {
            await Task.Delay(100);

            UserModel user = new UserModel()
            {
                UserId = 1,
                Name = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin",
                Password = "abc"
            };

            return user;
        }
    }
}

