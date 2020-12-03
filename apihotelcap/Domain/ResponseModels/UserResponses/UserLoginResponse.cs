using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.ResponseModels.UserResponses
{
    public class UserLoginResponse : UserModel
    {
        public int Id { get; set; }
        public string Hash { get; set; }

        public UserLoginResponse(int id, string email, string name, string password, string profile)
            : base(email, name, password, profile) 
        {
            Id = id;
        }
    }
}
