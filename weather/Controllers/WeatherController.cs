using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using weather.Models;
using System.Xml.Serialization;
using System.IO;
using weather.Logica;
using weather.Logica.Models;
using Swashbuckle.Swagger.Annotations;

namespace weather.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class WeatherController : ApiController
    {
        [HttpGet]
        [SwaggerResponse(200, "Locatie gevonden.")]
        [SwaggerResponse(401, "Niet ingelogd.")]
        [SwaggerResponse(404, "Locatie niet gevonden.")]
        public async Task<HttpResponseMessage> WeatherRequestAsync(string meetLocatie = null)
        {
            if(!string.IsNullOrWhiteSpace(meetLocatie))
            {
                var BuienradarClient = new BuienradarClient();
                var result = await BuienradarClient.SendAsync().ConfigureAwait(false);

                foreach (var weerstation in result.weergegevens.actueel_weer.weerstations)
                {
                    if (IsMatch(meetLocatie, weerstation))
                    {
                        var response = new HttpRequestMessage();
                        response.Method = HttpMethod.Get;
                        return response.CreateResponse<weerstation>(HttpStatusCode.OK, weerstation, new HttpConfiguration());
                    }
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        private static bool IsMatch(string meetLocatie, weerstation weerstation)
        {
            return meetLocatie.ToLower() == weerstation.stationnaam.regio.ToLower() 
                || weerstation.stationnaam.value.ToLower().Contains(meetLocatie.ToLower());
        }
    }
}
