using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserModel GetUserDetails(LoginModel loginModel);
        Task<UserModel> GetUserDetailsById(Expression<Func<UserModel, bool>> predicate);
    }
}
