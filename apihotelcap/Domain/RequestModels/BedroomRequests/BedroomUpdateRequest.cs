namespace apihotelcap.Domain.RequestModels.BedroomRequests
{
    public class BedroomUpdateRequest
    {
        public string Situation { get; set; }

        public BedroomUpdateRequest(string situation)
        {
            Situation = situation;
        }
    }
}
