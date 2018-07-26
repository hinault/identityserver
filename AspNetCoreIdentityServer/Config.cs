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
