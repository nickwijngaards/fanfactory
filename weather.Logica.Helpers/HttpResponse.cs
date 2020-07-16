using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using weather.Logica.Models;

namespace weather.Logica.Helpers
{
    public static class HttpResponse
    {
        public static async Task<T> FormatXmlHttpResponseMessageToObjectAsync<T>(this HttpResponseMessage xmlResponse) where T : class
        {
            using (var content = await xmlResponse.Content.ReadAsStreamAsync()) {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("buienradarnl"));
                return (T)serializer.Deserialize(content);
            };
        }
    }
}
