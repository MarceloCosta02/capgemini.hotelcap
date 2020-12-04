using apihotelcap.Domain.DTO;
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
