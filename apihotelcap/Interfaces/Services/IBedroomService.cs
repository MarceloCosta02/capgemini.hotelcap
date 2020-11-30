using apihotelcap.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Services
{
    public interface IBedroomService
    {
        /// <summary>
        /// Metodo que insere quartos
        /// </summary>
        /// <param name="bedroom"></param>
        Bedroom InsertBedroom(Bedroom bedroom);
    }
}
