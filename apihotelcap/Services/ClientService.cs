using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }                   

        public ClientResponse GetClientById(int Id)
        {
            var result = _repo.GetClientById(Id);

            if (result == null || result.Equals(""))
                throw new Exception($"Não existe um cliente com o ID: {Id}");
            else
                return result;
        }      

        public void InsertClient(ClientCreateRequest client)
        {
            var result = ValidateClientChilds(client);

            if (result)
                _repo.InsertClient(client);
        }

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
