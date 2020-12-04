using apihotelcap.Domain.Models;
using System;

namespace apihotelcap.Domain.RequestModels.ClientRequests
{
    public class OccupationCreateRequest : OccupationModel
    {
        public OccupationCreateRequest(int qtdeDiarys, DateTime date, string situation, int idClient, int idBedroom) 
            : base(qtdeDiarys, date, situation, idClient, idBedroom) { }
    }
}
