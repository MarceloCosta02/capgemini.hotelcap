using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.UserRequests
{
    public class UserCreateRequest : UserModel
    {
        public UserCreateRequest(string name, string email, string password, string profile) 
            : base(name, email, password, profile) { }
    }
}
