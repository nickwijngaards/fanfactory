using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace weather.Logica
{
    public class HttpRequest
    {
        public async Task<HttpResponseMessage> SendAsync(HttpMethod method, string link)
        {
            /*
             * het aanmaken van een HttpClient
             */
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/xml");

                var httpMessage = GenerateRequestMessage(method, link);

                var response = await client.SendAsync(httpMessage);
                response.EnsureSuccessStatusCode();

                return response;
            }
                      
        }

        private static HttpRequestMessage GenerateRequestMessage(HttpMethod method, string link)
        {
           /*
           * het aanmaken van de Request
           */
            var httpMessage = new HttpRequestMessage();
            httpMessage.Method = method;
            httpMessage.RequestUri = new Uri(link);
            return httpMessage;
        }
    }
}
