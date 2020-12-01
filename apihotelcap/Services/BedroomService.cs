using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static apihotelcap.Enums.BedroomType;

namespace apihotelcap.Services
{
    public class BedroomService : IBedroomService
    {
        private readonly IBedroomRepository _repo;

        public BedroomService(IBedroomRepository repo)
        {
            _repo = repo;
        }

        public BedroomAndBedroomTypeResponse GetBedroomById(int Id)
        {
            var result = _repo.GetBedroomById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um quarto com o ID: {Id}");
            else
                return result;
        }

        public IEnumerable<BedroomAndBedroomTypeResponse> GetBedroomByIdBedroomType(int IdBedroomType)
        {
            var result = _repo.GetBedroomByIdBedroomType(IdBedroomType);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um quarto com o ID de tipo do quarto: {IdBedroomType}");
            else
                return result;
        }

        public void InsertBedroom(BedroomCreateRequest bedroom)
        {
            var result = ValidateBedroomChilds(bedroom);

            if (result)
            {
                int IdBedroomType = _repo.VerifyIfBedroomTypeExists(bedroom.IdBedroomType);
                if (IdBedroomType != 0)
                {
                    _repo.InsertBedroom(bedroom);
                }
                else
                    throw new Exception($"O quarto com ID {bedroom.IdBedroomType} não está cadastrado");
            }          
        }

        public string UpdateSituation(BedroomUpdateRequest bedroomUpdate, int Id)
        {
            if (!bedroomUpdate.Situation.Any())
                throw new Exception("Situation não pode ser vazio");
            else
            {
                var result = _repo.UpdateSituation(bedroomUpdate.Situation, Id);
                return result;
            }
        }

        public bool ValidateBedroomChilds(BedroomCreateRequest bedroom)
        {
            string Active = BedroomTypeValues.A.ToString();
            string Inactive = BedroomTypeValues.I.ToString();

            if (bedroom.NoBedroom < 1)
                throw new Exception("O número de quartos não pode ser menor que 1");
            else if (!bedroom.Situation.Equals(Active) && !bedroom.Situation.Equals(Inactive))
                throw new Exception($"A situação do quarto não pode ser {bedroom.Situation}, são aceitos apenas A (Ativo) e I (Inativo)");
            else if (bedroom.IdBedroomType == 0)
                throw new Exception("O Id do quarto não pode ser 0");
            else
                return true;
        }            
    }
}
