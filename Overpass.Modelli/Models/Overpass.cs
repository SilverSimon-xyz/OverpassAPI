using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overpass.Modelli.Models
{
    public class NodoOverpass
    {
        public string type { get; set; }
        public long id { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public Tags tags { get; set; }
    }

    public class Tags
    {
        public string name { get; set; }
        public string amenity { get; set; }
        public string opening_hours { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string wheelchair { get; set; }

    }
  
}
