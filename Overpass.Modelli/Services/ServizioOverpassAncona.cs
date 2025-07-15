using System;
using System.Collections;
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
        private static string BaseUri = "https://overpass-api.de/api/interpreter";

        public static async Task<NodoOverpass[]> DaiElencoNodiAnconaOverpass()
        {
            
            var query = ServizioQuery.QueryNodiAncona();

            var json = EseguiRichiesta(query);

            NodoOverpass[] ElencoNodiAncona = EstraiElementsDalJSON<NodoOverpass>(await json);

            return ElencoNodiAncona;
        }

        public static async Task<NodoOverpass[]> FiltraNodiAnconaOverpass(string filter)
        {

            NodoOverpass[] ElencoNodiAncona = await DaiElencoNodiAnconaOverpass();

            return ElencoNodiAncona.Where(n => n.tags.amenity == filter || n.tags.tourism == filter || n.tags.leisure == filter).ToArray();
        }


        public static async Task<StradaOverpass[]> DaiElencoStradeAnconaOverpass()
        {
            
            var query = ServizioQuery.QueryStradeAncona();

            var json = EseguiRichiesta(query);

            StradaOverpass[] ElencoStradeAncona = EstraiElementsDalJSON<StradaOverpass>(await json);

            return ElencoStradeAncona;
        }

        private static async Task<string> EseguiRichiesta(string query)
        {
            var httpClient = new HttpClient();

            var request = "data=" + Uri.EscapeDataString(query);
            var contents = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync(BaseUri, contents);

            return await response.Content.ReadAsStringAsync();
        }

        private static T[] EstraiElementsDalJSON<T>(string json)
        {
            var jObject = JObject.Parse(json);
            var jElements = jObject["elements"];

            return jElements?.ToObject<T[]>() ?? Array.Empty<T>();
        }
    }
}
