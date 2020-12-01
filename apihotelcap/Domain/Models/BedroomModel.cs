using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace apihotelcap.Domain.Models
{
    public class BedroomModel
    {
        [Description("Andar")]
        public int Floor { get; set; }

        [Description("Número do Quarto")]
        public int NoBedroom { get; set; }

        public string Situation { get; set; }

        public int IdBedroomType { get; set; }

        public BedroomModel(int floor, int noBedroom, string situation, int idBedroomType)
        {
            Floor = floor;
            NoBedroom = noBedroom;
            Situation = situation;
            IdBedroomType = idBedroomType;
        }

        public BedroomModel(string situation)
        {
            Situation = situation;
        }
    }
}
