using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
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
    public class BedroomTypeService : IBedroomTypeService
    {
        private readonly IBedroomTypeRepository _repo;

        public BedroomTypeService(IBedroomTypeRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<BedroomTypeResponse> GetAllBedroomsType()
        {
            var result = _repo.GetAllBedroomsType();

            if (!result.Any())
                throw new Exception("Não existem quartos cadastrados");
            else
                return result;
        }

        public BedroomTypeResponse GetBedroomTypeById(int Id)
        {
            var result = _repo.GetBedroomTypeById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um tipo de quarto com o ID: {Id}");
            else
                return result;
        }

        public void InsertBedroomType(BedroomTypeCreateRequest bedroomType)
        {
            var result = ValidateBedroomTypeChilds(bedroomType);

            if (result)            
                _repo.InsertBedroomType(bedroomType);           
            
        }      

        public bool ValidateBedroomTypeChilds(BedroomTypeCreateRequest bedroomType)
        {
            if (bedroomType.Value <= 0)
                throw new Exception("O valor não pode ser menor ou igual a R$0,00");
            else if (string.IsNullOrEmpty(bedroomType.Description))
                throw new Exception("A descrição do quarto está vazia");
            else
                return true;
        }      
    }
}
