using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.ResponseModels.ClientResponses
{
    public class OccupationResponse : OccupationModel
    {
        public int Id { get; set; }

        public OccupationResponse(int id, int qtdeDiarys, DateTime date, string situation, int idClient, int idBedroom) 
            : base(qtdeDiarys, date, situation, idClient, idBedroom)
        {
            Id = id;       
        }
    }
}
