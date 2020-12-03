﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Domain.ResponseModels.UserResponses;
using apihotelcap.Domain.RequestModels.UserRequests;
using System.Data.SqlClient;
using Dapper;
using System.Diagnostics;

namespace apihotelcap.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
               
        public void InsertUser(UserCreateRequest user)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into UserHotel (Name, Email, Password, Profile) " +
                            "values (@Name, @Email, @Password, @Profile)";

            var result = connection.Execute(query, new
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Profile = user.Profile
            });

            Debug.WriteLine("User cadastrado com sucesso");
        }


        public UserLoginResponse ValidateUser(UserLoginRequest user)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select Id, Email, Name, Password, Profile from UserHotel " +
                            " where Email = @Email" +
                            " and Password = @Password";

            var result = connection.Query<UserLoginResponse>(query, new { Email = user.Email, Password = user.Password }); ;

            return result.FirstOrDefault();
        }
    }
}