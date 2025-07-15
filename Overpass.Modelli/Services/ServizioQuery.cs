using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overpass.Modelli.Services
{
    public static class ServizioQuery
    {
        public static string QueryNodiAncona()
        {
            return """
                [out:json][timeout:25];
                area["name"="Ancona"]["admin_level"="6"]->.a;
                (
                    node["amenity"](area.a);
                    node["tourism"](area.a);
                    node["leisure"](area.a);
                );
                out;
                """;
            
        }

        public static string QueryStradeAncona()
        {
            return """
                [out:json][timeout:25];
                area["name"="Ancona"]["admin_level"="6"]->.a;
                (
                    way(area.a);
                );
                out body 200;
                >;
                out skel qt 10;
                """;

        }
    }
}
