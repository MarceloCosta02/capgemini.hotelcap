using apihotelcap.Domain.Models;

namespace apihotelcap.Domain.RequestModels.Bedroom.BedroomResponses
{
    public class BedroomResponse : BedroomModel
    {
        public int Id { get; set; }     

        public BedroomResponse(int id, int floor, int noBedroom, string situation, int idBedroomType)
            : base(floor, noBedroom, situation, idBedroomType)
        {
            Id = id;          
        }
    }
}
