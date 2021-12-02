using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ListOfVatTaxpayers.Module.Api
{
    class ApiConnection
    {
        HttpClient _client;
        public ApiConnection()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://wl-api.mf.gov.pl/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Tuple<string, bool>> InvokeEndpointAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync(path);

            return Tuple.Create(await response.Content.ReadAsStringAsync(), response.IsSuccessStatusCode);
        }
    }
}
