using apihotelcap.Domain.DTO;
using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using apihotelcap.Enums;
using apihotelcap.Interfaces.Infra.Facade;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public async Task<TransferResultDTO> GetOccupationsDontPaid()
        {
            var occupations = _repo.GetOccupationsDontPaid();

            var result = await _transferFacade.CallTransferAPI(occupations);

            return result;
        }
    }
}
