using apihotelcap.Domain.Models;
using apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses;
using apihotelcap.Domain.RequestModels.BedroomRequests;
using apihotelcap.Domain.RequestModels.ClientRequests;
using apihotelcap.Domain.ResponseModels.ClientResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Interfaces.Repository
{
    public interface IOccupationRepository
    {
        /// <summary>
        /// Metodo que cadastra as ocupações no banco
        /// </summary>
        /// <param name="occupation"></param>
        void InsertOccupation(OccupationCreateRequest occupation);

        /// <summary>
        /// Metodo que lista as ocupações não pagas
        /// </summary>
        List<InvoiceModel> GetOccupationsDontPaid();
    }
}
