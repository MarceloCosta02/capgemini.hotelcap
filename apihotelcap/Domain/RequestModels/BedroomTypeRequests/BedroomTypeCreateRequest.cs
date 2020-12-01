using apihotelcap.Domain.Models;
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
    public class BedroomTypeCreateRequest : BedroomTypeModel
    {
        public BedroomTypeCreateRequest(string description, double value)
            : base(description, value) { }
    }
}
