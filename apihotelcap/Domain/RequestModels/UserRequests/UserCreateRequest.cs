using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.RequestModels.UserRequests
{
    public class UserCreateRequest : UserModel
    {
        public UserCreateRequest(string name, string email, string password, string profile) 
            : base(name, email, password, profile) { }
    }
}
