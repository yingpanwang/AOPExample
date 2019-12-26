using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IUserService 
    {
        User GetUser();
    }

    [MyIntercept]
    public class UserService:IUserService
    {

        public User GetUser() 
        {
            return new User() {  };
        }
    }
}
