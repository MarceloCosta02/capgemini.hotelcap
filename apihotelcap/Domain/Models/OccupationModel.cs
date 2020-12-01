using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apihotelcap.Domain.Models
{
    public class OccupationModel
    {
        public int QtdeDiarys { get; set; }

        public DateTime Date { get; set; }

        [JsonIgnore]
        public string Situation { get; set; }

        public int IdClient { get; set; }

        public int IdBedroom { get; set; }

        public OccupationModel(int qtdeDiarys, DateTime date, string situation, int idClient, int idBedroom)
        {
            QtdeDiarys = qtdeDiarys;
            Date = date;
            Situation = situation;
            IdClient = idClient;
            IdBedroom = idBedroom;
        }
    }
}
