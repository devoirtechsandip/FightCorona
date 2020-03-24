using CoronaHelp.Models.Dashboard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoronaHelp.DataService
{
    public class WorldDataService
    {
        private readonly HttpClient client;

        public WorldDataService()
        {
            client = new HttpClient();
        }

        public async Task<WorldData> LoadAsync()
        {
            var uri = new Uri("https://corona.lmao.ninja/countries");
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.NullValueHandling = NullValueHandling.Ignore;
                return JsonConvert.DeserializeObject<WorldData>(content, serializerSettings);
            }

            throw new HttpRequestException("Connection Error.");
        }
    }
}
