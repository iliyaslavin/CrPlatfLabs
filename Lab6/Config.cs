using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.DataProtection;
using System.Collections.Generic;

public static class Config
{
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "m2m-client",
                ClientSecrets = { new Secret("secret".Sha256()) }, // Пароль для клієнта

                AllowedGrantTypes = GrantTypes.ClientCredentials, // Використовуємо Client Credentials Grant

                AllowedScopes = { "api1" } // Дозволені області для цього клієнта
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "Access to API 1")
        };
}
