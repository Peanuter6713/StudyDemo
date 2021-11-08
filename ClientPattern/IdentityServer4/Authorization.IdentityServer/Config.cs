// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Authorization.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource()
                {
                    Name = "Api1",
                    DisplayName = "test api1",
                    Scopes = new List<string>
                    {
                        "Client-ApiScope"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope()
                {
                    Name = "Client-ApiScope"
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientId = "ClientPattern",
                    // 无交互用户，请使用client/secret进行身份验证
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // 身份验证的机密
                    ClientSecrets =
                    {
                        new Secret("ClientPatternSecret".Sha256())
                    },
                    // scopes that client has access to
                    // 客户端有权访问的作用域 可以访问资源 必须在这里定义， 才能访问，才能体现在token中
                    AllowedScopes =
                    {
                        "Client-ApiScope" // 必须是这里声明了Api的scope，在获取Token的时候获取到
                    }
                }
            };
    }
}