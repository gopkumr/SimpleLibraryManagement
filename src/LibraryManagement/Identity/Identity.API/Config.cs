namespace Identity.API
{
    using IdentityServer4.Models;
    using System.Collections.Generic;


    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("Customer.Read", "Read Customer Data") { UserClaims = new[] { "user_level" } },
                new ApiScope("Customer.Write", "Write Customer Data"){ UserClaims = new[] { "user_level" } },
                new ApiScope("Customer.Delete", "Delete Customer Data"){ UserClaims = new[] { "user_level" } },

                new ApiScope("Inventory.Read", "Read Inventory Data"){ UserClaims = new[] { "user_level" } },
                new ApiScope("Inventory.Write", "Write Inventory Data"){ UserClaims = new[] { "user_level" } },
                new ApiScope("Inventory.Delete", "Delete Inventory Data"){ UserClaims = new[] { "user_level" } },

                new ApiScope("Lending.Read", "Read Lending Data"){ UserClaims = new[] { "user_level" } },
                new ApiScope("Lending.Write", "Write Lending Data"){ UserClaims = new[] { "user_level" } },
                new ApiScope("Lending.Delete", "Delete Lending Data"){ UserClaims = new[] { "user_level" } }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "webapp",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("0D14BAAC-EF15-41C1-99A2-07DCCB1543BC".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "Customer.Read", "Customer.Write", "Customer.Delete", "Inventory.Read", "Inventory.Write", "Inventory.Delete", "Lending.Read", "Lending.Write", "Lending.Delete" }
                }
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("Customer", "Customer API"){ Scopes=new[]{ "Customer.Read", "Customer.Write", "Customer.Delete" } },
                new ApiResource("Inventory", "Inventory API"){Scopes=new[]{ "Inventory.Read", "Inventory.Write", "Inventory.Delete" } },
                new ApiResource("Lending", "Lending API"){Scopes=new[]{ "Lending.Read", "Lending.Write", "Lending.Delete" } }
            };
    }
}


