using apihotelcap.Configuration;
using System.Text.Json.Serialization;

namespace apihotelcap.Domain.Models
{
    public class InvoiceModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public double TotalValue { get; set; }
        public string Hash { get; set; }
        public string HashBank { get; set; }

        public InvoiceModel(int id, double totalValue, string hash)
        {
            Id = id;
            TotalValue = totalValue;
            Hash = hash;
            HashBank = ConfigurationHelper.GetAppSettingsKeyConfig("HashBank");
        }       
    }
}
