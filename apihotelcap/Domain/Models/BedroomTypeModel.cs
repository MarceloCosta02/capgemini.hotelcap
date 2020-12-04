namespace apihotelcap.Domain.Models
{
    public class BedroomTypeModel
    {
        public string Description { get; set; }

        public double Value { get; set; }   

        public BedroomTypeModel() { }

        public BedroomTypeModel(string description, double value)
        {
            Description = description;
            Value = value;
        }
    }
}
