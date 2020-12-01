using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.Models
{
    public class ClientModel
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Hash { get; set; }

        public ClientModel(string name, string cpf, string hash)
        {
            Name = name;
            CPF = cpf;
            Hash = hash;
        }
    }
}
