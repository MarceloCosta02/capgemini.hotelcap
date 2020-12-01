using apihotelcap.Configuration;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Infra.ExternalServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Infra.ExternalServices
{
    public class BankGateway : IBankGateway
    {
        public string GetBankServiceKey(BankGatewayEndpoint endPoint)
        {
            var EndPointBank = ConfigurationHelper.GetAppSettingsKeyConfig("EndPointBank");  
            return EndPointBank += EnumHelper.GetEnumDescription(endPoint);
        }
    }
}
