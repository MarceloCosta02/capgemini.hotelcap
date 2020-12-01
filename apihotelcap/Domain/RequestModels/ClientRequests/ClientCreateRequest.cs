using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.RequestModels.ClientRequests
{
    public class ClientCreateRequest : ClientModel
    {
        public ClientCreateRequest(string name, string cpf, string hash) 
            : base(name, cpf, hash) { }
    }
}
