using apihotelcap.Domain.DTO;
using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Infra.Facade
{
    public interface ITransferFacade
    {
        Task<TransferResultDTO> CallTransferAPI(IEnumerable<InvoiceModel> invoices);
    }
}
