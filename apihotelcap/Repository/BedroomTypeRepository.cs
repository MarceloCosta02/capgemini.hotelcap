using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
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
    public class BedroomTypeRepository : IBedroomTypeRepository
    {
        private readonly string _connectionString;

        public BedroomTypeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InsertBedroomType(BedroomTypeCreateRequest bedroomType)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into BedRoomType (Description, Value) " +
                            "values (@Description, @Value)";

            var result = connection.Execute(query, new
            {
                Description = bedroomType.Description,
                Value = bedroomType.Value,              
            });

            Debug.WriteLine("Tipo de Quarto cadastrado com sucesso");
        }

        /// <summary>
        /// Metodo que lista todos os tipos de quarto do banco
        /// </summary>  
        public IEnumerable<BedroomTypeResponse> GetAllBedroomsType()
        {
            var connection = new SqlConnection(_connectionString);

            var result = connection
                            .Query<BedroomTypeResponse>("select Id, Description, Value from BedroomType");

            return result;
        }

        /// <summary>
        /// Metodo que lista um tipo de quarto pelo id
        /// </summary>
        /// <param name="Id"></param>
        public BedroomTypeResponse GetBedroomTypeById(int Id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select Id, Description, Value from BedroomType " +
                            " where Id = @Id";

            var result = connection.Query<BedroomTypeResponse>(query, new { Id = Id });

            return result.FirstOrDefault();
        }      
    }
}
