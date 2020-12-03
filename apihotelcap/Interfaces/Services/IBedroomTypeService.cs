using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Services
{
    public interface IBedroomTypeService
    {
        /// <summary>
        /// Metodo que insere os tipos de quartos
        /// </summary>
        /// <param name="bedroomType"></param>
        void InsertBedroomType(BedroomTypeCreateRequest bedroomType);

        /// <summary>
        /// Metodo que retorna todos os tipos de quarto
        /// </summary>  
        IEnumerable<BedroomTypeResponse> GetAllBedroomsType();

        /// <summary>
        /// Metodo que retorna um tipo de quarto pelo id
        /// </summary>
        /// <param name="Id"></param>
        BedroomTypeResponse GetBedroomTypeById(int Id);
    }
}
