using apihotelcap.Enums;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using apihotelcap.Models.RequestModels;
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

        public Bedroom InsertBedroom(Bedroom bedroom)
        {
            var result = ValidateBedroomChilds(bedroom);

            if (result)
            {
                int IdBedroomType = _repo.VerifyIfBedroomTypeExists(bedroom.IdBedroomType);
                if (IdBedroomType != 0)
                {
                    _repo.InsertBedroom(bedroom);
                    return bedroom;
                }
                else
                    throw new Exception($"O quarto com ID {bedroom.IdBedroomType} não está cadastrado");
            }
            else
                return new Bedroom();
        }

        public bool ValidateBedroomChilds(Bedroom bedroom)
        {     
            if (bedroom.NoBedroom < 1)
                throw new Exception("O número de quartos não pode ser menor que 1");
            else if (!bedroom.Situation.Contains(nameof(BedroomTypeValues.A)) || !bedroom.Situation.Contains(nameof(BedroomTypeValues.I)))
                throw new Exception($"A situação do quarto não pode ser {bedroom.Situation}, são aceitos apenas A (Ativo) e I (Inativo)");
            else if (bedroom.IdBedroomType == 0)
                throw new Exception("O Id do quarto não pode ser 0");
            else
                return true;
        }
    }
}
