using apihotelcap.Domain.RequestModels.UserRequests;
using apihotelcap.Domain.ResponseModels.UserResponses;

namespace apihotelcap.Interfaces.Repository
{
    public interface IUserService
    {
        /// <summary>
        /// Metodo que cadastra os usuários no banco
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(UserCreateRequest user);

        /// <summary>
        /// Metodo loga o usuário
        /// </summary>
        /// <param name="user"></param>
        UserLoginResponse Login(UserLoginRequest user);
    }
}
