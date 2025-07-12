using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Overpass.Modelli.Models;

namespace Overpass.Modelli.Services
{
    public static class ServizioOverpassAncona
    {

        public static async Task<NodoOverpass[]> DaiElencoNodiAnconaOverpass()
        {
            string BaseUri = "https://overpass-api.de/api/interpreter";
            var query = """
                [out:json][timeout:25];
                area["name"="Ancona"]["admin_level"="6"]->.a;
                (
                    node["amenity"="restaurant"](area.a);
                    node["tourism"="museum"](area.a);
                    node["amenity"="bank"](area.a);
                    node["leisure"="park"](area.a);
                    node["amenity"="school"](area.a);
                );
                out;
                """;
            var httpClient = new HttpClient();

            var request = "data=" + Uri.EscapeDataString(query);
            var contents = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync(BaseUri, contents);

            var json = await response.Content.ReadAsStringAsync();

            NodoOverpass[] ElencoNodiAncona = EstraiElementsDalJSON(json);

            return ElencoNodiAncona;
        }

        private static NodoOverpass[] EstraiElementsDalJSON(string json)
        {
            var jObject = JObject.Parse(json);
            var jElements = jObject["elements"];

            return jElements?.ToObject<NodoOverpass[]>() ?? Array.Empty<NodoOverpass>();
        }

    }
}
