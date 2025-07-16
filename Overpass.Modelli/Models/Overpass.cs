using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Overpass.Modelli.Models
{
    public class NodoOverpass
    {
        public string type { get; set; }
        public long id { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public NodeTags tags { get; set; }
    }

    public class StradaOverpass
    {
        public string type { get; set; }
        public long id { get; set; }
        public List<object> nodes { get; set; }
        public WayTags tags { get; set; }
    }

    public class NodeTags
    {
        public string name { get; set; }
        [JsonProperty("addr:city")]
        public string city { get; set; }
        [JsonProperty("addr:housenumber")]
        public string housenumber { get; set; }
        [JsonProperty("addr:postcode")]
        public string postcode { get; set; }
        [JsonProperty("addr:street")]
        public string street { get; set; }
        public string amenity { get; set; }
        public string opening_hours { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string wheelchair { get; set; }
        public string fee { get; set; }
        public string tourism { get; set; }
        public string internet_access { get; set; }
        public string leisure { get; set; }
        public string sport { get; set; }
        public string access { get; set; }
        public string email { get; set; }
    }

    public class WayTags
    {
        public string highway { get; set; }
        public string junction { get; set; }
        public string lanes { get; set; }
        public string lit { get; set; }
        public string maxspeed { get; set; }
        public string name { get; set; }

        public string destination { get; set; }

        public string building { get; set; }
        public string historic { get; set; }
        public string tourism { get; set; }
        public string wheelchair { get; set; }
        public string leisure { get; set; }
        public string sport { get; set; }
        public string access { get; set; }

        public string bicycle { get; set; }
        public string foot { get; set; }
    }

}
