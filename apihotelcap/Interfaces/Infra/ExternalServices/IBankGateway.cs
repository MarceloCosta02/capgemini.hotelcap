using apihotelcap.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Infra.ExternalServices
{
    public interface IBankGateway
    {
        /// <summary>
        /// Metodo que concatena a baseURL com o endpoint de transferência
        /// </summary>
        /// <param name="apiKey"></param>
        string GetBankServiceKey(BankGatewayEndpoint apiKey);

    }
}
