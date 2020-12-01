using apihotelcap.Domain.Models;
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

        /// <summary>
        /// Metodo que lista as ocupações não pagas
        /// </summary>
        public async Task<List<InvoiceModel>> GetOccupationsDontPaid()
        {
            var connection = new SqlConnection(_connectionString);

            var query = "select occ.Id, (occ.QtdeDiarys * bt.Value) as TotalValue, c.Hash from Occupation occ " +
                        "inner join Client c on c.Id = occ.IdClient " +
                        "inner join BedRoom b on b.Id = occ.IdBedroom " +
                        "inner join BedroomType bt on bt.Id = b.IdBedroomType " +
                        "where occ.Situation = 'N' ";

            var result = await connection.QueryAsync<InvoiceModel>(query);
            
            return result.ToList();
        }

        public void SetOccupationsToPaid(string Situation, int Id)
        {
            var connection = new SqlConnection(_connectionString);

            var query = "update Occupation " +
                        "set Situation = @Situation " +
                        "where Id = @Id ";

            var result = connection.Execute(query, new
            {
                Situation = Situation,
                Id = Id
            });

            Debug.WriteLine("Ocupação atualizada com sucesso");
        }
    }
}
