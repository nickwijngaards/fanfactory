using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weather.Logica.Models
{
    public class BuienradarModel
    {
        public weergegevens weergegevens { get; set; }
    }

    public class weergegevens
    {
        public string titel { get; set; }
        public string link { get; set; }
        public string omschrijving { get; set; }
        public string language { get; set; }
        public string copyright { get; set; }
        public string gebruik { get; set; }
        public actueel_weer actueel_weer { get; set; }
    }

    public class actueel_weer
    {
        public List<weerstation> weerstations { get; set; }
    }


    public class weerstation
    {
        [System.Xml.Serialization.XmlAttribute("id")]
        public int id { get; set; }

        public string stationcode { get; set; }
        public stationnaam stationnaam { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string datum { get; set; }
        public string luchtvochtigheid { get; set; }
        public string temperatuurGC { get; set; }
        public string regenMMPU { get; set; }
        public icoonactueel icoonactueel { get; set; }

    }
    public class stationnaam
    {
        [System.Xml.Serialization.XmlText]
        public string value { get; set; }

        [System.Xml.Serialization.XmlAttribute("regio")]
        public string regio { get; set; }
    }

    public class icoonactueel
    {
        [System.Xml.Serialization.XmlText]
        public string iconLink { get; set; }

        [System.Xml.Serialization.XmlAttribute("zin")]
        public string zin { get; set; }
    }
}