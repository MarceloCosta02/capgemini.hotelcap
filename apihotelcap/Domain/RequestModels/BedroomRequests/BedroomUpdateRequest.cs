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
