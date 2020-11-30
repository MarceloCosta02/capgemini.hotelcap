using apihotelcap.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apihotelcap.Models.RequestModels
{
    public class Bedroom
    {
        [Description("Andar")]
        public int Floor { get; set; }

        [Description("Número do Quarto")]
        public int NoBedroom { get; set; }

        public string Situation { get; set; }

        public int IdBedroomType { get; set; }

        public Bedroom() { }
    }
}
