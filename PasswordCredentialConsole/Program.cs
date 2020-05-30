using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace IdentityServerConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // 从元数据中发现端口
            // 调用API
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5009");
            // 请求以获得令牌
     
            var tokenResponse = await client.RequestPasswordTokenAsync(
                new  PasswordTokenRequest()
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "pwdClient",
                    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                    Scope = "api1 openid profile phone address email",
                    UserName = "alice",
                    Password = "alice",
                });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
          
            client.SetBearerToken(tokenResponse.AccessToken);
            
           // var response1 = await client.GetAsync("http://localhost:5002/WeatherForecast");//请求ApiResouce
            var response = await client.GetAsync(disco.UserInfoEndpoint); //请求IdentityResource
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