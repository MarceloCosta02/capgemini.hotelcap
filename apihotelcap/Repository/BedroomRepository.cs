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
    public class BedroomRepository : IBedroomRepository
    {
        private readonly string _connectionString;

        public BedroomRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Bedroom InsertBedroom(Bedroom bedroom)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into BedRoom (Floor, NoBedroom, Situation, IdBedroomType) " +
                            "values (@Floor, @NoBedroom, @Situation, @IdBedroomType)";

            var result = connection.Execute(query, new
            {
                Floor = bedroom.Floor,
                NoBedroom = bedroom.NoBedroom,
                Situation = bedroom.Situation,
                IdBedroomType = bedroom.IdBedroomType
            });

            Debug.WriteLine("Quarto cadastrado com sucesso");
            return bedroom;
        }

        /// <summary>
        /// Metodo que verifica se o tipo de quarto existe no banco
        /// </summary>
        /// <param name="IdBedroomType"></param>
        public int VerifyIfBedroomTypeExists(int IdBedroomType)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select count(Id) from BedroomType " +
                            " where Id = @IdBedroomType";

            var result = connection.Query<int>(query, new { IdBedroomType = IdBedroomType });

            return result.FirstOrDefault();
        }
    }
}
