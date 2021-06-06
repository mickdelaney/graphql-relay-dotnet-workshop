// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Workshop.OIDC
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new []
        {
            new ApiScope("accounts.api", "Accounts Api"),
            new ApiScope("content.api", "Content Api")
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                ClientId = "graphql.client",
                ClientName = "React Client",
                
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,

                RedirectUris =           { "http://localhost:5704/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:5704" },
                AllowedCorsOrigins =     { "http://localhost:5704" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "accounts.api",
                    "content.api"
                }
            }
        };
    }
}