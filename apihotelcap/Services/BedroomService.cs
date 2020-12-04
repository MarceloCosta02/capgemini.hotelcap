using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Metodo que retorna um quarto pelo Id
        /// </summary>
        /// <param name="Id"></param>
        public BedroomAndBedroomTypeResponse GetBedroomById(int Id)
        {
            var result = _repo.GetBedroomById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um quarto com o ID: {Id}");
            else
                return result;
        }

        /// <summary>
        /// Metodo que retorna um quarto pelo Id do tipo do quarto
        /// </summary>
        /// <param name="IdBedroomType"></param>
        public IEnumerable<BedroomAndBedroomTypeResponse> GetBedroomByIdBedroomType(int IdBedroomType)
        {
            var result = _repo.GetBedroomByIdBedroomType(IdBedroomType);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um quarto com o ID de tipo do quarto: {IdBedroomType}");
            else
                return result;
        }

        /// <summary>
        /// Metodo que insere quartos
        /// </summary>
        /// <param name="bedroom"></param>
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

        /// <summary>
        /// Metodo que atualiza a situação de um quarto
        /// </summary>
        /// <param name="bedroomUpdate"></param>
        /// <param name="Id"></param>
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

        /// <summary>
        /// Metodo que valida os campos enviados por parametro
        /// </summary>
        /// <param name="bedroom"></param>
        private bool ValidateBedroomChilds(BedroomCreateRequest bedroom)
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
