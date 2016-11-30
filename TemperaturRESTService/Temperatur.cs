using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TemperaturRESTService
{
    [DataContract]
    public class Temperatur
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DatoTid { get; set; }

        [DataMember]
        public string By { get; set; }

        [DataMember]
        public bool Inde { get; set; }

        [DataMember]
        public bool Ude { get; set; }

        [DataMember]
        public float Temp { get; set; }

        [DataMember]
        public string Kommentar { get; set; }


    }

    public partial class Temperaturer
    {
        private static readonly Temperaturer _instance = new Temperaturer();

        private Temperaturer() { }

        public static Temperaturer Instance
        {
            get { return _instance; }
        }

        public List<Temperatur> TemperaturTabel
        {
            get { return temp; }
        }

        private List<Temperatur> temp = new List<Temperatur>()
        {
            new Temperatur()
            {
                By = "Roskilde",
                DatoTid = DateTime.Today,
                Id = 1,
                Inde = true,
                Kommentar = "Ja jajaja",
                Temp = 12,
                Ude = false
            },
             new Temperatur()
            {
                By = "Slagelse",
                DatoTid = DateTime.Today,
                Id = 2,
                Inde = false,
                Kommentar = "nej nej nej",
                Temp = 8,
                Ude = true
            }
        };
    }
}