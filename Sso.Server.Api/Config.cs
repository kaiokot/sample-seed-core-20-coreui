using Common.Domain.Base;
using IdentityModel;
using IdentityServer4.Models;
using Newtonsoft.Json;
using Sso.Server.Api.Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.IdentityServerConstants;
using System.Linq;

namespace Sso.Server.Api
{
    public class Config
    {
        public static User MakeUsersAdmin()
        {
            return new User
            {
                SubjectId = "1",
                Username = "adm",
                Password = "123456",
                Claims = ClaimsForAdmin("adm", "adm@adm.com.br")
            };
        }

        public static List<Claim> ClaimsForAdmin(string name, string email)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, name),
                new Claim(JwtClaimTypes.Email, email),
                new Claim("role", "admin"),
            };
        }

        public static List<Claim> ClaimsForTenant(int tenantId, string name, string email)
        {
            return new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, name),
                new Claim(JwtClaimTypes.Email, email),
                new Claim("role","tenant"),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ssosa", "Sso Basic")
                {
                    Scopes = new List<Scope>()
                    {
                        new Scope
                        {
                            UserClaims = new List<string> {"name", "openid", "email", "role", "tools"},
                            Name = "ssosa",
                            Description = "sso basic",
                        }
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<Client> GetClients(ConfigSettingsBase settings)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Seed",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "ssosa"
                    }
                },

				new Client
                {
                    ClientId = "Seed-spa",
                    ClientSecrets = { new Secret("segredo".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

					RedirectUris = settings.RedirectUris.ToList(),
                    PostLogoutRedirectUris =  settings.PostLogoutRedirectUris.ToList() ,
                    AllowedCorsOrigins =  settings.ClientAuthorityEndPoint.ToList(),

                    AllowedScopes =
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        "ssosa"
                    },
					RequireConsent = false,
                    AccessTokenLifetime = 43200
                }
          
            };
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                MakeUsersAdmin()
            };
        }

    }
}
