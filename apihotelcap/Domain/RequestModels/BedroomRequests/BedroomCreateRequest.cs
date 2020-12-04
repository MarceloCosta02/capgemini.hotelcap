using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.BedroomRequests
{
    public class BedroomCreateRequest : BedroomModel
    {
        public BedroomCreateRequest(int floor, int noBedroom, string situation, int idBedroomType)
            : base(floor, noBedroom, situation, idBedroomType) {   }
    }
}
