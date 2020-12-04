using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;

namespace apihotelcap.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Metodo que lista um cliente pelo id
        /// </summary>
        /// <param name="Id"></param>
        public ClientResponse GetClientById(int Id)
        {
            var result = _repo.GetClientById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um cliente com o ID: {Id}");
            else
                return result;
        }

        /// <summary>
        /// Metodo que insere os clientes no banco
        /// </summary>
        /// <param name="client"></param>
        public void InsertClient(ClientCreateRequest client)
        {
            var result = ValidateClientChilds(client);

            if (result)
                _repo.InsertClient(client);
        }


        /// <summary>
        /// Metodo que valida os campos enviados por parametro
        /// </summary>
        /// <param name="createRequest"></param>
        private bool ValidateClientChilds(ClientCreateRequest createRequest)
        {
            if (string.IsNullOrEmpty(createRequest.Name))
                throw new Exception("O nome do cliente não pode ser vazio");
            else if (string.IsNullOrEmpty(createRequest.CPF))
                throw new Exception("O CPF não pode ser vazio");
            else if (string.IsNullOrEmpty(createRequest.Hash))
                throw new Exception("O Hash da conta bancária não pode ser vazio");
            else
                return true;
        }      
    }
}
