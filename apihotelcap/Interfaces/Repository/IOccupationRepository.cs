using apihotelcap.Domain.Models;
using apihotelcap.Domain.RequestModels.ClientRequests;
using System.Collections.Generic;
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
        Task<List<InvoiceModel>> GetOccupationsDontPaid();

        /// <summary>
        /// Metodo que atualiza as ocupações para pagas
        /// </summary>
        void SetOccupationsToPaid(string Situation, int Id);
    }
}
