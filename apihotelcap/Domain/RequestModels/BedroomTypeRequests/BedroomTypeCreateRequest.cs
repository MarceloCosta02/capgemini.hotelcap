using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.BedroomRequests
{
    public class BedroomTypeCreateRequest : BedroomTypeModel
    {
        public BedroomTypeCreateRequest(string description, double value)
            : base(description, value) { }
    }
}
