using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.ResponseModels.Bedroom.BedroomResponses
{
    public class BedroomAndBedroomTypeResponse
    {
        public int Floor { get; set; }
        public int NoBedroom { get; set; }
        public string Situation { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

        public BedroomAndBedroomTypeResponse(int floor, int noBedroom, string situation, string description, double value)
        {
            this.Floor = floor;
            this.NoBedroom = noBedroom;
            this.Situation = situation;
            this.Description = description;
            this.Value = value;
        }
    }
}
