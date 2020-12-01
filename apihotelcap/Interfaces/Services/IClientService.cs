using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Metodo que insere os clientes no banco
        /// </summary>
        /// <param name="client"></param>
        void InsertClient(ClientCreateRequest client);

        /// <summary>
        /// Metodo que lista um cliente pelo id
        /// </summary>
        /// <param name="Id"></param>
        ClientResponse GetClientById(int Id);
    }
}
