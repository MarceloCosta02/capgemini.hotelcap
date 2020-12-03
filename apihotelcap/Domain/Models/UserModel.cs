using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
               
        public UserModel(string email, string name, string password, string profile)
        {
            Email = email;
            Name = name;
            Password = password;
            Profile = profile;
        }
    }
}
