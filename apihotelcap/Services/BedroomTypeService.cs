using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apihotelcap.Services
{
    public class BedroomTypeService : IBedroomTypeService
    {
        private readonly IBedroomTypeRepository _repo;

        public BedroomTypeService(IBedroomTypeRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Metodo que retorna todos os tipos de quarto
        /// </summary>  
        public IEnumerable<BedroomTypeResponse> GetAllBedroomsType()
        {
            var result = _repo.GetAllBedroomsType();

            if (!result.Any())
                throw new Exception("Não existem quartos cadastrados");
            else
                return result;
        }

        /// <summary>
        /// Metodo que retorna um tipo de quarto pelo id
        /// </summary>
        /// <param name="Id"></param>
        public BedroomTypeResponse GetBedroomTypeById(int Id)
        {
            var result = _repo.GetBedroomTypeById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um tipo de quarto com o ID: {Id}");
            else
                return result;
        }

        /// <summary>
        /// Metodo que insere os tipos de quartos
        /// </summary>
        /// <param name="bedroomType"></param>
        public void InsertBedroomType(BedroomTypeCreateRequest bedroomType)
        {
            var result = ValidateBedroomTypeChilds(bedroomType);

            if (result)            
                _repo.InsertBedroomType(bedroomType);           
            
        }

        /// <summary>
        /// Metodo que valida os campos enviados por parametro
        /// </summary>
        /// <param name="bedroomType"></param>
        private bool ValidateBedroomTypeChilds(BedroomTypeCreateRequest bedroomType)
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
