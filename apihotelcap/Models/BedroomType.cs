using apihotelcap.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apihotelcap.Models
{
    public class BedroomType
    {
        public string Description { get; set; }

        public double Value { get; set; }   

        public BedroomType() { }
    }
}
