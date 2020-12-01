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
    public class BedroomResponse : BedroomModel
    {
        public int Id { get; set; }     

        public BedroomResponse(int id, int floor, int noBedroom, string situation, int idBedroomType)
            : base(floor, noBedroom, situation, idBedroomType)
        {
            Id = id;          
        }
    }
}
