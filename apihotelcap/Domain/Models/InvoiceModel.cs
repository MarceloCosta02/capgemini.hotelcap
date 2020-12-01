using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.Models
{
    public class InvoiceModel
    {
        public double TotalValue { get; set; }
        public string HashClient { get; set; }

        public const string HashBank = "AGR1NVBBDC4NXT3";

        public InvoiceModel(double totalValue, string hashClient)
        {
            TotalValue = totalValue;
            HashClient = hashClient;
        }       
    }
}
