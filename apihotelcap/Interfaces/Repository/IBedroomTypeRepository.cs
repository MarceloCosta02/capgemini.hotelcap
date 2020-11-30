using apihotelcap.Models;
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
        BedroomType InsertBedroomType(BedroomType bedroomType);     
    }
}
