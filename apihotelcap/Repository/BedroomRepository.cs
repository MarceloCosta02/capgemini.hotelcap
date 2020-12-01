using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses;
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
    public class BedroomRepository : IBedroomRepository
    {
        private readonly string _connectionString;

        public BedroomRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InsertBedroom(BedroomCreateRequest bedroom)
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

        /// <summary>
        /// Metodo que lista um quarto pelo Id
        /// </summary>
        /// <param name="Id"></param>
        public BedroomAndBedroomTypeResponse GetBedroomById(int Id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select br.Floor, br.NoBedroom, br.Situation, bt.Description, bt.Value " +
                        "from BedRoom br inner join BedroomType bt " +
                        "on br.IdBedroomType = bt.Id " +
                        "where br.Id = @Id ";

            var result = connection.Query<BedroomAndBedroomTypeResponse>(query, new { Id = Id });

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Metodo que lista um quarto pelo Id do tipo do quarto
        /// </summary>
        /// <param name="IdBedroomType"></param>
        public IEnumerable<BedroomAndBedroomTypeResponse> GetBedroomByIdBedroomType(int IdBedroomType)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select br.Floor, br.NoBedroom, br.Situation, bt.Description, bt.Value " +
                        "from BedRoom br inner join BedroomType bt " +
                        "on br.IdBedroomType = bt.Id " +
                        "where br.IdBedroomType = @IdBedroomType ";

            var result = connection.Query<BedroomAndBedroomTypeResponse>(query, new { IdBedroomType = IdBedroomType });

            return result;
        }

        /// <summary>
        /// Metodo que atualiza a situação de um quarto
        /// </summary>
        /// <param name="situation"></param>
        /// <param name="Id"></param>
        public string UpdateSituation(string situation, int Id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update BedRoom " +
                        "set Situation = @Situation " +
                        "where Id = @Id ";

            var result = connection.Execute(query, new
            {
                Situation = situation,
                Id = Id
            });

            Debug.WriteLine("Quarto atualizado com sucesso");
            return situation;
        }

    }
}
