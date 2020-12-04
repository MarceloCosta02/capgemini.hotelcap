using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.ClientRequests
{
    public class ClientCreateRequest : ClientModel
    {
        public ClientCreateRequest(string name, string cpf, string hash) 
            : base(name, cpf, hash) { }
    }
}
