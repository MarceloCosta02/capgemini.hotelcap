using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Repository
{
    public interface IBedroomRepository
    {
        /// <summary>
        /// Metodo que cadastra os quartos no banco
        /// </summary>
        /// <param name="bedroom"></param>
        void InsertBedroom(BedroomCreateRequest bedroom);

        /// <summary>
        /// Metodo que verifica se o tipo de quarto existe no banco
        /// </summary>
        /// <param name="IdBedroomType"></param>
        int VerifyIfBedroomTypeExists(int IdBedroomType);

        /// <summary>
        /// Metodo que lista um quarto pelo Id
        /// </summary>
        /// <param name="Id"></param>
        BedroomAndBedroomTypeResponse GetBedroomById(int Id);

        /// <summary>
        /// Metodo que lista um quarto pelo Id do tipo do quarto
        /// </summary>
        /// <param name="IdBedroomType"></param>
        IEnumerable<BedroomAndBedroomTypeResponse> GetBedroomByIdBedroomType(int IdBedroomType);

        /// <summary>
        /// Metodo que atualiza a situação de um quarto
        /// </summary>
        /// <param name="bedroomUpdate"></param>
        /// <param name="Id"></param>
        string UpdateSituation(string bedroomUpdate, int Id);
    }
}
