using apihotelcap.Domain.RequestModels.ClientRequests;

namespace apihotelcap.Interfaces.Services
{
    public interface IOccupationService
    {
        /// <summary>
        /// Metodo que insere as ocupações no banco
        /// </summary>
        /// <param name="occupation"></param>
        void InsertOccupation(OccupationCreateRequest occupation);          
    }
}
