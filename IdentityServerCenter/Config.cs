using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerCenter
{
    public  class Config
    {
        public static IEnumerable<ApiResource> GetResources()
        {
            return  new List<ApiResource>()
            {
                new ApiResource("api","My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return  new List<Client>()
            {
                #region ClientCredentials 客户端验证
                new Client()
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api"}

                },
                #endregion
                #region Password 密码验证
                new Client()
                {
                    ClientId = "pwdClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api"}

                }
            #endregion

            };
        }
        /// <summary>
        /// 测试用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GeTestUsers()
        {
            return  new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "jesse",
                    Password = "123456"
                }
            };
        }
    }
}
