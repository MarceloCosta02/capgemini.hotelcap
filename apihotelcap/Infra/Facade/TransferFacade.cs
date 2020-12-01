using apihotelcap.Domain.DTO;
using apihotelcap.Domain.Models;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Infra.ExternalServices;
using apihotelcap.Interfaces.Infra.Facade;
using Newtonsoft.Json;
using Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apihotelcap.Infra.Facade
{
    public class TransferFacade : ITransferFacade
    {
        private readonly HttpClient _client;
        private readonly IBankGateway _bankGateway;

        public TransferFacade(IBankGateway bankGateway)
        {
            _client = new HttpClient();
            _bankGateway = bankGateway;
        }

        public async Task<TransferResultDTO> CallTransferAPI(IEnumerable<InvoiceModel> invoices)
        {
            try
            {
                var jsonBody = JsonConvert.SerializeObject(invoices);
                var data = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage resposta = await _client.PostAsync(_bankGateway.GetBankServiceKey(BankGatewayEndpoint.Transfer), data);
                resposta.EnsureSuccessStatusCode();
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TransferResultDTO>(json.ToString());
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"API de Transferência Indisponivel {ex.Message}", ex.InnerException);
            }
            catch (JsonSerializationException js)
            {
                throw new HttpRequestException($"Retorno da API contem valores nulos {js.Message}", js.InnerException);
            }
        }
    }
}
