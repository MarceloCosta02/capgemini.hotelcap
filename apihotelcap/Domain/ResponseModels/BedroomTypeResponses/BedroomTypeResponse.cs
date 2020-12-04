using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses
{
    public class BedroomTypeResponse : BedroomTypeModel
    {
        public int Id { get; set; }     

        public BedroomTypeResponse(int id, string description, double value)
            : base(description, value)
        {
            Id = id;           
        }
    }
}
