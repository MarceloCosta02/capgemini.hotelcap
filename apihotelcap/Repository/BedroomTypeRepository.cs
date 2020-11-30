using apihotelcap.Interfaces.Repository;
using apihotelcap.Models;
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

        public BedroomType InsertBedroomType(BedroomType bedroomType)
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
            return bedroomType;
        }
    }
}
