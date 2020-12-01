using apihotelcap.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
