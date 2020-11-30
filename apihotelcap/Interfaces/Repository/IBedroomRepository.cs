using apihotelcap.Models.RequestModels;
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
        Bedroom InsertBedroom(Bedroom bedroom);

        /// <summary>
        /// Metodo que verifica se o tipo de quarto existe no banco
        /// </summary>
        /// <param name="IdBedroomType"></param>
        int VerifyIfBedroomTypeExists(int IdBedroomType);
    }
}
