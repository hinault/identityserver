using IdentityServer4.Models;
using System.Collections.Generic;

namespace AspNetCoreIdentityServer
{
    public class Config
    {

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {

                new Client
                {
                    ClientId = "consoleappclient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "testapi" }
                }

           };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("testapi", "My Test API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
         {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
            };
        }

    }
}
