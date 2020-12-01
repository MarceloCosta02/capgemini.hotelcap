using apihotelcap.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Infra.ExternalServices
{
    public interface IBankGateway
    {
        string GetBankServiceKey(BankGatewayEndpoint apiKey);

    }
}
