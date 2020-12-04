using apihotelcap.Domain.DTO;
using apihotelcap.Interfaces.Infra.Facade;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IOccupationRepository _repo;
        private readonly ITransferFacade _transferFacade;

        public InvoiceService(IOccupationRepository repo, ITransferFacade transferFacade)
        {
            _repo = repo;
            _transferFacade = transferFacade;
        }

        /// <summary>
        /// Metodo que lista as ocupações não pagas
        /// </summary>
        public async Task<TransferResultDTO> GetOccupationsDontPaid()
        {
            TransferResultDTO result = null;
            var occupations = await _repo.GetOccupationsDontPaid();

            if (!occupations.Any())
                return new TransferResultDTO("Não existem ocupações com pagamento pendente", 200);
            else
            {
                foreach (var item in occupations)
                {
                    result = await _transferFacade.CallTransferAPI(item);
                    if (result.Status == 404 || result.Status == 400)
                        return result;
                    else
                    {
                        _repo.SetOccupationsToPaid("P", item.Id);
                    }
                }

                return result;
            }           
        }
    }
}
