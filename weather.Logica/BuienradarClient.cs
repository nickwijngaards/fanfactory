using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using weather.Logica.Helpers;
using weather.Logica.Models;

namespace weather.Logica
{
    public class BuienradarClient
    {

        public async Task<BuienradarModel> SendAsync ()
        {
            var httpRequest = new HttpRequest();
            var response = await httpRequest.SendAsync(HttpMethod.Get, "https://data.buienradar.nl/1.0/feed/xml").ConfigureAwait(false);
            return await response.FormatXmlHttpResponseMessageToObjectAsync<BuienradarModel>().ConfigureAwait(false); ;
        }

    }
}
