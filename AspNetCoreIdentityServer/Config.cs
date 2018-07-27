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
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                }
           
           };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                
            };
        }
    }
}
