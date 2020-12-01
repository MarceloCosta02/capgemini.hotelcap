using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Repository
{
    public interface IBedroomTypeRepository
    {
        /// <summary>
        /// Metodo que cadastra os tipos quartos no banco
        /// </summary>
        /// <param name="bedroomType"></param>
        void InsertBedroomType(BedroomTypeCreateRequest bedroomType);

        /// <summary>
        /// Metodo que lista todos os tipos de quarto do banco
        /// </summary>  
        IEnumerable<BedroomTypeResponse> GetAllBedroomsType();

        /// <summary>
        /// Metodo que lista um tipo de quarto pelo id
        /// </summary>
        /// <param name="Id"></param>
        BedroomTypeResponse GetBedroomTypeById(int Id);
    }
}
