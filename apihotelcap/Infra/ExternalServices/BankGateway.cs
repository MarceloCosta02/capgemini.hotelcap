using apihotelcap.Configuration;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Infra.ExternalServices;

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
