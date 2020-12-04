using apihotelcap.Domain.Models;

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
