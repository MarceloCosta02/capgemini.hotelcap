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
    public class OccupationRepository : IOccupationRepository
    {
        private readonly string _connectionString;

        public OccupationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Metodo que cadastra as ocupações no banco
        /// </summary>
        /// <param name="occupation"></param>
        public void InsertOccupation(OccupationCreateRequest occupation)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "insert into Occupation (QtdeDiarys, Date, Situation, IdBedroom, IdClient) " +
                            "values (@QtdeDiarys, @Date, @Situation, @IdBedroom, @IdClient)";

            var result = connection.Execute(query, new
            {
                QtdeDiarys = occupation.QtdeDiarys,
                Date = occupation.Date,
                Situation = occupation.Situation,
                IdBedroom = occupation.IdBedroom,
                IdClient = occupation.IdClient,
            });

            Debug.WriteLine("Ocupação cadastrada com sucesso");
        }            
    }
}
