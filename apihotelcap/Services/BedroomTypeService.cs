using apihotelcap.Enums;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using apihotelcap.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BedroomType = apihotelcap.Models.BedroomType;

namespace apihotelcap.Services
{
    public class BedroomTypeService : IBedroomTypeService
    {
        private readonly IBedroomTypeRepository _repo;

        public BedroomTypeService(IBedroomTypeRepository repo)
        {
            _repo = repo;
        }

        public BedroomType InsertBedroomType(BedroomType bedroomType)
        {
            var result = ValidateBedroomTypeChilds(bedroomType);

            if (result)
            {
                _repo.InsertBedroomType(bedroomType);
                return bedroomType;
            }
            else
                return new BedroomType();
        }

        public bool ValidateBedroomTypeChilds(BedroomType bedroomType)
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
