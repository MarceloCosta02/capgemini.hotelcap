using apihotelcap.Domain.DTO;
using apihotelcap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Services
{
    public interface IInvoiceService
    {
        /// <summary>
        /// Metodo que lista as ocupações não pagas
        /// </summary>
        public Task<TransferResultDTO> GetOccupationsDontPaid();
    }
}
