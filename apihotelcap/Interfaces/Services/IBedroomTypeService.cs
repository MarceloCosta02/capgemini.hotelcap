using apihotelcap.Models;
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
        BedroomType InsertBedroomType(BedroomType bedroomType);
    }
}
