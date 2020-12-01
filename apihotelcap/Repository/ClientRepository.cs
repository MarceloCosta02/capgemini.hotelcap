using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Interfaces.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }      
      

        /// <summary>
        /// Metodo que cadastra os clientes no banco
        /// </summary>
        /// <param name="client"></param>
        public void InsertClient(ClientCreateRequest client)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into Client (Name, CPF, Hash) " +
                            "values (@Name, @CPF, @Hash)";

            var result = connection.Execute(query, new
            {
                Name = client.Name,
                CPF = client.CPF,
                Hash = client.Hash
            });

            Debug.WriteLine("Cliente cadastrado com sucesso");
        }

        /// <summary>
        /// Metodo que lista um cliente pelo id
        /// </summary>
        /// <param name="Id"></param>
        public ClientResponse GetClientById(int Id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select Id, Name, CPF from Client " +
                            " where Id = @Id";

            var result = connection.Query<ClientResponse>(query, new { Id = Id });

            return result.FirstOrDefault();
        }
    }
}
