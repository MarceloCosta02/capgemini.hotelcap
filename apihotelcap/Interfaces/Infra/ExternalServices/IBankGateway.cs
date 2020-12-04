using apihotelcap.Enums;

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
