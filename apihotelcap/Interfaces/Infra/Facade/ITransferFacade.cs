using apihotelcap.Domain.DTO;
using apihotelcap.Domain.Models;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Infra.Facade
{
    public interface ITransferFacade
    {
        /// <summary>
        /// Metodo que chama a API de transferência do banco
        /// </summary>
        /// <param name="invoices"></param>
        Task<TransferResultDTO> CallTransferAPI(InvoiceModel invoices);
    }
}
