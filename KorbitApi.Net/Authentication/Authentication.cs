using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KorbitApi.Net.Authentication
{
    public class Authentication : IAuthentication
    {
        [JsonProperty("token_type")]
        public string tokenType { get; internal set; }

        [JsonProperty("access_token")]
        public string accessToken { get; internal set; }

        [JsonProperty("expires_in")]
        public double expiresIn { get; internal set; }

        [JsonProperty("refresh_token")]
        public string refreshToken { get; internal set; }

        public string Email { get; set; }
        public string Password { get; set; }

        private ApiWebClient ApiWebClient { get; set; }
        internal Authentication(ApiWebClient apiWebClient, string email, string password) : this(apiWebClient)
        {
            Email = email;
            Password = password;
        }

        internal Authentication(ApiWebClient apiWebClient)
        {
            ApiWebClient = apiWebClient;
        }
    }
}
