using apihotelcap.Configuration;
using apihotelcap.Domain.RequestModels.UserRequests;
using apihotelcap.Domain.ResponseModels.UserResponses;
using apihotelcap.Interfaces.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apihotelcap.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Metodo que cadastra os usuários no banco
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(UserCreateRequest user)
        {
            var result = ValidateUserChilds(user);

            if(result)
                _repo.InsertUser(user);
        }

        /// <summary>
        /// Metodo loga o usuário
        /// </summary>
        /// <param name="user"></param>
        public UserLoginResponse Login(UserLoginRequest user)
        {
            var result = _repo.ValidateUser(user);

            if (result == null || result.Equals(""))
                throw new Exception("Dados de login incorretos");
            else
            {
                var token = GenerateToken(result);
                result.Hash = token;
                result.Password = null;

                return result;
            }
        }

        /// <summary>
        /// Metodo que gera o JWT Token
        /// </summary>
        /// <param name="user"></param>
        private string GenerateToken(UserLoginResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationHelper.GetAppSettingsKeyConfig("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString().Trim()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Profile)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Metodo que valida os campos enviados por parametro
        /// </summary>
        /// <param name="user"></param>
        private bool ValidateUserChilds(UserCreateRequest user)
        {
            if (string.IsNullOrEmpty(user.Name))
                throw new Exception("O nome do usuário não pode ser vazio");
            else if (string.IsNullOrEmpty(user.Email))
                throw new Exception("O email do usuário não pode ser vazio");
            else if (string.IsNullOrEmpty(user.Password))
                throw new Exception("A senha do usuário não pode ser vazia");
            else if (string.IsNullOrEmpty(user.Profile))
                throw new Exception("O perfil do usuário não pode ser vazio");
            else
                return true;
        }
    }
}
