using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly IOccupationRepository _repo;

        public OccupationService(IOccupationRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Metodo que insere as ocupações no banco
        /// </summary>
        /// <param name="occupation"></param>
        public void InsertOccupation(OccupationCreateRequest occupation)
        {
            var result = ValidateOccupationChilds(occupation);

            if (result)
            {
                occupation.Situation = "N";
                _repo.InsertOccupation(occupation);
            }       
        }

        private bool ValidateOccupationChilds(OccupationCreateRequest occupation)
        {
            if (occupation.QtdeDiarys.Equals(0))
                throw new Exception("A quantidade de diárias não pode ser 0");
            else if (occupation.IdClient.Equals(0))
                throw new Exception("O id do cliente não pode se 0");
            else if (occupation.IdBedroom.Equals(0))
                throw new Exception("O id do quarto não pode se 0");
            else
                return true;
        }      
    }
}
