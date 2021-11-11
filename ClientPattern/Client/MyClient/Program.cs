using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("获取发现文档");
                HttpClient client = new HttpClient();
                DiscoveryDocumentResponse disco = client.GetDiscoveryDocumentAsync("https://localhost:5001/").Result;
                if (disco.IsError)
                {
                    Console.WriteLine(disco.IsError);
                    return;
                }

                // 密码模式获取Token
                string accessToken = null;
                {
                    Console.WriteLine("密码模式获取Token");
                    TokenResponse tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = disco.TokenEndpoint,
                        ClientId = "PwdPattern",
                        ClientSecret = "PwdPatternSecret",
                        Scope = "Client-ApiScope openid profile",
                        UserName = "Richard",
                        Password = "Richard"
                    }).Result;
                    accessToken = tokenResponse.AccessToken;
                }
            }
            catch
            {

            }

            Console.WriteLine("Hello World!");
        }
    }
}
