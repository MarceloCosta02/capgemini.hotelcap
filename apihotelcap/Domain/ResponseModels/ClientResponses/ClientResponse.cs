using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.ResponseModels.ClientResponses
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public ClientResponse(int id, string name, string cPF)
        {
            Id = id;
            Name = name;
            CPF = cPF;
        }
    }
}
