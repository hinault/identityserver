using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args) => CallWebApi().GetAwaiter().GetResult();

        static async Task CallWebApi()

        {
            var client = new HttpClient();
            // discover endpoints from metadata
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "consoleappclient",
                ClientSecret = "secret",
                Scope = "testapi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);

            // call api
            var apiclient = new HttpClient();
            apiclient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiclient.GetAsync("https://localhost:5003/secure");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
