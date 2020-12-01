using apihotelcap.Domain.Models;
using apihotelcap.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
